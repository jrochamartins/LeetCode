/*
 * https://leetcode.com/problems/ransom-note/?envType=featured-list&envId=challenges-for-new-users
 * Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
 * Each letter in magazine can only be used once in ransomNote.
 * 
 * Example 1:
 * Input: ransomNote = "a", magazine = "b"
 * Output: false
 * 
 * Example 2:
 * Input: ransomNote = "aa", magazine = "ab"
 * Output: false
 * 
 * Example 3:
 * Input: ransomNote = "aa", magazine = "aab"
 * Output: true
 * 
 * Constraints:
 * 1 <= ransomNote.length, magazine.length <= 105
 * ransomNote and magazine consist of lowercase English letters.
 */

using System.Collections.Generic;
using Xunit;

namespace Solutions
{
    public class RansomNote
    {
        static bool CanConstruct(string ransomNote, string magazine)
        {
            var magazineLetters = new Dictionary<char, int>(magazine.Length);
            foreach (var c in magazine)
                if (magazineLetters.ContainsKey(c)) magazineLetters[c]++;
                else magazineLetters[c] = 1;

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (!magazineLetters.ContainsKey(ransomNote[i]) || magazineLetters[ransomNote[i]] == 0)
                    return false;
                magazineLetters[ransomNote[i]]--;
            }
            return true;
        }

        public class Tests
        {
            [Fact]
            public void Case()
            {
                Assert.True(CanConstruct("jose", "ajaseob"));
                Assert.False(CanConstruct("a", "b"));
                Assert.False(CanConstruct("aa", "ab"));
                Assert.True(CanConstruct("aa", "aab"));
            }
        }
    }
}
