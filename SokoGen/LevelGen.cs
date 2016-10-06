using System;
using System.IO;
using System.Linq;
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

        public Level(Level level)
        {
            grid = level.grid.Select(x => x.ToList()).ToList(); //Stack Overflow said so
            solution = level.solution;
            difficulty = level.difficulty;
            generationTime = level.generationTime;
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

        struct coordinate
        {
            public int column, row;

            public coordinate(int column, int row)
            {
                this.column = column;
                this.row = row;
            }
        }

        char WALL = '#';
        char FLOOR = ' ';
        char GOAL = '.';
        char BOX = '$';
        char BOXONGOAL = '*';
        char PLAYER = '@';
        char PONGOAL = '+';
        char DEADFIELD = 'x';
        char PATTERN_EDGE = '-';

        public int noOfBoxes { get; set; }
        public int noOfLevels { get; set; }
        public int roomHeight { get; set; }
        public int roomWidth { get; set; }
        public int difficulty { get; set; }
        public float timeLimit { get; set; }
        public int genSeed { get; set; }

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

        public List<Level> startGeneration()
        {
            startTime = DateTime.Now;
            randGen = new Random(genSeed);
            List<Level> levelSet = new List<Level>();

            int levels;
            if(noOfLevels == 0) { levels = randomNumber(1, 20); } else { levels = noOfLevels; }

            for (int i = 0; i < levels; i++)
            {
                Level level = generateLevel(noOfBoxes, roomHeight, roomWidth, difficulty, i, levels);
                levelSet.Add(level);

                if (worker.CancellationPending)
                {
                    timeoutClock.Stop();
                    worker.ReportProgress(100, "Cancelled: Generated " + i + " Levels");
                    return levelSet;
                }
            }

            worker.ReportProgress(100, "Generated " + levels + " Levels");

            return levelSet;
        }

        public Level generateLevel(int noOfBoxes, int roomHeight, int roomWidth, int difficulty, int levelNum, int totalLevels)
        {
            bool generationSuccessful = false;
            Level newLevel = new Level();
            float percentage;
            int indProcesses = 5;
            int totalProcesses = totalLevels * (indProcesses + 1);
            int numBoxes = 0, roomH = 0, roomW = 0, diff = 0;

            while (!generationSuccessful)
            {
                newLevel = new Level();

                calculateProperties(ref numBoxes, ref diff, ref roomH, ref roomW);

                percentage = (((levelNum * indProcesses)) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Init Level " + levelNum);
                
                initLevel(ref newLevel, roomH, roomW);

                percentage = (((levelNum * indProcesses) + 1) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Placing Patterns in Level " + levelNum);

                placePatterns(ref newLevel, roomH, roomW);

                percentage = (((levelNum * indProcesses) + 2) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Checking Connectivity in Level " + levelNum);

                generationSuccessful = checkConnectivity(ref newLevel, roomH, roomW, numBoxes);

                percentage = (((levelNum * indProcesses) + 3) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Placing Goals and Boxes in Level " + levelNum);

                if (generationSuccessful) generationSuccessful = placeGoalsAndBoxes(ref newLevel, roomH, roomW, numBoxes);

                percentage = (((levelNum * indProcesses) + 4) * 100) / totalProcesses;
                worker.ReportProgress((int)percentage, "Placing Player in Level " + levelNum);

                if (generationSuccessful) generationSuccessful = placePlayer(ref newLevel, roomH, roomW);
            }

            percentage = (((levelNum * indProcesses) + 5) * 100) / totalProcesses;
            worker.ReportProgress((int)percentage, "Level " + levelNum + " Generated");

            return newLevel;
        }

        public void calculateProperties(ref int numBoxes, ref int diff, ref int roomH, ref int roomW)
        {
            if (noOfBoxes == 0) { numBoxes = randomNumber(3, 6); }
            if (roomHeight == 0) { roomH = randomNumber(3, 15, 3); }
            if (difficulty == 0) { diff = randomNumber(1, 5); }
            if (roomWidth == 0)
            {
                if (roomH == 3) { roomW = randomNumber(6, 15, 3); }
                else { roomW = randomNumber(3, 15, 3); }
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

                            int rand = randomNumber(0, patterns.Count - 1);
                            Level chosenPattern = new Level(patterns[rand]);
                            chosenPattern = rotatePattern(chosenPattern, randomNumber(0, 3));

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

        public Level rotatePattern(Level pattern, int rotation)
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

            return tempPattern;
        }

        public bool checkConnectivity(ref Level level, int roomHeight, int roomWidth, int numBoxes)
        {
            List<List<int>> tempGrid = new List<List<int>>();
            bool floorFound = false;
            int wallCount = 0;
            int floorCount = 0;

            for(int column = 0; column < roomHeight + 2; column++)
            {
                List<int> tempRow = new List<int>();

                for (int row = 0; row < roomWidth + 2; row++)
                {
                    if (level.grid[column][row] == FLOOR)
                    {
                        tempRow.Add(0);
                    }
                    else
                    {
                        tempRow.Add(1);
                    }
                }
                tempGrid.Add(tempRow);
            }

            for(int column = 0; column < roomHeight + 2; column++)
            {
                for(int row = 0; row < roomWidth + 2; row++)
                {
                    if (tempGrid[column][row] == 0 && floorFound == false)
                    {
                        floorFound = true;
                        floodFill(ref tempGrid, column, row, roomWidth + 2, roomHeight + 2);
                    }
                }
            }

            for(int column = 0; column < roomHeight + 2; column++)
            {
                for(int row = 0; row < roomWidth + 2; row++)
                {
                    if (tempGrid[column][row] == 0) { return false; }
                    else if (tempGrid[column][row] == 1)
                    {
                        wallCount++;
                    }
                    else if (tempGrid[column][row] == 2)
                    {
                        floorCount++;
                    }

                    if(wallCount == tempGrid.Count * tempGrid[column].Count()){ return false; }
                }
            }
            if(floorCount <= numBoxes + numBoxes + 1 + 5)
            {
                return false;
            }

            return true;
        }

        public void floodFill(ref List<List<int>> grid, int column, int row, int roomWidth, int roomHeight)
        {
            coordinate coord = new coordinate(column, row);

            Queue<coordinate> gridQueue = new Queue<coordinate>();

            gridQueue.Enqueue(coord);

            while(gridQueue.Count > 0)
            {
                coordinate node = gridQueue.Dequeue();

                if(grid[node.column][node.row] == 0)
                {
                    grid[node.column][node.row] = 2;
                    if (node.row > 0) if (grid[node.column][node.row-1] == 0) { gridQueue.Enqueue(new coordinate(node.column, node.row - 1)); }
                    if (node.row < roomWidth) if (grid[node.column][node.row + 1] == 0) { gridQueue.Enqueue(new coordinate(node.column, node.row + 1)); }
                    if (node.column > 0) if (grid[node.column-1][node.row] == 0) { gridQueue.Enqueue(new coordinate(node.column - 1, node.row)); }
                    if (node.column < roomHeight) if (grid[node.column+1][node.row] == 0) { gridQueue.Enqueue(new coordinate(node.column + 1, node.row)); }
                }
            }
        }

        public bool placeGoalsAndBoxes(ref Level level, int roomHeight, int roomWidth, int numBoxes)
        {
            bool goalsPlaced = false, boxesPlaced = false;
            int goalCount = 0, boxCount = 0;
            int xCoord = 0, yCoord = 0;
            Level deadFields = new Level();

            while (!goalsPlaced)
            {
                xCoord = randomNumber(1, roomWidth);
                yCoord = randomNumber(1, roomHeight);

                if(level.grid[yCoord][xCoord] == FLOOR)
                {
                    level.grid[yCoord][xCoord] = GOAL;
                    goalCount++;
                }

                if(goalCount == numBoxes)
                {
                    goalsPlaced = true;
                }
            }

            deadFields = calcDeadFields(level);

            while (!boxesPlaced)
            {
                xCoord = randomNumber(1, roomWidth);
                yCoord = randomNumber(1, roomHeight);

                if(deadFields.grid[yCoord][xCoord] == FLOOR)
                {
                    level.grid[yCoord][xCoord] = BOX;
                    deadFields.grid[yCoord][xCoord] = BOX;
                    boxCount++;
                }
                else if(level.grid[yCoord][xCoord] == GOAL)
                {
                    if(neighbourCount(level, yCoord, xCoord) < 2 && boxCount < numBoxes - 1)
                    {
                        level.grid[yCoord][xCoord] = BOXONGOAL;
                        boxCount++;
                    }
                }

                if(boxCount == numBoxes)
                {
                    boxesPlaced = true;
                }
            }

            if(boxesPlaced && goalsPlaced)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int neighbourCount(Level level, int yCoord, int xCoord)
        {
            int neighbourWalls = 0;

            if(level.grid[yCoord - 1][xCoord] == WALL)
            {
                neighbourWalls++;
            }
            if (level.grid[yCoord + 1][xCoord] == WALL)
            {
                neighbourWalls++;
            }
            if (level.grid[yCoord][xCoord - 1] == WALL)
            {
                neighbourWalls++;
            }
            if (level.grid[yCoord][xCoord + 1] == WALL)
            {
                neighbourWalls++;
            }

            return neighbourWalls;
        }

        public Level calcDeadFields(Level level)
        {
            Level deadFields = new Level(level);

            for(int y = 0; y < deadFields.grid.Count(); y++)
            {
                for(int x = 0; x < deadFields.grid[y].Count(); x++)
                {

                    if(deadFields.grid[y][x] == FLOOR && neighbourCount(deadFields, y, x) > 1)
                    {
                        deadFields.grid[y][x] = DEADFIELD;
                    }

                }
            }

            return deadFields;
        }

        public bool placePlayer(ref Level level, int roomHeight, int roomWidth)
        {
            bool playerPlaced = false;
            int xCoord, yCoord;

            while (!playerPlaced)
            {
                xCoord = randomNumber(1, roomWidth);
                yCoord = randomNumber(1, roomHeight);

                if (level.grid[yCoord][xCoord] == FLOOR || level.grid[yCoord][xCoord] == GOAL)
                {
                    level.grid[yCoord][xCoord] = PLAYER;
                    playerPlaced = true;
                }
            }

            return playerPlaced;
        }

        public int generateSeed()
        {
            byte[] cryptoRes = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(cryptoRes);
            return BitConverter.ToInt32(cryptoRes, 0);
        }

        public int randomNumber(int min, int max, int divisor = 1)
        {
            int num = randGen.Next(min, max + 1);

            while(num % divisor != 0)
            {
                num = randGen.Next(min, max + 1);
            }

            return num;
        }

        public void printLevel(Level level, int levelNum)
        {

            Console.WriteLine("Printing Level " + levelNum);

            for(int y = 0; y < level.grid.Count; y++)
            {
                for(int x = 0; x < level.grid[y].Count; x++)
                {
                    char c = level.grid[y][x];
                    Console.Write(c);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
        
    }
}
