using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamentals._11._1_PLINQ
{
    public static class PLINQDemo1
    {
        public static void PLINQDemo()
        {
            var sw = new Stopwatch();
            sw.Start();

            var numbers = Enumerable.Range(0, 1000);

            //var filterNumber = (from n in numbers.AsParallel().WithDegreeOfParallelism(4)
            var filterNumber = (from n in numbers.AsParallel()
                                where IsValid(n)
                                select n
                ).ToList();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        private static bool IsValid(int num)
        {
            Thread.Sleep(10);
            if (num % 2 != 0) return false;
            if (num % 5 != 0) return false;

            return true;
        }
    }
}
