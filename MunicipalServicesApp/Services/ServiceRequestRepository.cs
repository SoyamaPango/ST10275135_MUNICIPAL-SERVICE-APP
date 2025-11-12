using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    public static class ServiceRequestRepository
    {
        private static SortedDictionary<DateTime, Queue<ServiceRequest>> requestsByDate =
            new SortedDictionary<DateTime, Queue<ServiceRequest>>();

        private static Dictionary<string, List<ServiceRequest>> requestsByStatus =
            new Dictionary<string, List<ServiceRequest>>(StringComparer.OrdinalIgnoreCase);

        private static HashSet<string> uniqueStatuses = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private static Stack<ServiceRequest> resolvedRequests = new Stack<ServiceRequest>();

        static ServiceRequestRepository()
        {
            // Demo service requests
            Add(new ServiceRequest("REQ001", "Water Leak - Main Street", "Pending", DateTime.Today.AddDays(-2)));
            Add(new ServiceRequest("REQ002", "Electricity Outage - Central", "In Progress", DateTime.Today.AddDays(-1)));
            Add(new ServiceRequest("REQ003", "Pothole Repair - Oak Ave", "Resolved", DateTime.Today));
            Add(new ServiceRequest("REQ004", "Broken Streetlight - Pine Rd", "Pending", DateTime.Today));
            Add(new ServiceRequest("REQ005", "Garbage Collection Delay", "In Progress", DateTime.Today.AddDays(-3)));
            Add(new ServiceRequest("REQ006", "Sewer Blockage - River Rd", "Pending", DateTime.Today.AddDays(-5)));
            Add(new ServiceRequest("REQ007", "Fallen Tree - Elm Street", "Resolved", DateTime.Today.AddDays(-4)));
            Add(new ServiceRequest("REQ008", "Illegal Dumping - Hilltop", "In Progress", DateTime.Today.AddDays(-2)));
            Add(new ServiceRequest("REQ009", "Street Sign Missing - Market Rd", "Pending", DateTime.Today.AddDays(-1)));
            Add(new ServiceRequest("REQ010", "Noise Complaint - Maple Ave", "Resolved", DateTime.Today.AddDays(-6)));
            Add(new ServiceRequest("REQ011", "Water Pressure Low - East End", "Pending", DateTime.Today.AddDays(-3)));
            Add(new ServiceRequest("REQ012", "Sidewalk Damage - Birch Lane", "In Progress", DateTime.Today.AddDays(-4)));
            Add(new ServiceRequest("REQ013", "Graffiti Removal - Civic Centre", "Pending", DateTime.Today.AddDays(-7)));
            Add(new ServiceRequest("REQ014", "Animal Control - Stray Dog", "Resolved", DateTime.Today.AddDays(-2)));
            Add(new ServiceRequest("REQ015", "Traffic Light Malfunction - Cross St", "In Progress", DateTime.Today.AddDays(-1)));

        }

        //  Add a new service request
        public static void Add(ServiceRequest request)
        {
            // Add to SortedDictionary (by date)
            if (!requestsByDate.ContainsKey(request.DateSubmitted))
                requestsByDate[request.DateSubmitted] = new Queue<ServiceRequest>();

            requestsByDate[request.DateSubmitted].Enqueue(request);

            // Add to Dictionary (by status)
            if (!requestsByStatus.ContainsKey(request.Status))
                requestsByStatus[request.Status] = new List<ServiceRequest>();

            requestsByStatus[request.Status].Add(request);

            // Add to Set (unique statuses)
            uniqueStatuses.Add(request.Status);

            // Push to stack if resolved
            if (request.Status.Equals("Resolved", StringComparison.OrdinalIgnoreCase))
                resolvedRequests.Push(request);
        }

        //  Get all requests 
        public static List<ServiceRequest> GetAll()
        {
            var all = new List<ServiceRequest>();
            foreach (var queue in requestsByDate.Values)
            {
                foreach (var req in queue)
                    all.Add(req);
            }
            return all;
        }

        //  Get requests by status
        public static List<ServiceRequest> GetByStatus(string status)
        {
            if (requestsByStatus.ContainsKey(status))
                return new List<ServiceRequest>(requestsByStatus[status]);
            return new List<ServiceRequest>();
        }

        //  Get unique statuses
        public static HashSet<string> GetUniqueStatuses() => uniqueStatuses;

        //  Get recently resolved 
        public static List<ServiceRequest> GetRecentResolved()
        {
            var result = new List<ServiceRequest>();
            foreach (var req in resolvedRequests)
            {
                result.Add(req);
                if (result.Count == 5) break;
            }
            return result;
        }
    }
}
