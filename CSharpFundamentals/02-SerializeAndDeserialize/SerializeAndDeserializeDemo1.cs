using CSharpFundamentals.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace CSharpFundamentals._02_SerializeAndDeserialize
{
    public static class SerializeAndDeserializeDemo1
    {
        private static Beer beer = new Beer() { Name = "Beer", Alcohol = 2 };
        public static void SerializeAndDeserializeDemo()
        {
            //SerializeObject();
            DeserializeObject();
        }
        private static void SerializeObject()
        {
            string myJson = JsonSerializer.Serialize(beer);
            Console.WriteLine(myJson);
            // JSON = "{ Beer: "Beer", Alcohol: 2, AList: [] }"
            File.WriteAllText("object.txt", myJson);
        }
        private static void DeserializeObject()
        {
            string myJson = File.ReadAllText("object.txt");
            Beer beer = JsonSerializer.Deserialize<Beer>(myJson);
            Console.WriteLine($"{beer.Name} {beer.Alcohol}");

        }

    }
}
