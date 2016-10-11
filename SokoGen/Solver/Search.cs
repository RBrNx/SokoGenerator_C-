﻿using System;
using System.Linq;
using System.Collections.Generic;
using Priority_Queue;

namespace SokoSolver
{
    class Node : IComparable<Node>
    {
        public Node parent;
        public State state;
        public int cost;
        public string move;
        Heuristics h;

        public Node(State state, Node parent, int cost, string move, Heuristics h)
        {
            this.state = state;
            this.parent = parent;
            this.cost = cost;
            this.move = move;
            this.h = h;
        }

        public override bool Equals(object obj)
        {
            Node n = (Node)obj;
            return (this.state == n.state);
        }

        public int CompareTo(Node n)
        {
            return (int)(h.getHeuristic(this.state) - h.getHeuristic(n.state));
        }

    }

    class Search
    {
        private static Heuristics h;
        Logger logger;

        public Search(Heuristics h)
        {
            Search.h = h;
            logger = new Logger();            
        }

        public string GreedySearch(Problem p)
        {
            int totalNode = 1;
            int redundant = 1;
            Node initial = new Node(p.initialState, null, 0, "", h);
            HashSet<State> explored = new HashSet<State>();
            SimplePriorityQueue<Node> fringe = new SimplePriorityQueue<Node>();
            fringe.Enqueue(initial, 0);

            logger.writeToLog("Starting Greedy Search");
            while (fringe.Count > 0)
            {
                Node n = fringe.Dequeue();
                if (p.goalTest(n.state))
                {
                    logger.writeToLog(n, "Dequeued", "GoalState");
                    return getSolution(n);
                }

                if (!p.deadlockTest(n.state))
                {
                    logger.writeToLog(n, "Dequeued", "Exploring");
                    explored.Add(n.state);
                    List<string> actions = p.actions(n.state);
                    foreach (string action in actions)
                    {
                        Node child = getChild(p, n, action);

                        if (child != null && child.state != null)
                        {
                            totalNode++;
                            if (!explored.Contains(child.state) && !fringe.Contains(child))
                            {
                                //if (!fringe.Contains(child))
                                //{
                                    logger.writeToLog(child, "Child Node", "Added to Fringe");
                                    fringe.Enqueue(child, (float)h.getHeuristic(child.state));
                                //}
                            }
                            else
                            {
                                redundant++;
                                logger.writeToLog(child, "Child Node", "Redundant");

                                for (int i = 0; i < fringe.Count; i++)
                                {
                                    Node next = fringe.Dequeue();
                                    if (next == child)
                                    {
                                        if (child.cost < next.cost)
                                        {
                                            fringe.Enqueue(child, (float)h.getHeuristic(child.state));
                                        }
                                    }
                                    else
                                    {
                                        fringe.Enqueue(next, (float)h.getHeuristic(next.state));
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    logger.writeToLog(n, "Dequeued", "Deadlock");
                }
            }
            return getSolution(null);
        }

        public string DFSSearch(Problem p)
        {
            logger.writeToLog("Starting DFS Search");
            int totalNode = 1;
            int redundant = 1;
            Node node = new Node(p.initialState, null, 0, "", h);
            if (p.goalTest(node.state))
            {
                return getSolution(node);
            }

            HashSet<State> explored = new HashSet<State>();
            Stack<Node> fringe = new Stack<Node>();
            fringe.Push(node);

            while(fringe.Count > 0)
            {
                node = fringe.Pop();
                logger.writeToLog(node, "Dequeued", "Exploring");
                explored.Add(node.state);
                List<string> actions = p.actions(node.state);
                foreach(string action in actions)
                {
                    Node child = getChild(p, node, action);
                    if(child != null && child.state != null)
                    {
                        totalNode++;

                        if(!explored.Contains(child.state) && !fringe.Contains(child))
                        {
                            string solution = getSolution(child);
                            if (p.goalTest(child.state))
                            {
                                logger.writeToLog(child, "Solved!", "GoalState");
                                return solution;
                            }
                            if (!p.deadlockTest(child.state))
                            {
                                logger.writeToLog(child, "Child Node", "Added to Fringe");
                                fringe.Push(child);
                            }
                        }
                        else
                        {
                            logger.writeToLog(child, "Child Node", "Redundant");
                            redundant++;
                        }
                    }
                }
            }
            return getSolution(null);
        }

        private string getSolution(Node n)
        {
            string result = "";
            if(n == null)
            {
                result = "Failed to solve Puzzle";
            }
            else
            {
                while(n.parent != null)
                {
                    result = n.move + " " + result;
                    n = n.parent;
                }
            }

            return result;
        }

        private Node getChild(Problem p, Node n, string action)
        {
            HashSet<Coordinate> boxes = new HashSet<Coordinate>(n.state.boxes);
            //grid = level.grid.Select(x => x.ToList()).ToList(); //Stack Overflow said so
            //List<Coordinate> boxes = n.state.boxes;
            int row = n.state.player.row;
            int col = n.state.player.col;

            int newCost = n.cost + 1;
            Coordinate newPlayer = n.state.player;
            char choice = action[0];

            switch (choice)
            {
                case 'u':
                    newPlayer = new Coordinate(row - 1, col);

                    if (boxes.Contains(newPlayer))
                    {
                        Coordinate newBox = new Coordinate(row - 2, col);
                        boxes.Remove(newPlayer);
                        boxes.Add(newBox);
                    }
                    break;

                case 'd':
                    newPlayer = new Coordinate(row + 1, col);

                    if (boxes.Contains(newPlayer))
                    {
                        Coordinate newBox = new Coordinate(row + 2, col);
                        boxes.Remove(newPlayer);
                        boxes.Add(newBox);
                    }
                    break;

                case 'l':
                    newPlayer = new Coordinate(row, col - 1);

                    if (boxes.Contains(newPlayer))
                    {
                        Coordinate newBox = new Coordinate(row, col - 2);
                        boxes.Remove(newPlayer);
                        boxes.Add(newBox);
                    }
                    break;

                case 'r':
                    newPlayer = new Coordinate(row, col + 1);

                    if (boxes.Contains(newPlayer))
                    {
                        Coordinate newBox = new Coordinate(row, col + 1);
                        boxes.Remove(newPlayer);
                        boxes.Add(newBox);
                    }
                    break;
            }

            return new Node(new State(boxes, newPlayer), n, newCost, choice.ToString(), h);
        }
    }
}