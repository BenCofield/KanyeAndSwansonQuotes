using System;
using Newtonsoft.Json.Linq;

namespace KanyeAndRonSwanson
{
    class Program
    {
        static void Main()
        {
            var client = new HttpClient();
            var KanyeUrl = "https://api.kanye.rest";
            var SwansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";


            for (int i = 0; i < 5; i++)
            {
                var KanyeResponse = client.GetStringAsync(KanyeUrl).Result;
                var KanyeQuote = JObject.Parse(KanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"\nKanye: {KanyeQuote}");

                var SwansonResponse = client.GetStringAsync(SwansonUrl).Result;
                var ronQuote = JArray.Parse(SwansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
                Console.WriteLine($"\nSwanson: {ronQuote}");

            }
        }
    }
}