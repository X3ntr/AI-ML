using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02_WaagDeSprong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("english.txt");
            string input = Console.ReadLine();

            Console.WriteLine(String.Format("positie {0}", JumpSearch(text, input)));
        }

        public static int JumpSearch(String[] L, String s)
        {
            /*
            L: ordered list
            N: length of list
            s: search key
            a: previous
            b: block size
            */
            int n = L.Length;
            int a = 0;
            int b = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));

            //perform jump
            while(StringCompare(L[Math.Min(b, n) -1], s))
            {
                a = b;
                b += Convert.ToInt32(Math.Floor(Math.Sqrt(n)));
                if (a >= n) return -1;
            }

            //linear search
            while(StringCompare(L[a], s))
            {
                a++;
                if (a == Math.Min(b, n)) return -1;
            }

            if (L[a] == s) return a + 1;

            return -1;
        }

        private static bool StringCompare(String a, String b)
        {
            for(int i = 0; i < a.Length && i < b.Length; i++)
            {
                if(a[i] < b[i])
                {
                    return true;
                }
                else if(a[i] > b[i])
                {
                    return false;
                }
            }
            if (a.Length < b.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
