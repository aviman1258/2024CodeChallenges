using static _2024LeetCode.Helpers.ListHelpers;

namespace _2024LeetCode
{
    // Given a pivot x, and a list lst, partition the list into three parts.

    // The first part contains all elements in lst that are less than x
    // The second part contains all elements in lst that are equal to x
    // The third part contains all elements in lst that are larger than x
    // Ordering within a part can be arbitrary.

    // For example, given x = 10 and lst = [9, 12, 3, 5, 14, 10, 10], one partition may be [9, 3, 5, 10, 10, 12, 14].


    internal class PivotPartitionList
    {
        public static void TestPivot()
        {
            TestPivot(new List<int> { 2, 34, 3, 76, 4, 6, 0, 34, 10 }, 10);
            TestPivot(new List<int> { 7, 2, 6, 1, 9, 4, 6, 7 }, 10);
            TestPivot(new List<int> { 7, 2, 6, 1, 9, 4, 6, 7 }, 0);
            TestPivot(new List<int> { 7, 2, 6, 1, 9, 4, 6, 7 }, 7);
        }
        
        private static void TestPivot(List<int> input, int pivot)
        {
            List<int> inputCopy = new(input);
            List<int> actual = Pivot(input, pivot);

            bool pivotEncountered = false;
            bool pass = true;

            foreach (int i in actual)
            {
                if(i >= pivot)
                    pivotEncountered = true;

                if (!pivotEncountered && i > pivot)
                {
                    pass = false;
                    break;
                }

                if (pivotEncountered && i < pivot)
                {
                    pass = false;
                    break;
                }
            }

            if (pass)
            {
                Console.WriteLine(string.Format("Pivot Pass! List to pivot: {0} with pivot {1}; Actual: {2};"
                    , ListToString(inputCopy), pivot, ListToString(actual)));
                return;
            }
            Console.WriteLine(string.Format("Pivot Fail! List to pivot: {0} with pivot {1}; Actual: {2};"
                , ListToString(inputCopy), pivot, ListToString(actual)));
        }

        private static List<int> PivotNaive(List<int> numbers, int pivotPt)
        {
            List<int> lessThanPivot = new();
            List<int> sameAsPivot = new();
            List<int> moreThanPivot = new();

            foreach(int number in numbers)
            {
                if (number < pivotPt)
                    lessThanPivot.Add(number);
                else if (number == pivotPt)
                    sameAsPivot.Add(number);
                else
                    moreThanPivot.Add(number);
            }

            return lessThanPivot.Concat(sameAsPivot).Concat(moreThanPivot).ToList();            
        } 

        private static List<int> Pivot(List<int> numbers, int pivotPt)
        {
            bool pivotSeen = false;
            int indexOfPivotSeen = 0;
            
            for(int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= pivotPt)
                {
                    pivotSeen = true;
                    indexOfPivotSeen = i;
                }
                
                if(!pivotSeen && numbers[i] > pivotPt)
                {
                    int number = numbers[i];
                    numbers.RemoveAt(i);
                    numbers.Add(number);
                    continue;
                }

                if(pivotSeen && numbers[i] < pivotPt)
                {
                    int number = numbers[i];
                    numbers.RemoveAt(i);
                    numbers.Insert(0, number);
                    indexOfPivotSeen++;
                    continue;
                }

                if(pivotSeen && numbers[i] == pivotPt && indexOfPivotSeen > 0)
                {
                    int number = numbers[i];
                    numbers.RemoveAt(i);
                    numbers.Insert(indexOfPivotSeen - 1, number);
                }    
            }

            return numbers;
        }
    }
}
