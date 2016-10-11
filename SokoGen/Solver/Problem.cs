using System.Collections.Generic;

namespace SokoSolver
{
    class Problem
    {
        public State initialState;
        public HashSet<Coordinate> walls;
        public List<Coordinate> goals;
        public Dictionary<Coordinate, Coordinate> blocked;

        public Problem(HashSet<Coordinate> walls, State initialState, List<Coordinate> goals)
        {
            this.initialState = initialState;
            this.walls = walls;
            this.goals = goals;
        }

        public bool goalTest(State state)
        {
            foreach(Coordinate box in state.boxes)
            {
                if (!goals.Contains(box))
                {
                    return false;
                }
            }
            return true;
        }

        public bool deadlockTest(State state)
        {
            foreach(Coordinate box in state.boxes)
            {
                int row = box.row;
                int col = box.col;

                if(!setContains(goals, row, col))
                {
                    if (setContains(walls, row - 1, col) && setContains(walls, row, col - 1)) return true; //Top and Left
                    if (setContains(walls, row - 1, col) && setContains(walls, row, col + 1)) return true; //Top and Right
                    if (setContains(walls, row + 1, col) && setContains(walls, row, col - 1)) return true; //Bottom and Left
                    if (setContains(walls, row + 1, col) && setContains(walls, row, col + 1)) return true; //Bottom and Right

                    if(setContains(walls, row - 1, col - 1) && setContains(walls, row - 1, col) && setContains(walls, row - 1, col + 1) && setContains(walls, row, col - 2)
                        && setContains(walls, row, col + 2) && !setContains(goals, row, col - 1) && !setContains(goals, row, col + 1)){ return true; } //Top and Sides

                    if (setContains(walls, row + 1, col - 1) && setContains(walls, row + 1, col) && setContains(walls, row + 1, col + 1) && setContains(walls, row, col - 2)
                        && setContains(walls, row, col + 2) && !setContains(goals, row, col - 1) && !setContains(goals, row, col + 1)) { return true; } //Bottom and Sides

                    if (setContains(walls, row - 1, col - 1) && setContains(walls, row, col - 1) && setContains(walls, row + 1, col - 1) && setContains(walls, row - 2, col)
                        && setContains(walls, row + 2, col) && !setContains(goals, row - 1, col) && !setContains(goals, row + 1, col)) { return true; } //Left and Vertical

                    if (setContains(walls, row - 1, col + 1) && setContains(walls, row, col + 1) && setContains(walls, row + 1, col + 1) && setContains(walls, row - 2, col)
                        && setContains(walls, row + 2, col) && !setContains(goals, row - 1, col) && !setContains(goals, row + 1, col)) { return true; } //Right and Horizontal
                }
            }
            return false;
        }

        public List<string> actions(State state)
        {
            List<string> actionList = new List<string>();
            int row = state.player.row;
            int col = state.player.col;
            List<Coordinate> boxes = new List<Coordinate>(state.boxes);

            //Checking if moving up, right, down, left is valid
            //For each, check if next player move is a wall
            //If next move has a box, check next box move does not overlap with wall or another box

            Coordinate newPlayer = new Coordinate(row - 1, col);
            Coordinate newBox = new Coordinate(row - 2, col);

            if (!walls.Contains(newPlayer))
            {
                /*if(!boxes.Contains(newPlayer) && !boxes.Contains(newBox) && !walls.Contains(newBox))
                {
                    actionList.Add("u");
                }*/
                if(boxes.Contains(newPlayer) && (boxes.Contains(newBox) || walls.Contains(newBox))) {;}
                else { actionList.Add("u"); }
            }

            newPlayer = new Coordinate(row, col + 1);
            newBox = new Coordinate(row, col + 2);

            if (!walls.Contains(newPlayer))
            {
                /*if (!boxes.Contains(newPlayer) && !boxes.Contains(newBox) && !walls.Contains(newBox))
                {
                    actionList.Add("r");
                }*/
                if (boxes.Contains(newPlayer) && (boxes.Contains(newBox) || walls.Contains(newBox))) {; }
                else { actionList.Add("r"); }
            }

            newPlayer = new Coordinate(row + 1, col);
            newBox = new Coordinate(row + 2, col);

            if (!walls.Contains(newPlayer))
            {
                /*if (!boxes.Contains(newPlayer) && !boxes.Contains(newBox) && !walls.Contains(newBox))
                {
                    actionList.Add("d");
                }*/
                if (boxes.Contains(newPlayer) && (boxes.Contains(newBox) || walls.Contains(newBox))) {; }
                else { actionList.Add("d"); }
            }

            newPlayer = new Coordinate(row, col - 1);
            newBox = new Coordinate(row, col - 2);

            if (!walls.Contains(newPlayer))
            {
                /*if (!boxes.Contains(newPlayer) && !boxes.Contains(newBox) && !walls.Contains(newBox))
                {
                    actionList.Add("l");
                }*/
                if (boxes.Contains(newPlayer) && (boxes.Contains(newBox) || walls.Contains(newBox))) {; }
                else { actionList.Add("l"); }
            }

            return actionList;
        }

        private bool setContains(List<Coordinate> set, int row, int col)
        {
            if(set.Contains(new Coordinate(row, col)))
            {
                return true;
            }
            return false;
        }

        private bool setContains(HashSet<Coordinate> set, int row, int col)
        {
            if (set.Contains(new Coordinate(row, col)))
            {
                return true;
            }
            return false;
        }
    }
}
