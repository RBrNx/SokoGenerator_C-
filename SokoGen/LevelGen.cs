using System;
using System.IO;
using System.Timers;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SokoGen
{
    public class Level
    {
        public List<List<char>> grid;
        public string solution;
        public int difficulty;
        public TimeSpan generationTime;

        public Level()
        {
            grid = new List<List<char>>();
            solution = "";
            difficulty = 0;
            generationTime = TimeSpan.MinValue;
        }
    }

    public class LevelGen
    {
        mainForm form;
        BackgroundWorker worker;
        List<Level> patterns = new List<Level>();
        Random randGen;
        System.Windows.Forms.Timer timer;
        System.Timers.Timer timeoutClock;
        DateTime startTime;
        TimeSpan timeElapsed;

        char WALL = '#';
        char FLOOR = ' ';
        char PATTERN_EDGE = '-';

        public int noOfBoxes { get; set; }
        public int noOfLevels { get; set; }
        public int roomHeight { get; set; }
        public int roomWidth { get; set; }
        public int difficulty { get; set; }
        public float timeLimit { get; set; }

        public LevelGen(mainForm form, BackgroundWorker worker, System.Windows.Forms.Timer timer)
        {
            this.form = form;
            this.worker = worker;
            this.timer = timer;
            loadPatterns();

            timeoutClock = new Timer();
            timeoutClock.AutoReset = true;
            timeoutClock.Interval = 1000;
            timeoutClock.Elapsed += TimeoutClock_Elapsed;
        }

        private void TimeoutClock_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime currTime = DateTime.Now;
            timeElapsed = currTime - startTime;
            if(timeLimit != 0)
            {
                if(timeElapsed.TotalMinutes > timeLimit)
                {
                    worker.CancelAsync();
                }
            }
        }

        public void loadPatterns()
        {
            string[] files = Directory.GetFiles("patterns/");
            Level pattern;
            List<char> row;
            List<List<char>> grid;

            for(int i = 0; i < files.Length; i++)
            {
                pattern = new Level();
                grid = new List<List<char>>();

                var lines = File.ReadLines(files[i]);
                foreach(string line in lines)
                {
                    row = new List<char>();
                    foreach (char c in line)
                    {
                        row.Add(c);
                    }
                    grid.Add(row);
                }
                pattern.grid = grid;
                patterns.Add(pattern);
            }
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

        public List<Level> startGeneration()
        {
            randGen = new Random(generateSeed());
            List<Level> levelSet = new List<Level>();

            int levels;
            if(noOfLevels == 0) { levels = randomNumber(ref randGen, 1, 20); } else { levels = noOfLevels; }

            for (int i = 0; i < levels; i++)
            {
                Level level = generateLevel(noOfLevels, noOfBoxes, roomHeight, roomWidth, difficulty, i, levels);
                levelSet.Add(level);

                if (worker.CancellationPending)
                {
                    timeoutClock.Stop();
                    return levelSet;
                }
            }

            worker.ReportProgress(100, "Generated " + levels + " Levels");

            /*for(int j = 0; j < 10000; j++)
            {
                CalculatePi(j);
                double percentage = ((j + 1) * 100) / 10000;
                worker.ReportProgress((int)percentage);
                if (worker.CancellationPending)
                {
                    return levelSet;
                }
                Console.WriteLine(percentage);
            }*/

            return levelSet;
        }

        public Level generateLevel(int noOfLevels, int noOfBoxes, int roomHeight, int roomWidth, int difficulty, int levelNum, int totalLevels)
        {
            bool generationSuccessful = false;
            Level newLevel = new Level();
            float percentage;
            int indProcesses = 2;
            int totalProcesses = totalLevels * (indProcesses + 1);

            while (!generationSuccessful)
            {
                newLevel = new Level();

                calculateProperties(ref noOfBoxes, ref difficulty, ref roomHeight, ref roomWidth);
                //System.Threading.Thread.Sleep(100);

                percentage = (((levelNum * indProcesses)) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Init Level " + levelNum);
                
                initLevel(ref newLevel, roomHeight, roomWidth);
                //System.Threading.Thread.Sleep(100);

                percentage = (((levelNum * indProcesses) + 1) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Placing Patterns in Level " + levelNum);

                placePatterns(ref newLevel, roomHeight, roomWidth);
                //System.Threading.Thread.Sleep(100);

                generationSuccessful = true;
            }

            percentage = (((levelNum * indProcesses) + 2) * 100) / totalProcesses;
            worker.ReportProgress((int)percentage, "Level " + levelNum + " Generated");

            return newLevel;
        }

        public void calculateProperties(ref int noOfBoxes, ref int difficulty, ref int roomHeight, ref int roomWidth)
        {
            if (noOfBoxes == 0) { noOfBoxes = randomNumber(ref randGen, 3, 6); }
            if (roomHeight == 0) { roomHeight = randomNumber(ref randGen, 3, 15, 3); }
            if (difficulty == 0) { difficulty = randomNumber(ref randGen, 1, 5); }
            if (roomWidth == 0)
            {
                if (roomHeight == 3) { roomWidth = randomNumber(ref randGen, 6, 15, 3); }
                else { roomWidth = randomNumber(ref randGen, 3, 15, 3); }
            }
        }

        public void initLevel(ref Level level, int roomHeight, int roomWidth)
        {
            List<char> row;
            roomHeight = roomHeight + 2;
            roomWidth = roomWidth + 2;

            for(int y = 0; y < roomHeight; y++)
            {
                row = new List<char>();
                for (int x = 0; x < roomWidth; x++)
                {
                    if(y == 0 || y == roomHeight-1 || x == 0 || x == roomWidth - 1)
                    {
                        row.Add(WALL);
                    }
                    else
                    {
                        row.Add(FLOOR);
                    }
                }
                level.grid.Add(row);
            }
        }

        public void placePatterns(ref Level level, int roomHeight, int roomWidth)
        {
            int patternPlacedCount = 0;
            Level tempLevel = new Level();

            for(int y = 1; y < roomHeight; y++)
            {
                for(int x = 1; x < roomWidth; x++)
                {
                    if((y-1) % 3 == 0 && (x-1) % 3 == 0)
                    {

                        while(patternPlacedCount != 25)
                        {
                            tempLevel = level;
                            patternPlacedCount = 0;

                            int rand = randomNumber(ref randGen, 0, patterns.Count - 1);
                            Level chosenPattern = patterns[rand];
                            rotatePattern(ref chosenPattern, randomNumber(ref randGen, 0, 3));

                            for(int pY = 0; pY < chosenPattern.grid.Count; pY++)
                            {
                                for(int pX = 0; pX < chosenPattern.grid[pY].Count; pX++)
                                {

                                    if (pX == 0 || pX == chosenPattern.grid[pY].Count - 1 || pY == 0 || pY == chosenPattern.grid.Count - 1)
                                    {
                                        if (chosenPattern.grid[pY][pX] == FLOOR)
                                        {
                                            if (tempLevel.grid[y + pY - 1][x + pX - 1] != FLOOR)
                                            {
                                                patternPlacedCount = -100;
                                            }
                                            else
                                            {
                                                patternPlacedCount++;
                                            }
                                        }
                                        else
                                        {
                                            patternPlacedCount++;
                                        }
                                    }
                                    else if (chosenPattern.grid[pY][pX] != PATTERN_EDGE)
                                    {
                                        tempLevel.grid[y + pY - 1][x + pX - 1] = chosenPattern.grid[pY][pX];
                                        patternPlacedCount++;
                                    }
                                    else
                                    {
                                        patternPlacedCount++;
                                    }
                                }
                            }
                        }
                        level = tempLevel;
                        patternPlacedCount = 0;
                    }
                }
            }
        }

        public void rotatePattern(ref Level pattern, int rotation)
        {
            Level tempPattern = pattern;

            switch (rotation)
            {
                case 1:
                    //Rotate 90 - Reverse Each Row
                    for(int i = 0; i < tempPattern.grid.Count; i++)
                    {
                        tempPattern.grid[i].Reverse();
                    }
                    break;

                case 2:
                    //Rotate 180 - Reverse Each Row, then Each Column
                    for (int i = 0; i < tempPattern.grid.Count; i++)
                    {
                        tempPattern.grid[i].Reverse();
                    }

                    tempPattern.grid.Reverse();
                    break;

                case 3:
                    //Rotate 270 - Reverse Each Column
                    tempPattern.grid.Reverse();
                    break;
            }

            pattern = tempPattern;
        }

        public int generateSeed()
        {
            byte[] cryptoRes = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(cryptoRes);
            return BitConverter.ToInt32(cryptoRes, 0);
        }

        public int randomNumber(ref Random randGen, int min, int max, int divisor = 1)
        {
            int num = randGen.Next(min, max + 1);

            while(num % divisor != 0)
            {
                num = randGen.Next(min, max + 1);
            }

            return num;
        }
        
    }
}
