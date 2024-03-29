using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024LeetCode
{
    internal class ContainerWithMaxVolume
    {
        public static void TestMaxArea()
        {
            TestMaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49);
            TestMaxArea(new int[] { 1, 1 }, 1);
        }

        private static void TestMaxArea(int[] input, int expected)
        {
            int actual = MaxArea(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("MaxArea Fail! Int Array: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("MaxArea Pass! Int Array: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static int MaxArea_Naive(int[] height, int n)
        {
            int maxArea = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int area;
                    if (height[i] < height[j])
                        area = height[i] * (j - i);
                    else
                        area = height[j] * (j - i);

                    if (area > maxArea)
                        maxArea = area;
                }
            }
            return maxArea;
        }

        private static int MaxArea(int[] height)
        {
            int maxArea = 0;
            int i = 0;
            int j = height.Length - 1;

            while(i < j)
            {
                if (height[i] < height[j])
                {
                    maxArea = Math.Max(height[i] * (j - i), maxArea);
                    i++;
                }
                else
                {
                    maxArea = Math.Max(height[j] * (j - i), maxArea);
                    j--;
                }
            }

            return maxArea;
        }
    }
}
