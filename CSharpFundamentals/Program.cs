using CSharpFundamentals.DelegatesFuncAndAction;
using CSharpFundamentals.Predicates;
using System;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("13.1 Delegates");
            Console.WriteLine("13.2 Func");
            Console.WriteLine("13.3 Action");
            Console.WriteLine("14. Predicates");
            var selection = Console.ReadLine();

            switch (selection)
            {
                case "13.1":
                    DelegatesDemo1.DelegateDemo1("TestDelegateDemo");
                    break;
                case "13.2":
                    FuncDemo1.FuncDemo("This is a test Func");
                    break;
                case "13.3":
                    ActionDemo1.ActionDemo("This is a test Func");
                    break;
                case "14":
                    //PredicateDemo1.PredicateDemo();
                    PredicateDemoBeers.PredicateBeers();
                    break;
                default:
                    break;
            }

        }
    }
}
