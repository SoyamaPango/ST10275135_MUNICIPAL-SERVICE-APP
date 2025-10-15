using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class ServiceStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvServiceStatus;
        private Button btnBack;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvServiceStatus = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceStatus)).BeginInit();
            this.SuspendLayout();

            // dgvServiceStatus
            this.dgvServiceStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceStatus.Location = new System.Drawing.Point(12, 12);
            this.dgvServiceStatus.Name = "dgvServiceStatus";
            this.dgvServiceStatus.Size = new System.Drawing.Size(560, 300);
            this.dgvServiceStatus.TabIndex = 0;

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(12, 330);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(100, 330);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ServiceStatusForm
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvServiceStatus);
            this.Name = "ServiceStatusForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Service Request Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceStatus)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
