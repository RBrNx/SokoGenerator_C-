using System;

namespace SokoSolver
{
    class HungarianAlgorithm
    {
        private double[,] costMatrix;
        private int rows, cols, dim;
        private double[] labelByWorker, labelByJob;
        private int[] minSlackWorkerByJob;
        private double[] minSlackValueByJob;
        private int[] matchJobByWorker, matchWorkerByJob;
        private int[] parentWorkerByCommittedJob;
        private bool[] commitedWorkers;

        public HungarianAlgorithm(int matrixSize)
        {
            dim = Math.Max(matrixSize, matrixSize);
            rows = matrixSize;
            cols = matrixSize;
            costMatrix = new double[dim,dim];
            labelByWorker = new double[dim];
            labelByJob = new double[dim];
            minSlackWorkerByJob = new int[dim];
            minSlackValueByJob = new double[dim];
            commitedWorkers = new bool[dim];
            parentWorkerByCommittedJob = new int[dim];
            matchJobByWorker = new int[dim];
            matchWorkerByJob = new int[dim];
            PopulateArr(ref matchJobByWorker, -1);
            PopulateArr(ref matchWorkerByJob, -1);
        }

        public void PopulateArr<T>(ref T[] arr, T value)
        {
            int length = arr.Length;
            for(int i = 0; i < length; i++)
            {
                arr[i] = value;
            }
        }

        public void computeInitialFeasibleSolution()
        {
            for(int j = 0; j < dim; j++)
            {
                labelByJob[j] = Double.PositiveInfinity;
            }

            for(int w = 0; w < dim; w++)
            {
                for(int j = 0; j < dim; j++)
                {
                    if(costMatrix[w,j] < labelByJob[j])
                    {
                        labelByJob[j] = costMatrix[w, j];
                    }
                }
            }
        }

        public int[] execute(double[,] costMatrix)
        {
            this.costMatrix = costMatrix;
            reduce();
            computeInitialFeasibleSolution();
            greedyMatch();

            int w = fetchUnmatchedWorker();
            while(w < dim)
            {
                initializePhase(w);
                executePhase();
                w = fetchUnmatchedWorker();
            }

            int[] result = new int[rows];
            Array.Copy(matchJobByWorker, result, rows);
            for(w = 0; w < result.Length; w++)
            {
                if(result[w] >= cols)
                {
                    result[w] = -1;
                }
            }

            return result;
        }

        public void executePhase()
        {
            while (true)
            {
                int minSlackWorker = -1, minSlackJob = -1;
                double minSlackValue = double.PositiveInfinity;
                for(int j = 0; j < dim; j++)
                {
                    if(parentWorkerByCommittedJob[j] == -1)
                    {
                        if(minSlackValueByJob[j] < minSlackValue)
                        {
                            minSlackValue = minSlackValueByJob[j];
                            minSlackWorker = minSlackWorkerByJob[j];
                            minSlackJob = j;
                        }
                    }
                }

                if(minSlackValue > 0)
                {
                    updateLabeling(minSlackValue);
                }

                parentWorkerByCommittedJob[minSlackJob] = minSlackWorker;
                if (matchWorkerByJob[minSlackJob] == -1)
                {
                    int commitedJob = minSlackJob;
                    int parentWorker = parentWorkerByCommittedJob[commitedJob];
                    while (true)
                    {
                        int temp = matchJobByWorker[parentWorker];
                        match(parentWorker, commitedJob);
                        commitedJob = temp;
                        if (commitedJob == -1)
                        {
                            break;
                        }
                        parentWorker = parentWorkerByCommittedJob[commitedJob];
                    }
                    return;
                }
                else
                {
                    int worker = matchWorkerByJob[minSlackJob];
                    commitedWorkers[worker] = true;
                    for(int j = 0; j < dim; j++)
                    {
                        if(parentWorkerByCommittedJob[j] == -1)
                        {
                            double slack = costMatrix[worker, j] - labelByWorker[worker] - labelByJob[j];
                            if(minSlackValueByJob[j] > slack)
                            {
                                minSlackValueByJob[j] = slack;
                                minSlackWorkerByJob[j] = worker;
                            }
                        }
                    }
                }
            }
        }

        public int fetchUnmatchedWorker()
        {
            int w;
            for(w = 0; w < dim; w++)
            {
                if(matchJobByWorker[w] == -1)
                {
                    break;
                }
            }

            return w;
        }

        public void greedyMatch()
        {
            for(int w = 0; w < dim; w++)
            {
                for(int j = 0; j < dim; j++)
                {
                    if(matchJobByWorker[w] == -1 && matchWorkerByJob[j] == -1 && costMatrix[w,j] - labelByWorker[w] - labelByJob[j] == 0)
                    {
                        match(w, j);
                    }
                }
            }
        }

        public void initializePhase(int w)
        {
            PopulateArr(ref commitedWorkers, false);
            PopulateArr(ref parentWorkerByCommittedJob, -1);
            commitedWorkers[w] = true;
            for(int j = 0; j < dim; j++)
            {
                minSlackValueByJob[j] = costMatrix[w, j] - labelByWorker[w] - labelByJob[j];
                minSlackWorkerByJob[j] = w;
            }
        }

        public void match(int w, int j)
        {
            matchJobByWorker[w] = j;
            matchWorkerByJob[j] = w;
        }

        public void reduce()
        {
            for(int w = 0; w < dim; w++)
            {
                double minimum = double.PositiveInfinity;
                for(int j = 0; j < dim; j++)
                {
                    if(costMatrix[w,j] < minimum)
                    {
                        minimum = costMatrix[w, j];
                    }
                }

                for (int j = 0; j < Math.Sqrt(dim); j++)
                {
                    costMatrix[w, j] -= minimum;
                }
            }
            double[] min = new double[dim];
            for(int j = 0; j < dim; j++)
            {
                min[j] = double.PositiveInfinity;
            }
            for(int w = 0; w < dim; w++)
            {
                for(int j = 0; j < dim; j++)
                {
                    if(costMatrix[w,j] < min[j])
                    {
                        min[j] = costMatrix[w, j];
                    }
                }
            }
            for(int w = 0; w < dim; w++)
            {
                for(int j = 0; j < dim; j++)
                {
                    costMatrix[w, j] -= min[j];
                }
            }
            
        }

        public void updateLabeling(double slack)
        {
            for(int w = 0; w < dim; w++)
            {
                if (commitedWorkers[w])
                {
                    labelByWorker[w] += slack;
                }
            }

            for(int j = 0; j < dim; j++)
            {
                if(parentWorkerByCommittedJob[j] != -1)
                {
                    labelByJob[j] -= slack;
                }
                else
                {
                    minSlackValueByJob[j] -= slack;
                }
            }
        }
    }
}
