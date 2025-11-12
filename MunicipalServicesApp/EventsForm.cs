using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class EventsForm : Form
    {
        private Dictionary<string, List<Event>> eventsByCategory = new Dictionary<string, List<Event>>();

        
        private Stack<string> searchHistory = new Stack<string>();

        private Queue<Event> recentEvents = new Queue<Event>();

        private HashSet<string> uniqueCategories = new HashSet<string>();

        public EventsForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadAllEvents();
        }

        private void LoadCategories()
        {
            comboCategory.Items.Clear();
            var cats = EventRepository.GetAllCategories();

            uniqueCategories = new HashSet<string>(cats); // Ensure no duplicates
            foreach (var c in uniqueCategories)
                comboCategory.Items.Add(c);
        }

        private void LoadAllEvents()
        {
            dgvEvents.DataSource = null;
            var allEvents = EventRepository.GetAll().ToList();
            dgvEvents.DataSource = allEvents;

            eventsByCategory = allEvents
                .GroupBy(e => e.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cat = comboCategory.SelectedItem != null ? comboCategory.SelectedItem.ToString() : "";
            string search = txtSearch.Text.Trim();
            DateTime date = datePicker.Value.Date;

            if (!string.IsNullOrEmpty(search))
                searchHistory.Push(search);

            var allEvents = EventRepository.GetAll();
            var results = new List<Event>();

            foreach (var ev in allEvents)
            {
                string evCat = ev.Category ?? "";
                bool matchCategory = string.IsNullOrEmpty(cat) || evCat.Equals(cat, StringComparison.OrdinalIgnoreCase);
                bool matchSearch = string.IsNullOrEmpty(search) ||
                                   (ev.Title != null && ev.Title.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (ev.Description != null && ev.Description.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
                bool matchDate = ev.Date.Date == date;

                if (matchCategory && matchSearch && matchDate)
                {
                    results.Add(ev);

                    
                    recentEvents.Enqueue(ev);
                    if (recentEvents.Count > 5)
                        recentEvents.Dequeue();
                }
            }

            dgvEvents.DataSource = null;
            dgvEvents.DataSource = results;

            UpdateRecommendations(search);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            comboCategory.SelectedIndex = -1;
            datePicker.Value = DateTime.Today;
            LoadCategories();
            LoadAllEvents();
            lstRecommendations.Items.Clear();
            searchHistory.Clear();
            recentEvents.Clear();
        }

        private void UpdateRecommendations(string searchQuery)
        {
            lstRecommendations.Items.Clear();

            string lastCategory = null;
            var searchedEvent = EventRepository.GetAll()
                .FirstOrDefault(ev => ev.Title.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0);

            if (searchedEvent != null)
                lastCategory = searchedEvent.Category;

            List<Event> relatedEvents = new List<Event>();
            if (!string.IsNullOrEmpty(lastCategory) && eventsByCategory.ContainsKey(lastCategory))
                relatedEvents = eventsByCategory[lastCategory];

            var recommendations = relatedEvents
                .Where(ev => ev.Title.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
                .Concat(EventRepository.GetAll().Where(ev =>
                    ev.Title.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0))
                .Distinct()
                .Take(5)
                .ToList();

            if (recommendations.Count == 0)
            {
                lstRecommendations.Items.Add("No recommendations available.");
            }
            else
            {
                foreach (var ev in recommendations)
                    lstRecommendations.Items.Add($"{ev.Title} ({ev.Date:d}) - {ev.Category}");
            }

            if (recentEvents.Count > 0)
            {
                lstRecommendations.Items.Add("");
                lstRecommendations.Items.Add(" Recently Viewed:");
                foreach (var r in recentEvents)
                    lstRecommendations.Items.Add($"• {r.Title}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var main = new MainForm();
            main.Show();
            this.Close();
        }
    }
}
