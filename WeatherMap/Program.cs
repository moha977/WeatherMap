using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;

namespace WeatherMap
{
   public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            string key = File.ReadAllText("appsettings.json");
            var api_key = JObject.Parse(key).GetValue("api_key").ToString();
            while (true)
            {
                Console.WriteLine("Welcome To Weather Map");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Enter Your City Name:");
                var city_name = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_key}";
                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a diffrent city?  Yes/No");
               var answer = Console.ReadLine();
                if (answer.ToLower() == "yes")
                {
                    Console.WriteLine(formattedResponse);                                                                            
                }
                else
                {
                    break;
                }

            }
        }
    }
}
