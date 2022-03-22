namespace Weather_app_MVC.Models
{
    public class Language
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Language()
        {
            Id = string.Empty;
            Name = string.Empty;
        }

        public Language(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
