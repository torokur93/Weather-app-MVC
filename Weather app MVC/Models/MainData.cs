using Newtonsoft.Json;

namespace Weather_app_MVC.Models
{
    public partial class CurrentWeather
    {
        public class MainData
        {
            public float Temp { get; set; }

            [JsonProperty(PropertyName ="feels_like")]
            public float FeelsLike { get; set; }
            public float TempMin { get; set; }
            public float TempMax { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
        }
    }
}
