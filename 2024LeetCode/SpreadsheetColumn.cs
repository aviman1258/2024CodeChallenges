namespace _2024LeetCode
{
    internal class SpreadsheetColumn
    {
        public static void TestColumnLabel()
        {
            TestColumnLabel(1, "A");
            TestColumnLabel(26, "Z");
            TestColumnLabel(27, "AA");
            TestColumnLabel(52, "AZ");
            TestColumnLabel(53, "BA");
            TestColumnLabel(701, "ZY");
            TestColumnLabel(702, "ZZ");
            TestColumnLabel(703, "AAA");
        }
        
        private static void TestColumnLabel(int input, string expected)
        {
            string actual = ColumnLabel(input);
            if (actual == expected)
            {
                Console.WriteLine(string.Format("Column Label Pass! Int to analyze: {0}; Expected: {1}; Actual: {2};",
                    input.ToString(), expected, actual));
                return;
            }
            Console.WriteLine(string.Format("Column Label Fail! Int to analyze: {0}; Expected: {1}; Actual: {2};",
                    input.ToString(), expected, actual));
        }

        public static Dictionary<int, char> ColumnLabels = new() 
        {
            {  0, 'Z' },
            {  1, 'A' },
            {  2, 'B' },
            {  3, 'C' },
            {  4, 'D' },
            {  5, 'E' },
            {  6, 'F' },
            {  7, 'G' },
            {  8, 'H' },
            {  9, 'I' },
            { 10, 'J' },
            { 11, 'K' },
            { 12, 'L' },
            { 13, 'M' },
            { 14, 'N' },
            { 15, 'O' },
            { 16, 'P' },
            { 17, 'Q' },
            { 18, 'R' },
            { 19, 'S' },
            { 20, 'T' },
            { 21, 'U' },
            { 22, 'V' },
            { 23, 'W' },
            { 24, 'X' },
            { 25, 'Y' },
            { 26, 'Z' }
        };

        private static string ColumnLabel(int n)
        {
            string result = string.Empty;
            
            while(n > 0)
            {
                int rem = n % 26;

                if (rem == 0)
                    n -= 1;

                result += ColumnLabels[rem];
                n /= 26;
            }

            char[] resultCharArr = result.ToCharArray();
            Array.Reverse(resultCharArr);
            result = new string(resultCharArr);
            return result;
        }
    }
}
