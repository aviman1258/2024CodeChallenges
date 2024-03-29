namespace _2024LeetCode
{
    internal class LongestPalindromicSubstring
    {
        public static void TestLongestPalndrome()
        {
            TestLongestPalindrome("babad", "bab");
            TestLongestPalindrome("cbbd", "bb");
            TestLongestPalindrome("racecar", "racecar");
            TestLongestPalindrome("babaddtattarrattatddetartrateedredividerb", "ddtattarrattatdd");
        }
        
        private static void TestLongestPalindrome(string input, string expected)
        {
            string actual = LongestPalindrome(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("LongestPalindrome Fail! String to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("LongestPalindrome Pass! String to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static string LongestPalindrome(string s)
        {
            int[] longestPalindromeIndices = { 0, 0 };

            for(int i = 0; i < s.Length; i++)
            {
                int[] currentIndices = ExpandFromMiddle(s, i, i);

                if(currentIndices[1] - currentIndices[0] > longestPalindromeIndices[1] - longestPalindromeIndices[0])                
                    longestPalindromeIndices = currentIndices;
                
                if(i + 1 < s.Length && s[i] == s[i + 1])
                {
                    int[] evenIndices = ExpandFromMiddle(s, i, i + 1);

                    if (evenIndices[1] - evenIndices[0] > longestPalindromeIndices[1] - longestPalindromeIndices[0])                    
                        longestPalindromeIndices = evenIndices;                    
                }
            }
            return s.Substring(longestPalindromeIndices[0], longestPalindromeIndices[1] - longestPalindromeIndices[0] + 1);
        }

        private static int[] ExpandFromMiddle(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--;
                j++;
            }
            return new int[] { i + 1, j - 1 };
        }
    }
}
