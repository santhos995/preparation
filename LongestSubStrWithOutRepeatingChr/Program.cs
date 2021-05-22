using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubStrWithOutRepeatingChr
{
    class Program
    {
        static void Main(string[] args)
        {
            LengthOfLongestSubstring("tmmzuxt");
        }
        static public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;

            int windowStart = 0, max = 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); //map with character index
            for (int windowEnd = 0; windowEnd < s.Length; windowEnd++)
            {
                if(map.ContainsKey(s.ElementAt(windowEnd)))
                {
                    windowStart = Math.Max(windowStart, map[s.ElementAt(windowEnd)] + 1);//max comparison is because we should not move the windowstart to backward.
                }
                map[s.ElementAt(windowEnd)] = windowEnd;
                max = Math.Max(max, (windowEnd - windowStart) + 1);
            }
            return max;
        }
    }
}
