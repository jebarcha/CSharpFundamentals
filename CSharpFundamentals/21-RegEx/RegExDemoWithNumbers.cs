using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpFundamentals._21_RegEx
{
    public static class RegExDemoWithNumbers
    {
        public static void Demo()
        {
            //string REGEX_PATTERN = @"(\d+:\d+)|(\d+)$";
            string REGEX_PATTERN = @"\d+:\d+|\d+$";
            string value = "000:000";
            var result = Regex.Match(value, REGEX_PATTERN);
            PrintResult(result);

            value = "00";
            result = Regex.Match(value, REGEX_PATTERN);
            PrintResult(result);

            value = "meta";
            result = Regex.Match(value, REGEX_PATTERN);
            PrintResult(result);

            value = "-----";
            result = Regex.Match(value, REGEX_PATTERN);
            PrintResult(result);
        }
        private static void PrintResult(Match result) => Console.WriteLine(result.Success ? "Success" : "NotSuccess");


    }
}
