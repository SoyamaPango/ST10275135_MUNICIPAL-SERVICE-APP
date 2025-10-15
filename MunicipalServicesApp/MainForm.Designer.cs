using System;
using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblSubtitle;
        private FlowLayoutPanel menuPanel;
        private Button btnReportIssues;
        private Button btnEvents;
        private Button btnServiceStatus;
        private Button btnDashboard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.headerPanel = new Panel();
            this.picLogo = new PictureBox();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.menuPanel = new FlowLayoutPanel();
            this.btnReportIssues = new Button();
            this.btnEvents = new Button();
            this.btnServiceStatus = new Button();
            this.btnDashboard = new Button();

            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(10, 90, 138);
            this.headerPanel.Controls.Add(this.picLogo);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 100;

            // picLogo
            this.picLogo.Image = Properties.Resources.Bayview_flag; // make sure it exists
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.Location = new System.Drawing.Point(20, 15);
            this.picLogo.Size = new System.Drawing.Size(70, 70);

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(100, 15);
            this.lblTitle.Size = new System.Drawing.Size(500, 35);
            this.lblTitle.Text = "Bayview Metropolitan Municipality";

            // lblSubtitle
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location = new System.Drawing.Point(102, 55);
            this.lblSubtitle.Size = new System.Drawing.Size(400, 25);
            this.lblSubtitle.Text = "Digital Citizen Services Portal";

            // menuPanel
            this.menuPanel.FlowDirection = FlowDirection.TopDown;
            this.menuPanel.WrapContents = false;
            this.menuPanel.Padding = new Padding(20);
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(180, 255, 255, 255);
            this.menuPanel.Size = new System.Drawing.Size(340, 300);
            this.menuPanel.Location = new System.Drawing.Point(
                (600 - 340) / 2,
                (400 - 300) / 2
            );
            this.menuPanel.Anchor = AnchorStyles.None;

            // btnReportIssues
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportIssues.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReportIssues.Margin = new Padding(10);
            this.btnReportIssues.Size = new System.Drawing.Size(300, 50);
            this.btnReportIssues.Click += new EventHandler(this.btnReportIssues_Click);

            // btnEvents
            this.btnEvents.Text = "Local Events & Announcements";
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEvents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEvents.FlatStyle = FlatStyle.Flat;
            this.btnEvents.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnEvents.FlatAppearance.BorderSize = 2;
            this.btnEvents.Margin = new Padding(10);
            this.btnEvents.Size = new System.Drawing.Size(300, 50);
            this.btnEvents.Click += new EventHandler(this.btnEvents_Click);

            // btnServiceStatus
            this.btnServiceStatus.Text = "Service Request Status";
            this.btnServiceStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnServiceStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnServiceStatus.FlatStyle = FlatStyle.Flat;
            this.btnServiceStatus.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnServiceStatus.FlatAppearance.BorderSize = 2;
            this.btnServiceStatus.Margin = new Padding(10);
            this.btnServiceStatus.Size = new System.Drawing.Size(300, 50);
            this.btnServiceStatus.Click += new EventHandler(this.btnServiceStatus_Click);

            // btnDashboard
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDashboard.FlatStyle = FlatStyle.Flat;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDashboard.FlatAppearance.BorderSize = 2;
            this.btnDashboard.Margin = new Padding(10);
            this.btnDashboard.Size = new System.Drawing.Size(300, 50);
            this.btnDashboard.Click += new EventHandler(this.btnDashboard_Click);

            this.menuPanel.Controls.AddRange(new Control[] {
                this.btnReportIssues,
                this.btnEvents,
                this.btnServiceStatus,
                this.btnDashboard
            });

            // MainForm
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.headerPanel);
            this.BackgroundImage = Properties.Resources.gov; 
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
        }
    }
}
