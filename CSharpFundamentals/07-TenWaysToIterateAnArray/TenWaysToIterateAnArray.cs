using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._07_TenWaysToIterateAnArray
{
    public static class TenWaysToIterateAnArray
    {
        private static List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        public static void DoWhile_1()
        {
            int i = 0;
            do
            {
                Console.WriteLine(numbers[i]);
                i++;
            } while (i < numbers.Count);
        }
        public static void While_2()
        {
            int i = 0;
            while (i < numbers.Count)
            {
                Console.WriteLine(numbers[i]);
                i++;

            }
        }
        public static void For_3()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        public static void ForEach_4()
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // if we want to know the index:
            foreach (var item in numbers.Select((num, i) => new { i, num }))
            {
                Console.WriteLine(item.i+ " " +item.num);
            }
        }

        public static void ForEachMethod_5()
        {
            // ForEach method is one of the method collections that List has
            // High order function that receives a first class function
            numbers.ForEach((num) => Console.WriteLine(num));
        }
        public static void Recursivity_6()
        {
            Show(numbers);
        }
        private static void Show(List<int> list, int i = 0)
        {
            if (i < list.Count)
            {
                Console.WriteLine(list[i++]);
                Show(list, i);
            } 
            else
            {
                return;
            }

        }
        public static void Goto_7()
        {
            int i = 0;
        Again:

            Console.WriteLine(numbers[i]);
            i++;
            if (i < numbers.Count)
                goto Again;
        }
        public static void ParallelForEach_8()
        {
            Parallel.ForEach(numbers, num =>
            {
                Console.WriteLine(num);
            });
        }

        public static void Lambda_9()
        {
            // Lambda basically is to save an specification of an anonymous expression in a variable
            int i = 0;
            Action fn = null;

            fn = () =>
            {
                if (i < numbers.Count)
                {
                    Console.WriteLine(numbers[i]);
                    i++;
                    fn();
                }
            };

            fn();
        }

        public static void Closure_10()
        {
            Action executor = ShowList(numbers);
            executor();   //or also: executor.Invoke();
        }
        private static Action ShowList(List<int> list)
        {
            int i = 0;
            Action fn = null;

            fn = () =>
            {
                if (i < list.Count)
                {
                    Console.WriteLine(list[i]);
                    i++;
                    fn();
                }
            };

            return fn;
        }


    }
}
