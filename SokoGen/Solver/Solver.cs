﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using SokoGen;

namespace SokoSolver
{
    public class Solver
    {
        private HashSet<Coordinate> walls;
        private HashSet<Coordinate> goals;
        private HashSet<Coordinate> boxes;

        public List<List<char>> grid;

        private Coordinate player;
        private Problem prob;
        private Heuristics h;

        private int row;
        private int col;

        char WALL = '#';
        char FLOOR = ' ';
        char GOAL = '.';
        char BOX = '$';
        char BOXONGOAL = '*';
        char PLAYER = '@';
        char PONGOAL = '+';
        char DEADFIELD = 'x';

        public Solver()
        {
            walls = new HashSet<Coordinate>();
            goals = new HashSet<Coordinate>();
            boxes = new HashSet<Coordinate>();
            //grid = new List<List<char>>();
        }

        public void loadLevel(Level level)
        {
            walls = new HashSet<Coordinate>();
            goals = new HashSet<Coordinate>();
            boxes = new HashSet<Coordinate>();

            for (int y = 0; y < level.grid.Count(); y++)
            {
                for(int x = 0; x < level.grid[y].Count(); x++)
                {
                    char c = level.grid[y][x];

                    if(c == WALL)
                    {
                        walls.Add(new Coordinate(y, x));
                    }

                    if (c == PLAYER || c == PONGOAL)
                    {
                        player = new Coordinate(y, x);
                    }
                    if (c == GOAL || c == PONGOAL || c == BOXONGOAL)
                    {
                        goals.Add(new Coordinate(y, x));
                    }
                    if (c == BOX || c == BOXONGOAL)
                    {
                        boxes.Add(new Coordinate(y, x));
                    }
                }
            }

            prob = new Problem(walls, new State(boxes, player), goals);
            h = new Heuristics(goals, 'x');
        }

        public bool loadLevel(string filename)
        {
            bool loaded = File.Exists(filename);
            if (loaded)
            {
                Level newLevel = new Level();
                string[] lines = File.ReadAllLines(filename);

                for(int i = 0; i < lines.Length; i++)
                {
                    if (!char.IsDigit(lines[i][0]))
                    {
                        List<char> tempRow = new List<char>();
                        for (int j = 0; j < lines[i].Length; j++)
                        {
                            tempRow.Add(lines[i][j]);
                        }
                        newLevel.grid.Add(tempRow);
                    }           
                }

                loadLevel(newLevel);
                return loaded;
            }
            else
            {
                return false;
            }
        }

        public bool solve(ref string solution, int timelimit)
        {
            Search s = new Search(h);
            string result = s.GreedySearch(prob, timelimit);
            if (result != "Failed to Solve Puzzle")
            {
                solution = result;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Level findStaticDeadlocks(Level level)
        {
            loadLevel(level);
            player = new Coordinate(0, 0);
            prob.initialState.player = player;
            State state = new State(goals, player);
            Search s = new Search(h);
            List<Coordinate> visited = s.findDeadlocks(prob);

            Level newLevel = new Level(level);

            for(int y = 0; y < newLevel.grid.Count; y++)
            {
                for(int x = 0; x < newLevel.grid[y].Count; x++)
                {
                    if (!visited.Contains(new Coordinate(y, x)) && newLevel.grid[y][x] != WALL)
                    {
                        newLevel.grid[y][x] = DEADFIELD;
                    }
                }
            }

            return newLevel;
        }
    }
}
