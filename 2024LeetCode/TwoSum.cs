namespace _2024LeetCode
{
    internal class TwoSum
    {
        /// <summary>
        /// Brute force method using nested for loops. NO2 complexity.
        /// </summary>
        /// <param name="nums">array to search in</param>
        /// <param name="target">the target to sum to</param>
        /// <returns><2 element array. Each element is an index./returns>
        /// <exception cref="Exception">In case a pair isnt found.</exception>
        public static int[] TwoSum_BruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new Exception("Not Found!");
        }

        /// <summary>
        /// Optimized, one pass solution using hash tavble. NO complexity.
        /// </summary>
        /// <param name="nums">array to search in</param>
        /// <param name="target">the target to sum to</param>
        /// <returns>2 element array. Each element is an index.</returns>
        /// <exception cref="Exception">In case a pair isnt found.</exception>
        public static int[] TwoSum_OnePass(int[] nums, int target)
        {
            Dictionary<int, int> hashTable = new();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (hashTable.ContainsKey(complement))
                {
                    return new int[] { hashTable[complement], i };
                }
                else
                {
                    hashTable[nums[i]] = i;
                }
            }
            throw new Exception("Not Found!");
        }
    }

    public class TwoSum_Test
    {
        private static bool TwoSum_Test1()
        {
            int[] nums = new int[4] { 2, 7, 11, 15 };
            int target = 9;
            int[] expected = new int[2] { 0, 1 };
            int[] actual = TwoSum.TwoSum_OnePass(nums, target);

            return TwoSum_Test_IsEqual(expected, actual);
        }

        private static bool TwoSum_Test2()
        {
            int[] nums = new int[3] { 3, 2, 4 };
            int target = 6;
            int[] expected = new int[2] { 1, 2 };
            int[] actual = TwoSum.TwoSum_OnePass(nums, target);

            return TwoSum_Test_IsEqual(expected, actual);
        }

        private static bool TwoSum_Test3()
        {
            int[] nums = new int[2] { 3, 3 };
            int target = 6;
            int[] expected = new int[2] { 0, 1 };
            int[] actual = TwoSum.TwoSum_OnePass(nums, target);

            return TwoSum_Test_IsEqual(expected, actual);

        }

        private static bool TwoSum_Test_IsEqual(int[] result1, int[] result2)
        {
            if (result1.Length != 2 && result2.Length != 2)
            {
                throw new Exception("Input arrays not 2 elements long.");
            }

            return (result1[0] == result2[0] && result1[1] == result2[1]);
        }

        public static void TwoSum_StartTest()
        {
            Console.WriteLine(String.Format("Two Sum Test Case 1: {0}", TwoSum_Test1() ? "Pass" : "Fail"));
            Console.WriteLine(String.Format("Two Sum Test Case 2: {0}", TwoSum_Test2() ? "Pass" : "Fail"));
            Console.WriteLine(String.Format("Two Sum Test Case 3: {0}", TwoSum_Test3() ? "Pass" : "Fail"));
        }
    }
}
