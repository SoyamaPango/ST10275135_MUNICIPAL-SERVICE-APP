namespace MunicipalServicesApp.Models
{
    public class Event
    {
        public string Id { get; set; } // unique id (string)
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public string Location { get; set; }

        public Event(string id, string title, string category, string description, System.DateTime date, string location)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Date = date;
            Location = location;
        }

        public override string ToString() => $"{Title} ({Category}) on {Date:g} at {Location}";
    }
}
