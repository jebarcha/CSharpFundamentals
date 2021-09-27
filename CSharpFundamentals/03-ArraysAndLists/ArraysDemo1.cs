using CSharpFundamentals.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._03_ArraysAndLists
{
    public static class ArraysDemo1
    {
        public static void ArraysDemo()
        {
            int[] nums = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //int num = nums[0];
            //Console.WriteLine(num);

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.WriteLine($"iteration {i} - {nums[i]}");
            //}

            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
        }
        public static void ListsDemo()
        {
            //List<int> lstNums = new List<int>();
            //lstNums.Add(0);
            //lstNums.Add(1);
            //lstNums.Add(2);
            //lstNums.Remove(0);
            Console.WriteLine("Lists-------------------------------");
            List<int> lstNums = new List<int>() { 1,2,3,4,5,6,7,8 };
            lstNums.Add(9);
            lstNums.Add(10);

            foreach (var num in lstNums)
            {
                Console.WriteLine($"lst element {num}");
            }


            Console.WriteLine("Lists Beers demo-------------------------------");
            List<Beer> lstBeers = new List<Beer>() { new Beer { Name = "Corona", Alcohol = 6 } };
            lstBeers.Add(new Beer() { Name = "Victoria", Alcohol = 7 });
            foreach (var beer in lstBeers)
            {
                Console.WriteLine(beer.Name);
            }
        }

        public static void QueueDemo()
        {
            Console.WriteLine("Queue (FIFO)-------------------------------");
            Queue<int> queNums = new Queue<int>();
            queNums.Enqueue(1);
            queNums.Enqueue(2);
            queNums.Enqueue(3);
            queNums.Enqueue(4);

            foreach (var num in queNums)
            {
                Console.WriteLine($"queue element {num}");
            }

        }

        public static void StackDemo()
        {
            Console.WriteLine("Stack (LIFO)-------------------------------");
            Stack<int> stkNums = new Stack<int>();
            stkNums.Push(1);
            stkNums.Push(2);
            stkNums.Push(3);
            stkNums.Push(4);

            foreach (var num in stkNums)
            {
                Console.WriteLine($"stack element {num}");
            }

        }

    }
}
