/*
 * https://leetcode.com/problems/palindrome-linked-list/?envType=featured-list&envId=challenges-for-new-users
 * Given the head of a singly linked list, return true if it is a palindrome or false otherwise
 * Input: head = [1,2,2,1] Output: true
 * Input: head = [1,2] Output: false
 * Constraints:
 * 
 * The number of nodes in the list is in the range [1, 105].
 * 0 <= Node.val <= 9
 * 
 * Follow up: Could you do it in O(n) time and O(1) space?
 */

using Xunit;

namespace Solutions
{
    public class PalindromeLinkedList
    {
        private ListNode _initHead;

        public bool IsPalindrome(ListNode head)
        {
            _initHead ??= head;

            if (IsLast(head))
            {
                var same = IsSame(_initHead, head);
                _initHead = _initHead.next;
                return same;
            }

            if (IsPalindrome(head: head.next)
                && IsSame(_initHead, head))
            {
                _initHead = _initHead.next;
                return true;
            }

            _initHead = null;
            return false;
        }

        static bool IsLast(ListNode head) => head.next == null;

        static bool IsSame(ListNode nodeA, ListNode nodeB) => nodeA == nodeB || nodeA.val == nodeB.val;

        public class Tests
        {
            [Fact]
            public void Case()
            {
                var s = new PalindromeLinkedList();
                Assert.True(s.IsPalindrome(ListNodeFactory.CreateArray(1)));
                Assert.False(s.IsPalindrome(ListNodeFactory.CreateArray(2, 1)));
                Assert.True(s.IsPalindrome(ListNodeFactory.CreateArray(2, 2)));
                Assert.False(s.IsPalindrome(ListNodeFactory.CreateArray(1, 2, 3)));
                Assert.True(s.IsPalindrome(ListNodeFactory.CreateArray(1, 2, 1)));
                Assert.False(s.IsPalindrome(ListNodeFactory.CreateArray(1, 2, 3, 1)));
                Assert.True(s.IsPalindrome(ListNodeFactory.CreateArray(1, 2, 2, 1)));
            }
        }
    }
}
