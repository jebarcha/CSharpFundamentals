using CSharpFundamentals.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._10_Generics
{
    public static class GenericsDemo1
    {
        public static async Task GenericsDemo()
        {
            var beer = new Beer() 
                { Name = "Ticus", Alcohol = 1 };

            SendRequest<Beer> service = new SendRequest<Beer>();
            var beerResp = await service.Send(beer);
            Console.WriteLine($"Id: {beerResp.id}");
        }
    }
}
