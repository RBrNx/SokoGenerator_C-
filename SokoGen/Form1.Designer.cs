namespace SokoGen
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
            ((System.ComponentModel.ISupportInitialize)(this.pbox_CurrLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label_CurrGenTime
            // 
            this.label_CurrGenTime.AutoEllipsis = true;
            this.label_CurrGenTime.AutoSize = true;
            this.label_CurrGenTime.Location = new System.Drawing.Point(520, 213);
            this.label_CurrGenTime.Name = "label_CurrGenTime";
            this.label_CurrGenTime.Size = new System.Drawing.Size(173, 13);
            this.label_CurrGenTime.TabIndex = 21;
            this.label_CurrGenTime.Text = "Current Generation Time - 00:00:00";
            // 
            // listbox_LevelSet
            // 
            this.listbox_LevelSet.FormattingEnabled = true;
            this.listbox_LevelSet.Location = new System.Drawing.Point(12, 31);
            this.listbox_LevelSet.Name = "listbox_LevelSet";
            this.listbox_LevelSet.Size = new System.Drawing.Size(205, 303);
            this.listbox_LevelSet.TabIndex = 0;
            this.listbox_LevelSet.SelectedIndexChanged += new System.EventHandler(this.listbox_LevelSet_SelectedIndexChanged);
            // 
            // textbox_GenSeed
            // 
            this.textbox_GenSeed.Location = new System.Drawing.Point(523, 31);
            this.textbox_GenSeed.Name = "textbox_GenSeed";
            this.textbox_GenSeed.Size = new System.Drawing.Size(187, 20);
            this.textbox_GenSeed.TabIndex = 2;
            // 
            // combo_NumLevels
            // 
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
            this.combo_NumLevels.Location = new System.Drawing.Point(523, 77);
            this.combo_NumLevels.Name = "combo_NumLevels";
            this.combo_NumLevels.Size = new System.Drawing.Size(88, 21);
            this.combo_NumLevels.TabIndex = 3;
            this.combo_NumLevels.SelectedIndexChanged += new System.EventHandler(this.combo_NumLevels_SelectedIndexChanged);
            // 
            // combo_RoomHeight
            // 
            this.combo_RoomHeight.FormattingEnabled = true;
            this.combo_RoomHeight.Items.AddRange(new object[] {
            "Random",
            "3",
            "6",
            "9",
            "12",
            "15"});
            this.combo_RoomHeight.Location = new System.Drawing.Point(622, 77);
            this.combo_RoomHeight.Name = "combo_RoomHeight";
            this.combo_RoomHeight.Size = new System.Drawing.Size(88, 21);
            this.combo_RoomHeight.TabIndex = 4;
            this.combo_RoomHeight.SelectedIndexChanged += new System.EventHandler(this.combo_RoomHeight_SelectedIndexChanged);
            // 
            // combo_NumBoxes
            // 
            this.combo_NumBoxes.FormattingEnabled = true;
            this.combo_NumBoxes.Items.AddRange(new object[] {
            "Random",
            "3",
            "4",
            "5",
            "6"});
            this.combo_NumBoxes.Location = new System.Drawing.Point(523, 124);
            this.combo_NumBoxes.Name = "combo_NumBoxes";
            this.combo_NumBoxes.Size = new System.Drawing.Size(88, 21);
            this.combo_NumBoxes.TabIndex = 5;
            this.combo_NumBoxes.SelectedIndexChanged += new System.EventHandler(this.combo_NumBoxes_SelectedIndexChanged);
            // 
            // combo_RoomWidth
            // 
            this.combo_RoomWidth.FormattingEnabled = true;
            this.combo_RoomWidth.Items.AddRange(new object[] {
            "Random",
            "3",
            "6",
            "9",
            "12",
            "15"});
            this.combo_RoomWidth.Location = new System.Drawing.Point(622, 124);
            this.combo_RoomWidth.Name = "combo_RoomWidth";
            this.combo_RoomWidth.Size = new System.Drawing.Size(88, 21);
            this.combo_RoomWidth.TabIndex = 6;
            this.combo_RoomWidth.SelectedIndexChanged += new System.EventHandler(this.combo_RoomWidth_SelectedIndexChanged);
            // 
            // combo_Difficulty
            // 
            this.combo_Difficulty.FormattingEnabled = true;
            this.combo_Difficulty.Items.AddRange(new object[] {
            "Random",
            "Very Easy",
            "Easy",
            "Medium",
            "Hard",
            "Very Hard"});
            this.combo_Difficulty.Location = new System.Drawing.Point(523, 171);
            this.combo_Difficulty.Name = "combo_Difficulty";
            this.combo_Difficulty.Size = new System.Drawing.Size(88, 21);
            this.combo_Difficulty.TabIndex = 7;
            this.combo_Difficulty.SelectedIndexChanged += new System.EventHandler(this.combo_Difficulty_SelectedIndexChanged);
            // 
            // label_GenSeed
            // 
            this.label_GenSeed.AutoSize = true;
            this.label_GenSeed.Location = new System.Drawing.Point(523, 16);
            this.label_GenSeed.Name = "label_GenSeed";
            this.label_GenSeed.Size = new System.Drawing.Size(82, 13);
            this.label_GenSeed.TabIndex = 9;
            this.label_GenSeed.Text = "Generator Seed";
            // 
            // label_CurrLevel
            // 
            this.label_CurrLevel.AutoSize = true;
            this.label_CurrLevel.Location = new System.Drawing.Point(238, 12);
            this.label_CurrLevel.Name = "label_CurrLevel";
            this.label_CurrLevel.Size = new System.Drawing.Size(70, 13);
            this.label_CurrLevel.TabIndex = 10;
            this.label_CurrLevel.Text = "Current Level";
            // 
            // label_LevelSet
            // 
            this.label_LevelSet.AutoSize = true;
            this.label_LevelSet.Location = new System.Drawing.Point(9, 12);
            this.label_LevelSet.Name = "label_LevelSet";
            this.label_LevelSet.Size = new System.Drawing.Size(52, 13);
            this.label_LevelSet.TabIndex = 11;
            this.label_LevelSet.Text = "Level Set";
            // 
            // label_NumLevels
            // 
            this.label_NumLevels.AutoSize = true;
            this.label_NumLevels.Location = new System.Drawing.Point(523, 62);
            this.label_NumLevels.Name = "label_NumLevels";
            this.label_NumLevels.Size = new System.Drawing.Size(70, 13);
            this.label_NumLevels.TabIndex = 12;
            this.label_NumLevels.Text = "No. of Levels";
            // 
            // label_RoomHeight
            // 
            this.label_RoomHeight.AutoSize = true;
            this.label_RoomHeight.Location = new System.Drawing.Point(619, 62);
            this.label_RoomHeight.Name = "label_RoomHeight";
            this.label_RoomHeight.Size = new System.Drawing.Size(69, 13);
            this.label_RoomHeight.TabIndex = 13;
            this.label_RoomHeight.Text = "Room Height";
            // 
            // label_NumBoxes
            // 
            this.label_NumBoxes.AutoSize = true;
            this.label_NumBoxes.Location = new System.Drawing.Point(523, 109);
            this.label_NumBoxes.Name = "label_NumBoxes";
            this.label_NumBoxes.Size = new System.Drawing.Size(68, 13);
            this.label_NumBoxes.TabIndex = 14;
            this.label_NumBoxes.Text = "No. of Boxes";
            // 
            // label_RoomWidth
            // 
            this.label_RoomWidth.AutoSize = true;
            this.label_RoomWidth.Location = new System.Drawing.Point(619, 109);
            this.label_RoomWidth.Name = "label_RoomWidth";
            this.label_RoomWidth.Size = new System.Drawing.Size(66, 13);
            this.label_RoomWidth.TabIndex = 15;
            this.label_RoomWidth.Text = "Room Width";
            // 
            // label_Difficulty
            // 
            this.label_Difficulty.AutoSize = true;
            this.label_Difficulty.Location = new System.Drawing.Point(523, 156);
            this.label_Difficulty.Name = "label_Difficulty";
            this.label_Difficulty.Size = new System.Drawing.Size(47, 13);
            this.label_Difficulty.TabIndex = 16;
            this.label_Difficulty.Text = "Difficulty";
            // 
            // label_GenTimeLimit
            // 
            this.label_GenTimeLimit.AutoSize = true;
            this.label_GenTimeLimit.Location = new System.Drawing.Point(619, 156);
            this.label_GenTimeLimit.Name = "label_GenTimeLimit";
            this.label_GenTimeLimit.Size = new System.Drawing.Size(77, 13);
            this.label_GenTimeLimit.TabIndex = 17;
            this.label_GenTimeLimit.Text = "Gen Time Limit";
            // 
            // comboTimeLimit
            // 
            this.comboTimeLimit.FormattingEnabled = true;
            this.comboTimeLimit.Items.AddRange(new object[] {
            "No Limit",
            "30 Secs",
            "1 Min",
            "2 Min",
            "5 Min",
            "10 Min"});
            this.comboTimeLimit.Location = new System.Drawing.Point(622, 171);
            this.comboTimeLimit.Name = "comboTimeLimit";
            this.comboTimeLimit.Size = new System.Drawing.Size(88, 21);
            this.comboTimeLimit.TabIndex = 18;
            this.comboTimeLimit.SelectedIndexChanged += new System.EventHandler(this.comboTimeLimit_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(523, 270);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(187, 23);
            this.progressBar.TabIndex = 19;
            // 
            // button_GenLevels
            // 
            this.button_GenLevels.Location = new System.Drawing.Point(523, 306);
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
            this.pbox_CurrLevel.Location = new System.Drawing.Point(241, 31);
            this.pbox_CurrLevel.Name = "pbox_CurrLevel";
            this.pbox_CurrLevel.Size = new System.Drawing.Size(262, 303);
            this.pbox_CurrLevel.TabIndex = 22;
            this.pbox_CurrLevel.TabStop = false;
            // 
            // label_processInfo
            // 
            this.label_processInfo.AutoEllipsis = true;
            this.label_processInfo.AutoSize = true;
            this.label_processInfo.Location = new System.Drawing.Point(520, 250);
            this.label_processInfo.Name = "label_processInfo";
            this.label_processInfo.Size = new System.Drawing.Size(92, 13);
            this.label_processInfo.TabIndex = 23;
            this.label_processInfo.Text = "Waiting on User...";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 347);
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
            this.MinimumSize = new System.Drawing.Size(738, 385);
            this.Name = "mainForm";
            this.Text = "Sokoban Level Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pbox_CurrLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_LevelSet;
        private System.Windows.Forms.TextBox textbox_GenSeed;
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
    }
}

