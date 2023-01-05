using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace L4U_BAL_SERVICES.Logic
{
    public class WeatherForecastLogic
    {
        /*
                /// <summary>
                /// This method calls the necessary service to get all productStore and based on the response, builds up the response
                /// </summary>
                /// <param name="appPath">Application path</param>
                /// <returns>List of products</returns>
                public static async Task<ResponseFunction> GetWeatherForecast()
                {
                    ActionResult<WeatherForecast> pList = await WeatherForecastService.GetWeatherForecast();
                    var forecast = pList.Result;
                    //List<WeatherData> pList = await WeatherForecastService.GetWeatherForecast();
                    //string result = await UsersService.AddNewUser(user, connectString);

                    return BuildReponseFromForecast(forecast);
                }*/

        public static async Task<ResponseFunction> GetWeatherForecast()
        {
            ActionResult<WeatherForecast> pList = await WeatherForecastService.GetWeatherForecast();
            //var forecast = pList.Result;

            // Build the response from the forecast object
            return BuildReponseFromList<WeatherForecast>(pList);

            /*
            return new ResponseFunction
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = $"The Weather forecast for {pList.Value.City.Name} on {DateTime.Now.ToShortDateString()} is:",
                Data = pList,
            };
            */
        }


        
        /*
        /// <summary>
        /// This is a generic method to build the response object from a response list
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="list">List of generic object</param>
        /// <returns>Response object</returns>
        private static ResponseFunction BuildReponseFromList<T>(ActionResult<T> list)
        {
            if (list.Equals(null))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.INTERNALSERVERERROR,
                    Message = "Ocorreu um erro inesperado",
                    Data = null
                };
            if (list.Value.Count.Equals(0))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.NOCONTENT,
                    Message = "Não existem registos",
                    Data = null
                };
            return new ResponseFunction
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = $"Foram obtidos {list.Count} resultados",
                Data = list
            };
        }*/


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


