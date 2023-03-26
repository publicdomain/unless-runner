// <copyright file="MainForm.cs" company="PublicDomain.is">
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
            // TODO Add code
        }

        /// <summary>
        /// Handles the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add codes
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
            // TODO Add code 
        }

        /// <summary>
        /// Handles the main form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO Add code
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
        }

        /// <summary>
        /// Handles the exit tool strip menu item1 click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItem1Click(object sender, EventArgs e)
        {
            // TODO Add code
        }
    }
}
