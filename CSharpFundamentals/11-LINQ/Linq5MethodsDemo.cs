using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._11_LINQ
{
    public static class Linq5MethodsDemo
    {
        public static void Linq5Methods_1_Union()
        {
            var numbers1 = new int[] { 1, 2, 3, 4, 5, 6};
            var numbers2 = new int[] { 6, 7, 8, 9, 10 };

            var numberUnion = numbers1.Union(numbers2);

            numberUnion.ToList().ForEach(e => Console.WriteLine(e));

        }

        public static void Linq5Methods_2_Zip()
        {
            var numbers1 = new int[] { 1, 2, 3, 4, 5, 6 };
            var numberWords = new string[] { "One", "Two", "Three", "Four", "Five", "Six" };

            var numbersWithZip = numbers1.Zip(numberWords, (n, w) =>
            {
                return n + " " + w;
            });

            numbersWithZip.ToList().ForEach(e => Console.WriteLine(e));
        }

        public static void Linq5Methods_3_Join()
        {
            var beers = new List<(string Name, int IdBrand)>
            {
                ("Pikantus", 1),
                ("Dunkel", 1),
                ("London Porter", 2),
                ("London Pride", 2)
            };

            var brand = new List<(int IdBrand, string Name)>
            {
                (1, "Erdinger"),
                (2, "Fuller's")
            };

            var beerDetail = beers.Join(brand, b => b.IdBrand, br => br.IdBrand, (beer, brand) =>
            {
                return new
                {
                    Name = beer.Name,
                    BrandName = brand.Name
                };
            });

            beerDetail.ToList().ForEach(e => Console.WriteLine(e));
        }

        public static void Linq5Methods_4_All()
        {
            var numbers1 = new int[] { 1, 2, 3, 4, 5, 6 };
            var numbers2 = new int[] { 6, 7, 8, 9, 10 };

            Console.WriteLine(numbers1.All(e => e > 5));
            Console.WriteLine(numbers2.All(e => e > 5));

        }

        public static void Linq5Methods_5_SelectMany()
        {
            // Shen we have Lists inside our objects

            var beerBrand = new List<(string Name, List<string> Beers)>
            {
                ("Erdinger", new List<string> { "Pikatus", "Dunkel" }),
                ("Delirium", new List<string> { "Tremes", "Red" })
            };

            var beerDetail = beerBrand.SelectMany(beerBrand => beerBrand.Beers,
                (beerBrand, beer) => new { beerBrand, beer } 
                ).Select(beerBrand => 
                    new
                    {
                        BrandName = beerBrand.beerBrand.Name,
                        BeerName = beerBrand.beer
                    }
                );

            beerDetail.ToList().ForEach(e => Console.WriteLine($"{e.BrandName} {e.BeerName}"));
        }
    }
}
