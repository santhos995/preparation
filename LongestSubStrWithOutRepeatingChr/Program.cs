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
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;

            int wStart = 0, max = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int wEnd = 0; wEnd < s.Length; wEnd++)
            {
                if (map.ContainsKey(s[wEnd]))
                {
                    wStart = Math.Max(wStart, map[s[wEnd]] + 1);//here we are identifying the right most index, windowStart can't go back/left.. 
                }
                max = Math.Max(max, wEnd - wStart + 1);
                map[s[wEnd]] = wEnd;
            }
            return max;
        }
    }
}
