
namespace UnlessRunner
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
        	this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.freeReleasesPublicDomainisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.originalThreadDonationCodercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sourceCodeGithubcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
        	this.itemsTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.itemsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.textFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
        	this.textFileSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        	this.programOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
        	this.removeButton = new System.Windows.Forms.Button();
        	this.browseButton = new System.Windows.Forms.Button();
        	this.launchButton = new System.Windows.Forms.Button();
        	this.programsListBox = new System.Windows.Forms.ListBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.mainMenuStrip.SuspendLayout();
        	this.mainStatusStrip.SuspendLayout();
        	this.mainTableLayoutPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mainMenuStrip
        	// 
        	this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem1,
        	        	        	this.minimizeToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem});
        	this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
        	this.mainMenuStrip.Name = "mainMenuStrip";
        	this.mainMenuStrip.Size = new System.Drawing.Size(284, 24);
        	this.mainMenuStrip.TabIndex = 29;
        	// 
        	// fileToolStripMenuItem1
        	// 
        	this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newToolStripMenuItem,
        	        	        	this.openToolStripMenuItem,
        	        	        	this.toolStripSeparator,
        	        	        	this.saveToolStripMenuItem,
        	        	        	this.toolStripSeparator3,
        	        	        	this.exitToolStripMenuItem1});
        	this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
        	this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem1.Text = "&File";
        	// 
        	// newToolStripMenuItem
        	// 
        	this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
        	this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.newToolStripMenuItem.Name = "newToolStripMenuItem";
        	this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
        	this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.newToolStripMenuItem.Text = "&New";
        	this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewToolStripMenuItemClick);
        	// 
        	// openToolStripMenuItem
        	// 
        	this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
        	this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        	this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
        	this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.openToolStripMenuItem.Text = "&Open";
        	this.openToolStripMenuItem.Click += new System.EventHandler(this.OnOpenToolStripMenuItemClick);
        	// 
        	// toolStripSeparator
        	// 
        	this.toolStripSeparator.Name = "toolStripSeparator";
        	this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
        	// 
        	// saveToolStripMenuItem
        	// 
        	this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
        	this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        	this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
        	this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.saveToolStripMenuItem.Text = "&Save";
        	this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnSaveToolStripMenuItemClick);
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
        	// 
        	// exitToolStripMenuItem1
        	// 
        	this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
        	this.exitToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
        	this.exitToolStripMenuItem1.Text = "E&xit";
        	this.exitToolStripMenuItem1.Click += new System.EventHandler(this.OnExitToolStripMenuItem1Click);
        	// 
        	// minimizeToolStripMenuItem
        	// 
        	this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
        	this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
        	this.minimizeToolStripMenuItem.Visible = false;
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.freeReleasesPublicDomainisToolStripMenuItem,
        	        	        	this.originalThreadDonationCodercomToolStripMenuItem,
        	        	        	this.sourceCodeGithubcomToolStripMenuItem,
        	        	        	this.toolStripSeparator2,
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// freeReleasesPublicDomainisToolStripMenuItem
        	// 
        	this.freeReleasesPublicDomainisToolStripMenuItem.Name = "freeReleasesPublicDomainisToolStripMenuItem";
        	this.freeReleasesPublicDomainisToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.freeReleasesPublicDomainisToolStripMenuItem.Text = "Free Releases @ PublicDomain.is";
        	this.freeReleasesPublicDomainisToolStripMenuItem.Click += new System.EventHandler(this.OnFreeReleasesPublicDomainisToolStripMenuItemClick);
        	// 
        	// originalThreadDonationCodercomToolStripMenuItem
        	// 
        	this.originalThreadDonationCodercomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("originalThreadDonationCodercomToolStripMenuItem.Image")));
        	this.originalThreadDonationCodercomToolStripMenuItem.Name = "originalThreadDonationCodercomToolStripMenuItem";
        	this.originalThreadDonationCodercomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.originalThreadDonationCodercomToolStripMenuItem.Text = "&Original thread @ DonationCoder.com";
        	this.originalThreadDonationCodercomToolStripMenuItem.Click += new System.EventHandler(this.OnOriginalThreadDonationCodercomToolStripMenuItemClick);
        	// 
        	// sourceCodeGithubcomToolStripMenuItem
        	// 
        	this.sourceCodeGithubcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sourceCodeGithubcomToolStripMenuItem.Image")));
        	this.sourceCodeGithubcomToolStripMenuItem.Name = "sourceCodeGithubcomToolStripMenuItem";
        	this.sourceCodeGithubcomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.sourceCodeGithubcomToolStripMenuItem.Text = "Source code @ Github.com";
        	this.sourceCodeGithubcomToolStripMenuItem.Click += new System.EventHandler(this.OnSourceCodeGithubcomToolStripMenuItemClick);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(275, 6);
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.aboutToolStripMenuItem.Text = "&About...";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
        	// 
        	// mainStatusStrip
        	// 
        	this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.itemsTextToolStripStatusLabel,
        	        	        	this.itemsToolStripStatusLabel});
        	this.mainStatusStrip.Location = new System.Drawing.Point(0, 340);
        	this.mainStatusStrip.Name = "mainStatusStrip";
        	this.mainStatusStrip.Size = new System.Drawing.Size(284, 22);
        	this.mainStatusStrip.SizingGrip = false;
        	this.mainStatusStrip.TabIndex = 28;
        	// 
        	// itemsTextToolStripStatusLabel
        	// 
        	this.itemsTextToolStripStatusLabel.Name = "itemsTextToolStripStatusLabel";
        	this.itemsTextToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
        	this.itemsTextToolStripStatusLabel.Text = "Items:";
        	// 
        	// itemsToolStripStatusLabel
        	// 
        	this.itemsToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.itemsToolStripStatusLabel.Name = "itemsToolStripStatusLabel";
        	this.itemsToolStripStatusLabel.Size = new System.Drawing.Size(14, 17);
        	this.itemsToolStripStatusLabel.Text = "0";
        	// 
        	// textFileOpenFileDialog
        	// 
        	this.textFileOpenFileDialog.DefaultExt = "txt";
        	this.textFileOpenFileDialog.Filter = "TXT Files|*.txt|All files (*.*)|*.*";
        	this.textFileOpenFileDialog.Multiselect = true;
        	// 
        	// textFileSaveFileDialog
        	// 
        	this.textFileSaveFileDialog.DefaultExt = "txt";
        	this.textFileSaveFileDialog.Filter = "TXT Files|*.txt|All files (*.*)|*.*";
        	// 
        	// programOpenFileDialog
        	// 
        	this.programOpenFileDialog.DefaultExt = "exe";
        	this.programOpenFileDialog.Filter = "EXE Files|*.exe";
        	this.programOpenFileDialog.Multiselect = true;
        	// 
        	// removeButton
        	// 
        	this.removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.removeButton.Location = new System.Drawing.Point(189, 26);
        	this.removeButton.Margin = new System.Windows.Forms.Padding(1, 1, 3, 1);
        	this.removeButton.Name = "removeButton";
        	this.removeButton.Size = new System.Drawing.Size(92, 33);
        	this.removeButton.TabIndex = 2;
        	this.removeButton.Text = "&Remove";
        	this.removeButton.UseVisualStyleBackColor = true;
        	this.removeButton.Click += new System.EventHandler(this.OnRemoveButtonClick);
        	// 
        	// browseButton
        	// 
        	this.mainTableLayoutPanel.SetColumnSpan(this.browseButton, 2);
        	this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.browseButton.ForeColor = System.Drawing.Color.DarkBlue;
        	this.browseButton.Location = new System.Drawing.Point(3, 26);
        	this.browseButton.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
        	this.browseButton.Name = "browseButton";
        	this.browseButton.Size = new System.Drawing.Size(184, 33);
        	this.browseButton.TabIndex = 1;
        	this.browseButton.Text = "&Browse to add";
        	this.browseButton.UseVisualStyleBackColor = true;
        	this.browseButton.Click += new System.EventHandler(this.OnBrowseButtonClick);
        	// 
        	// launchButton
        	// 
        	this.mainTableLayoutPanel.SetColumnSpan(this.launchButton, 3);
        	this.launchButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.launchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        	this.launchButton.ForeColor = System.Drawing.Color.Red;
        	this.launchButton.Location = new System.Drawing.Point(3, 277);
        	this.launchButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
        	this.launchButton.Name = "launchButton";
        	this.launchButton.Size = new System.Drawing.Size(278, 38);
        	this.launchButton.TabIndex = 4;
        	this.launchButton.Text = "&Launch";
        	this.launchButton.UseVisualStyleBackColor = true;
        	this.launchButton.Click += new System.EventHandler(this.OnLaunchButtonClick);
        	// 
        	// programsListBox
        	// 
        	this.mainTableLayoutPanel.SetColumnSpan(this.programsListBox, 3);
        	this.programsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.programsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.programsListBox.FormattingEnabled = true;
        	this.programsListBox.ItemHeight = 16;
        	this.programsListBox.Location = new System.Drawing.Point(3, 63);
        	this.programsListBox.Name = "programsListBox";
        	this.programsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        	this.programsListBox.Size = new System.Drawing.Size(278, 210);
        	this.programsListBox.Sorted = true;
        	this.programsListBox.TabIndex = 3;
        	this.programsListBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnProgramsListBoxPreviewKeyDown);
        	// 
        	// label1
        	// 
        	this.mainTableLayoutPanel.SetColumnSpan(this.label1, 3);
        	this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(3, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(278, 25);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "&Programs list";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// mainTableLayoutPanel
        	// 
        	this.mainTableLayoutPanel.ColumnCount = 3;
        	this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
        	this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
        	this.mainTableLayoutPanel.Controls.Add(this.label1, 0, 0);
        	this.mainTableLayoutPanel.Controls.Add(this.programsListBox, 0, 2);
        	this.mainTableLayoutPanel.Controls.Add(this.launchButton, 0, 3);
        	this.mainTableLayoutPanel.Controls.Add(this.browseButton, 0, 1);
        	this.mainTableLayoutPanel.Controls.Add(this.removeButton, 2, 1);
        	this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
        	this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
        	this.mainTableLayoutPanel.RowCount = 4;
        	this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        	this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
        	this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        	this.mainTableLayoutPanel.Size = new System.Drawing.Size(284, 316);
        	this.mainTableLayoutPanel.TabIndex = 30;
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(284, 362);
        	this.Controls.Add(this.mainTableLayoutPanel);
        	this.Controls.Add(this.mainMenuStrip);
        	this.Controls.Add(this.mainStatusStrip);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "UnlessRunner";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
        	this.mainMenuStrip.ResumeLayout(false);
        	this.mainMenuStrip.PerformLayout();
        	this.mainStatusStrip.ResumeLayout(false);
        	this.mainStatusStrip.PerformLayout();
        	this.mainTableLayoutPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.OpenFileDialog programOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog textFileSaveFileDialog;
        private System.Windows.Forms.OpenFileDialog textFileOpenFileDialog;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.ListBox programsListBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel itemsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel itemsTextToolStripStatusLabel;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubcomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalThreadDonationCodercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeReleasesPublicDomainisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
    }
}
