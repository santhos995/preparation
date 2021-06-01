using System;
using System.Linq;

namespace LC.LongestPalindromeSubString
{
    class LongestPalindromeSubString
    {
        static void Main(string[] args)
        {
            var soln = new Solution();
            var answer = soln.LongestPalindrome("abbad");
            Console.WriteLine(answer);
            answer = soln.LongestPalindrome("a");
            Console.WriteLine(answer);
            answer = soln.LongestPalindrome("ac");
            Console.WriteLine(answer);
            answer = soln.LongestPalindrome("cbbd");
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        public class Solution
        {
            int st = 0, len = 0;
            public string LongestPalindrome(string s)
            {
                if (s.Length < 2)
                    return s;

                for (int i = 0; i < s.Length; i++)
                {
                    LPHelper(s, i, i);
                    if (i + 1 < s.Length && s[i] == s[i + 1])
                        LPHelper(s, i, i + 1);
                }
                return s.Substring(st, len);
            }
            void LPHelper(string s, int l, int r)
            {
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    l--;
                    r++;
                }
                //our valid stringrange is just l+1 and r-1

                if ((r - l - 1) > len)
                {
                    //Console.WriteLine($"{st} to {l+1}, {len} to {r-l-1}");
                    st = l + 1;
                    len = r - l - 1;
                }
            }
        }


    }
}
