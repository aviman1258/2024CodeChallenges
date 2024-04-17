using static _2024LeetCode.Helpers.ListHelpers;
   
namespace _2024LeetCode
{
    internal class RotateArray
    {
        public static void TestRotate()
        {
            TestRotate(new int[] { 0, 1, 2, 3, 4 }, 3, new int[] { 3, 4, 0, 1, 2 });
            TestRotate(new int[] { 0, 1, 2, 3, 4 }, 0, new int[] { 0, 1, 2, 3, 4 });
            TestRotate(new int[] { 0, 1, 2, 3, 4 }, 9, new int[] { 0, 1, 2, 3, 4 });
            TestRotate(new int[] { 0, 1, 2, 3, 4 }, 5, new int[] { 0, 1, 2, 3, 4 });
            TestRotate(new int[] { 0, 1, 2, 3, 4 }, 1, new int[] { 1, 2, 3, 4, 0 });
        }
        
        private static void TestRotate(int[] inputArray, int k, int[] expected)
        {
            int[] actual = RotateInPlace(inputArray, k);
            if (IntArraysAreEqual(actual, expected))
            {
                Console.WriteLine(string.Format("Rotate Pass! Array to rotate {0} by {1} elements; Expected: {2}; Actual {3}", 
                    IntArrayToString(inputArray), k, IntArrayToString(expected), IntArrayToString(actual)));
                return;
            }
            Console.WriteLine(string.Format("Rotate Fail! Array to rotate {0} by {1} elements; Expected: {2}; Actual {3}",
                    IntArrayToString(inputArray), k, IntArrayToString(expected), IntArrayToString(actual)));
        }
        
        private static int[] Rotate(int[] arr, int k)
        {
            int n = arr.Length;

            if (k > n || k <= 0) return arr;

            int[] rotArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i < k)
                    rotArr[i + (n - k)] = arr[i];
                else
                    rotArr[i - k] = arr[i];
            }

            return rotArr;
        }

        private static int[] RotateInPlace(int[] arr, int k)
        {            
            int n = arr.Length;

            if (k > n || k <= 0) return arr;

            int i = 0;
            int indexToSwap = 0;

            while(i < n)
            {
                if (indexToSwap < k)
                    indexToSwap += (n - k);
                else
                    indexToSwap -= k;

                int temp = arr[indexToSwap];
                arr[indexToSwap] = arr[0];
                arr[0] = temp;
                
                i++;
            }
            
            return arr;
        }
    }
}
