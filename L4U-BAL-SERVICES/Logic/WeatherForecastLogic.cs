using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace L4U_BAL_SERVICES.Logic
{
    /// <summary>
    /// ----------------------------------------- COMENTAR COM DIOGO ------------------------------
    /// </summary>
    public class WeatherForecastLogic
    {



        /// <summary>
        /// ----------------------------------------- COMENTAR COM DIOGO ------------------------------
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseFunction> GetWeatherForecast()
        {
            ActionResult<WeatherForecast> pList = await WeatherForecastService.GetWeatherForecast();

            // Build the response from the forecast object
            return BuildReponseFromList<WeatherForecast>(pList);
        }



        /// <summary>
        /// ----------------------------------------- COMENTAR COM DIOGO ------------------------------
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static ResponseFunction BuildReponseFromList<T>(ActionResult<WeatherForecast> list)
        {
            if (list.Value.Equals(null))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.INTERNALSERVERERROR,
                    Message = "Ocorreu um erro inesperado",
                    Data = null
                };
            if (list.Value.Equals(0))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.NOCONTENT,
                    Message = "Não existem registos",
                    Data = null
                };
            return new ResponseFunction
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = $"The Weather forecast for {list.Value.City.Name} on {DateTime.Now.ToShortDateString()} is:",
                Data = list.Value
            };
        }



    }
}


