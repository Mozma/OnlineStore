using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace OnlineStore.View.Report
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            productReportViewer.Enabled = true;
            using (MarketDBEntities context = new MarketDBEntities())
            {
                GetProductReport_ResultBindingSource.DataSource = 
                    context.GetProductReport(fromDateTimePicker.Value, toDateTimePicker.Value);
                ReportParameter[] rParams = new ReportParameter[]
                {
                    new ReportParameter("fromDate", fromDateTimePicker.Value.ToShortDateString()),
                    new ReportParameter("toDate", toDateTimePicker.Value.ToShortDateString())
                };
                productReportViewer.LocalReport.SetParameters(rParams);
            }
            
            productReportViewer.RefreshReport();
            productReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            productReportViewer.ZoomMode = ZoomMode.PageWidth; 
            
        }

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
