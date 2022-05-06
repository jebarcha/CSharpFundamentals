using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class CountNumbersInAString
    {
        public static void CountNumbersDemo()
        {
            string text = "an12398jqwf???214!@#%dmasA";
            //string pattern = @"[0-9]";
            string pattern = @"[a-zA-Z]";
            var regex = new Regex(pattern);
            int n = regex.Matches(text).Count;

            Console.WriteLine($"\"{text}\" has {n}");
        }
    }
}
