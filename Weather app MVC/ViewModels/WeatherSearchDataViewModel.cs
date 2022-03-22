using Weather_app_MVC.Models;


namespace Weather_app_MVC.ViewModels
{
    public class WeatherSearchDataViewModel
    {
        public List<Language> Languages { get; set; }
        public List<Unit> Units { get; set; }

        public string selectedLanguage { get; set; }
        public string selectedUnit { get; set; }
        public string apiKey { get; set; }

        public WeatherSearchDataViewModel()
        {
            Languages = new List<Language>();
            Units = new List<Unit>();
            selectedLanguage = String.Empty;
            selectedUnit = String.Empty;
            apiKey = String.Empty;

        }

    }
}
