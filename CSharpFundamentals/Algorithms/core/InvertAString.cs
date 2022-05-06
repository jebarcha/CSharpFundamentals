using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class InvertAString
    {
        public static void InvertDemo()
        {
            string text = "pato";
            string textResult = "";


            var res = text.Reverse();
            textResult = String.Join("", res);

            //char[] chars = text.ToCharArray();
            //Array.Reverse(chars);
            //var textResult = new String(chars);

            Console.WriteLine(textResult);
        }
    }
}
