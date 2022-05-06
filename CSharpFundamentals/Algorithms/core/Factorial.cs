using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class Factorial
    {
        public static void CalculateFactorial(int n)
        {
            Console.WriteLine("Factorial");
            Console.WriteLine($"Factorial de 5: {GetFactorial(5)}");
        }
        public static int GetFactorial(int number)
        {
            int auxFact = 1;
            int[] array = Enumerable.Repeat(auxFact, number).ToArray();
            //Console.WriteLine(String.Join(",", array));

            var fact = array.Select(n => auxFact++)
                            .Aggregate(1, (acc, num) => acc * num);

            return fact;
        }
    }
}
