using System.Text.Json;
using static _2024LeetCode.Helpers.ListHelpers;

namespace _2024LeetCode
{
    /*
     * You are given a list of data entries that represent entries and exits of groups of people into a building. 
     * 
     * An entry looks like this:
     * {"timestamp": 1526579928, count: 3, "type": "enter"}
     * This means 3 people entered the building.
     * 
     * An exit looks like this:
     * {"timestamp": 1526580382, count: 2, "type": "exit"} 
     * 
     * This means that 2 people exited the building. timestamp is in Unix time.
     * Find the busiest period in the building, that is, the time with the most people in the building. 
     * Return it as a pair of (start, end) timestamps. 
     * You can assume the building always starts off and ends up empty, i.e. with 0 people inside.
     */

    public class DataEntry
    {
        public int timestamp;
        public int count;
        public string entryType;

        public DataEntry(int timestamp = 0, int count = 0, string entryType = "entry")
        {
            this.timestamp = timestamp;
            this.count = count;
            this.entryType = entryType;
        }
    }
    
    internal class BuildingPopulation
    {
        public static void TestGetMaxCountInterval()
        {
            List<DataEntry> dataEntries = new()
            {
                new DataEntry(1526579928, 3, "enter"),
                new DataEntry(1526579950, 2, "exit"),
                new DataEntry(1526580000, 1, "enter"),
                new DataEntry(1526580090, 1, "exit")  
            };

            int[] expected = new int[] { 1526579928, 1526579950 };

            TestGetMaxCountInterval(dataEntries, expected);
        }
        
        private static void TestGetMaxCountInterval(List<DataEntry> input1, int[] expected)
        {
            int[] actual = GetMaxCountInterval(input1);
            if (IntArraysAreEqual(actual.ToArray(), expected.ToArray()))
            {
                Console.WriteLine(string.Format("Finding Max Count Interval Pass! Max Count Interval of\n{0}found to be {1}. Should be {2}",
                    ListToString(input1), IntArrayToString(actual), IntArrayToString(expected)));
                return;
            }
            Console.WriteLine(string.Format("Finding Max Count Interval Fail! Max Count Interval of\n{0}found to be {1}. Should be {2}",
                    ListToString(input1), IntArrayToString(actual), IntArrayToString(expected)));
        }

        private static int[] GetMaxCountInterval(List<DataEntry> dataEntries)
        {
            int maxCount = 0;
            int maxCountStartTime = 0;
            int maxCountEndTime = int.MaxValue;
            int currentCount = 0;
            bool inMaxCountInterval = false;

            IOrderedEnumerable<DataEntry> sortedDataEntries = dataEntries.OrderBy(x => x.timestamp);

            foreach (DataEntry sortedDataEntry in sortedDataEntries)
            {
                if (sortedDataEntry.entryType == "enter")
                {
                    currentCount += sortedDataEntry.count;
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        maxCountStartTime = sortedDataEntry.timestamp;
                        inMaxCountInterval = true;
                    }
                }
                else
                {
                    currentCount -= sortedDataEntry.count;

                    if (currentCount < 0) 
                        currentCount = 0;

                    if (inMaxCountInterval && currentCount <= maxCount)
                    {
                        maxCountEndTime = sortedDataEntry.timestamp;
                        inMaxCountInterval = false;
                    }
                }
            }

            return new int[] { maxCountStartTime, maxCountEndTime };
        }
    }
}
