using CSharpFundamentals.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._09_AnonymousTypes
{
    public static class AnonymousTypesDemo1
    {
        // An anonymous type is something we can define without having a specific structure
        // anonymous types are read only (we cannot change or reassing its values)

        public static void AnonymousTypesDemo()
        {
            // We create our object beer having our class Beer for that.
            //var beer = new Beer() { Name = "London Porter", Alcohol = 8 };

            // We also can create an object without having a class
            var beer = new { Name = "London Porter", Alcohol = 8 };

            ///beer.Name = "Other";  //this is not allowed
            Console.WriteLine(beer.Name);
        }

        public static void AnonymousTypesDemo2()
        {
            List<Beer> beers = new List<Beer>() { 
                new Beer() { Name = "London Porter", Alcohol = 8},
                new Beer() { Name = "Honey Dew", Alcohol = 7}
            };

            // from a source that has a structure, we can create an anonymous source
            var nameBeers = from d in beers
                            select new { onlyName = d.Name };
            nameBeers.ToList().ForEach(d => Console.WriteLine(d.onlyName));
        }

        public static void AnonymousTypesDemo3()
        {
            // a delegate is the representation of a functionality with a type
            Action<int> FunctionInt = (num) => Console.WriteLine(num);
            var some = new
            {
                Name = "Something",
                Function = FunctionInt
            };
            some.Function(2);

            // This is not allowed, anonymous types cannot have functions using arrow functions or anonymous function,
            // but we can use delegates for that
            //var some = new
            //{
            //    Name = "Something",
            //    Function = () =>
            //    {
            //        Console.WriteLine("Print Something");
            //    }
            //};

            //--------------------------------------------------------
            //an anonymous types has reflection
            //Reflection is the capacity that a language or technology to see itself
            //an object can see its own properties (metadata), also anonymous types can.
            foreach (var o in some.GetType().GetProperties())
            {
                Console.WriteLine($"Name:{o.Name} | Value:{o.GetValue(some)} | Type:{some.GetType().GetProperty(o.Name)}");
            }
        }

    }
}
