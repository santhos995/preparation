using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubStrWithOutRepeatingChr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            int count = 0, windowEnd = 0, max = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int windowStart = 0; windowStart < s.Length; windowStart++)
            {
                if (!map.ContainsKey(s.ElementAt(windowStart)))
                {
                    map.Add(s.ElementAt(windowStart), 1);
                    count++;
                    max = Math.Max(max, count);
                }
                else
                {
                    while (windowEnd <= windowStart && s.ElementAt(windowStart) != s.ElementAt(windowEnd)) // moving the sliding window to the point where it find the non-repeating char
                    {
                        count--;
                        map.Remove(s.ElementAt(windowEnd));
                        windowEnd++;
                    }
                    if(windowEnd != windowStart)
                    {
                        windowEnd++;
                    }
                }
            }
            return max;
        }
    }
}
