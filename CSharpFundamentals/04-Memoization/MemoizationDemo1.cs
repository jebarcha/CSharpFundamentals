using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._04_Memoization
{
    public static class MemoizationDemo1
    {
        public static void Factorial()
        {
            Func<long, long> factorial = null;
            factorial = n => n > 1 ? n * factorial(n-1) : 1;

            //Console.WriteLine(factorial(9));

            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < 20000000; i++)
            {
                factorial(9);
            }
            Console.WriteLine(stopWatch.ElapsedMilliseconds);


            var factorial2 = factorial.Memoize();
            var stopWatch2 = Stopwatch.StartNew();

            for (int i = 0; i < 20000000; i++)
            {
                factorial(9);
            }
            Console.WriteLine(stopWatch2.ElapsedMilliseconds);

        }

        private static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func)
        {
            var cache = new ConcurrentDictionary<T, TResult>();
            return (a) => cache.GetOrAdd(a, func);
        } 


    }
}
