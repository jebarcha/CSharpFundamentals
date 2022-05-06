using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Algorithms.core
{
    public static class HammingDistance
    {
        public static void HammingDemo()
        {
            string text1 = "patitosw";
            string text2 = "paratosa";

            int distance = 0;

            if (text1.Length != text2.Length)
                throw new Exception("Lenght are different");

            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] != text2[i])
                    distance++;
            }

            Console.WriteLine($"Distance is: {distance}");
        }
    }
}
