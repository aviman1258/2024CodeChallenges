namespace _2024LeetCode
{
    internal class ZigZagConversion
    {
        public static void TestConvert()
        {
            TestConvert("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR");
            TestConvert("PAYPALISHIRING", 4, "PINALSIGYAHRPI");
            TestConvert("A", 1, "A");
            TestConvert("AB", 1, "AB");
        }
        
        private static void TestConvert(string input, int rows, string expected)
        {
            string actual = Convert(input, rows);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("Convert Fail! String to convert: {0}; Rows: {3}; Expected: {1}; Actual: {2};", input, expected, actual, rows));
                return;
            }
            Console.WriteLine(string.Format("Convert Pass! String to convert: {0}; Rows: {3}; Expected: {1}; Actual: {2};", input, expected, actual, rows));
        }

        private static string Convert(string s, int rows)
        {
            if (rows == 1) return s;
            
            string result = String.Empty;
            int currentRow = 1;
            bool rowIncreasing = true;

            Dictionary<int,int> map = new();

            for(int i = 0; i < s.Length; i++)
            {
                map.Add(i, currentRow);
                
                if(rowIncreasing)
                    currentRow++;
                else
                    currentRow--;

                if(currentRow == rows)
                    rowIncreasing = false;

                if(currentRow == 1)
                    rowIncreasing = true;
            }
            
            for(int row = 1; row <= rows; row++)
            {
                List<int> indecies = new();
                foreach(var keyValuePair in map)
                {
                    if(keyValuePair.Value == row)
                    {
                        indecies.Add(keyValuePair.Key);
                    }
                }
                indecies.Sort();

                foreach(int index in indecies)
                {
                    result += s[index];
                }
            }

            return result;
        }

    }
}
