using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._06_Tuples
{
    public static class TuplesDemo1
    {
        // Tuples is a list of elements
        // we can save a collection of functions in a tuple

        // We can implement Composite pattern, that pattern is similar as inheritance but we can do multiple inheritance.

        public static void TuplesDemo()
        {

            var counter = Counter();
            counter.increment();
            counter.increment();
            Console.WriteLine(counter.get());
            counter.substract();
            Console.WriteLine(counter.get());

        }

        // this is a function that returns a tuple
        // and that tuple is a group of functions
        private static (Action increment, Action substract, Func<int> get) Counter()
        {
            int i = 0;

            Action increment = () => i++;
            Action substract = () => i--;
            Func<int> get = () => i;

            return (increment, substract, get);
        }
    }
}
