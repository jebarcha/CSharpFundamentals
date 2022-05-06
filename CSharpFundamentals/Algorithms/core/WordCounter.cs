using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class WordCounter
    {
        public static void WordCounterDemo()
        {
            string text = "    a  text with some   words    ";
            int n = 0;
            var words = text.Trim().Split(' ');
            n = words.Length;

            Console.WriteLine($"\"{text.Trim()}\" has {n} words");
        }
    }
}
