﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Models
{
    public class WeatherForecast
    {

        public City City { get; set; }
        [JsonIgnore]
        public string Cod { get; set; }

        [JsonIgnore]
        public double Message { get; set; }
        [JsonIgnore]
        public int Cnt { get; set; }

        public List<WeatherData> List { get; set; }
    }

    public class City
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }

    public class WeatherData
    {
        [JsonIgnore]
        public long Dt { get; set; }
        public MainData Main { get; set; }
        public List<Weather> Weather { get; set; }

    }

    public class MainData
    {
        public double TempCelsius => Math.Round(Temp - 273.15);
        public double Temp { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
    }

}