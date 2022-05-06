using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class Fibonacci
    {
        public static List<int> GetFibonacci(int number)
        {
            int a = 0;
            int b = 1;
            var list = Enumerable.Range(1, 10).ToList();
            var fibo = list.Aggregate(new List<int> { 0 }, (acc, n) => {
                var temp = a;
                a = b;
                b = temp + b;
                acc.Add(a);
                return acc;
            });

            Console.WriteLine(String.Join(",", fibo));

            return fibo;

            //javascript:
            //function fibo(n, a = 0, b = 1) {
            //    return new Array(n)
            //          .fill('demo fibo')
            //          .reduce((acc) => {
            //              const temp = a;
            //              a = b;
            //              b = temp + b;
            //              acc.push(a);
            //              return acc;
            //          }, [0]);
            //}

        }
    }
}
