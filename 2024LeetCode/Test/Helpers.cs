namespace _2024LeetCode.Test
{
    public static class Helpers
    {
        public static string IntArrayToString(int[] array)
        {
            return $"[{string.Join(", ", array)}]";
        }

        public static string ListListIntToString(List<List<int>> listListInt)
        {
            return $"[{string.Join(", ", listListInt.Select(innerList => $"[{string.Join(", ", innerList)}]"))}]";
        }

        public static string ListIntToString(List<int> list)
        {
            return "[" + string.Join(", ", list) + "]";
        }

        public static bool AreListEqual(List<List<int>> list1, List<List<int>> list2)
        {
            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                List<int> sublist1 = list1[i];
                List<int> sublist2 = list2[i];

                if (sublist1.Count != sublist2.Count) return false;

                for (int j = 0; j < sublist1.Count; j++)
                    if (sublist1[j] != sublist2[j]) return false;
            }

            return true;
        }
    }
}
