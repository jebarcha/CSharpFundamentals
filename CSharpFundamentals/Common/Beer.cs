using CSharpFundamentals._10_Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Common
{
    public class Beer : IRequest
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Alcohol { get; set; }
    }

    public static class BeerUtils
    {
        public static List<Beer> Beers()
        {
            return new List<Beer>() {
                new Beer() { Name = "Ipa", Alcohol = 3 },
                new Beer() { Name = "Tripel", Alcohol = 15 },
                new Beer() { Name = "Stout", Alcohol = 9 },
                new Beer() { Name = "Pale ale", Alcohol = 8 }
            };
        }

    }


}
