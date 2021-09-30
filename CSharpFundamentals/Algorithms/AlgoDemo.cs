﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms
{
    public static class AlgoDemo
    {
        public static void IsPalindromeDemo()
        {
            string text = "abba abba"; //"jose de"; //"anna anna";
            //if (IsPalindromeStack(text))
            if (IsPalindrome(text))
                    Console.WriteLine($"Is a Palindrome: {text}");
            else
                Console.WriteLine($"Is Not a Palindrome: {text}");
        }
        private static bool IsPalindrome(string input)
        {
            var inputWithNoSpaces = input.Replace(" ", "");
            var stringReverse = input.Replace(" ","").Reverse().ToArray();
            var stringJoinReverse = String.Join("", stringReverse);

            return inputWithNoSpaces == stringJoinReverse;
        }
        private static bool IsPalindromeStack(string input)
        {
            var myStack = new Stack<char>();
            foreach (var item in input)
            {
                myStack.Push(item);
            }

            string reverseText = "";
            foreach (var item in myStack)
            {
                reverseText += item;
            }

            return input == reverseText;
        }
    }
}
