using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._06_Tuples
{
    public static class CompositionWithTuplesDemo
    {
        public static void CompositionWithTuples()
        {
            var composit = MyComposite();
            composit.Counter.increment();
            composit.Counter.increment();
            Console.WriteLine(composit.Counter.get());

            composit.BeerDB.Add(1);
        }

        public static (
            (Action increment, Action substract, Func<int> get) Counter,
            (Action<int> Add, Action<int> Update, Action<int> Delete) BeerDB
        ) MyComposite()
        {
            return (
                Counter(),
                BeerDB()
            );
        }


        private static (Action increment, Action substract, Func<int> get) Counter()
        {
            int i = 0;

            Action increment = () => i++;
            Action substract = () => i--;
            Func<int> get = () => i;

            return (increment, substract, get);
        }
        private static (Action<int> Add, Action<int> Update, Action<int> Delete) BeerDB()
        {
            return (
                (num) => Console.WriteLine("Add " + num),
                (num) => Console.WriteLine("Edit " + num),
                (num) => Console.WriteLine("Delete " + num)
            );
        }
    }
}
