using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions
{
    public class JsonTest
    {
        public void MakeApiCall()
        {
            Console.WriteLine("Making an api call...");

            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.plutools.pw/v1/servers");
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Result: " + result);
            }
            Console.ReadLine();
        }
    }
}
