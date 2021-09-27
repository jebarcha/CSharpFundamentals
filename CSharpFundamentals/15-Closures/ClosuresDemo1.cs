using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._15_Closures
{
    // Closures are usefull to give the state to our internal function. Do not alter anything from the outside
    public static class ClosuresDemo1
    {
        public static void ClosuresDemo()
        {
            Action fn = Execute(2);
            Some(fn);
            Some(fn);
            Some(fn);
            //fn();
            //fn();
            //fn();
        }
        static void Some(Action fn)
        {
            Console.WriteLine("start");
            fn();
            Console.WriteLine("end");
        }
        public static Action Execute(int n)
        {
            int i = 0;
            Console.WriteLine("Hello, I have been initialized");

            return () =>
            {
                if (i < n)
                {
                    Console.WriteLine("Hello, I'm a function");
                }
                else
                {
                    Console.WriteLine("Hello, I do not execute because is exceded");
                }
                i++;    // our variable i changes and keeps its state inside the function (closure)
            };
        }
    }
}
