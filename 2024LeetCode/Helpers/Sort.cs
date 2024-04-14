namespace _2024LeetCode.Helpers
{
    public static class Sort
    {
        public static void QuickSort(int[] nums, int? start = null, int? end = null)
        {
            if (start == null) start = 0;
            if (end == null) end = nums.Length - 1;

            if (start < end)
            {
                int p = PivotPartitionList(nums, (int) start, (int) end);

                QuickSort(nums, start, p - 1);
                QuickSort(nums, p + 1, end);
            }

        }

        private static int PivotPartitionList(int[] nums, int start, int end)
        {
            int pivot = nums[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if(nums[j] <= pivot)
                {
                    i++;
                    Swap(nums, i, j);
                }
            }
            Swap(nums, i + 1, end);
            return i + 1;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
