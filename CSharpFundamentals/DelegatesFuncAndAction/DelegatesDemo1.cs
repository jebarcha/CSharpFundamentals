
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DelegatesFuncAndAction
{
    // Delegates is to send functions as a parameter of another function
    // Delegate is a signature of a function
    public static class DelegatesDemo1
    {
        public delegate string DelegateShow(string myString);

        public static void DelegateDemo1(string cadena)
        {
            DelegateShow mostrar = ToShow;
            DoSomething(mostrar);

        }
        private static void DoSomething(DelegateShow finalFunction)
        {
            Console.WriteLine("Delegate:I do something");
            Console.WriteLine(finalFunction("It was sent from another function"));
        }
        private static string ToShow(string input)
        {
            return input.ToUpper();
        }
    }

}
