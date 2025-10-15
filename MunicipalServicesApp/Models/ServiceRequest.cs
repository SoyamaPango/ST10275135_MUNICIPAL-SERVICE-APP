using System;

namespace MunicipalServicesApp.Models
{
    public class ServiceRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime DateSubmitted { get; set; }

        public ServiceRequest(string id, string title, string status, DateTime date)
        {
            Id = id;
            Title = title;
            Status = status;
            DateSubmitted = date;
        }

        public override string ToString() => $"{Title} ({Status}) submitted on {DateSubmitted:g}";
    }
}
