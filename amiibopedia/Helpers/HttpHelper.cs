using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace amiibopedia.Helpers
{
    public class HttpHelper<T>
    {
        public HttpHelper()
        {

        }

        public async Task<T> GetServiceDataAsync(string serviceAddress)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(serviceAddress);
            var response =
                await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResult =
                await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }
    }
}
