using System;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp.Services
{
    public static class EventRepository
    {
        private static CustomBST<DateTime, CustomLinkedList<Event>> eventsByDate = new CustomBST<DateTime, CustomLinkedList<Event>>();

        private static CustomBST<string, CustomLinkedList<Event>> eventsByCategory = new CustomBST<string, CustomLinkedList<Event>>();

        static EventRepository()
        {
            // Demo events
            Add(new Event("E1", "Farmers Market", "Markets", "Fresh produce and crafts", DateTime.Today.AddDays(2), "Town Square"));
            Add(new Event("E2", "Roadworks Update", "Announcements", "Temporary roadworks on Main St.", DateTime.Today.AddDays(1), "Main St."));
            Add(new Event("E3", "Concert in the Park", "Entertainment", "Local bands perform", DateTime.Today.AddDays(10), "Bayview Park"));
            Add(new Event("E4", "Water Maintenance", "Announcements", "Planned maintenance across the city", DateTime.Today.AddDays(3), "Citywide"));
            Add(new Event("E5", "Art Exhibition", "Arts", "Local artists showcase their work", DateTime.Today.AddDays(5), "Community Hall"));
            Add(new Event("E6", "Blood Donation Drive", "Health", "Support our local blood bank", DateTime.Today.AddDays(7), "City Clinic"));
            Add(new Event("E7", "Community Clean-Up", "Environment", "Join us to clean up the riverside", DateTime.Today.AddDays(4), "Riverside Park"));
            Add(new Event("E8", "Fire Safety Workshop", "Education", "Learn fire safety tips from experts", DateTime.Today.AddDays(6), "Fire Station"));
            Add(new Event("E9", "Heritage Day Parade", "Cultural", "Celebrate our diverse heritage", DateTime.Today.AddDays(12), "Main Street"));
            Add(new Event("E10", "Youth Soccer Tournament", "Sports", "High school teams compete", DateTime.Today.AddDays(9), "City Stadium"));
            Add(new Event("E11", "Load Shedding Update", "Announcements", "Schedule for next week's power outages", DateTime.Today.AddDays(2), "Citywide"));
            Add(new Event("E12", "Book Fair", "Education", "Discover new authors and titles", DateTime.Today.AddDays(8), "Library Grounds"));
            Add(new Event("E13", "Health Awareness Walk", "Health", "5km walk to promote healthy living", DateTime.Today.AddDays(11), "Seaside Promenade"));
            Add(new Event("E14", "Animal Adoption Day", "Community", "Find a furry friend to take home", DateTime.Today.AddDays(13), "SPCA Centre"));
            Add(new Event("E15", "Water Conservation Talk", "Environment", "Tips to save water at home", DateTime.Today.AddDays(14), "Civic Centre"));

        }

        public static void Add(Event e)
        {
            // By date 
            DateTime keyDate = e.Date.Date;
            var list = eventsByDate.Find(keyDate);
            if (list == null) list = new CustomLinkedList<Event>();
            list.AddLast(e);
            eventsByDate.Insert(keyDate, list);

            // By category
            var cat = (e.Category ?? "Other").Trim().ToLowerInvariant();
            var clist = eventsByCategory.Find(cat);
            if (clist == null) clist = new CustomLinkedList<Event>();
            clist.AddLast(e);
            eventsByCategory.Insert(cat, clist);
        }

        // Retrieve events between dates inclusive
        public static CustomLinkedList<Event> GetByDateRange(DateTime start, DateTime end)
        {
            var result = new CustomLinkedList<Event>();
            foreach (var kv in eventsByDate)
            {
                var date = kv.Key;
                if (date >= start.Date && date <= end.Date)
                {
                    var list = kv.Value;
                    foreach (var ev in list) result.AddLast(ev);
                }
            }
            return result;
        }

        // Retrieve events by category 
        public static CustomLinkedList<Event> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return new CustomLinkedList<Event>();
            var key = category.Trim().ToLowerInvariant();
            var list = eventsByCategory.Find(key);
            if (list == null) return new CustomLinkedList<Event>();
            return list;
        }

        // Return all events
        public static CustomLinkedList<Event> GetAll()
        {
            var result = new CustomLinkedList<Event>();
            foreach (var kv in eventsByDate)
            {
                foreach (var ev in kv.Value) result.AddLast(ev);
            }
            return result;
        }

        // Expose categories (unique) using a CustomSet-like traversal
        public static CustomLinkedList<string> GetAllCategories()
        {
            var result = new CustomLinkedList<string>();
            foreach (var kv in eventsByCategory)
            {
                result.AddLast(kv.Key);
            }
            return result;
        }
    }
}
