using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_WeHebbenConnectie
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodes = Convert.ToInt32(Console.ReadLine());
            int connections = Convert.ToInt32(Console.ReadLine());
            List<int>[] graph = new List<int>[nodes];

            for(int i = 0; i < connections; i++)
            {                
                graph[i] = new List<int>();
            }

            for(int i = 0; i < connections; i++)
            {
                string[] connection = Console.ReadLine().Split();
                graph[Convert.ToInt32(connection[0])].Add(Convert.ToInt32(connection[1]));
                graph[Convert.ToInt32(connection[1])].Add(Convert.ToInt32(connection[0]));
            }

            isConnected(graph);
        }

        static void isConnected(List<int>[] graph, int node = 0)
        {
            bool[] visited = new bool[graph.Length];
            Queue<int> queue = new Queue<int>();

            visited[node] = true;
            queue.Enqueue(node);

            while(queue.Count != 0)
            {
                node = queue.Dequeue();

                foreach(int connection in graph[node])
                {
                    if(!visited[connection])
                    {
                        visited[connection] = true;
                        queue.Enqueue(connection);
                    }
                }
            }

            if(visited.Contains(false))
            {
                Console.WriteLine("not connected");
            }
            else
            {
                Console.WriteLine("connected");
            }
        }
    }
}
