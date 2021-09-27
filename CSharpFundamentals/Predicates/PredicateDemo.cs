using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Predicates
{
    public class Beer
    {
        public string Name { get; set; }
        public int Alcohol { get; set; }
    }

    public static class PredicateDemo
    {
        public static void PredicateDemo1()
        {
            var numbers = new List<int> { 1, 56, 2, 3, 3, 45, 6 };
            //var predicate = new Predicate<int>(IsDividerBy2);
            var predicate = new Predicate<int>(n => n % 2 == 0);
            Predicate<int> negativePredicate = x => !predicate(x);
            var dividersBy2 = numbers.FindAll(negativePredicate);

            dividersBy2.ForEach(n => Console.WriteLine(n));
        }
        //static bool IsDividerBy2(int n) => n % 2 == 0;

        public static void PredicateBeers()
        {
            var beers = new List<Beer>() { 
                new Beer() { Name = "Ipa", Alcohol = 3 },
                new Beer() { Name = "Pale ale", Alcohol = 8 },
                new Beer() { Name = "Stout", Alcohol = 9 },
                new Beer() { Name = "Tripel", Alcohol = 15 }
            };

            //ShowBeersThatMakesMeDrunk(beers, x => x.Alcohol >= 8  //without extended method
            beers.ShowBeersThatMakesMeDrunk(x => x.Alcohol >= 8 && x.Alcohol<15);   //with extended method, we extend List :)
        }
        static void ShowBeersThatMakesMeDrunk(this List<Beer> beers, Predicate<Beer> condition)
        {

            var evilBeers = beers.FindAll(condition).ToList();
            evilBeers.ForEach(b => Console.WriteLine(b.Name));
        }
    }
}
