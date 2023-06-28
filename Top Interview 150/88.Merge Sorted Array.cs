//https://leetcode.com/problems/merge-sorted-array/?envType=study-plan-v2&envId=top-interview-150
// Victory https://leetcode.com/problems/merge-sorted-array/submissions/977520415/?envType=study-plan-v2&envId=top-interview-150

using BenchmarkDotNet.Attributes;
using FluentAssertions;
using Xunit;

namespace Solutions
{
    public class Merge_Sorted_Array
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var q1 = new Queue<int>();
            var q2 = new Queue<int>();

            for (int i = 0; i < m; i++)
                q1.Enqueue(nums1[i]);
            for (int i = 0; i < n; i++)
                q2.Enqueue(nums2[i]);

            for (int i = 0; i < m + n; i++)
            {
                if (q1.Count > 0 && q2.Count > 0)
                    nums1[i] = q1.Peek() < q2.Peek() ? q1.Dequeue() : q2.Dequeue();
                else if (q1.Count > 0)
                    nums1[i] = q1.Dequeue();
                else if (q2.Count > 0)
                    nums1[i] = q2.Dequeue();
            }
        }

        [MemoryDiagnoser]
        public class Benchmarks
        {
            [Benchmark()]
            public void Bench1()
            {
                var test = new Tests();
                test.Case1();
            }

            [Benchmark()]
            public void Bench2()
            {
                var test = new Tests();
                test.Case2();
            }

            [Benchmark()]
            public void Bench3()
            {
                var test = new Tests();
                test.Case3();
            }
        }

        public class Tests
        {
            /// <summary>
            /// Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n =3
            /// Output: [1,2,2,3,5,6]
            /// Explanation: The arrays we are merging are[1, 2, 3] and[2, 5, 6].
            /// The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
            /// </summary>
            [Fact]
            public void Case1()
            {
                var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
                var nums2 = new int[] { 2, 5, 6 };
                Merge(nums1, 3, nums2, 3);
                nums1.Should().Equal(1, 2, 2, 3, 5, 6);
            }

            /// <summary>
            ///Input: nums1 = [1], m = 1, nums2 = [], n = 0
            /// Output: [1]
            /// Explanation: The arrays we are merging are[1] and[].
            /// The result of the merge is [1].
            /// </summary>
            [Fact]
            public void Case2()
            {
                var nums1 = new int[] { 1 };
                var nums2 = Array.Empty<int>();
                Merge(nums1, 1, nums2, 0);
                nums1.Should().Equal(1);
            }

            /// <summary>
            /// Input: nums1 = [0], m = 0, nums2 = [1], n = 1
            /// Output: [1]
            /// Explanation: The arrays we are merging are [] and [1].
            /// The result of the merge is [1].
            /// Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
            /// </summary>
            [Fact]
            public void Case3()
            {
                var nums1 = new int[] { 0 };
                var nums2 = new int[] { 1 };
                Merge(nums1, 0, nums2, 1);
                nums1.Should().Equal(1);
            }
        }
    }
}
