using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class Fibonacci
    {
        static int fibonacciIterative(int n)
        {
            if (n <= 1)
                return n;

            int fib = 1;
            int prevFib = 1;

            for (int i = 2; i < n; i++)
            {
                int temp = fib;
                fib += prevFib;
                prevFib = temp;
            }

            return fib;
        }
        static int fibonacciRecursive(int n)
        {
            if (n <= 1)
                return n;
            return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
        }


        static List<int> GetFibonacci(int untilNumber)
        {
            //input:  0 1 2 3 4 5 6  7  8  9 10 11  12
            var numbers = Enumerable.Range(0, untilNumber + 1).ToList();
            int a = 0;
            int b = 1;
            int c = 0;
            var fibo = new List<int>();
            for (int i = 0; i < numbers.Count(); i++)
            {
                fibo.Add(a); //0, 1, 1, 2

                c = a + b; //1 2 3
                a = b;     //1 1 2
                b = c;     //1 2 3
            }

            //output: 0 1 1 2 3 5 8 13 21 34 55 89 144
            return fibo;
        }
        public static List<int> GetFibonacci2(int number)
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
