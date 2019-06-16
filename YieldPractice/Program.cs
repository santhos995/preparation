using System;
using System.Collections.Generic;

namespace YieldPractice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            foreach(int val in yieldMethod())
            {
                Console.WriteLine(val);
            }
        }

        private static IEnumerable<int> yieldMethod()
        {
            for(int i=0;i<10;i++)
            {
                yield return i;
            }
        }
    }
}
