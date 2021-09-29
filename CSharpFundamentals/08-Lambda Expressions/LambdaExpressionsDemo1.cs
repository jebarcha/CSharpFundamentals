using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._08_Lambda_Expressions
{
    public static class LambdaExpressionsDemo1
    {
        // Lambda Expressions is a simple or reduce way to create anonymous functions
        // in Net already exists a lot of functions that recieves a lambda expression, but we can also create them (Func<>).
        public static void LambdaExpressionsDemo()
        {
            Func<int, int> b = (a) => a * 2;
            int res = b(4);
            Console.WriteLine($"mult x 2: {res}");

            Func<int, int, int> suma = (a, b) => a + b;
            Console.WriteLine($"suma:{suma(4, 10)}");

            Func<int, int, int> greaterThan = (a, b) =>
            {
                if (a > b) return a;
                else return b;
            };

            int greater = greaterThan(4, 10);
            Console.WriteLine($"Greater:{greater}");
        }
        public static void LambdaExpressionsDemo2()
        {
            var numbers = new List<int>() { 3, 5, 7, 4, 8, 9, 2 };
            Func<int, bool> GetPairs = (number) => number % 2 == 0;

            var pairs = numbers.Where(GetPairs);
            //equivalent: var pairs = numbers.Where((number) => number % 2 == 0);
            //with GetPairs function we have it encapsulated
            foreach (var p in pairs)
            {
                Console.WriteLine(p);
            }
        }

        public static void LambdaExpressionsDemo3()
        {
            //We can have Lambda expressions that receives another Lambda expression
            var numbers = new List<int>() { 3, 5, 7, 4, 8, 9, 2 };

            Action<int> print = (number) => Console.WriteLine(number);

            //Action<List<int>> show = (numbers) =>
            Action show = () =>
            {
                foreach (var number in numbers)
                {
                    print(number);
                }
            };
            
            //print(5);
            show();
        }

        public static void LambdaExpressionsDemo4()
        {
            //We can have Lambda expressions that receives another Lambda expression
            var numbers = new List<int>() { 3, 5, 7, 4, 8, 9, 2 };

            Func<int, Func<int, int>, int> fnHighOrder = (number, fn) =>
            {
                if (number > 100)
                {
                    return fn(number);
                }
                else
                {
                    return number;
                }

            };

            int result = fnHighOrder(600, n => n * 2);
            Console.WriteLine(result);
        }


    }
}
