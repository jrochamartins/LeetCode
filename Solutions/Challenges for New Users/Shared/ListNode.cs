namespace Solutions
{
    public class ListNode
    {
        public int val;

        public ListNode next;

        public ListNode(int val) => this.val = val;

        public ListNode(int val, ListNode next) : this(val) => this.next = next;
    }

    public static class ListNodeFactory
    {
        public static ListNode CreateSequential(int size)
        {
            var arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = i + 1;
            return CreateArray(arr);
        }

        public static ListNode CreateArray(params int[] arr)
        {
            ListNode head = null;
            ListNode tail = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (head == null)
                {
                    head = new ListNode(arr[i]);
                    tail = head;
                    continue;
                }
                tail.next = new ListNode(arr[i]);
                tail = tail.next;
            }
            return head;
        }
    }
}
