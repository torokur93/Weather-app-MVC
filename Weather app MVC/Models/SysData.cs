namespace Weather_app_MVC.Models
{
    public partial class CurrentWeather
    {
        public class SysData
        {
            public int Id { get; set; }
            public int Type { get; set; }
            public string Country { get; set; }
            public int SunRise { get; set; }
            public int SunSet { get; set; }


            public SysData()
            {
                Id = 0;
                Type = 0;
                Country = String.Empty;
                SunRise = 0;
                SunSet = 0;
            }


            public DateTime GetSunRise()
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(SunRise).ToLocalTime();
            }


            public DateTime GetSunSet()
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(SunSet).ToLocalTime();
            }

        }
    }
}
