namespace _2024LeetCode
{
    internal class ReverseInt
    {
        public static void TestReverse()
        {
            TestReverse(123, 321);
            TestReverse(-123, -321);
            TestReverse(120, 21);
            TestReverse(0, 0);
            TestReverse(-1, -1);
            TestReverse(1534236469, 0);
            TestReverse(-2147483648, 0);
        }
        
        private static void TestReverse(int input, int expected)
        {
            int actual = Reverse(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("Reverse Fail! Int to reverse: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("Reverse Pass! Int to reverse: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        public static int Reverse(int x)
        {
            try
            {
                checked
                {
                    int posX = Math.Abs(x);

                    int reverse = 0;

                    while (posX > 0)
                    {
                        int digit = posX % 10;
                        posX /= 10;
                        reverse = (reverse * 10) + digit;
                    }

                    if (x < 0)
                        reverse *= -1;

                    return reverse;
                }
            }
            catch(OverflowException)
            {
                return 0;
            }
        }
    }
}
