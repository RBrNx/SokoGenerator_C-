using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanSolver
{
    public static class Solver
    {

        public static bool Solve(string level, ref string solution)
        {
            Global.cleanGlobal();
            Level.levelFromString(level);

            SolFunc.initArrays();
            //Console.WriteLine("Starting Solve");
            Global.solvable = true;
            Global.levelSol.length = 0;
            LevelInfo.preprocessLevel();
            Global.deadlockTable.calculateStaticDeadlocks();
            //Level.printLevel(Global.level);

            SolvingRoutine.trySolveLevel();
            if (Global.solvable)
            {
                if(!SolFunc.checkSolution(Global.levelSol, Global.level))
                {
                    Global.solvable = false;
                    return false;
                }
                solution = new string(Global.levelSol.move, 0, Global.levelSol.length);
                return true;
            }
            return false;
        }

        public static List<List<char>> findDeadfields(string level)
        {
            Global.cleanGlobal();
            Level.levelFromString(level);
            SolFunc.initArrays();
            LevelInfo.preprocessDeadfields();
            Level.printLevel(Global.level);
            return Global.level.grid;
        }

    }
}
