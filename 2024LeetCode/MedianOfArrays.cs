using System.Text;
using static _2024LeetCode.Test.ListHelpers;

namespace _2024LeetCode
{
    //Median of 2 sorted arrays.
    internal class MedianOfArrays
    {
        public static void TestFindMedianSortedArrays()
        {
            TestFindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }, 2.0);
            TestFindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5);
            TestFindMedianSortedArrays(new int[] { 1, 4 }, new int[] { 2, 3 }, 2.5);
        }
        
        private static void TestFindMedianSortedArrays(int[] input1, int[] input2, double expected)
        {
            double actual = FindMedianSortedArrays(input1, input2);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("Finding Median Fail! Median of {0} and {1} found to be {2}. Should be {3}", 
                    IntArrayToString(input1), IntArrayToString(input2), actual, expected));
                return;
            }
            Console.WriteLine(string.Format("Finding Median Pass! Median of {0} and {1} found to be {2}. Should be {3}",
                    IntArrayToString(input1), IntArrayToString(input2), actual, expected));
        }

        private static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] nums = new int[nums1.Length + nums2.Length];
            int nums1Ptr = 0;
            int nums2Ptr = 0;

            for (int i = 0; i < nums1.Length + nums2.Length; i++)
            {
                if(nums1Ptr > nums1.Length - 1)
                {
                    nums[i] = nums2[nums2Ptr];
                    nums2Ptr++;
                } 
                else if (nums2Ptr > nums2.Length - 1)
                {
                    nums[i] = nums1[nums1Ptr];
                    nums1Ptr++;
                }
                else
                {
                    if (nums1[nums1Ptr] < nums2[nums2Ptr])
                    {
                        nums[i] = nums1[nums1Ptr];
                        nums1Ptr++;
                    }
                    else if (nums1[nums1Ptr] > nums2[nums2Ptr])
                    {
                        nums[i] = nums2[nums2Ptr];
                        nums2Ptr++;
                    }
                    else
                    {
                        nums[i] = nums1[nums1Ptr];
                        nums[i + 1] = nums2[nums2Ptr];
                        i++;
                        nums1Ptr++;
                        nums2Ptr++;
                    }
                } 
            }

            if(nums.Length % 2 == 0)
                return (nums[(nums.Length / 2) - 1] + nums[nums.Length / 2]) / 2.0;

            return nums[nums.Length / 2];
        }
    }
}
