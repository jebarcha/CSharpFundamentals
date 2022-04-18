using CSharpFundamentals._01_Date;
using CSharpFundamentals._02_SerializeAndDeserialize;
using CSharpFundamentals._03_ArraysAndLists;
using CSharpFundamentals._04_Memoization;
using CSharpFundamentals._06_Tuples;
using CSharpFundamentals._07_TenWaysToIterateAnArray;
using CSharpFundamentals._08_Lambda_Expressions;
using CSharpFundamentals._09_AnonymousTypes;
using CSharpFundamentals._10_Generics;
using CSharpFundamentals._11._1_PLINQ;
using CSharpFundamentals._11_LINQ;
using CSharpFundamentals._12_AsyncronousTasks;
using CSharpFundamentals._14_Predicates;
using CSharpFundamentals._15_Closures;
using CSharpFundamentals._16_Task;
using CSharpFundamentals._17_Threads;
using CSharpFundamentals._18_ThreadPool;
using CSharpFundamentals._19_Parallel;
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

            //IterationsDemo.Iterations.DoWhile();
            //IterationsDemo.Iterations.While();
            //IterationsDemo.Iterations.For();
            //IterationsDemo.Iterations.ForEach();
            //IterationsDemo.Iterations.ForEachItem();
            //IterationsDemo.Iterations.ListForEach();
            //IterationsDemo.Iterations.Recursive();
            //IterationsDemo.Iterations.GoTo();
            //IterationsDemo.Iterations.ThreadingTasksParallel();
            //IterationsDemo.Iterations.LambdaExpression();
            //IterationsDemo.Iterations.UsingClosures();


            //CSharpFundamentals.Algorithms.Palindrome.IsPalindromeDemo();
            CSharpFundamentals.Algorithms.core.Buble.RunBuble();
            return;


            //Algorithms.AlgoDemo.IsPalindromeDemo();
            //return;

            //CSharpFundamentals._03_ArraysAndLists.DemoTmp.DemoReverseCad();
            //return;

            Console.WriteLine("1 Dates");
            Console.WriteLine("2 Serialize and Deserialize");
            Console.WriteLine("3.1 Arrays");
            Console.WriteLine("3.2 Lists");
            Console.WriteLine("3.3 Queues");
            Console.WriteLine("3.4 Stacks");
            Console.WriteLine("4 Memoization");
            Console.WriteLine("6. Tuples");
            Console.WriteLine("7. Ten ways to iterate an array");
            Console.WriteLine("8. Lambda Expressions");
            Console.WriteLine("9. Anonymous Types");
            Console.WriteLine("10. Generics");
            Console.WriteLine("11. LINQ");
            Console.WriteLine("11.1 PLINQ");
            Console.WriteLine("12. Asyncronous Tasks");
            Console.WriteLine("13.1 Delegates");
            Console.WriteLine("13.2 Func");
            Console.WriteLine("13.3 Action");
            Console.WriteLine("14. Predicates");
            Console.WriteLine("15. Closures");
            Console.WriteLine("16. Task");
            Console.WriteLine("17. Threads");
            Console.WriteLine("18. ThreadPool");
            Console.WriteLine("19. Parallel");
            var selection = Console.ReadLine();

            Console.WriteLine("--------------------");
            switch (selection)
            {
                case "1":
                    DatesDemo1.DatesDemo();
                    break;
                case "2":
                    SerializeAndDeserializeDemo1.SerializeAndDeserializeDemo();
                    break;
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
                case "4":
                    MemoizationDemo1.Factorial();
                    break;
                case "6":
                    TuplesDemo1.TuplesDemo();
                    Console.WriteLine("Tuples BeerDB demo-------------");
                    TuplesBeerDemo.TuplesBeer();
                    Console.WriteLine("Tuples - Composite pattern demo");
                    CompositionWithTuplesDemo.CompositionWithTuples();
                    break;
                case "7":
                    TenWaysToIterateAnArray.Closure_10();
                    break;
                case "8":
                    //LambdaExpressionsDemo1.LambdaExpressionsDemo();
                    //LambdaExpressionsDemo1.LambdaExpressionsDemo2();
                    //LambdaExpressionsDemo1.LambdaExpressionsDemo3();
                    LambdaExpressionsDemo1.LambdaExpressionsDemo4();
                    break;
                case "9":
                    //AnonymousTypesDemo1.AnonymousTypesDemo();
                    //AnonymousTypesDemo1.AnonymousTypesDemo2();
                    AnonymousTypesDemo1.AnonymousTypesDemo3();
                    break;
                case "10":
                    await GenericsDemo1.GenericsDemo();
                    break;
                case "11.1":
                    PLINQDemo1.PLINQDemo();
                    break;
                case "11":
                    //LinqDemo1.LinqDemo();
                    //LinqDemo1.LinqDemoBeers();

                    //Linq5MethodsDemo.Linq5Methods_1_Union();
                    //Linq5MethodsDemo.Linq5Methods_2_Zip();
                    //Linq5MethodsDemo.Linq5Methods_3_Join();
                    //Linq5MethodsDemo.Linq5Methods_4_All();
                    Linq5MethodsDemo.Linq5Methods_5_SelectMany();

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
                    //PredicateDemoBeers.PredicateBeers();
                    PredicateDemoThree.PredicateThree();
                    break;
                case "15":
                    ClosuresDemo1.ClosuresDemo();
                    break;
                case "16":
                    await TaskDemo1.TaskDemo();
                    break;
                case "17":
                    ThreadsDemo1.ThreadsDemo();
                    break;
                case "18":
                    ThreadPoolDemo1.ThreadPoolDemo();
                    break;
                case "19":
                    ParallelDemo1.ParallelDemo();
                    break;

                default:
                    break;
            }

        }
    }
}
