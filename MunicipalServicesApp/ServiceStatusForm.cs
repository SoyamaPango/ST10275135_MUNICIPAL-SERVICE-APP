using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp.Forms
{
    public partial class ServiceStatusForm : Form
    {
        private BinarySearchTree bst = new BinarySearchTree();
        private AVLTree avl = new AVLTree();
        private MinHeap heap = new MinHeap();
        private Graph graph = new Graph();

        public ServiceStatusForm()
        {
            InitializeComponent();
            BuildStructures();
            DisplayPriorityView();
        }

        // Build BST, AVL, Heap, and Graph from repository data
        private void BuildStructures()
        {
            bst = new BinarySearchTree();
            avl = new AVLTree();
            heap = new MinHeap();
            graph = new Graph();

            var all = ServiceRequestRepository.GetAll();
            foreach (var r in all)
            {
                // Insert into BST (keyed by Id)
                bst.Insert(r);

                // Insert into AVL Tree (keyed by DateSubmitted)
                avl.Insert(r);

                // Insert into heap (priority by DateSubmitted; older = higher)
                heap.Insert(r);
            }

            // Build sample dependencies for demo
            for (int i = 0; i < all.Count - 1; i++)
            {
                graph.AddEdge(all[i].Id, all[i + 1].Id);
            }
        }

        // Display requests sorted by heap (older first)
        private void DisplayPriorityView()
        {
            dgvServiceStatus.Rows.Clear();
            var sorted = heap.GetAllSortedByPriority();
            foreach (var r in sorted)
            {
                dgvServiceStatus.Rows.Add(r.Id, r.Title, r.Status, r.DateSubmitted.ToString("yyyy-MM-dd"));
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BuildStructures();
            DisplayPriorityView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearchId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Enter a Request ID to search.", "Input required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var found = bst.Search(id);
            if (found != null)
            {
                MessageBox.Show($"Found request:\n\nID: {found.Id}\nTitle: {found.Title}\nStatus: {found.Status}\nDate: {found.DateSubmitted:g}",
                    "Request Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Request with ID '{id}' not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowDeps_Click(object sender, EventArgs e)
        {
            string id = txtSearchId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Enter a Request ID to view dependencies.", "Input required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var traversal = graph.DfsTraverse(id);
            if (traversal == null || traversal.Count == 0)
            {
                MessageBox.Show("No dependencies found for this request.", "Dependencies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Dependency traversal starting from {id}:\n\n{string.Join(" -> ", traversal)}",
                "Dependencies (DFS)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnShowResolved_Click(object sender, EventArgs e)
        {
            // Example: filter resolved requests
            dgvServiceStatus.Rows.Clear();
            var resolved = ServiceRequestRepository.GetByStatus("Resolved");
            foreach (var r in resolved)
            {
                dgvServiceStatus.Rows.Add(r.Id, r.Title, r.Status, r.DateSubmitted.ToString("yyyy-MM-dd"));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var m = new MainForm();
            m.Show();
            this.Close();
        }
    }
}
