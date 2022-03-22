using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Weather_app_MVC.Models;
using Weather_app_MVC.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.IO.Compression;

namespace Weather_app_MVC.Controllers
{
    public class WeatherController : Controller
    {


        static WeatherSearchDataViewModel _weatherViewModel = new WeatherSearchDataViewModel();


        private IWebHostEnvironment Environment;
        string languageFilePath = "SupportedLanguages.json";
        string cityDataURL = "http://bulk.openweathermap.org/sample/city.list.json.gz";
        string api_root = "https://api.openweathermap.org/data/2.5/weather";


        public WeatherController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }



        // Actions

        public IActionResult Index()
        {

            InitUnits();
            LoadLanguages();
            LoadSessionData();

            return View(_weatherViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CityList(string searchText)
        {

            if (searchText == null) { return BadRequest(); }

            List<City> cities = new List<City>();

            cities = await GetCityList();

            return PartialView("_CityList", cities.FindAll(x => x.Name.ToLower().Contains(searchText.ToLower())));

        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherData(string city, string lon, string lat, string unit, string lang, string apikey)
        {
            if (city == null || lon == null || lat == null || unit == null || lang == null || apikey == null) { return BadRequest(); }
            if (city == String.Empty || lon == String.Empty || lat == String.Empty || unit == String.Empty || lang == String.Empty || apikey == String.Empty) { return BadRequest(); }

            HttpContext.Session.SetString("selectedUnit", unit);
            HttpContext.Session.SetString("selectedLanguage", lang);
            HttpContext.Session.SetString("apiKey", apikey);

            string requestURL = $"{api_root}?lat={lat}&lon={lon}&appid={apikey}&units={unit.ToLower()}&lang={lang}";

            WeatherDataViewModel weatherDataViewModel = new WeatherDataViewModel();

            weatherDataViewModel.Unit = _weatherViewModel.Units.Find(x => x.Name.ToLower()==unit.ToLower());

            HttpClient client = new HttpClient();

            try
            {

                Stream stream = await client.GetStreamAsync(requestURL);
                StreamReader streamReader = new StreamReader(stream);

                JsonReader reader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();
                weatherDataViewModel.CurrentWeather = serializer.Deserialize<CurrentWeather>(reader);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }


            return PartialView("_WeatherData", weatherDataViewModel);
        }


        public void LoadSessionData()
        {

            _weatherViewModel.selectedUnit = HttpContext.Session.GetString("selectedUnit");
            _weatherViewModel.selectedLanguage = HttpContext.Session.GetString("selectedLanguage");
            _weatherViewModel.apiKey = HttpContext.Session.GetString("apiKey");
        }

        // Unit list

        public void InitUnits()
        {


            _weatherViewModel.Units.Add(new Unit("K", "m/s", "Default"));
            _weatherViewModel.Units.Add(new Unit("°C", "m/s", "Metric"));
            _weatherViewModel.Units.Add(new Unit("°F", "mph", "Imperial"));

        }



        // Language List

        void LoadLanguages()
        {

            try
            {
                Stream stream = new FileStream(Path.Combine(this.Environment.WebRootPath, languageFilePath), FileMode.Open);
                StreamReader streamReader = new StreamReader(stream);
                JsonReader reader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();
                _weatherViewModel.Languages = serializer.Deserialize<List<Language>>(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        // City list

        async Task<List<City>> GetCityList()
        {

            List<City> cities = new List<City>();
            Uri cityDataUri = new Uri(cityDataURL);

            HttpClient client = new HttpClient();

            try
            {

                byte[] response = await client.GetByteArrayAsync(cityDataUri);

                using (Stream stream = new MemoryStream(response))
                {

                    using (Stream decompressedStream = DecompressCityList(stream))
                    {
                        cities = LoadCityList(decompressedStream);
                    }


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }

            return cities;

        }


        Stream DecompressCityList(Stream compressedStream)
        {

            Stream outputStream = new MemoryStream();

            try
            {
                using (GZipStream decompressor = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    decompressor.CopyTo(outputStream);
                }

                outputStream.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return outputStream;
        }


        List<City> LoadCityList(Stream stream)
        {

            List<City> cities = new List<City>();

            try
            {
                StreamReader streamReader = new StreamReader(stream);

                JsonReader reader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();
                cities = serializer.Deserialize<List<City>>(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return cities;

        }



    }
}
