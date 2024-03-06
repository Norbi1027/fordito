using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Headers;

namespace fordito
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Írd be a fordítandó szöveget!");
            string asd = Console.ReadLine();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
    {
        { "X-RapidAPI-Key", "2aafff4238msh42a8819a4d67bb9p1129c3jsne6571485665a" },
        { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "q", asd },
        { "target", "en" },
        { "source", "hu" },

    }),
            };
            using (var response = await client.SendAsync(request))
            {
                List<Fordito> fordito = new List<Fordito>();
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body.Replace("{\"data\":{\"translations\":[{\"translatedText\":\""," ").Replace("\"}]}}"," "));
                Console.ReadLine();
            }

        }
    }
}
