using System.Text.Json.Serialization;

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

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }

    public class WeatherData
    {
        
        public long Dt { get; set; }
        public MainData Main { get; set; }
        public List<Weather> Weather { get; set; }

    }

    public class MainData
    {
        [JsonPropertyName("Celcius Temperature")]
        public double TempCelsius => Math.Round(Temp - 273.15);
        [JsonPropertyName("Kelvin Temperature")]
        public double Temp { get; set; }
        
        [JsonIgnore]
        public double TempMin { get; set; }
        [JsonIgnore]
        public double TempMax { get; set; }
        
        public int Humidity { get; set; }
    }

    public class Weather
    {

        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
    }

}
