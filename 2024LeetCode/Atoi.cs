namespace _2024LeetCode
{
    internal class Atoi
    {
        public static void TestMyAtoi()
        {
            TestMyAtoi("+00067", 67);
            TestMyAtoi("-546", -546);
            TestMyAtoi("12", 12);
            TestMyAtoi("0568", 568);
            TestMyAtoi("-0040", -40);
            TestMyAtoi("sixty", 0);
            TestMyAtoi("235 the is a number", 235);
            TestMyAtoi("   -0235", -235);
            TestMyAtoi("21474836486768765", 2147483647);
            TestMyAtoi("-21474836486798754", -2147483648);
            TestMyAtoi("+-12", 0);
            TestMyAtoi("00000-42a1234", 0);
            TestMyAtoi("3.14159", 3);
        }

        private static void TestMyAtoi(string input, int expected)
        {
            int actual = MyAtoi(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("Atoi Fail! String to convert: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("Atoi Pass! String to convert: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static int MyAtoi(string s)
        {
            int retInt = 0;
            bool numberStarted = false;
            bool isNegative = false;
            bool signSeen = false;

            Dictionary<char, int> map = new()
            {
                { '1', 1 },
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 }
            };

            Dictionary<char, int> map2 = new()
            {
                { ' ', 0 },
                { '+', 0 },
                { '-', 0 },
                { '0', 0 },
                { '.', 0}
            };


            try
            {
                foreach (char c in s)
                {
                    if (!numberStarted && !map2.ContainsKey(c) && !map.ContainsKey(c))
                    {
                        return 0;
                    }

                    if(c == '+' || c == '-')
                    {
                        if (signSeen)
                            return 0;
                        else
                            signSeen = true;
                    }

                    if (!numberStarted && c == '-')
                    {
                        isNegative = true;
                    }
                    else if (!numberStarted && map.ContainsKey(c))
                    {
                        numberStarted = true;
                        retInt += map[c];
                    }
                    else if (numberStarted && (map.ContainsKey(c) || c == '0'))
                    {
                        checked
                        {
                            if (c == '0')
                                retInt *= 10;
                            else
                                retInt = (retInt * 10) + map[c];
                        }
                    }
                    else if (numberStarted && !map.ContainsKey(c))
                    {
                        if (c == ' ' || c == '.')
                        {
                            if (isNegative)
                                return retInt * -1;
                            return retInt;
                        }
                        else
                            return 0;
                    }
                    //Console.WriteLine(String.Format("adding digit: {0}; retVal: {1}", c, retInt));
                }
            }
            catch (OverflowException)
            {
                if (isNegative)
                    return int.MinValue;
                else
                    return int.MaxValue;
            }


            if (isNegative)
                return retInt * -1;
            return retInt;
        }
    }
}
