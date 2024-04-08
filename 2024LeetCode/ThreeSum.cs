using static _2024LeetCode.Test.Helpers;

namespace _2024LeetCode
{
    internal class ThreeSum
    {
        private static void TestGetThreeSums(int[] input, IList<IList<int>> expected)
        {
            IList<IList<int>> actual = GetThreeSums(input);
            if (AreListEqual((List<List<int>>) actual, (List<List<int>>) expected))
            {
                Console.WriteLine(string.Format("Three Sum Pass! Array to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("LongestPalindrome Pass! String to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        

        private static IList<IList<int>> GetThreeSums(int[] nums)
        {

        }
    }
}
