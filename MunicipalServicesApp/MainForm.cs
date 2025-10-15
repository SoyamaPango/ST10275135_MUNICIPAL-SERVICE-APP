using System;
using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            var reportIssuesForm = new ReportIssuesForm();
            reportIssuesForm.Show();
            this.Hide(); 
        }


        private void btnEvents_Click(object sender, EventArgs e)
        {
            EventsForm eventsForm = new EventsForm();
            eventsForm.ShowDialog();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            var serviceStatusForm = new ServiceStatusForm();
            serviceStatusForm.Show();
            this.Hide();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide(); //  Hides MainForm
        }

    }
}
