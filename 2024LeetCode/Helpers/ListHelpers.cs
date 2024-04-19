using System.Reflection;
using System.Text;

namespace _2024LeetCode.Helpers
{
    public static class ListHelpers
    {
        public static string IntArrayToString(int[] array)
        {
            return $"[{string.Join(", ", array)}]";
        }

        public static string ListListIntToString(List<List<int>> listListInt)
        {
            return $"[{string.Join(", ", listListInt.Select(innerList => $"[{string.Join(", ", innerList)}]"))}]";
        }

        public static string ListListIntToString(IList<IList<int>> listListInt)
        {
            return $"[{string.Join(", ", listListInt.Select(innerList => $"[{string.Join(", ", innerList)}]"))}]";
        }

        public static string ListToString(List<int> list)
        {
            return "[" + string.Join(", ", list) + "]";
        }

        public static string ListToString<T>(List<T> list)
        {
            StringBuilder sb = new();

            foreach (var item in list)
            {
                Type type = item.GetType();
                FieldInfo[] fields = type.GetFields();

                sb.Append($"{type.Name}: ");
                foreach (var field in fields)
                {
                    sb.Append($"{field.Name} = {field.GetValue(item)}, ");
                }
                sb.Length -= 2; // Remove the trailing comma and space
                sb.AppendLine();
            }

            return sb.ToString();
        }


        public static bool AreListListIntEqual(List<List<int>> list1, List<List<int>> list2)
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

        public static bool AreUnorderedListListIntEqual(IList<IList<int>> list1, IList<IList<int>> list2)
        {
            if (list1.Count != list2.Count) return false;

            int numOfLists = list1.Count;

            List<List<int>> list1Copy = new();
            List<List<int>> list2Copy = new();

            foreach (List<int> list in list1)
            {
                List<int> sortedList = list.OrderBy(x => x).ToList();
                list1Copy.Add(sortedList);
            }

            foreach (List<int> list in list2)
            {
                List<int> sortedList = list.OrderBy(x => x).ToList();
                list2Copy.Add(sortedList);
            }

            for (int i = 0; i < numOfLists; i++)
            {
                bool foundListInt = false;

                for(int j = 0; j < numOfLists; j++)
                {
                    if(list1Copy[i].SequenceEqual(list2Copy[j]))
                    {
                        foundListInt = true;
                        break;
                    }
                }
                
                if (!foundListInt) return false;
            }

            return true;
        }

        public static bool IntArraysAreEqual(int[] arr1, int[] arr2)
        {
            if(arr1.Length != arr2.Length) return false;

            int n = arr1.Length;
            
            for(int i = 0; i < n; i++)
            {
                if( arr1[i] != arr2[i]) return false;
            }

            return true;
        }
    }

    public class ListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
            if (x.Count != y.Count)
                return false;

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(IList<int> obj)
        {
            int hash = 17;
            foreach (var item in obj)
            {
                hash = hash * 23 + item.GetHashCode();
            }
            return hash;
        }
    }
}
