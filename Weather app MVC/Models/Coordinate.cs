using Newtonsoft.Json;

namespace Weather_app_MVC.Models
{
    public class Coordinate
    {
        [JsonProperty(PropertyName = "lon")]
        public float Longitude { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }

        public Coordinate()
        {
            Longitude = 0;
            Latitude = 0; 
        }

        public Coordinate(float lon, float lat)
        {
            Longitude = lon;
            Latitude = lat;
        }
    }
}
