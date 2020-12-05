using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Dijkstra
{
    class Program
    {
        static List<int>[] labyrinth;

        static void Main(string[] args)
        {
            CreateLabyrinth();
        }

        static void CreateList(int n)
        {
            labyrinth = new List<int>[n];

            for(int i = 0; i < labyrinth.Length; i++)
            {
                labyrinth[i] = new List<int>();
            }
        }

        static void AddEdge(int node1, int node2)
        {
            labyrinth[node1].Add(node2);
            labyrinth[node2].Add(node1);
        }

        static void CreateLabyrinth()
        {
            CreateList(25);
            AddEdge(0, 1);
            AddEdge(1, 2);
            AddEdge(2, 3);
            AddEdge(3, 4);
            AddEdge(4, 9);
            AddEdge(9, 14);
            AddEdge(14, 19);
            AddEdge(19, 24);
            AddEdge(23, 24);
            AddEdge(22, 23);
            AddEdge(21, 22);
            AddEdge(20, 21);
            AddEdge(15, 20);
            AddEdge(10, 15);
            AddEdge(5, 10);
            AddEdge(0, 5);
            AddEdge(18, 19);
            AddEdge(18, 23);
            AddEdge(17, 18);
            AddEdge(17, 22);
            AddEdge(12, 17);
        }
    }
}
