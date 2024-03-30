namespace _2024LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    internal class AddTwoNumbers
    {
        public static void TestAdd2Numbers()
        {
            
        }
        
        private static void TestAdd2Numbers(ListNode input1, ListNode input2, ListNode expected)
        {
            ListNode actual = Add2Numbers(input1, input2);

            int actualInt = 0;
            int expectedInt = 0;
            int input1Int = 0;
            int input2Int = 0;

            ListNode currentActual = actual;         
            int actualTensPlace = 1;
            while (currentActual != null)
            {
                actualInt += currentActual.val * actualTensPlace;
                actualTensPlace *= 10;                
                currentActual = currentActual.next;
            }

            ListNode currentExpected = expected;
            int expectedTensPlace = 1;
            while (currentExpected != null)
            {
                expectedInt += currentExpected.val * expectedTensPlace;
                expectedTensPlace *= 10;
                currentExpected = currentExpected.next;
            }

            ListNode currentInput1 = input1;
            int input1TensPlace = 1;
            while (currentInput1 != null)
            {
                input1Int += currentInput1.val * input1TensPlace;
                input1TensPlace *= 10;
                currentInput1 = currentInput1.next;
            }

            ListNode currentInput2 = input2;
            int input2TensPlace = 1;
            while (currentInput2 != null)
            {
                input2Int += currentInput2.val * input2TensPlace;
                input2TensPlace *= 10;
                currentInput2 = currentInput2.next;
            }

            if (actualInt == expectedInt)
            {
                Console.WriteLine(string.Format("Add2Numbers Pass! {0} + {1}; Expected: {2}; Actual: {3};", input1Int, input2Int, expectedInt, actualInt));
                return;
            }
            Console.WriteLine(string.Format("Add2Numbers Fail! {0} + {1}; Expected: {2}; Actual: {3};", input1Int, input2Int, expectedInt, actualInt));
        }

        public static ListNode Add2Numbers(ListNode l1, ListNode l2)
        {
            return new ListNode();
        }
    }
}
