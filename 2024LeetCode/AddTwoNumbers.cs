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
            TestAdd2Numbers(IntToListNode(123), IntToListNode(256), IntToListNode(379));
            TestAdd2Numbers(IntToListNode(23), IntToListNode(176), IntToListNode(199));
            TestAdd2Numbers(IntToListNode(0), IntToListNode(0), IntToListNode(0));
            TestAdd2Numbers(IntToListNode(100), IntToListNode(0), IntToListNode(100));
            TestAdd2Numbers(IntToListNode(2), IntToListNode(32234), IntToListNode(32236));
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

        private static ListNode Add2NumbersAsInt(ListNode l1, ListNode l2)
        {
            ListNode currentL1 = l1;
            int currentL1TensPlace = 1;
            int l1Int = 0;

            while(currentL1 != null)
            {
                l1Int += currentL1.val * currentL1TensPlace;
                currentL1TensPlace *= 10;
                currentL1 = currentL1.next;
            }

            ListNode currentL2 = l2;
            int currentL2TensPlace = 1;
            int l2Int = 0;

            while (currentL2 != null)
            {
                l2Int += currentL2.val * currentL2TensPlace;
                currentL2TensPlace *= 10;
                currentL2 = currentL2.next;
            }

            int result = l1Int + l2Int;

            return IntToListNode(result);
        }

        private static ListNode IntToListNode(int num)
        {
            ListNode head = new();
            ListNode current = head;
            while (num > 0)
            {
                int digit = num % 10;
                num /= 10;

                current.next = new ListNode(digit);
                current = current.next;
            }

            return head.next;
        }

        private static ListNode Add2Numbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode firstNode = null;
            ListNode currentNode = null;
            while(l1 != null || l2 != null || carry != 0)
            {
                int l1Data = l1 != null ? l1.val : 0;
                int l2Data = l2 != null ? l2.val : 0;

                int sum = l1Data + l2Data + carry;

                int quotient = Math.DivRem(sum, 10, out int remainder);
                carry = quotient;
                ListNode newNode = new(remainder);
                if (firstNode == null)
                {
                    firstNode = newNode;
                    currentNode = newNode;
                }
                else
                {
                    currentNode.next = newNode;
                    currentNode = currentNode.next;
                }

                l1 = l1?.next;
                l2 = l2?.next;

            }
            return firstNode;
        }
    }
}
