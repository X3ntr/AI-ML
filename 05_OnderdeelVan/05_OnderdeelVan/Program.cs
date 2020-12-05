using System;

namespace _05_OnderdeelVan
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string s = Console.ReadLine();

            OnderdeelVan(input, s);
        }

        static void OnderdeelVan(string lookup, string s, int sIndex = 0, int cIndex = 0)
        {
            if(lookup != s)
            {
                //check if lookup[0] in s
                //if no -> no match
                //if yes -> set sIndex
                //jump lookup[1]

                if (cIndex < lookup.Length)
                {
                    int r = hasChar(lookup[cIndex], s, sIndex);
                    if (r >= 0)
                    {
                        OnderdeelVan(lookup, s, r, cIndex + 1);
                    }
                    else
                    {
                        Console.WriteLine(String.Format("false --> {0} is geen onderdeel van '{1}'", lookup, s));
                    }
                }
                else
                {
                    //do stuff
                    Console.WriteLine(String.Format("true --> {0} is onderdeel van '{1}'", lookup, s));
                }
            }
            else
            {
                Console.WriteLine(String.Format("true --> {0} is onderdeel van '{1}'", lookup, s));
            }
        }

        private static int hasChar(char c, string s, int sIndex = 0, int cIndex = 0)
        {
            if (sIndex + cIndex < s.Length)
            {
                if (c == s[sIndex + cIndex])
                {
                    return sIndex + cIndex;
                }
                else
                {
                    return hasChar(c, s, sIndex, cIndex + 1);
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
