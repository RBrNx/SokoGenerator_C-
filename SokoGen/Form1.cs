using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SokoGen
{
    public partial class mainForm : Form
    {
        LevelGen Generator;
        List<Level> levelSet;
        Dictionary<char, Image> sprites = new Dictionary<char, Image>();
        Timer timer;
        DateTime startTime;
        TimeSpan elapsedTime;
        ContextMenuStrip rightClickMenu;
        List<float> timeLimits = new List<float>();
        bool genSeedEnabled = false;

        public mainForm()
        {
            InitializeComponent();
            LoadImages();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timerTick);
            Generator = new LevelGen(this, backgroundWorker, timer);
            InitializeForms();
        }

        private void InitializeForms()
        {
            Dictionary<string, float> timeLimits = new Dictionary<string, float>();
            timeLimits.Add("No Limit", 0);
            timeLimits.Add("30 Secs", 0.5f);
            timeLimits.Add("1 Min", 1);
            timeLimits.Add("2 Min", 1);
            timeLimits.Add("5 Min", 1);
            timeLimits.Add("10 Min", 10);

            comboTimeLimit.DataSource = new BindingSource(timeLimits, null);
            comboTimeLimit.DisplayMember = "Key";
            comboTimeLimit.ValueMember = "Value";

            combo_NumLevels.SelectedIndex = 0;
            combo_NumBoxes.SelectedIndex = 0;
            combo_RoomHeight.SelectedIndex = 0;
            combo_RoomWidth.SelectedIndex = 0;
            combo_Difficulty.SelectedIndex = 0;
            comboTimeLimit.SelectedIndex = 1;
            label_CurrGenTime.Text = "Current Generation Time - 00:00:00";
            textbox_GenSeed.Text = "";

            textbox_GenSeed.TextChanged += (senders, args) =>
            {
                if(textbox_GenSeed.BackColor == Color.IndianRed)
                {
                    textbox_GenSeed.BackColor = default(Color);
                    label_processInfo.ForeColor = default(Color);
                    label_processInfo.Text = "Waiting for User...";
                }          
            };

            ToolStripMenuItem deleteItem = new ToolStripMenuItem { Text = "Delete Level" };
            deleteItem.Click += DeleteItem_Click;
            ToolStripMenuItem regenLevel = new ToolStripMenuItem { Text = "Regenerate Level" };
            regenLevel.Click += RegenLevel_Click;

            rightClickMenu = new ContextMenuStrip();
            rightClickMenu.Items.AddRange(new ToolStripItem[] { deleteItem, regenLevel } );
            listbox_LevelSet.MouseUp += Listbox_LevelSet_MouseUp;
        }

        private void Listbox_LevelSet_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            int index = listbox_LevelSet.IndexFromPoint(e.Location);
            if(index != ListBox.NoMatches)
            {
                listbox_LevelSet.SelectedIndex = index;
                rightClickMenu.Show(Cursor.Position);
                rightClickMenu.Visible = true;
            }
            else
            {
                rightClickMenu.Visible = false;
            }
        }

        private void RegenLevel_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            for(int i = listbox_LevelSet.Items.Count-1; i >= 0; i--)
            {
                if(listbox_LevelSet.GetSelected(i) == true)
                {
                    levelSet.RemoveAt(i);
                }
            }

            if (levelSet.Count > 0)
            {
                ListLevels(levelSet);
                listbox_LevelSet.SelectedIndex = listbox_LevelSet.TopIndex;
            }
            else
            {
                listbox_LevelSet.Items.Clear();
                listbox_LevelSet.ClearSelected();
            }
        }

        private void button_GenLevels_Click(object sender, EventArgs e)
        {             
            if (!backgroundWorker.IsBusy)
            {
                bool valid = false;
                progressBar.Value = 0;
                elapsedTime = new TimeSpan(0, 0, 0);
                label_CurrGenTime.Text = "Current Generation Time - " + elapsedTime.ToString();

                if(checkBox_autoSeed.Checked)
                {
                    textbox_GenSeed.Text = Generator.generateSeed().ToString();
                    Generator.genSeed = Int32.Parse(textbox_GenSeed.Text);
                    valid = true;
                }
                else
                {
                    int seed;
                    valid = Int32.TryParse(textbox_GenSeed.Text, out seed);
                    if (valid) { Generator.genSeed = seed; }
                }

                if (!valid)
                {
                    textbox_GenSeed.BackColor = Color.IndianRed;
                    label_processInfo.Text = "Please Enter a Valid Numerical Seed";
                    label_processInfo.ForeColor = Color.Red;
                    return;
                }

                comboTimeLimit.Enabled = false;
                combo_Difficulty.Enabled = false;
                combo_NumBoxes.Enabled = false;
                combo_NumLevels.Enabled = false;
                combo_RoomHeight.Enabled = false;
                combo_RoomWidth.Enabled = false;
                if (textbox_GenSeed.ReadOnly == false) { textbox_GenSeed.ReadOnly = true; }

                timer.Start();
                startTime = DateTime.Now;

                backgroundWorker.RunWorkerAsync();

                button_GenLevels.Text = "Cancel Generation";
            }
            else
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            levelSet = Generator.startGeneration();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            label_processInfo.Text = e.ProgressPercentage + "% - " + (string)e.UserState;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Stop();
            button_GenLevels.Text = "Begin Generation!";

            comboTimeLimit.Enabled = true;
            combo_Difficulty.Enabled = true;
            combo_NumBoxes.Enabled = true;
            combo_NumLevels.Enabled = true;
            combo_RoomHeight.Enabled = true;
            combo_RoomWidth.Enabled = true;
            if (genSeedEnabled == true) { textbox_GenSeed.ReadOnly = false; }

            ListLevels(levelSet);
            DisplayLevel(levelSet[0]);
        }

        private void LoadImages()
        {
            Image box = Image.FromFile("textures/BOX.png");
            Image boxShipped = Image.FromFile("textures/BOX_SHIPPED.png");
            Image goal = Image.FromFile("textures/GOAL.png");
            Image player = Image.FromFile("textures/MAN.png");
            Image floor = Image.FromFile("textures/FLOOR.png");
            Image wall = Image.FromFile("textures/WALL.png");

            Bitmap boxOnGoal = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(boxOnGoal);
            g.DrawImage(goal, new Point(0, 0));
            g.DrawImage(boxShipped, new Point(0, 0));
            g.Dispose();

            Bitmap boxOnFloor = new Bitmap(64, 64);
            g = Graphics.FromImage(boxOnFloor);
            g.DrawImage(floor, new Point(0, 0));
            g.DrawImage(box, new Point(0, 0));
            g.Dispose();

            Bitmap playerOnGoal = new Bitmap(64, 64);
            g = Graphics.FromImage(playerOnGoal);
            g.DrawImage(goal, new Point(0, 0));
            g.DrawImage(player, new Point(0, 0));
            g.Dispose();

            Bitmap playerOnFloor = new Bitmap(64, 64);
            g = Graphics.FromImage(playerOnFloor);
            g.DrawImage(floor, new Point(0, 0));
            g.DrawImage(player, new Point(0, 0));
            g.Dispose();


            sprites.Add('$', boxOnFloor);
            sprites.Add('*', boxOnGoal);
            sprites.Add(' ', floor);
            sprites.Add('.', goal);
            sprites.Add('@', playerOnFloor);
            sprites.Add('+', playerOnGoal);
            sprites.Add('#', wall);
        }

        private void DisplayLevel(Level level)
        {
            int levelHeight = level.grid.Count;
            int levelWidth = level.grid[0].Count;

            Bitmap levelBMP = new Bitmap(levelWidth * 64, levelHeight * 64);
            Graphics g = Graphics.FromImage(levelBMP);

            for(int y = 0; y < levelHeight; y++)
            {
                for(int x = 0; x < levelWidth; x++)
                {
                    char key = level.grid[y][x];
                    g.DrawImage(sprites[key], new Point(x * 64, y * 64));
                }
            }

            pbox_CurrLevel.Image = levelBMP;
            pbox_CurrLevel.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void ListLevels(List<Level> levelSet)
        {
            listbox_LevelSet.Items.Clear();

            for(int i = 0; i < levelSet.Count; i++)
            {
                TimeSpan genTime = new TimeSpan(0, 2, 45);
                string diff = "Easy";
                listbox_LevelSet.Items.Add("Level " + (i+1) + " - " + genTime.ToString(@"hh\:mm\:ss") + " - " + diff);
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            DateTime currTime = DateTime.Now;
            elapsedTime = currTime - startTime;
            label_CurrGenTime.Text = "Current Generation Time - " + elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void combo_NumBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.noOfBoxes = combo_NumBoxes.SelectedIndex;
        }

        private void combo_RoomHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.roomHeight = combo_RoomHeight.SelectedIndex;
        }

        private void combo_RoomWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.roomWidth = combo_RoomWidth.SelectedIndex;
        }

        private void combo_Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.difficulty = combo_Difficulty.SelectedIndex;
        }

        private void comboTimeLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.timeLimit = ((KeyValuePair<string, float>)comboTimeLimit.SelectedItem).Value;
        }

        private void combo_NumLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.noOfLevels = combo_NumLevels.SelectedIndex;
        }

        private void listbox_LevelSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listbox_LevelSet.SelectedIndex != -1)
            {
                Level level = levelSet[listbox_LevelSet.SelectedIndex];
                DisplayLevel(level);
            }

        }

        private void checkBox_autoSeed_CheckedChanged(object sender, EventArgs e)
        {
            textbox_GenSeed.ReadOnly = !textbox_GenSeed.ReadOnly;
            genSeedEnabled = !textbox_GenSeed.ReadOnly;
        }
    }


}
