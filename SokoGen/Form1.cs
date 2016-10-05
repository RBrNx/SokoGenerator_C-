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
            combo_NumLevels.SelectedIndex = 0;
            combo_NumBoxes.SelectedIndex = 0;
            combo_RoomHeight.SelectedIndex = 0;
            combo_RoomWidth.SelectedIndex = 0;
            combo_Difficulty.SelectedIndex = 0;
            comboTimeLimit.SelectedIndex = 0;
            label_CurrGenTime.Text = "Current Generation Time - 00:00:00";

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
            listbox_LevelSet.Items.RemoveAt(listbox_LevelSet.SelectedIndex);
        }

        private void button_GenLevels_Click(object sender, EventArgs e)
        {             
            if (!backgroundWorker.IsBusy)
            {
                progressBar.Value = 0;
                elapsedTime = new TimeSpan(0, 0, 0);
                label_CurrGenTime.Text = "Current Generation Time - " + elapsedTime.ToString();

                timer.Start();
                startTime = DateTime.Now;

                textbox_GenSeed.Text = Generator.generateSeed().ToString();
                
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

        private static string CalculatePi(int digits)
        {
            digits++;

            uint[] x = new uint[digits * 10 / 3 + 2];
            uint[] r = new uint[digits * 10 / 3 + 2];

            uint[] pi = new uint[digits];

            for (int j = 0; j < x.Length; j++)
                x[j] = 20;

            for (int i = 0; i < digits; i++)
            {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;

                    x[j] += carry;

                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;

                    carry = q * num;
                }


                pi[i] = (x[x.Length - 1] / 10);


                r[x.Length - 1] = x[x.Length - 1] % 10; ;

                for (int j = 0; j < x.Length; j++)
                    x[j] = r[j] * 10;
            }

            var result = "";

            uint c = 0;

            for (int i = pi.Length - 1; i >= 0; i--)
            {
                pi[i] += c;
                c = pi[i] / 10;

                result = (pi[i] % 10).ToString() + result;
            }

            return result;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Stop();
            button_GenLevels.Text = "Begin Generation!";
            ListLevels(levelSet);
            DisplayLevel(levelSet[0]);
        }

        private void LoadImages()
        {
            sprites.Add('$', Image.FromFile("textures/BOX.png"));
            sprites.Add('*', Image.FromFile("textures/BOX_SHIPPED.png"));
            sprites.Add(' ', Image.FromFile("textures/FLOOR.png"));
            sprites.Add('.', Image.FromFile("textures/GOAL.png"));
            sprites.Add('@', Image.FromFile("textures/MAN.png"));
            sprites.Add('#', Image.FromFile("textures/WALL.png"));
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
            for(int i = listbox_LevelSet.Items.Count; i > 0; i--)
            {
                listbox_LevelSet.Items.RemoveAt(i);
            }

            for(int i = 0; i < levelSet.Count; i++)
            {
                TimeSpan genTime = new TimeSpan(0, 2, 45);
                string diff = "Easy";
                listbox_LevelSet.Items.Add("Level " + i + " - " + genTime.ToString(@"hh\:mm\:ss") + " - " + diff);
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
            Generator.timeLimit = comboTimeLimit.SelectedIndex;
        }

        private void combo_NumLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator.noOfLevels = combo_NumLevels.SelectedIndex;
        }

        private void listbox_LevelSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level level = levelSet[listbox_LevelSet.SelectedIndex];
            DisplayLevel(level);
        }
    }


}
