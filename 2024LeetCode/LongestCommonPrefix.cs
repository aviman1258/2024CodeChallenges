namespace _2024LeetCode
{
    internal class LongestCommonPrefix
    {        
        public static void TestLongestCommonPrefix()
        {
            TestLongestCommonPrefix(new string[] { "flower", "flow", "flight" }, "fl");
            TestLongestCommonPrefix(new string[] { "plane", "alpha", "cow" }, "");
        }

        private static void TestLongestCommonPrefix(string[] input, string expected)
        {
            string actual = GetLongestCommonPrefix(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("LongestCommonPrefix Fail! Strings to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("LongestCommonPrefix Pass! Strings to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static string GetLongestCommonPrefix(string[] strs)
        {
           if (strs == null || strs.Length == 0)
                return string.Empty;

            string shortest = strs[0];
            foreach (string str in strs)
            {
                if (str.Length < shortest.Length)
                    shortest = str;
            }

            for (int i = 0; i < shortest.Length; i++)
            {
                char current = shortest[i];
                for (int j = 0; j < strs.Length; j++)
                {
                    if(strs[j][i] != current)
                    {
                        return shortest.Substring(0, i);
                    }
                }
            }

            return shortest;
        }
    }
}
