using CSharpFundamentals._03_ArraysAndLists;
using CSharpFundamentals._10_Generics;
using CSharpFundamentals._11_LINQ;
using CSharpFundamentals._12_AsyncronousTasks;
using CSharpFundamentals._15_Closures;
using CSharpFundamentals.DelegatesFuncAndAction;
using CSharpFundamentals.Predicates;
using System;
using System.Threading.Tasks;

namespace CSharpFundamentals
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //CSharpFundamentals._03_ArraysAndLists.DemoTmp.DemoReverseCad();
            //return;

            Console.WriteLine("3.1 Arrays");
            Console.WriteLine("3.2 Lists");
            Console.WriteLine("3.3 Queues");
            Console.WriteLine("3.4 Stacks");
            Console.WriteLine("10. Generics");
            Console.WriteLine("11. LINQ");
            Console.WriteLine("12. Asyncronous Tasks");
            Console.WriteLine("13.1 Delegates");
            Console.WriteLine("13.2 Func");
            Console.WriteLine("13.3 Action");
            Console.WriteLine("14. Predicates");
            Console.WriteLine("15. Closures");
            var selection = Console.ReadLine();

            switch (selection)
            {
                case "3.1":
                    ArraysDemo1.ArraysDemo();
                    break;
                case "3.2":
                    ArraysDemo1.ListsDemo();
                    break;
                case "3.3":
                    ArraysDemo1.QueueDemo();
                    break;
                case "3.4":
                    ArraysDemo1.StackDemo();
                    break;
                case "10":
                    await GenericsDemo1.GenericsDemo();
                    break;
                case "11":
                    //LinqDemo1.LinqDemo();
                    LinqDemo1.LinqDemoBeers();
                    break;
                case "12":
                    AsyncDemo1.AsyncDemo();
                    break;
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
                case "15":
                    ClosuresDemo1.ClosuresDemo();
                    break;
                default:
                    break;
            }

        }
    }
}
