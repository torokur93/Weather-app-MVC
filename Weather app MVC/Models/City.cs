namespace Weather_app_MVC.Models
{

    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Coordinate Coord { get; set; }


        public City()
        {
            Id = string.Empty;
            Name = string.Empty;
            State = string.Empty;
            Country = string.Empty;
            Coord = new Coordinate();
        }

        public City(string id, string name, string state, string country, Coordinate coord)
        {
            Id = id;
            Name = name;
            State = state;
            Country = country;
            Coord = coord;
        }
    }
}
