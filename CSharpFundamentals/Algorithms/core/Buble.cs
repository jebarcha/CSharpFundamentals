using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class Buble
    {
        //public static int[] _numbers = new int[] { 10, 2, 3, 4, 5, 1, 9 };
        public static List<int> numbers = new List<int>() { 4, 1, 5, 10, 2, 3, 4, 5, 1, 9 };

        public static void RunBuble()
        {
            Console.WriteLine("Start");
            Show();

            int extIteration = 0;
            int intIteration = 0;
            bool flag = true;
            for (int i = 0; i < numbers.Count - 1 && flag; i++)
            {
                flag = false;
                extIteration++;
                for (int j = 0; j < numbers.Count - 1 - i; j++)
                {
                    intIteration++;
                    if (numbers[j] > numbers[j + 1])
                    {
                        flag = true;
                        int aux = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = aux;
                    }
                }
            }

            Console.WriteLine($"number of external iterations {extIteration}");
            Console.WriteLine($"number of internal iterations {intIteration}");
            Console.WriteLine("After Order");
            Show();

        }

        public static void Show()
        {
            numbers.ForEach(n => Console.WriteLine(n));
            Console.WriteLine("\n");
        }

    }
}
