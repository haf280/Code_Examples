namespace DataProcessingApplication
{
    partial class DataProcessingMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataProcessingMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDialogueCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDialogueCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDialogueCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadRawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.speakerUtteranceTabPage = new System.Windows.Forms.TabPage();
            this.speakerUtteranceListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.settingsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.processRawDataButton = new System.Windows.Forms.ToolStripButton();
            this.dialogueCorpusTabPage = new System.Windows.Forms.TabPage();
            this.dialogueCorpusListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.speakerUtteranceTabPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.dialogueCorpusTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDialogueCorpusToolStripMenuItem,
            this.loadDialogueCorpusToolStripMenuItem,
            this.saveDialogueCorpusToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadRawDataToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDialogueCorpusToolStripMenuItem
            // 
            this.newDialogueCorpusToolStripMenuItem.Name = "newDialogueCorpusToolStripMenuItem";
            this.newDialogueCorpusToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.newDialogueCorpusToolStripMenuItem.Text = "New dialogue corpus";
            this.newDialogueCorpusToolStripMenuItem.Click += new System.EventHandler(this.newDialogueCorpusToolStripMenuItem_Click);
            // 
            // loadDialogueCorpusToolStripMenuItem
            // 
            this.loadDialogueCorpusToolStripMenuItem.Name = "loadDialogueCorpusToolStripMenuItem";
            this.loadDialogueCorpusToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadDialogueCorpusToolStripMenuItem.Text = "Load dialogue corpus";
            this.loadDialogueCorpusToolStripMenuItem.Click += new System.EventHandler(this.loadDialogueCorpusToolStripMenuItem_Click);
            // 
            // saveDialogueCorpusToolStripMenuItem
            // 
            this.saveDialogueCorpusToolStripMenuItem.Name = "saveDialogueCorpusToolStripMenuItem";
            this.saveDialogueCorpusToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.saveDialogueCorpusToolStripMenuItem.Text = "Save dialogue corpus";
            this.saveDialogueCorpusToolStripMenuItem.Click += new System.EventHandler(this.saveDialogueCorpusToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // loadRawDataToolStripMenuItem
            // 
            this.loadRawDataToolStripMenuItem.Name = "loadRawDataToolStripMenuItem";
            this.loadRawDataToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadRawDataToolStripMenuItem.Text = "Load raw data";
            this.loadRawDataToolStripMenuItem.Click += new System.EventHandler(this.loadRawDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(233, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.speakerUtteranceTabPage);
            this.mainTabControl.Controls.Add(this.dialogueCorpusTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 28);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(933, 526);
            this.mainTabControl.TabIndex = 3;
            // 
            // speakerUtteranceTabPage
            // 
            this.speakerUtteranceTabPage.Controls.Add(this.speakerUtteranceListBox);
            this.speakerUtteranceTabPage.Controls.Add(this.toolStrip1);
            this.speakerUtteranceTabPage.Location = new System.Drawing.Point(4, 25);
            this.speakerUtteranceTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.speakerUtteranceTabPage.Name = "speakerUtteranceTabPage";
            this.speakerUtteranceTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.speakerUtteranceTabPage.Size = new System.Drawing.Size(925, 497);
            this.speakerUtteranceTabPage.TabIndex = 0;
            this.speakerUtteranceTabPage.Text = "Speaker-utterance set";
            this.speakerUtteranceTabPage.UseVisualStyleBackColor = true;
            // 
            // speakerUtteranceListBox
            // 
            this.speakerUtteranceListBox.BackColor = System.Drawing.Color.Black;
            this.speakerUtteranceListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.speakerUtteranceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speakerUtteranceListBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speakerUtteranceListBox.ForeColor = System.Drawing.Color.Lime;
            this.speakerUtteranceListBox.FormattingEnabled = true;
            this.speakerUtteranceListBox.ItemHeight = 14;
            this.speakerUtteranceListBox.Location = new System.Drawing.Point(3, 35);
            this.speakerUtteranceListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.speakerUtteranceListBox.Name = "speakerUtteranceListBox";
            this.speakerUtteranceListBox.Size = new System.Drawing.Size(919, 458);
            this.speakerUtteranceListBox.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.settingsComboBox,
            this.toolStripSeparator3,
            this.processRawDataButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(111, 25);
            this.toolStripLabel1.Text = "Parsing settings";
            // 
            // settingsComboBox
            // 
            this.settingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.settingsComboBox.Items.AddRange(new object[] {
            "Settings 1"});
            this.settingsComboBox.Items.AddRange(new object[] {
            "Settings 2"});
            this.settingsComboBox.Items.AddRange(new object[] {
            "Settings 3"});
            this.settingsComboBox.Name = "settingsComboBox";
            this.settingsComboBox.Size = new System.Drawing.Size(140, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // processRawDataButton
            // 
            this.processRawDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.processRawDataButton.Image = ((System.Drawing.Image)(resources.GetObject("processRawDataButton.Image")));
            this.processRawDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.processRawDataButton.Name = "processRawDataButton";
            this.processRawDataButton.Size = new System.Drawing.Size(124, 28);
            this.processRawDataButton.Text = "Process raw data";
            this.processRawDataButton.Click += new System.EventHandler(this.processRawDataButton_Click);
            // 
            // dialogueCorpusTabPage
            // 
            this.dialogueCorpusTabPage.Controls.Add(this.dialogueCorpusListBox);
            this.dialogueCorpusTabPage.Location = new System.Drawing.Point(4, 25);
            this.dialogueCorpusTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialogueCorpusTabPage.Name = "dialogueCorpusTabPage";
            this.dialogueCorpusTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialogueCorpusTabPage.Size = new System.Drawing.Size(925, 495);
            this.dialogueCorpusTabPage.TabIndex = 1;
            this.dialogueCorpusTabPage.Text = "Dialogue corpus";
            this.dialogueCorpusTabPage.UseVisualStyleBackColor = true;
            // 
            // dialogueCorpusListBox
            // 
            this.dialogueCorpusListBox.BackColor = System.Drawing.Color.Black;
            this.dialogueCorpusListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueCorpusListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogueCorpusListBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueCorpusListBox.ForeColor = System.Drawing.Color.Lime;
            this.dialogueCorpusListBox.FormattingEnabled = true;
            this.dialogueCorpusListBox.ItemHeight = 14;
            this.dialogueCorpusListBox.Location = new System.Drawing.Point(3, 4);
            this.dialogueCorpusListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialogueCorpusListBox.Name = "dialogueCorpusListBox";
            this.dialogueCorpusListBox.Size = new System.Drawing.Size(919, 487);
            this.dialogueCorpusListBox.TabIndex = 4;
            // 
            // DataProcessingMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataProcessingMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data processing application";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.speakerUtteranceTabPage.ResumeLayout(false);
            this.speakerUtteranceTabPage.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.dialogueCorpusTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadRawDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDialogueCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newDialogueCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDialogueCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage speakerUtteranceTabPage;
        private System.Windows.Forms.ListBox speakerUtteranceListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton processRawDataButton;
        private System.Windows.Forms.TabPage dialogueCorpusTabPage;
        private System.Windows.Forms.ListBox dialogueCorpusListBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox settingsComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

