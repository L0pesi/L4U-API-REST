using L4U_BOL_MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace L4U_DAL_DATA.Services
{
    public class WeatherForecastService
    {
        public static async Task<ActionResult<WeatherForecast>> GetWeatherForecast()
        {
            try
            {

                // Call the external service to retrieve data
                var apiKey = "ed5ed7bc164fca521c299430418089eb"; //Key of the api
                var cityId = "2742032"; //Braga
                var url = $"http://api.openweathermap.org/data/2.5/forecast?id={cityId}&appid={apiKey}";
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);

                    // Deserialize the JSON response into a C# object
                    var forecast = JsonConvert.DeserializeObject<WeatherForecast>(response);

                    // Get the current date and time
                    var now = DateTime.Now;

                    // Filter the list of weather data by the current date
                    var todayForecast = forecast.List
                        .Where(data =>
                        {
                            var date = DateTimeOffset.FromUnixTimeSeconds(data.Dt).DateTime;
                            return date.Year == now.Year && date.Month == now.Month && date.Day == now.Day;
                        })
                         .Select(data => new WeatherData
                         {
                             Dt = data.Dt,
                             Main = data.Main,
                             Weather = data.Weather
                         })
                            .ToList();

                    // Create a new WeatherForecast object with the City, Cod, Message, Cnt, and filtered list of weather data for the current day
                    var todayWeatherForecast = new WeatherForecast
                    {
                        City = forecast.City,
                        Cod = forecast.Cod,
                        Message = forecast.Message,
                        Cnt = forecast.Cnt,
                        List = todayForecast
                    };

                    return todayWeatherForecast;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
