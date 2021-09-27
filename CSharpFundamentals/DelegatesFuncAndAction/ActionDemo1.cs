
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DelegatesFuncAndAction
{
    //***************************************************************
    // Action is similar as Func, but Action does not return anything
    //***************************************************************
    public static class ActionDemo1
    {
        public static void ActionDemo(string cadena)
        {
            //Action<string, string> mostrar = ToShow;
            Action<string, string> mostrar = (a, b) => Console.WriteLine("Anonymous: " + a + "-" + b);   //use anonymous function (if execute or use it only once, we can use it this way)
            DoSomething(mostrar);

        }
        private static void DoSomething(Action<string, string> finalFunction)
        {
            Console.WriteLine("Action:I do something");
            finalFunction("It was sent from another function", "another string");
            Console.WriteLine("do something else..");
        }
        //public static void ToShow(string cad, string cad2)
        //{
        //    Console.WriteLine(cad + " " + cad2);
        //}
       
    }

}
