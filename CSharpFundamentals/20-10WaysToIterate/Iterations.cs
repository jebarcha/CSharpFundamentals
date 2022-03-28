using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.IterationsDemo
{
    public static class Iterations
    {
        private static List<int> numbers = new List<int>() { 1, 2, 3, 4, 5};

        public static void DoWhile()
        {
            Console.WriteLine("DoWhile Demo");
            int i = 0;
            do
	        {
                Console.WriteLine(numbers[i]);
                i++;
	        } while (i < numbers.Count);
        }

        public static void While()
        {
            Console.WriteLine("While Demo");
            int i = 0;
            while (i < numbers.Count)
            {
                Console.WriteLine(numbers[i]);
                i++;
            }
        }

        public static void For()
        {
            Console.WriteLine("For Demo");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        public static void ForEach()
        {
            Console.WriteLine("ForEach Demo");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public static void ForEachItem()
        {
            Console.WriteLine("ForEachItem Demo");
            foreach (var item in numbers.Select((num, index) => new { index, num }))
            {
                Console.WriteLine($"index:{item.index} | value:{item.num}");
            }
        }
        public static void ListForEachLambda()
        {
            Console.WriteLine("ListForEach Lambda Demo");
            numbers.ForEach((num) => Console.WriteLine(num));
        }
        public static void Recursive()
        {
            Console.WriteLine("Recursive Demo");
            ShowList(numbers);
        }
        private static void ShowList(List<int> list, int i=0)
        {
            if (i < list.Count)
            {
                Console.WriteLine(list[i++]);
                ShowList(list, i);
            }
            else
            {
                return;
            }
        }

        public static void GoTo()
        {
            Console.WriteLine("Goto Demo");
            int i = 0;
        Again:
            Console.WriteLine(numbers[i]);
            i++;
            if (i<numbers.Count)
            {
                goto Again;
            }
        }
        public static void ThreadingTasksParallel()
        {
            Console.WriteLine("ThreadingTasksParallel Demo");
            Parallel.ForEach(numbers, num =>
            {
                Console.WriteLine(numbers[num-1]);
            });
        }
        public static void LambdaExpression()
        {
            Console.WriteLine("LambdaExpression Demo");
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
        public static void UsingClosures()
        {
            Console.WriteLine("Closures Demo");
            Action executor = Show(numbers);
            executor();
        }
        private static Action Show(List<int> list)
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
