using Newtonsoft.Json;

namespace Weather_app_MVC.Models
{
    public partial class CurrentWeather
    {

        public Coordinate Coord { get; set; }
        public List<WeatherData> Weather { get; set; } 

        public string Base { get; set; }

        public MainData Main { get; set; }

        public int Visibility { get; set; }

        public WindData Wind { get; set; }

        public CloudsData Clouds { get; set; }
        public int Dt { get; set; }

        public SysData Sys { get; set; }
        public int Timezone { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

        public CurrentWeather()
        {
            Coord = new Coordinate();
            Weather = new List<WeatherData>();
            Base = String.Empty;
            Main = new MainData();
            Visibility = 0;
            Wind = new WindData();
            Clouds = new CloudsData();
            Dt = 0;
            Sys = new SysData();
            Timezone = 0;
            Id = 0;
            Name = String.Empty;
            Cod = 0;
        }


        public DateTime GetDateTime()
        {
            DateTime dt = DateTime.Now;

            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Dt).ToLocalTime();
        }


    }
}
