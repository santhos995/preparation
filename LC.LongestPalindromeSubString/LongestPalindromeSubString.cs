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
            public string LongestPalindrome(string s)
            {
                string lPalindrome = s.ElementAt(0).ToString();
                for (int i = 0; i < s.Length; i++)
                {
                    // there are two possibilities to find palindrome from current position, only if ith and (i+1)th elements are same
                    //Possibility one -  mid = i, possibility two - mid = i, i+1  
                    // consider abba, here if i = 1 as well as i = 1,2 are two possibilities
                    string s1 = getPalindrome(s, i - 1, i + 1);

                    if (i + 1 < s.Length && (s.ElementAt(i) == s.ElementAt(i + 1)))
                    {
                        string s2 = getPalindrome(s, i - 1, i + 2);

                        string temp = (s1.Length < s2.Length) ? s2 : s1;
                        lPalindrome = (lPalindrome.Length < temp.Length) ? temp : lPalindrome;
                    }
                    else
                        lPalindrome = (lPalindrome.Length < s1.Length) ? s1 : lPalindrome;

                }
                return lPalindrome;
            }

            private string getPalindrome(string s, int left, int right)
            {
                if (left < 0 || right >= s.Length || s.ElementAt(left) != s.ElementAt(right))
                    return s.Substring(left + 1, (right - (left+1)));
                else
                {
                    while (left - 1 >= 0 && right + 1 < s.Length && s.ElementAt(left - 1) == s.ElementAt(right + 1))
                    {
                        left--;
                        right++;
                    }
                    return s.Substring(left, (right - left) + 1);
                }
            }

            private bool isPalindrome(string s, int left, int right)
            {
                return left > 0 && right < s.Length && s.ElementAt(left) == s.ElementAt(right);
            }
        }
    }
}
