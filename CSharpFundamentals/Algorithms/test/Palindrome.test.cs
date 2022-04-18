using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFundamentals.Algorithms.test
{
    public class Palindrome
    {
        [Fact]
        public void ReturnTrueIfStringIsPalindrome()
        {
            string word = "abba abba";
            var result = Algorithms.Palindrome.IsPalindrome(word);
            Assert.True(result);
        }
        [Fact]
        public void ReturnFalseIfStringIsNotPalindrome()
        {
            string word = "jose de jesus";
            var result = Algorithms.Palindrome.IsPalindrome(word);
            Assert.False(result);
        }

    }
}
