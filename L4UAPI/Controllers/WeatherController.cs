using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Response;
using Microsoft.AspNetCore.Mvc;

namespace L4U_WebService.Controllers
{
    /// <summary>
    /// This is the controller class, responsible to receive and handle all Users's request
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController
    {
        [HttpGet]
        [Route("GetWeatherForecast")]
        public async Task<ResponseFunction> GetWeatherForecast()
        {
            return await WeatherForecastLogic.GetWeatherForecast();
        }

    }
}
