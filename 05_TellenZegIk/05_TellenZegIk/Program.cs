using System;

namespace _05_TellenZegIk
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(TellenZegIk(input));
        }

        static int TellenZegIk(string s)
        {
            if (s.Length > 1)
            {
                string s1 = (Convert.ToInt32(s[0].ToString()) + Convert.ToInt32(s[1].ToString())).ToString();

                if (s.Length > 2)
                {
                    s = s1 + s.Substring(2);
                    return TellenZegIk(s);
                }
                else
                {
                    if (s1.Length > 1)
                    {
                        return TellenZegIk(s1);
                    }
                    else
                    {
                        return Convert.ToInt32(s1);
                    }
                }
            }
            else
            {
                return Convert.ToInt32(s);
            }
        }
    }
}
