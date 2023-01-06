using L4U_BOL_MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace L4U_DAL_DATA.Services
{
    /// <summary>
    /// -----------------------------------------COMENTAR COM DIOGO ---------------------------------
    /// </summary>





    /// <summary>
    /// -----------------------------------------COMENTAR COM DIOGO ---------------------------------
    /// </summary>

    public class WeatherForecastService
    {
        public static async Task<ActionResult<WeatherForecast>> GetWeatherForecast()
        {
            try
            {

                // Call the external service to retrieve data
                var apiKey = "ed5ed7bc164fca521c299430418089eb"; //Key of the api
                var cityId = "2742032"; //Braga
                var dt = DateTime.Now; //Actual Date
                var url = $"http://api.openweathermap.org/data/2.5/forecast?id={cityId}&appid={apiKey}&dt={dt}&cnt={8}&lang=pt"; //url 
                //https://api.openweathermap.org/data/2.5/forecast?id=2742032&appid=ed5ed7bc164fca521c299430418089eb&dt=2023-01-06T01:07:10Z
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);

                    // Deserialize the JSON response into a C# object
                    var forecast = JsonConvert.DeserializeObject<WeatherForecast>(response);

                    // Get the current date and time
                    //var now = DateTime.Now;

                    var todayForecast = forecast.List;


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
