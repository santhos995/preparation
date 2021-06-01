using System;

namespace LC.PeakElement
{
    class PeakNumber
    {
        static void Main(string[] args)
        {
            var soln = new Solution();
            var answer = soln.FindPeakElement(new int[] { 1, 2, 3, 4, 1 });
            Console.WriteLine(answer);
            answer = soln.FindPeakElement(new int[]{ 1, 2, 3, 1, 2, 1});
            Console.WriteLine(answer);
        }
        public class Solution
        {
            public int FindPeakElement(int[] nums)
            {
                if (nums.Length < 2) 
                    return nums[0];
                
                int l = 0, r = nums.Length-1;
                while(true)
                {
                    int mid = l + ((r-l) >> 1);
                    if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
                        return nums[mid];
                    else if (nums[mid] >= nums[r])
                        l = mid + 1;
                    else
                        r = mid - 1;
                }
                return -1;
            }
        }
    }
}
