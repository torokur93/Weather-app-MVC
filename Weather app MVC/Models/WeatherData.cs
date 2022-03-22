namespace Weather_app_MVC.Models
{
    public partial class CurrentWeather
    {
        public class WeatherData
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }

            public WeatherData()
            {
                Id = 0;
                Main = String.Empty;
                Description = String.Empty;
                Icon = String.Empty;
            }

        }
    }
}
