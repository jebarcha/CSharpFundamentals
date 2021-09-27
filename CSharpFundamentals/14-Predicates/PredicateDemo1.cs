using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Predicates
{
    public class PredicateDemo1
    {
        public static void PredicateDemo()
        {
            var numbers = new List<int> { 1, 56, 2, 3, 3, 45, 6 };

            //var predicate = new Predicate<int>(IsDividerBy2);
            var predicate = new Predicate<int>(n => n % 2 == 0);
            Predicate<int> negativePredicate = x => !predicate(x);
            var dividersBy2 = numbers.FindAll(negativePredicate);
            dividersBy2.ForEach(n => Console.WriteLine(n));
        }

        //static bool IsDividerBy2(int n) => n % 2 == 0;

    }
}
