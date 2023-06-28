/*
 * https://leetcode.com/problems/roman-to-integer/?envType=featured-list&envId=challenges-for-new-users
 * This is a personal solution for leet code problem
 */

using Xunit;

namespace Solutions
{
    public class RomanToInteger
    {
        static int RomanToInt(string s)
        {
            var result = 0;
            int currentValue, oldValue = 0;

            for (int i = s.Length - 1; i > -1; i--)
            {
                currentValue = RomanToInt(s[i]);
                if (currentValue >= oldValue) result += currentValue;
                else result -= currentValue;
                oldValue = currentValue;
            }

            //GC.Collect(); //Reduces memory but adds 10ms to run.
            return result;
        }

        static int RomanToInt(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
            };
            return 0;
        }

        public class Tests
        {
            [Fact]
            public void Case()
            {
                Assert.Equal(3999, RomanToInt("MMMCMXCIX"));
                Assert.Equal(58, RomanToInt("LVIII"));
                Assert.Equal(1994, RomanToInt("MCMXCIV"));
                Assert.Equal(3, RomanToInt("III"));
                Assert.Equal(2482, RomanToInt("MMCDLXXXII"));
            }
        }
    }
}
