using static _2024LeetCode.Helpers.ListHelpers;

namespace _2024LeetCode
{
    internal class ThreeSum
    {
        public static void TestGetThreeSums()
        {
            int[] input = new int[] { -1, 0, 1, 2, -1, -4 };
            List<int> list1 = new() { -1, 0, 1 };
            List<int> list2 = new() { -1, -1, 2 };
            List<IList<int>> list = new() { list1, list2 };

            TestGetThreeSums(input, list);

            input = new int[] { 0, 1, 1 };
            list = new() {};

            TestGetThreeSums(input, list);

            input = new int[] { 0, 0, 0, 0 };
            list1 = new() { 0, 0, 0 };
            list = new() { list1 };

            TestGetThreeSums(input, list);

            input = new int[] { -2, 0, 1, 1, 2 };
            list1 = new() { -2, 0, 2 };
            list2 = new() { -2, 1, 1 };
            list = new() { list1, list2 };

            TestGetThreeSums(input, list);
        }
        
        private static void TestGetThreeSums(int[] input, IList<IList<int>> expected)
        {
            IList<IList<int>> actual = GetThreeSums(input);
            if (AreUnorderedListListIntEqual(actual, expected))
            {
                Console.WriteLine(string.Format("Three Sum Pass! Array to analyze: {0}; Expected: {1}; Actual: {2};",
                    IntArrayToString(input), ListListIntToString(expected), ListListIntToString(actual)));
                return;
            }
            Console.WriteLine(string.Format("Three Sum Fail! Array to analyze: {0}; Expected: {1}; Actual: {2};",
                    IntArrayToString(input), ListListIntToString(expected), ListListIntToString(actual)));
        }

        

        private static IList<IList<int>> GetThreeSums_Naive(int[] nums)
        {
            int n = nums.Length;
            IList<IList<int>> results = new List<IList<int>>();

            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    for(int k = j + 1; k < n; k++)
                    {
                        if(nums[i] + nums[j] + nums[k] == 0)
                        {
                            results.Add(new List<int> {nums[i], nums[j], nums[k]});
                        }
                    }
                } 
            }

            HashSet<IList<int>> hashSet = new(new Helpers.ListComparer());

            foreach(IList<int> result in results)
            {
                IList<int> sortedResult = result.OrderBy(x => x).ToList();
                hashSet.Add(sortedResult);
            }

            return hashSet.ToList();
        }

        private static IList<IList<int>> GetThreeSums(int[] nums)
        {
            List<IList<int>> results = new();

            if( nums.Length <= 2 )
                return results;

            Array.Sort(nums);

            int start = 0;
            int leftPtr, rightPtr;
            int target;

            while(start < nums.Length - 2)
            {                
                leftPtr = start + 1;
                rightPtr = nums.Length - 1;
                target = nums[start] * -1;

                while (leftPtr < rightPtr)
                {
                    if (nums[leftPtr] + nums[rightPtr] > target)
                    {
                        rightPtr--;
                    }
                    else if (nums[leftPtr] + nums[rightPtr] < target)
                    {
                        leftPtr++;
                    }
                    else
                    {
                        List<int> result = new() { nums[start], nums[leftPtr], nums[rightPtr] };
                        results.Add(result);

                        while (leftPtr < rightPtr && nums[leftPtr] == result[1])
                            leftPtr++;

                        while (leftPtr > rightPtr && nums[rightPtr] == result[2])
                            rightPtr--;
                    }
                }

                int currentNum = nums[start];

                while (start < nums.Length - 2 && nums[start] == currentNum)
                    start++;
            }

            return results;
        }
    }
}
