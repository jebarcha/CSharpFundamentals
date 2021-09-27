using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharpFundamentals._10_Generics
{
    public class SendRequest<T> where T : IRequest   //this way we cannot send anything that does not implement our interface IRequest in this case
    {
        private HttpClient _client = new HttpClient();
        public async Task<T> Send(T model)
        {
            string url = "https://jsonplaceholder.typicode.com/posts/";

            var data = JsonSerializer.Serialize<T>(model);
            HttpContent content =
                new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<T>(result);
                return postResult;
            }

            return default(T);

        }
    }
}
