/*
 * https://leetcode.com/problems/middle-of-the-linked-list/?envType=featured-list&envId=challenges-for-new-users
 * Given the head of a singly linked list, return the middle node of the linked list.
 * If there are two middle nodes, return the second middle node.
 * 
 * Example 1:
 * Input: head = [1,2,3,4,5]
 * Output: [3,4,5]
 * Explanation: The middle node of the list is node 3.
 * 
 * Example 2:
 * Input: head = [1,2,3,4,5,6]
 * Output: [4,5,6]
 * Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
 * 
 * Constraints:
 * The number of nodes in the list is in the range [1, 100].
 * 1 <= Node.val <= 100
 */

using Xunit;

namespace Solutions
{
    public class MiddleOfTheLinkedList
    {
        public static ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            while (head?.next != null)
            {
                head = head.next.next;
                slow = slow.next;
            }
            return slow;
        }

        public class Tests
        {
            [Fact]
            public void Case1()
            {
                var head = MiddleNode(ListNodeFactory.CreateSequential(5));
                for (int i = 2; i < 5; i++)
                {
                    Assert.Equal(i + 1, head.val);
                    head = head.next;
                }
            }

            [Fact]
            public void Case2()
            {
                var head = MiddleNode(ListNodeFactory.CreateSequential(6));
                for (int i = 3; i < 6; i++)
                {
                    Assert.Equal(i + 1, head.val);
                    head = head.next;
                }
            }
        }
    }
}
