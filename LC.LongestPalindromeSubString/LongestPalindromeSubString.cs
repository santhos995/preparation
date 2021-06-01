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
            int maxLen = 0, k = 0;
            public string LongestPalindrome(string s)
            {
               
                for (int i = 0; i < s.Length; i++)
                {
                    // there are two possibilities to find palindrome from current position, only if ith and (i+1)th elements are same
                    //Possibility one -  mid = i, possibility two - mid = i, i+1  
                    // consider abba, here if i = 1 as well as i = 1,2 are two possibilities
                    
                }
                return string.Empty;
            }

            private void chkPalindromeAndStoreMaxLen(string s, int left, int right)
            {

            }
        }
    }
}
