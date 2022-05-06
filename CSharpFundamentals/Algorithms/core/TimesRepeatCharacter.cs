using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class TimesRepeatCharacter
    {
        public static void RepeatCharDemo()
        {
            string text = "abcabcabcasdfsdffghsdfasdf";
            char characterToFind = 'a';

            //imperative way
            int repeatTimes = text.Where(c => c == characterToFind).Count();

            // delcarative way
            //foreach (var c in text)
            //{
            //    if (c == characterToFind)
            //    {
            //        repeatTimes++;
            //    }
            //}
            
            Console.WriteLine($"{characterToFind} is repeated {repeatTimes} times");
        }
    }
}
