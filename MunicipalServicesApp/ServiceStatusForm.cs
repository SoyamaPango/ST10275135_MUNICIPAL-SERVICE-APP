using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class ServiceStatusForm : Form
    {
        public ServiceStatusForm()
        {
            InitializeComponent();
            LoadServiceStatus();
        }

        private void LoadServiceStatus()
        {
            dgvServiceStatus.DataSource = null;
            dgvServiceStatus.DataSource = ServiceRequestRepository.GetAll();

            dgvServiceStatus.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServiceStatus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var main = new MainForm();
            main.Show();
            this.Close();
        }
    }
}
