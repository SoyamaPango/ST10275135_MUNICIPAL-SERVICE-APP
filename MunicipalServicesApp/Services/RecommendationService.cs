using System;
using MunicipalServicesApp.DataStructures;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    public static class RecommendationService
    {
        private static CustomQueue<string> searchHistory = new CustomQueue<string>();
        private const int HistoryLimit = 50;

        public static void RecordSearch(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return;
            searchHistory.Enqueue(category.Trim().ToLowerInvariant());
            // maintain size
            while (searchHistory.Count > HistoryLimit) searchHistory.Dequeue();
        }

        public static CustomLinkedList<Event> Recommend(int topCategories = 3, int eventsPerCategory = 3)
        {
            // tally counts using BST category -> count (int)
            var counts = new CustomBST<string, int>();
            // iterate queue by dequeuing into temporary queue then re-enqueue to preserve history
            var temp = new CustomQueue<string>();
            while (!searchHistory.IsEmpty)
            {
                var c = searchHistory.Dequeue();
                temp.Enqueue(c);
                var existing = counts.Find(c);
                if (existing == null) counts.Insert(c, 1);
                else counts.Insert(c, existing + 1);
            }
            // restore
            while (!temp.IsEmpty) searchHistory.Enqueue(temp.Dequeue());

            // build priority queue
            var pq = new CustomPriorityQueue<string>();
            foreach (var kv in counts)
            {
                // kv.Value is count
                pq.Enqueue(kv.Key, kv.Value);
            }

            var recommendations = new CustomLinkedList<Event>();
            int catPicked = 0;
            while (!pq.IsEmpty && catPicked < topCategories)
            {
                var cat = pq.Dequeue();
                var events = EventRepository.GetByCategory(cat);
                int taken = 0;
                foreach (var ev in events)
                {
                    recommendations.AddLast(ev);
                    taken++;
                    if (taken >= eventsPerCategory) break;
                }
                catPicked++;
            }

            // if no history, fall back to upcoming events
            if (recommendations.Count == 0)
            {
                var all = EventRepository.GetAll();
                int i = 0;
                foreach (var e in all) { recommendations.AddLast(e); if (++i >= 10) break; }
            }

            return recommendations;
        }
    }
}
