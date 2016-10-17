using System;
using System.IO;
using System.Collections.Generic;

namespace SokoSolver
{
    class Logger
    {
        string logfilePath = "log.txt";
        TextWriter tw;

        public Logger()
        {
            if (!File.Exists(logfilePath))
            {
                //File.Create(logfilePath);
                tw = new StreamWriter(logfilePath, true);
                //tw.WriteLine("File Created.");
                tw.Close();
            }
            else
            {
                File.Delete(logfilePath);
                tw = new StreamWriter(logfilePath, true);
                //tw.WriteLine("File Created.");
                tw.Close();
            }
        }

        public Logger(string filepath) : this()
        {
            logfilePath = filepath;
        }

        public void writeToLog(string message, bool printToConsole = false, bool append = true)
        {
            tw = new StreamWriter(logfilePath, append);
            string print = "[" + DateTime.Now + "]  " + message;
            tw.WriteLine(print);
            tw.Close();

            if (printToConsole) { Console.WriteLine(print); }
        }

        public void writeToLog(Node n, string beforeMessage, string afterMessage)
        {
            tw = new StreamWriter(logfilePath, true);
            List<Coordinate> listboxes = new List<Coordinate>(n.state.boxes);
            string nodeDetails = /*"Cost - " + n.cost + "\t Move - " + n.move + */"\t PlayerPos - (" + n.state.player.col + ", " + n.state.player.row + ")";
            string boxes = "\t\t Boxes [";
            for(int i = 0; i < listboxes.Count; i++)
            {
                boxes += "(" + listboxes[i].col + ", " + listboxes[i].row + "), ";
            }
            boxes += "]";
            tw.WriteLine("[" + DateTime.Now + "]  " + beforeMessage + " :: " + nodeDetails + boxes + " :: " + afterMessage);
            //tw.WriteLine(boxes);
            tw.Close();
        }
    }
}
