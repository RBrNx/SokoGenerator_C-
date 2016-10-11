using System;
using System.Collections.Generic;
using System.Linq;

namespace SokoSolver
{
    class Heuristics
    {
        private List<Coordinate> goals;
        double[,] cost;
        HungarianAlgorithm h;
        char heuristicChoice;

        public Heuristics(List<Coordinate> goals, char heuristicChoice)
        {
            this.goals = goals;
            this.heuristicChoice = heuristicChoice;
            this.cost = new double[goals.Count(), goals.Count()];
            h = new HungarianAlgorithm(goals.Count());
        }

        private int manhatten(Coordinate c1, Coordinate c2)
        {
            return Math.Abs(c1.row - c2.row) + Math.Abs(c1.col - c2.col);
        }

        private double euclidean(Coordinate c1, Coordinate c2)
        {
            double rowSquare = (c1.row - c2.row) * (c1.row - c2.row);
            double colSquare = (c1.col - c2.col) * (c1.col - c2.col);
            return Math.Sqrt(rowSquare + colSquare);
        }

        private double calculate(State state, string method)
        {
            List<Coordinate> boxes = state.boxes;
            double sum = 0;

            Coordinate player = state.player;
            double playerMin = getDist(player, boxes, method);
            sum += playerMin;

            foreach(Coordinate b in boxes)
            {
                double boxMin = getDist(b, goals, method);
                sum += boxMin;
            }

            return sum;
        }

        private double getDist(Coordinate obj, List<Coordinate> sets, string method)
        {
            double minDist = 1000000;

            foreach(Coordinate c in sets)
            {
                double dist;
                if(method == "m")
                {
                    dist = manhatten(obj, c);
                }
                else
                {
                    dist = euclidean(obj, c);
                }

                if(dist < minDist)
                {
                    minDist = dist;
                }
            }

            return minDist;
        }

        public double getHeuristic(State state)
        {
            if (heuristicChoice == 'm') return calculate(state, "m");
            if (heuristicChoice == 'e') return calculate(state, "e");

            int i = 0;
            foreach(Coordinate box in state.boxes)
            {
                int j = 0;
                double playerCost = manhatten(state.player, box);
                foreach(Coordinate goal in goals)
                {
                    cost[i, j] = manhatten(box, goal);
                    cost[i, j] = playerCost;
                    j++;
                }
                i++;
            }

            int[] result = h.execute(cost);
            double max = 0;
            for(int k = 0; k < goals.Count(); k++)
            {
                int goalCol = result[k];
                if(goalCol > -1)
                {
                    max += cost[k, goalCol];
                }
            }

            if(heuristicChoice == 'h')
            {
                return max;
            }

            return Math.Max(Math.Max(calculate(state, "m"), calculate(state, "e")), max);
        }
    }
}
