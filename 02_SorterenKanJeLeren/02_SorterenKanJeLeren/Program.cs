using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SorterenKanJeLeren
{

    //https://www.informit.com/articles/article.aspx?p=2180073&seqNum=3


    public class Program
    {
        private static int radix = 256;
        private static int M = 15;   // cutoff for small subarrays
        private static String[] auxArray; // auxiliary array for distribution

        public static void Main(string[] args)
        {
            string[] input = "take lead lay issue current report seem give card door consider likely film hot address kill list assume image determine including appear meet movie entire place agreement close kitchen break draw more my head player face participant century already western economic ground kind pressure fail same drop executive problem I office national goal attack ten establish mission for item thank total have know baby catch shoot should tough season business send own company not positive between per morning work popular minute indicate allow without sexual tonight economy new process back outside wide degree effort some even course those whom system".ToLower().Split(' ');

            Sort(input);

            foreach(String s in input)
            {
                Console.WriteLine(s);
            }
        }
       
        private static int charAt(String s, int index)
        {
            if (index < s.Length)
            {
                return s[index];
            }
            else
            {
                return -1;
            }
        }

        public static void Sort(String[] inputArray)
        {
            auxArray = new String[inputArray.Length];
            Sort(inputArray, 0, inputArray.Length - 1, 0);
        }

        private static void Sort(String[] inputArray, int low, int high, int index)
        {
            // Sort from inputArray[low] to inputArray[high], starting at the index'th character
            if (high <= low + M)
            {
                insertionSort(inputArray, low, high, index);
                return;
            }

            int[] count = new int[radix + 2];        
            
            // Compute frequency counts

            for (int i = low; i <= high; i++)
            {
                count[charAt(inputArray[i], index) + 2]++;
            }

            // Transform counts to indices
            for (int r = 0; r < radix + 1; r++)
            {   
                count[r + 1] += count[r];
            }

            // Distribute
            for (int i = low; i <= high; i++)
            {   
                auxArray[count[charAt(inputArray[i], index) + 1]++] = inputArray[i];
            }

            // Copy back
            for (int i = low; i <= high; i++)
            {
                inputArray[i] = auxArray[i - low];
            }

            // Recursively sort for each character value
            for (int r = 0; r < radix; r++)
            {
                Sort(inputArray, low + count[r], low + count[r + 1] - 1, index + 1);
            }
        }

        public static void insertionSort(String[] inputArray, int low, int high, int index)
        {  
            for (int i = low; i <= high; i++)
                for (int j = i; j > low && less(inputArray[j], inputArray[j - 1], index); j--)
                    exch(inputArray, j, j - 1);
        }
        private static bool less(String v, String w, int d)
        {
            return v.Substring(d).CompareTo(w.Substring(d)) < 0;
        }

        private static void exch(Object[] o, int i, int j)
        {
            Object s = o[i];
            o[i] = o[j];
            o[j] = s;
        }
    }
}
