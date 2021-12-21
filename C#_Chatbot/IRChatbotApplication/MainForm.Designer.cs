namespace IRChatbotApplication
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDialogueCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDialogueCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.chatTabPage = new System.Windows.Forms.TabPage();
            this.dialogueListView = new System.Windows.Forms.ListView();
            this.inputTextBox = new ChatbotLibrary.InputTextBox();
            this.dialoueCorpusTabPage = new System.Windows.Forms.TabPage();
            this.dialogueCorpusTabControl = new System.Windows.Forms.TabControl();
            this.corpusItemsTabPage = new System.Windows.Forms.TabPage();
            this.corpusItemsListBox = new System.Windows.Forms.ListBox();
            this.corpusVocabularyTabPage = new System.Windows.Forms.TabPage();
            this.corpusVocabularyListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.importButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.chatTabPage.SuspendLayout();
            this.dialoueCorpusTabPage.SuspendLayout();
            this.dialogueCorpusTabControl.SuspendLayout();
            this.corpusItemsTabPage.SuspendLayout();
            this.corpusVocabularyTabPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1046, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDialogueCorpusToolStripMenuItem,
            this.saveDialogueCorpusToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
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
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showScoreToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // showScoreToolStripMenuItem
            // 
            this.showScoreToolStripMenuItem.CheckOnClick = true;
            this.showScoreToolStripMenuItem.Name = "showScoreToolStripMenuItem";
            this.showScoreToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.showScoreToolStripMenuItem.Text = "Show score";
            this.showScoreToolStripMenuItem.Click += new System.EventHandler(this.showScoreToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.chatTabPage);
            this.mainTabControl.Controls.Add(this.dialoueCorpusTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 30);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1046, 594);
            this.mainTabControl.TabIndex = 1;
            // 
            // chatTabPage
            // 
            this.chatTabPage.Controls.Add(this.dialogueListView);
            this.chatTabPage.Controls.Add(this.inputTextBox);
            this.chatTabPage.Location = new System.Drawing.Point(4, 25);
            this.chatTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatTabPage.Name = "chatTabPage";
            this.chatTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatTabPage.Size = new System.Drawing.Size(1038, 565);
            this.chatTabPage.TabIndex = 0;
            this.chatTabPage.Text = "Chat";
            this.chatTabPage.UseVisualStyleBackColor = true;
            // 
            // dialogueListView
            // 
            this.dialogueListView.BackColor = System.Drawing.Color.Black;
            this.dialogueListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogueListView.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueListView.ForeColor = System.Drawing.Color.Lime;
            this.dialogueListView.HideSelection = false;
            this.dialogueListView.Location = new System.Drawing.Point(3, 31);
            this.dialogueListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialogueListView.Name = "dialogueListView";
            this.dialogueListView.Size = new System.Drawing.Size(1032, 530);
            this.dialogueListView.TabIndex = 1;
            this.dialogueListView.UseCompatibleStateImageBehavior = false;
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.Color.DimGray;
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputTextBox.Enabled = false;
            this.inputTextBox.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.ForeColor = System.Drawing.Color.Lime;
            this.inputTextBox.Location = new System.Drawing.Point(3, 4);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(1032, 27);
            this.inputTextBox.TabIndex = 0;
            // 
            // dialoueCorpusTabPage
            // 
            this.dialoueCorpusTabPage.Controls.Add(this.dialogueCorpusTabControl);
            this.dialoueCorpusTabPage.Controls.Add(this.toolStrip1);
            this.dialoueCorpusTabPage.Location = new System.Drawing.Point(4, 25);
            this.dialoueCorpusTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialoueCorpusTabPage.Name = "dialoueCorpusTabPage";
            this.dialoueCorpusTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialoueCorpusTabPage.Size = new System.Drawing.Size(1038, 567);
            this.dialoueCorpusTabPage.TabIndex = 1;
            this.dialoueCorpusTabPage.Text = "Dialogue corpus";
            this.dialoueCorpusTabPage.UseVisualStyleBackColor = true;
            // 
            // dialogueCorpusTabControl
            // 
            this.dialogueCorpusTabControl.Controls.Add(this.corpusItemsTabPage);
            this.dialogueCorpusTabControl.Controls.Add(this.corpusVocabularyTabPage);
            this.dialogueCorpusTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogueCorpusTabControl.Location = new System.Drawing.Point(3, 31);
            this.dialogueCorpusTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dialogueCorpusTabControl.Name = "dialogueCorpusTabControl";
            this.dialogueCorpusTabControl.SelectedIndex = 0;
            this.dialogueCorpusTabControl.Size = new System.Drawing.Size(1032, 532);
            this.dialogueCorpusTabControl.TabIndex = 6;
            // 
            // corpusItemsTabPage
            // 
            this.corpusItemsTabPage.Controls.Add(this.corpusItemsListBox);
            this.corpusItemsTabPage.Location = new System.Drawing.Point(4, 25);
            this.corpusItemsTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.corpusItemsTabPage.Name = "corpusItemsTabPage";
            this.corpusItemsTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.corpusItemsTabPage.Size = new System.Drawing.Size(1024, 503);
            this.corpusItemsTabPage.TabIndex = 0;
            this.corpusItemsTabPage.Text = "Corpus items";
            this.corpusItemsTabPage.UseVisualStyleBackColor = true;
            // 
            // corpusItemsListBox
            // 
            this.corpusItemsListBox.BackColor = System.Drawing.Color.Black;
            this.corpusItemsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corpusItemsListBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corpusItemsListBox.ForeColor = System.Drawing.Color.Lime;
            this.corpusItemsListBox.FormattingEnabled = true;
            this.corpusItemsListBox.ItemHeight = 14;
            this.corpusItemsListBox.Location = new System.Drawing.Point(3, 4);
            this.corpusItemsListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.corpusItemsListBox.Name = "corpusItemsListBox";
            this.corpusItemsListBox.Size = new System.Drawing.Size(1018, 495);
            this.corpusItemsListBox.TabIndex = 5;
            // 
            // corpusVocabularyTabPage
            // 
            this.corpusVocabularyTabPage.Controls.Add(this.corpusVocabularyListBox);
            this.corpusVocabularyTabPage.Location = new System.Drawing.Point(4, 25);
            this.corpusVocabularyTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.corpusVocabularyTabPage.Name = "corpusVocabularyTabPage";
            this.corpusVocabularyTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.corpusVocabularyTabPage.Size = new System.Drawing.Size(1024, 503);
            this.corpusVocabularyTabPage.TabIndex = 1;
            this.corpusVocabularyTabPage.Text = "Corpus vocabulary";
            this.corpusVocabularyTabPage.UseVisualStyleBackColor = true;
            // 
            // corpusVocabularyListBox
            // 
            this.corpusVocabularyListBox.BackColor = System.Drawing.Color.Black;
            this.corpusVocabularyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corpusVocabularyListBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corpusVocabularyListBox.ForeColor = System.Drawing.Color.Lime;
            this.corpusVocabularyListBox.FormattingEnabled = true;
            this.corpusVocabularyListBox.ItemHeight = 14;
            this.corpusVocabularyListBox.Location = new System.Drawing.Point(3, 4);
            this.corpusVocabularyListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.corpusVocabularyListBox.Name = "corpusVocabularyListBox";
            this.corpusVocabularyListBox.Size = new System.Drawing.Size(1018, 495);
            this.corpusVocabularyListBox.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1032, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // importButton
            // 
            this.importButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.importButton.Image = ((System.Drawing.Image)(resources.GetObject("importButton.Image")));
            this.importButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(58, 24);
            this.importButton.Text = "Import";
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 624);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information-retrieval chatbot,v 1.0 (c) Mattias Wahde, 2021";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.chatTabPage.ResumeLayout(false);
            this.chatTabPage.PerformLayout();
            this.dialoueCorpusTabPage.ResumeLayout(false);
            this.dialoueCorpusTabPage.PerformLayout();
            this.dialogueCorpusTabControl.ResumeLayout(false);
            this.corpusItemsTabPage.ResumeLayout(false);
            this.corpusVocabularyTabPage.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage chatTabPage;
        private System.Windows.Forms.ListView dialogueListView;
        private ChatbotLibrary.InputTextBox inputTextBox;
        private System.Windows.Forms.TabPage dialoueCorpusTabPage;
        private System.Windows.Forms.ToolStripMenuItem loadDialogueCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDialogueCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showScoreToolStripMenuItem;
        private System.Windows.Forms.TabControl dialogueCorpusTabControl;
        private System.Windows.Forms.TabPage corpusItemsTabPage;
        private System.Windows.Forms.ListBox corpusItemsListBox;
        private System.Windows.Forms.TabPage corpusVocabularyTabPage;
        private System.Windows.Forms.ListBox corpusVocabularyListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton importButton;
    }
}

