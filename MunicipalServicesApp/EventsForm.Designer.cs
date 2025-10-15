using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class EventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvEvents;
        private ComboBox comboCategory;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh; 
        private ListBox lstRecommendations;
        private Button btnBack;
        private Label lblCategory;
        private Label lblSearch;
        private Label lblDate;
        private Label lblRecommendations;
        private DateTimePicker datePicker; 

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEvents = new DataGridView();
            this.comboCategory = new ComboBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.btnRefresh = new Button();
            this.lstRecommendations = new ListBox();
            this.btnBack = new Button();
            this.lblCategory = new Label();
            this.lblSearch = new Label();
            this.lblDate = new Label();
            this.lblRecommendations = new Label();
            this.datePicker = new DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();

            // dgvEvents
            this.dgvEvents.Location = new System.Drawing.Point(20, 100);
            this.dgvEvents.Size = new System.Drawing.Size(600, 300);
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // comboCategory
            this.comboCategory.Location = new System.Drawing.Point(120, 20);
            this.comboCategory.Size = new System.Drawing.Size(150, 25);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(400, 20);
            this.txtSearch.Size = new System.Drawing.Size(150, 25);

            // datePicker
            this.datePicker.Location = new System.Drawing.Point(120, 60);
            this.datePicker.Size = new System.Drawing.Size(150, 25);
            this.datePicker.Format = DateTimePickerFormat.Short;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(400, 60);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnRefresh (far right next to Back)
            this.btnRefresh.Location = new System.Drawing.Point(780, 420);
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lstRecommendations
            this.lstRecommendations.Location = new System.Drawing.Point(650, 100);
            this.lstRecommendations.Size = new System.Drawing.Size(200, 300);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(20, 420);
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // Labels
            this.lblCategory.Location = new System.Drawing.Point(20, 20);
            this.lblCategory.Text = "Category:";
            this.lblCategory.AutoSize = true;

            this.lblSearch.Location = new System.Drawing.Point(320, 20);
            this.lblSearch.Text = "Search:";
            this.lblSearch.AutoSize = true;

            this.lblDate.Location = new System.Drawing.Point(20, 60);
            this.lblDate.Text = "Date:";
            this.lblDate.AutoSize = true;

            this.lblRecommendations.Location = new System.Drawing.Point(650, 70);
            this.lblRecommendations.Text = "Recommended:";
            this.lblRecommendations.AutoSize = true;

            // Add Controls
            this.ClientSize = new System.Drawing.Size(880, 470);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblRecommendations);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Local Events & Announcements";

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
