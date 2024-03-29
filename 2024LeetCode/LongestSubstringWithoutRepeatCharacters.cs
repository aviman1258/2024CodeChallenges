namespace _2024LeetCode
{
    internal class LongestSubstringWithoutRepeatCharacters
    {
        public static void TestLengthOfLongestSubstring()
        {
            TestLengthOfLongestSubstring("abcabcbb", 3);
            TestLengthOfLongestSubstring("bbbbb", 1);
            TestLengthOfLongestSubstring("pwwkew", 3);
            TestLengthOfLongestSubstring(" ", 1);
            TestLengthOfLongestSubstring("", 0);
            TestLengthOfLongestSubstring("au", 2);
            TestLengthOfLongestSubstring("dvdf", 3);
            TestLengthOfLongestSubstring("abba", 2);
            TestLengthOfLongestSubstring("tmmzuxt", 5);
        }

        private static void TestLengthOfLongestSubstring(string input, int expected)
        {
            int actual = LengthOfLongestSubstring(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("Convert Fail! String to convert: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("Convert Pass! String to convert: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            int leftPtr = 0;
            int rightPtr = 0;
            int longest = 0;
            HashSet<char> chars = new();

            while(rightPtr < s.Length)
            {
                if (chars.Contains(s[rightPtr]))
                {
                    chars.Remove(s[leftPtr]);
                    leftPtr++;
                }
                else
                {
                    chars.Add(s[rightPtr]);
                    rightPtr++;
                    longest = Math.Max(longest, chars.Count);
                }
            }
            return longest;
        }
    }
}
