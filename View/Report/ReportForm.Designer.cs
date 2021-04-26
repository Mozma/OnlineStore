
namespace OnlineStore.View.Report
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.GetProductReport_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GetProductReport_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GetProductReport_ResultBindingSource
            // 
            this.GetProductReport_ResultBindingSource.DataSource = typeof(OnlineStore.GetProductReport_Result);
            // 
            // productReportViewer
            // 
            this.productReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productReportViewer.Enabled = false;
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.GetProductReport_ResultBindingSource;
            this.productReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.productReportViewer.LocalReport.ReportEmbeddedResource = "OnlineStore.View.Report.ProductReport.rdlc";
            this.productReportViewer.Location = new System.Drawing.Point(2, 37);
            this.productReportViewer.Name = "productReportViewer";
            this.productReportViewer.ServerReport.BearerToken = null;
            this.productReportViewer.Size = new System.Drawing.Size(757, 623);
            this.productReportViewer.TabIndex = 0;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Location = new System.Drawing.Point(12, 10);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(136, 20);
            this.fromDateTimePicker.TabIndex = 1;
            this.fromDateTimePicker.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Location = new System.Drawing.Point(154, 10);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(136, 20);
            this.toDateTimePicker.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(296, 8);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(115, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Получить отчёт";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 660);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.productReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm";
            this.Text = "Отчёт по продажам";
            ((System.ComponentModel.ISupportInitialize)(this.GetProductReport_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer productReportViewer;
        private System.Windows.Forms.BindingSource GetProductReport_ResultBindingSource;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Button btnAccept;
    }
}