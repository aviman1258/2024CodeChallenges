namespace _2024LeetCode
{
    internal class CompressString
    {
        public static void TestCompressString()
        {
            TestCompressString("aabbcdee", "a2b2cde2");
            TestCompressString("xxxhyxjjjjuj", "x3hyxj4uj");
            TestCompressString("", "");
            TestCompressString("  fdf fff", " 2fdf f3");
        }
        
        private static void TestCompressString(string input, string expected)
        {
            string actual = Compress(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("Compress Fail! String to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("Compress Pass! String to analyze: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static string Compress(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            string result = string.Empty;
            char c = s[0];
            int ct = 1;

            for(int i = 1; i < s.Length; i++)
            {
                if (s[i] == c)
                    ct++;
                else
                {
                    if (ct == 1) result += c;
                    else result += (c + ct.ToString());
                    c = s[i];
                    ct = 1;
                }              
            }

            if (ct == 1) result += c;
            else result += (c + ct.ToString());

            return result;
        }
    }
}
