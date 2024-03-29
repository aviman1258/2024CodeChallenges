namespace _2024LeetCode
{
    public class PerfectSet
    {
        // You are shopping on Amazon.com for some bags of rice.
        // Each listing displays the number of grains of rice that the bags contains.
        // You want to buy a perfect set of rice bags from the entire search results lists, riceBags.
        // A perfefct set of rice bags, perfect, is defined as:
        // 1. The set contains at least two bags of rice.
        // 2. When the rice bags in the set perfect are sorted in increasing order by grain count,
        // it satisfies the condition perfect[i] * perfect[i] = perfect[i + 1] for all 1 <= i < n.
        // Here n is the size of the set and perfect[i] is the number of rice grains in bag i.
        //
        // Find the largest possible set of perfect and return an integer, the size of that set.
        // If no such set is possible, then return -1.
        // It is guaranteed that all elements in riceBags are distinct.
        public static void TestMaxSetSize()
        {
            TestMaxSetSize(new int[] { 3, 9, 4, 2, 16 }, 3);
            TestMaxSetSize(new int[] { 10, 3, 6, 7, 4 }, -1);
        }

        private static void TestMaxSetSize(int[] input, int expected)
        {
            int actual = MaxSetSize(input);
            if (actual != expected)
            {
                Console.WriteLine(string.Format("PerfectSet Fail! String to convert: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
                return;
            }
            Console.WriteLine(string.Format("PerfectSet Pass! String to convert: {0}; Expected: {1}; Actual: {2};", input, expected, actual));
        }

        private static int MaxSetSize(int[] riceBags)
        {
            int result = 0;

            int riceBagsLength = riceBags.Length;

            Dictionary<int,int> grains = new();

            for (int i = 0; i < riceBagsLength; i++)
            {
                grains.Add(riceBags[i], riceBags[i] * riceBags[i]);
            }
            
            for (int j = 0; j < riceBagsLength; j++)
            {
                int localCt = 0;
                int startingKey = riceBags[j];

                while (grains.ContainsKey(startingKey))
                {
                    localCt++;
                    startingKey = grains[startingKey];
                }

                if (localCt > result)
                {
                    result = localCt;
                }
            }
            
            if (result < 2)
            {
                result = -1;
            }

            return result;
        }
    }
}
