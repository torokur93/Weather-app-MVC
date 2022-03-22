namespace Weather_app_MVC.Models
{
    public class Unit
    {
        public string TemperatureSymbol { get; set; }
        public string VelocitySymbol { get; set; }
        public string Name { get; set; }

        public Unit()
        {
            TemperatureSymbol = string.Empty;
            VelocitySymbol = string.Empty;
            Name = string.Empty;
        }

        public Unit(string temperatureSymbol, string velocitySymbol, string name)
        {
            TemperatureSymbol = temperatureSymbol;
            VelocitySymbol = velocitySymbol;
            Name = name;
        }
    }
}
