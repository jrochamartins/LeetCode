/*
 * https://leetcode.com/problems/fizz-buzz/?envType=featured-list&envId=challenges-for-new-users
 * Given an integer n, return a string array answer (1-indexed) where:
 * 
 * answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
 * answer[i] == "Fizz" if i is divisible by 3.
 * answer[i] == "Buzz" if i is divisible by 5.
 * answer[i] == i (as a string) if none of the above conditions are true.
 * 
 * Example 1:
 * Input: n = 3
 * Output: ["1","2","Fizz"]
 * 
 * Example 2:
 * Input: n = 5
 * Output: ["1","2","Fizz","4","Buzz"]
 * 
 * Example 3:
 * Input: n = 15
 * Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
 * 
 * Constraints:
 * 1 <= n <= 104
 */

using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Solutions
{
    public class FizzBuzzSolution
    {
        const string FIZZ = "Fizz";
        const string BUZZ = "Buzz";

        static IList<string> FizzBuzz(int n)
        {
            var list = new string[n];
            for (int i = 1; i <= n; i++)
                list[i - 1] = (i % 3 == 0, i % 5 == 0) switch
                {
                    (true, true) => FIZZ + BUZZ,
                    (true, false) => FIZZ,
                    (false, true) => BUZZ,
                    (false, false) => i.ToString()
                };
            //GC.Collect(); //Reduces memory but adds 10ms to run.
            return list;
        }

        public class Tests
        {
            [Fact]
            public void Case1()
            {
                FizzBuzz(3)
                    .Should().Equal("1", "2", FIZZ);
            }

            [Fact]
            public void Case2()
            {
                FizzBuzz(5)
                    .Should().Equal("1", "2", FIZZ, "4", BUZZ);
            }

            [Fact]
            public void Case3()
            {
                FizzBuzz(15)
                    .Should().Equal("1", "2", FIZZ, "4", BUZZ, FIZZ, "7", "8", FIZZ, BUZZ, "11", FIZZ, "13", "14", FIZZ + BUZZ);
            }
        }
    }
}
