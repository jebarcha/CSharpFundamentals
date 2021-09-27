
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DelegatesFuncAndAction
{
    //*******************************************************************************************
    //Func uses generics, the last type of Func is the return type. We can have 16 parameters max
    //*******************************************************************************************
    public static class FuncDemo1
    {
        public static void FuncDemo(string cadena)
        {
            Func<string, int> mostrar = ToShow;   
            DoSomething(mostrar);

        }
        private static void DoSomething(Func<string, int> finalFunction)
        {
            Console.WriteLine("Func:I do something");
            Console.WriteLine("The length of the string is " + finalFunction("It was sent from another function"));
        }
        private static int ToShow(string input)
        {
            return input.Count();
        }
    }

}
