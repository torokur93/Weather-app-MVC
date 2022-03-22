using Weather_app_MVC.Models;

namespace Weather_app_MVC.ViewModels
{
    public class WeatherDataViewModel
    {
        public CurrentWeather CurrentWeather { get; set; }
        public Unit Unit { get; set; }


        public WeatherDataViewModel()
        {
            CurrentWeather = new CurrentWeather();
            Unit = new Unit();
        }
    }
}
