namespace _2024LeetCode
{
    internal class KaprekarsContant
    {
        // The number 6174 is known as Kaprekar's contant, after the mathematician who discovered an associated property:
        // for all four-digit numbers with at least two distinct digits, repeatedly applying a simple procedure eventually results in this value.
        // The procedure is as follows:

        // For a given input x, create two new numbers that consist of the digits in x in ascending and descending order.
        // Subtract the smaller number from the larger number.
        // For example, this algorithm terminates in three steps when starting from 1234:

        // 4321 - 1234 = 3087
        // 8730 - 0378 = 8352
        // 8532 - 2358 = 6174
        // Write a function that returns how many steps this will take for a given input N.

        public static void TestKaprekar()
        {
            TestKaprekar(1234, 3);
            TestKaprekar(12343, 0);
            TestKaprekar(3333, 0);
            TestKaprekar(7341, 7);
            TestKaprekar(4734, 4);
            TestKaprekar(3233, 5);
        }
        
        private static void TestKaprekar(int input, int expected)
        {
            int actual = Kaprekar(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("TestKaprekar Fail! Int to test: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("TestKaprekar Pass! Int to test: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static int Kaprekar(int x)
        {
            int ct = 0;
            int number = x;

            if (!IsKaprekar(x)) return 0;

            while (number != 6174)
            {
                int[] numbers = GetNumbers(number);
                number = numbers[0] - numbers[1];
                ct++;
            }

            return ct;
        }

        private static int[] GetNumbers(int x)
        {
            int num1 = 0;
            int num2 = 0;

            List<int> digits = new();

            while(x > 0)
            {
                digits.Add(x % 10);
                x /= 10;
            }            

            if(digits.Count < 4)
            {
                int zerosToAdd = 4 - digits.Count;
                while (zerosToAdd > 0)
                {
                    digits.Add(0);
                    zerosToAdd--;
                }
            }

            List<int> ascendingOrder = digits.OrderBy(num => num).ToList();
            List<int> descendingOrder = digits.OrderByDescending(num => num).ToList();

            foreach(int digit in ascendingOrder)
            {
                num1 = (num1 * 10) + digit; 
            }

            foreach(int digit in descendingOrder)
            {
                num2 = (num2 * 10) + digit;
            }

            return new int[] { Math.Max(num1, num2), Math.Min(num1, num2) };
        }

        private static bool IsKaprekar(int x)
        {
            HashSet<int> digits = new();
            int ct = 0;

            while (x > 0)
            {
                digits.Add(x % 10);
                x /= 10;
                ct++;
            }

            if (ct == 4 && digits.Count > 1) return true;
            return false;
        }
    }
}
