﻿// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Management;
using PublicDomain;
using System.Xml.Serialization;
using System.Reflection;

namespace UnlessRunner
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The process exclusion list.
        /// </summary>
        private List<string> processExclusionList = new List<string>() { "conhost", "dwm", "explorer", "rundll32", "taskhost" };

        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = null;

        /// <summary>
        /// The settings data path.
        /// </summary>
        private string settingsDataPath = $"{Application.ProductName}-SettingsData.txt";

        /// <summary>
        /// Queries the full name of the process image.
        /// </summary>
        /// <returns><c>true</c>, if full process image name was queryed, <c>false</c> otherwise.</returns>
        /// <param name="hprocess">Hprocess.</param>
        /// <param name="dwFlags">Dw flags.</param>
        /// <param name="lpExeName">Lp exe name.</param>
        /// <param name="size">Size.</param>
        [DllImport("kernel32.dll")] public static extern bool QueryFullProcessImageName(IntPtr hprocess, int dwFlags, StringBuilder lpExeName, out int size);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UnlessRunner.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            /* Set icons */

            // Set associated icon from exe file
            this.associatedIcon = Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);

            // Set PublicDomain.is tool strip menu item image
            this.freeReleasesPublicDomainisToolStripMenuItem.Image = this.associatedIcon.ToBitmap();

            /* Settings data */

            // Check for settings file
            if (!File.Exists(this.settingsDataPath))
            {
                // Create new settings file
                this.SaveSettingsFile(this.settingsDataPath, new SettingsData());
            }

            // Load settings from disk
            this.settingsData = this.LoadSettingsFile(this.settingsDataPath);

            // Add items to listbox
            this.programsListBox.Items.AddRange(this.settingsData.ProgramsList.ToArray());

            // Update item count
            this.itemsToolStripStatusLabel.Text = this.programsListBox.Items.Count.ToString();
        }

        /// <summary>
        /// Handles the browse button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBrowseButtonClick(object sender, EventArgs e)
        {
            // Reset file name
            this.programOpenFileDialog.FileName = string.Empty;

            // Show open file dialog
            if (this.programOpenFileDialog.ShowDialog() == DialogResult.OK && this.programOpenFileDialog.FileNames.Length > 0)
            {
                // Iterate program files
                foreach (var programFilePath in this.programOpenFileDialog.FileNames)
                {
                    // Validate it's an executable file
                    if (Path.GetExtension(programFilePath).ToLowerInvariant() == ".exe")
                    {
                        // Avoid duplicates
                        if (!this.programsListBox.Items.Contains(programFilePath))
                        {
                            // Add to programs list
                            this.programsListBox.Items.Add(programFilePath);
                        }
                    }
                }

                // Update item count
                this.itemsToolStripStatusLabel.Text = this.programsListBox.Items.Count.ToString();
            }
        }

        /// <summary>
        /// Handles the launch button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLaunchButtonClick(object sender, EventArgs e)
        {
            // Check there's something to work with
            if (this.programsListBox.Items.Count == 0)
            {
                // Halt flow
                return;
            }

            /* Process list (System.Diagnostics.Process) */

            // Declare running list
            List<string> runningList = new List<string>();

            // TODO List processes for current user [Can be improved]
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    // Test against excluson list
                    if (!this.processExclusionList.Contains(process.ProcessName))
                    {
                        // Add lowercased
                        runningList.Add(Path.GetFileName(process.ProcessName.ToLowerInvariant()));
                    }
                }
                catch
                {
                    // Get by API
                    try
                    {
                        // Set string builder
                        StringBuilder fullProcessPathStringBuilder = new StringBuilder(1024);

                        // Set buffer length
                        int bufferLength = (int)fullProcessPathStringBuilder.Capacity + 1;

                        // Get process path by full image name
                        QueryFullProcessImageName(process.Handle, 0, fullProcessPathStringBuilder, out bufferLength);

                        // Check for success
                        if (fullProcessPathStringBuilder.ToString().Length > 0)
                        {
                            // Add lowercased
                            runningList.Add(Path.GetFileNameWithoutExtension(fullProcessPathStringBuilder.ToString().ToLowerInvariant()));
                        }
                    }
                    catch
                    {
                        ; // Let it fall through
                    }
                }
            }

            /* Programs list (By user) */

            // Get current programs list into a regular list
            List<string> programsList = this.programsListBox.Items.OfType<string>().ToList();

            // Iterate in reverse
            for (int i = programsList.Count - 1; i >= 0; i--)
            {
                // Check if it's running
                if (runningList.Contains(Path.GetFileNameWithoutExtension(programsList[i]).ToLowerInvariant()))
                {
                    // Remove from list
                    programsList.RemoveAt(i);
                }
            }

            // Start non-running processes
            foreach (var programPath in programsList)
            {
                // Start
                Process.Start(programPath);
            }
        }

        /// <summary>
        /// Handles the programs list box preview key down.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnProgramsListBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Check for delete key
            if (e.KeyCode == Keys.Delete)
            {
                // Remove selected
                this.removeButton.PerformClick();
            }
        }

        /// <summary>
        /// Handles the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Clear listbox items
            this.programsListBox.Items.Clear();

            // Update item count
            this.itemsToolStripStatusLabel.Text = this.programsListBox.Items.Count.ToString();
        }

        /// <summary>
        /// Handles the open tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Reset file name
            this.textFileOpenFileDialog.FileName = string.Empty;

            // Show open file dialog
            if (this.textFileOpenFileDialog.ShowDialog() == DialogResult.OK && this.textFileOpenFileDialog.FileNames.Length > 0)
            {
                // Iterate text files
                foreach (var textFilePath in this.textFileOpenFileDialog.FileNames)
                {
                    // Iterate lines
                    foreach (var exePath in File.ReadAllLines(textFilePath))
                    {
                        // Validate it's an executable file
                        if (Path.GetExtension(exePath).ToLowerInvariant() == ".exe")
                        {
                            // Verify it's present
                            if (File.Exists(exePath))
                            {
                                // Avoid duplicates
                                if (!this.programsListBox.Items.Contains(exePath))
                                {
                                    // Add to programs list
                                    this.programsListBox.Items.Add(exePath);
                                }
                            }
                        }
                    }
                }

                // Update item count
                this.itemsToolStripStatusLabel.Text = this.programsListBox.Items.Count.ToString();
            }
        }

        /// <summary>
        /// Handles the save tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Check there's something to save
            if (this.programsListBox.Items.Count == 0)
            {
                // Inform user
                MessageBox.Show($"Nothing to save.", "Empty list", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Halt flow
                return;
            }

            // Empty file name
            this.textFileSaveFileDialog.FileName = string.Empty;

            // Open save file dialog
            if (this.textFileSaveFileDialog.ShowDialog() == DialogResult.OK && this.textFileSaveFileDialog.FileName.Length > 0)
            {
                try
                {
                    // Save lines to disk
                    File.WriteAllLines(this.textFileSaveFileDialog.FileName, this.programsListBox.Items.Cast<string>().ToArray());
                }
                catch (Exception exception)
                {
                    // Inform user
                    MessageBox.Show($"Error when saving to \"{Path.GetFileName(this.textFileSaveFileDialog.FileName)}\":{Environment.NewLine}{exception.Message}", "Save file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our website
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=39042.0");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub
            Process.Start("https://github.com/publicdomain/unless-runner");
        }

        /// <summary>
        /// Handles the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Set license text
            var licenseText = $"CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication{Environment.NewLine}" +
                $"https://creativecommons.org/publicdomain/zero/1.0/legalcode{Environment.NewLine}{Environment.NewLine}" +
                $"Libraries and icons have separate licenses.{Environment.NewLine}{Environment.NewLine}" +
                $"Talk icon by inspire-studio - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/talk-chat-comment-communication-6931551/{Environment.NewLine}{Environment.NewLine}" +
                $"Patreon icon used according to published brand guidelines{Environment.NewLine}" +
                $"https://www.patreon.com/brand{Environment.NewLine}{Environment.NewLine}" +
                $"GitHub mark icon used according to published logos and usage guidelines{Environment.NewLine}" +
                $"https://github.com/logos{Environment.NewLine}{Environment.NewLine}" +
                $"DonationCoder icon used with permission{Environment.NewLine}" +
                $"https://www.donationcoder.com/forum/index.php?topic=48718{Environment.NewLine}{Environment.NewLine}" +
                $"PublicDomain icon is based on the following source images:{Environment.NewLine}{Environment.NewLine}" +
                $"Bitcoin by GDJ - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/bitcoin-digital-currency-4130319/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter P by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/p-glamour-gold-lights-2790632/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter D by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/d-glamour-gold-lights-2790573/{Environment.NewLine}{Environment.NewLine}";

            // Prepend sponsors
            licenseText = $"RELEASE SUPPORTERS:{Environment.NewLine}{Environment.NewLine}* Jesse Reichler (mouser){Environment.NewLine}* Max P.{Environment.NewLine}* Kathryn S.{Environment.NewLine}* Cranioscopical{Environment.NewLine}* tomos{Environment.NewLine}{Environment.NewLine}=========={Environment.NewLine}{Environment.NewLine}" + licenseText;

            // Set title
            string programTitle = typeof(MainForm).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;

            // Set version for generating semantic version
            Version version = typeof(MainForm).GetTypeInfo().Assembly.GetName().Version;

            // Set about form
            var aboutForm = new AboutForm(
                $"About {programTitle}",
                $"{programTitle} {version.Major}.{version.Minor}.{version.Build}",
                $"Made for: Contro{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #87, Week #13 @ March 28, 2023",
                licenseText,
                this.Icon.ToBitmap())
            {
                // Set about form icon
                Icon = this.associatedIcon,

                // Set always on top
                TopMost = this.TopMost
            };

            // Show about form
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the main form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Clear afresh
            this.settingsData.ProgramsList.Clear();

            // Add items into settings data list 
            this.settingsData.ProgramsList.AddRange(this.programsListBox.Items.Cast<string>());

            // Save settings data to disk
            this.SaveSettingsFile(this.settingsDataPath, this.settingsData);
        }

        /// <summary>
        /// Handles the remove button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRemoveButtonClick(object sender, EventArgs e)
        {
            // Pause painting
            this.programsListBox.BeginUpdate();

            // Iterate in reverse
            for (int i = this.programsListBox.Items.Count - 1; i >= 0; i--)
            {
                // Check if it's selected
                if (this.programsListBox.SelectedIndices.Contains(i))
                {
                    // Remove the item
                    this.programsListBox.Items.RemoveAt(i);
                }
            }

            // Resume painting
            this.programsListBox.EndUpdate();

            // Update item count
            this.itemsToolStripStatusLabel.Text = this.programsListBox.Items.Count.ToString();
        }

        /// <summary>
        /// Loads the settings file.
        /// </summary>
        /// <returns>The settings file.</returns>
        /// <param name="settingsFilePath">Settings file path.</param>
        private SettingsData LoadSettingsFile(string settingsFilePath)
        {
            // Use file stream
            using (FileStream fileStream = File.OpenRead(settingsFilePath))
            {
                // Set xml serialzer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                // Return populated settings data
                return xmlSerializer.Deserialize(fileStream) as SettingsData;
            }
        }

        /// <summary>
        /// Saves the settings file.
        /// </summary>
        /// <param name="settingsFilePath">Settings file path.</param>
        /// <param name="settingsDataParam">Settings data parameter.</param>
        private void SaveSettingsFile(string settingsFilePath, SettingsData settingsDataParam)
        {
            try
            {
                // Use stream writer
                using (StreamWriter streamWriter = new StreamWriter(settingsFilePath, false))
                {
                    // Set xml serialzer
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                    // Serialize settings data
                    xmlSerializer.Serialize(streamWriter, settingsDataParam);
                }
            }
            catch (Exception exception)
            {
                // Advise user
                MessageBox.Show($"Error saving settings file.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{exception.Message}", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }
    }
}
