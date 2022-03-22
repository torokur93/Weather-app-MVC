namespace Weather_app_MVC.Models
{
    public partial class CurrentWeather
    {
        public class WindData
        {
            public float Speed { get; set; }
            public int Deg { get; set; }
            public float Gust { get; set; }
        }
    }
}
