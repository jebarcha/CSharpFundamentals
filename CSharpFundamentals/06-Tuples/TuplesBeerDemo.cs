using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._06_Tuples
{
    public static class TuplesBeerDemo
    {
        public static void TuplesBeer()
        {
            var beerDB = BeerDB();
            beerDB.Add();
            beerDB.Update();
            beerDB.Delete();
        }
        private static (Action Add, Action Update, Action Delete ) BeerDB()
        {
            return (
                () => Console.WriteLine("Add"),
                () => Console.WriteLine("Edit"),
                () => Console.WriteLine("Delete")
            );
        }
    }
}
