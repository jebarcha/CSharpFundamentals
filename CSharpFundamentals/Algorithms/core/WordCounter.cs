using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class WordCounter
    {
        public static void WordCounterDemo()
        {
            string text = "    a  text with some   words    ";
            int n = 0;

            text = Regex.Replace(text, @"\s+", " ").Trim();
            var words = text.Split(' ');
            n = words.Length;

            Console.WriteLine($"\"{text}\" has {n} words");
        }
    }
}
