using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06_TicTacToe
{
    public class KNNAI : Player
    {
        Dictionary<double[], int> trainingset = new Dictionary<double[], int>();
        public KNNAI(string symbol) : base("KNN-AI", symbol)
        {
            StreamReader sr = new StreamReader("ttt.dat");
            string[] boards = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < 6551; i++)
            {
                int bestMove = Convert.ToInt32(boards[i].Last<char>().ToString()) + 1;
                double[] board = Array.ConvertAll(boards[i].Remove(boards[i].Length - 2, 2).Split(), Double.Parse);

                trainingset.Add(board, bestMove);
            }
        }

        private int Classify(double[] test)
        {
            double[] distances = new double[trainingset.Count];

            for(int i = 0; i < trainingset.Count; i++)
            {
                distances[i] = EuclidianDistance(test, trainingset.ElementAt(i).Key);
            }

            double min = distances.Min();
            int index = Array.IndexOf(distances, min);
            return trainingset.ElementAt(index).Value;
        }

        private static double EuclidianDistance(double[] sampleOne, double[] sampleTwo)
        {
            double d = 0;
            for(int i = 0; i < sampleOne.Length; i++)
            {
                d += Math.Pow(sampleOne[i] - sampleTwo[i], 2);
            }
            return Math.Sqrt(d);
        }

        public int PlayMove(Board board)
        {
            return Classify(board.getBoardKey());
        }
    }
}
