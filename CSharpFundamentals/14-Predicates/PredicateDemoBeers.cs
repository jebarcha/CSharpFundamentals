using CSharpFundamentals.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.Predicates
{
    public static class PredicateDemoBeers
    {
        public static void PredicateBeers()
        {
            var beers = BeerUtils.Beers();
            //var beers = new List<Beer>() { 
            //    new Beer() { Name = "Ipa", Alcohol = 3 },
            //    new Beer() { Name = "Pale ale", Alcohol = 8 },
            //    new Beer() { Name = "Stout", Alcohol = 9 },
            //    new Beer() { Name = "Tripel", Alcohol = 15 }
            //};

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
