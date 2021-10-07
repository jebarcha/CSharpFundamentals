using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._01_Date
{
    public static class DatesDemo1
    {
        public static void DatesDemo()
        {
            var date1 = DateTime.ParseExact("01-12-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var date2 = DateTime.ParseExact("01-12-2021", "MM-dd-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine($"{date1.Day}-{date1.Month}-{date1.Year}");
            Console.WriteLine($"{date2.Day}-{date2.Month}-{date2.Year}");


        }
    }
}
