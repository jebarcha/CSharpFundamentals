using CSharpFundamentals.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._11_LINQ
{
    public static class LinqDemo1
    {
        // LINQ we can use Query sintax or Method syntax
        // or integrated syntax or extension syntax

        public static void LinqDemo()
        {
            Console.WriteLine("LinqDemo-----------------------------------------");
            List<int> nums = new List<int>() { 1,4,5,6,7,2,3};
            var num7 = nums.Where(n => n == 7).FirstOrDefault();
            Console.WriteLine(num7);

            Console.WriteLine("---");
            var numsOrdered = nums.OrderBy(d => d);
            foreach (var num in numsOrdered)
            {
                Console.WriteLine(num);
            }

            var sumNum = nums.Sum(d => d);
            Console.WriteLine($"Sum:{sumNum}");

            var avgNum = nums.Average(d => d);
            Console.WriteLine($"Avg:{avgNum}");
        }
        public static void LinqDemoBeers()
        {
            List<Beer> beers = BeerUtils.Beers();

            var lstBeersOrdered = from d in beers
                                  where d.Name.ToLower().Contains("i")
                                  orderby d.Alcohol
                                  select d;
            Console.WriteLine("Beer list ordered by Alcohol number - Query Syntax");
            foreach (var beer in lstBeersOrdered)
            {
                Console.WriteLine($"{beer.Name}-{beer.Alcohol}");
            }
        }
    }
}
