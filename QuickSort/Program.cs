using System;
using System.Linq;

namespace QuickSort
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] input = {7, 2, 6, 3, 5, 4, 1 };
            quickSort(input, 0, input.Length - 1);
            NewMethod(input);
        }

        private static string NewMethod(int[] input)
        {
            string res = string.Empty;

            foreach (int val in input)
            {
                res = res + val + " ";
            }
            Console.WriteLine(res);
            return res;
        }

        private static void quickSort(int[] ar, int st, int ed)
        {
            if (st < ed)
            {
                int pivot = partition(ar, st, ed);
                quickSort(ar, st, pivot-1);
                quickSort(ar, pivot + 1, ed);
            }
        }

        private static int partition(int[] ar, int st, int ed)
        {
            int i = st - 1;
            int piv = ar[(st + ed)/2];
            for(int j = st; j<ed;j++)
            {
                if(ar[j]<=piv)
                {
                    i++;
                    swap(ar,i, j);
                }
            }

                swap(ar, i + 1, ed);

            return i + 1;
        }

        private static void swap(int[] ar, int v1, int v2)
        {
            int temp = ar[v1];
            ar[v1] = ar[v2];
            ar[v2] = temp;
        }
    }
}
