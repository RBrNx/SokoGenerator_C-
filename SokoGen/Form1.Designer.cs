﻿namespace SokoGen
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.label_CurrGenTime = new System.Windows.Forms.Label();
            this.listbox_LevelSet = new System.Windows.Forms.ListBox();
            this.textbox_GenSeed = new System.Windows.Forms.TextBox();
            this.combo_NumLevels = new System.Windows.Forms.ComboBox();
            this.combo_RoomHeight = new System.Windows.Forms.ComboBox();
            this.combo_NumBoxes = new System.Windows.Forms.ComboBox();
            this.combo_RoomWidth = new System.Windows.Forms.ComboBox();
            this.combo_Difficulty = new System.Windows.Forms.ComboBox();
            this.label_GenSeed = new System.Windows.Forms.Label();
            this.label_CurrLevel = new System.Windows.Forms.Label();
            this.label_LevelSet = new System.Windows.Forms.Label();
            this.label_NumLevels = new System.Windows.Forms.Label();
            this.label_RoomHeight = new System.Windows.Forms.Label();
            this.label_NumBoxes = new System.Windows.Forms.Label();
            this.label_RoomWidth = new System.Windows.Forms.Label();
            this.label_Difficulty = new System.Windows.Forms.Label();
            this.label_GenTimeLimit = new System.Windows.Forms.Label();
            this.comboTimeLimit = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_GenLevels = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pbox_CurrLevel = new System.Windows.Forms.PictureBox();
            this.label_processInfo = new System.Windows.Forms.Label();
            this.checkBox_autoSeed = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_CurrLevel)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CurrGenTime
            // 
            this.label_CurrGenTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CurrGenTime.AutoEllipsis = true;
            this.label_CurrGenTime.AutoSize = true;
            this.label_CurrGenTime.Location = new System.Drawing.Point(520, 226);
            this.label_CurrGenTime.Name = "label_CurrGenTime";
            this.label_CurrGenTime.Size = new System.Drawing.Size(173, 13);
            this.label_CurrGenTime.TabIndex = 21;
            this.label_CurrGenTime.Text = "Current Generation Time - 00:00:00";
            // 
            // listbox_LevelSet
            // 
            this.listbox_LevelSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listbox_LevelSet.FormattingEnabled = true;
            this.listbox_LevelSet.Location = new System.Drawing.Point(12, 44);
            this.listbox_LevelSet.Name = "listbox_LevelSet";
            this.listbox_LevelSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listbox_LevelSet.Size = new System.Drawing.Size(205, 316);
            this.listbox_LevelSet.TabIndex = 0;
            this.listbox_LevelSet.SelectedIndexChanged += new System.EventHandler(this.listbox_LevelSet_SelectedIndexChanged);
            // 
            // textbox_GenSeed
            // 
            this.textbox_GenSeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_GenSeed.Location = new System.Drawing.Point(523, 44);
            this.textbox_GenSeed.Name = "textbox_GenSeed";
            this.textbox_GenSeed.ReadOnly = true;
            this.textbox_GenSeed.Size = new System.Drawing.Size(89, 20);
            this.textbox_GenSeed.TabIndex = 2;
            // 
            // combo_NumLevels
            // 
            this.combo_NumLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_NumLevels.FormattingEnabled = true;
            this.combo_NumLevels.Items.AddRange(new object[] {
            "Random",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.combo_NumLevels.Location = new System.Drawing.Point(523, 90);
            this.combo_NumLevels.Name = "combo_NumLevels";
            this.combo_NumLevels.Size = new System.Drawing.Size(88, 21);
            this.combo_NumLevels.TabIndex = 3;
            this.combo_NumLevels.SelectedIndexChanged += new System.EventHandler(this.combo_NumLevels_SelectedIndexChanged);
            // 
            // combo_RoomHeight
            // 
            this.combo_RoomHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_RoomHeight.FormattingEnabled = true;
            this.combo_RoomHeight.Items.AddRange(new object[] {
            "Random",
            "3",
            "6",
            "9",
            "12",
            "15"});
            this.combo_RoomHeight.Location = new System.Drawing.Point(622, 90);
            this.combo_RoomHeight.Name = "combo_RoomHeight";
            this.combo_RoomHeight.Size = new System.Drawing.Size(88, 21);
            this.combo_RoomHeight.TabIndex = 4;
            this.combo_RoomHeight.SelectedIndexChanged += new System.EventHandler(this.combo_RoomHeight_SelectedIndexChanged);
            // 
            // combo_NumBoxes
            // 
            this.combo_NumBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_NumBoxes.FormattingEnabled = true;
            this.combo_NumBoxes.Items.AddRange(new object[] {
            "Random",
            "3",
            "4",
            "5",
            "6"});
            this.combo_NumBoxes.Location = new System.Drawing.Point(523, 137);
            this.combo_NumBoxes.Name = "combo_NumBoxes";
            this.combo_NumBoxes.Size = new System.Drawing.Size(88, 21);
            this.combo_NumBoxes.TabIndex = 5;
            this.combo_NumBoxes.SelectedIndexChanged += new System.EventHandler(this.combo_NumBoxes_SelectedIndexChanged);
            // 
            // combo_RoomWidth
            // 
            this.combo_RoomWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_RoomWidth.FormattingEnabled = true;
            this.combo_RoomWidth.Items.AddRange(new object[] {
            "Random",
            "3",
            "6",
            "9",
            "12",
            "15"});
            this.combo_RoomWidth.Location = new System.Drawing.Point(622, 137);
            this.combo_RoomWidth.Name = "combo_RoomWidth";
            this.combo_RoomWidth.Size = new System.Drawing.Size(88, 21);
            this.combo_RoomWidth.TabIndex = 6;
            this.combo_RoomWidth.SelectedIndexChanged += new System.EventHandler(this.combo_RoomWidth_SelectedIndexChanged);
            // 
            // combo_Difficulty
            // 
            this.combo_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Difficulty.FormattingEnabled = true;
            this.combo_Difficulty.Items.AddRange(new object[] {
            "Random",
            "Very Easy",
            "Easy",
            "Medium",
            "Hard",
            "Very Hard"});
            this.combo_Difficulty.Location = new System.Drawing.Point(523, 184);
            this.combo_Difficulty.Name = "combo_Difficulty";
            this.combo_Difficulty.Size = new System.Drawing.Size(88, 21);
            this.combo_Difficulty.TabIndex = 7;
            this.combo_Difficulty.SelectedIndexChanged += new System.EventHandler(this.combo_Difficulty_SelectedIndexChanged);
            // 
            // label_GenSeed
            // 
            this.label_GenSeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_GenSeed.AutoSize = true;
            this.label_GenSeed.Location = new System.Drawing.Point(523, 29);
            this.label_GenSeed.Name = "label_GenSeed";
            this.label_GenSeed.Size = new System.Drawing.Size(82, 13);
            this.label_GenSeed.TabIndex = 9;
            this.label_GenSeed.Text = "Generator Seed";
            // 
            // label_CurrLevel
            // 
            this.label_CurrLevel.AutoSize = true;
            this.label_CurrLevel.Location = new System.Drawing.Point(238, 25);
            this.label_CurrLevel.Name = "label_CurrLevel";
            this.label_CurrLevel.Size = new System.Drawing.Size(70, 13);
            this.label_CurrLevel.TabIndex = 10;
            this.label_CurrLevel.Text = "Current Level";
            // 
            // label_LevelSet
            // 
            this.label_LevelSet.AutoSize = true;
            this.label_LevelSet.Location = new System.Drawing.Point(9, 25);
            this.label_LevelSet.Name = "label_LevelSet";
            this.label_LevelSet.Size = new System.Drawing.Size(52, 13);
            this.label_LevelSet.TabIndex = 11;
            this.label_LevelSet.Text = "Level Set";
            // 
            // label_NumLevels
            // 
            this.label_NumLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_NumLevels.AutoSize = true;
            this.label_NumLevels.Location = new System.Drawing.Point(523, 75);
            this.label_NumLevels.Name = "label_NumLevels";
            this.label_NumLevels.Size = new System.Drawing.Size(70, 13);
            this.label_NumLevels.TabIndex = 12;
            this.label_NumLevels.Text = "No. of Levels";
            // 
            // label_RoomHeight
            // 
            this.label_RoomHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RoomHeight.AutoSize = true;
            this.label_RoomHeight.Location = new System.Drawing.Point(619, 75);
            this.label_RoomHeight.Name = "label_RoomHeight";
            this.label_RoomHeight.Size = new System.Drawing.Size(69, 13);
            this.label_RoomHeight.TabIndex = 13;
            this.label_RoomHeight.Text = "Room Height";
            // 
            // label_NumBoxes
            // 
            this.label_NumBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_NumBoxes.AutoSize = true;
            this.label_NumBoxes.Location = new System.Drawing.Point(523, 122);
            this.label_NumBoxes.Name = "label_NumBoxes";
            this.label_NumBoxes.Size = new System.Drawing.Size(68, 13);
            this.label_NumBoxes.TabIndex = 14;
            this.label_NumBoxes.Text = "No. of Boxes";
            // 
            // label_RoomWidth
            // 
            this.label_RoomWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RoomWidth.AutoSize = true;
            this.label_RoomWidth.Location = new System.Drawing.Point(619, 122);
            this.label_RoomWidth.Name = "label_RoomWidth";
            this.label_RoomWidth.Size = new System.Drawing.Size(66, 13);
            this.label_RoomWidth.TabIndex = 15;
            this.label_RoomWidth.Text = "Room Width";
            // 
            // label_Difficulty
            // 
            this.label_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Difficulty.AutoSize = true;
            this.label_Difficulty.Location = new System.Drawing.Point(523, 169);
            this.label_Difficulty.Name = "label_Difficulty";
            this.label_Difficulty.Size = new System.Drawing.Size(47, 13);
            this.label_Difficulty.TabIndex = 16;
            this.label_Difficulty.Text = "Difficulty";
            // 
            // label_GenTimeLimit
            // 
            this.label_GenTimeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_GenTimeLimit.AutoSize = true;
            this.label_GenTimeLimit.Location = new System.Drawing.Point(619, 169);
            this.label_GenTimeLimit.Name = "label_GenTimeLimit";
            this.label_GenTimeLimit.Size = new System.Drawing.Size(77, 13);
            this.label_GenTimeLimit.TabIndex = 17;
            this.label_GenTimeLimit.Text = "Gen Time Limit";
            // 
            // comboTimeLimit
            // 
            this.comboTimeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboTimeLimit.FormattingEnabled = true;
            this.comboTimeLimit.Location = new System.Drawing.Point(622, 184);
            this.comboTimeLimit.Name = "comboTimeLimit";
            this.comboTimeLimit.Size = new System.Drawing.Size(88, 21);
            this.comboTimeLimit.TabIndex = 18;
            this.comboTimeLimit.SelectedIndexChanged += new System.EventHandler(this.comboTimeLimit_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(523, 297);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(187, 23);
            this.progressBar.TabIndex = 19;
            // 
            // button_GenLevels
            // 
            this.button_GenLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GenLevels.Location = new System.Drawing.Point(523, 333);
            this.button_GenLevels.Name = "button_GenLevels";
            this.button_GenLevels.Size = new System.Drawing.Size(187, 23);
            this.button_GenLevels.TabIndex = 20;
            this.button_GenLevels.Text = "Begin Generation!";
            this.button_GenLevels.UseVisualStyleBackColor = true;
            this.button_GenLevels.Click += new System.EventHandler(this.button_GenLevels_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // pbox_CurrLevel
            // 
            this.pbox_CurrLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_CurrLevel.Location = new System.Drawing.Point(241, 44);
            this.pbox_CurrLevel.Name = "pbox_CurrLevel";
            this.pbox_CurrLevel.Size = new System.Drawing.Size(262, 316);
            this.pbox_CurrLevel.TabIndex = 22;
            this.pbox_CurrLevel.TabStop = false;
            // 
            // label_processInfo
            // 
            this.label_processInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_processInfo.AutoEllipsis = true;
            this.label_processInfo.AutoSize = true;
            this.label_processInfo.Location = new System.Drawing.Point(520, 277);
            this.label_processInfo.Name = "label_processInfo";
            this.label_processInfo.Size = new System.Drawing.Size(92, 13);
            this.label_processInfo.TabIndex = 23;
            this.label_processInfo.Text = "Waiting for User...";
            // 
            // checkBox_autoSeed
            // 
            this.checkBox_autoSeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_autoSeed.AutoSize = true;
            this.checkBox_autoSeed.Checked = true;
            this.checkBox_autoSeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoSeed.Location = new System.Drawing.Point(622, 44);
            this.checkBox_autoSeed.Name = "checkBox_autoSeed";
            this.checkBox_autoSeed.Size = new System.Drawing.Size(76, 17);
            this.checkBox_autoSeed.TabIndex = 24;
            this.checkBox_autoSeed.Text = "Auto Seed";
            this.checkBox_autoSeed.UseVisualStyleBackColor = true;
            this.checkBox_autoSeed.CheckedChanged += new System.EventHandler(this.checkBox_autoSeed_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 368);
            this.Controls.Add(this.checkBox_autoSeed);
            this.Controls.Add(this.label_processInfo);
            this.Controls.Add(this.pbox_CurrLevel);
            this.Controls.Add(this.label_CurrGenTime);
            this.Controls.Add(this.button_GenLevels);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.comboTimeLimit);
            this.Controls.Add(this.label_GenTimeLimit);
            this.Controls.Add(this.label_Difficulty);
            this.Controls.Add(this.label_RoomWidth);
            this.Controls.Add(this.label_NumBoxes);
            this.Controls.Add(this.label_RoomHeight);
            this.Controls.Add(this.label_NumLevels);
            this.Controls.Add(this.label_LevelSet);
            this.Controls.Add(this.label_CurrLevel);
            this.Controls.Add(this.label_GenSeed);
            this.Controls.Add(this.combo_Difficulty);
            this.Controls.Add(this.combo_RoomWidth);
            this.Controls.Add(this.combo_NumBoxes);
            this.Controls.Add(this.combo_RoomHeight);
            this.Controls.Add(this.combo_NumLevels);
            this.Controls.Add(this.textbox_GenSeed);
            this.Controls.Add(this.listbox_LevelSet);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(738, 385);
            this.Name = "mainForm";
            this.Text = "Sokoban Level Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pbox_CurrLevel)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_LevelSet;
        private System.Windows.Forms.ComboBox combo_NumLevels;
        private System.Windows.Forms.ComboBox combo_RoomHeight;
        private System.Windows.Forms.ComboBox combo_NumBoxes;
        private System.Windows.Forms.ComboBox combo_RoomWidth;
        private System.Windows.Forms.ComboBox combo_Difficulty;
        private System.Windows.Forms.Label label_GenSeed;
        private System.Windows.Forms.Label label_CurrLevel;
        private System.Windows.Forms.Label label_LevelSet;
        private System.Windows.Forms.Label label_NumLevels;
        private System.Windows.Forms.Label label_RoomHeight;
        private System.Windows.Forms.Label label_NumBoxes;
        private System.Windows.Forms.Label label_RoomWidth;
        private System.Windows.Forms.Label label_Difficulty;
        private System.Windows.Forms.Label label_GenTimeLimit;
        private System.Windows.Forms.ComboBox comboTimeLimit;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_GenLevels;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.PictureBox pbox_CurrLevel;
        private System.Windows.Forms.Label label_CurrGenTime;
        private System.Windows.Forms.Label label_processInfo;
        private System.Windows.Forms.CheckBox checkBox_autoSeed;
        private System.Windows.Forms.TextBox textbox_GenSeed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

