using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ColorByNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToChar(input[j]);
                }
            }

            int start = Convert.ToInt32(Console.ReadLine());

            char value = matrix[getPosition(start, n)[0], getPosition(start, n)[1]];
            ColorByNumber(matrix, start, value, n);

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        public static void ColorByNumber(char[,] matrix, int start, char value, int n)
        {           
            foreach(int position in getAdjacent(start, n))
            {
                if(matrix[getPosition(position, n)[0], getPosition(position, n)[1]] == value)
                {
                    matrix[getPosition(position, n)[0], getPosition(position, n)[1]] = 'X';
                    ColorByNumber(matrix, position, value, n);
                }
            }
        }

        public static List<int> getAdjacent(int start, int n)
        {
            List<int> adjacent = new List<int>();
            //top
            if (start >= n)
            {
                adjacent.Add(start - n);
            }
            //left
            if (start % n != 0)
            {
                adjacent.Add(start - 1);
            }
            //bottom
            if (start < (n * n) - n)
            {
                adjacent.Add(start + n);
            }
            //right
            if (start % n != n -1)
            {
                adjacent.Add(start + 1);
            }

            return adjacent;
        }

        public static int[] getPosition(int start, int n)
        {
            return new int[] { start / n, start % n };
        }
    }
}
