using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace OnlineStore.View.Report
{
    public partial class InoiceReportForm : Form
    {
        List<CartView> CartViews;
        Order order;

        public InoiceReportForm()
        {
            InitializeComponent();
        }

        public InoiceReportForm(Order order, List<CartView> CartViews)
        {
            this.CartViews = CartViews;
            this.order = order;

            InitializeComponent();
        }

        private void InoiceReportForm_Load(object sender, EventArgs e)
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from cart in context.CartViews
                            where cart.Order_id == order.Order_id
                            select cart;

                ReportDataSource rds = new ReportDataSource("DataSet2", query.ToList());

                reportViewer.LocalReport.DataSources.Add(rds);


                ReportParameter[] rParams = new ReportParameter[]
                {
                    new ReportParameter("pOrderID", order.Order_id.ToString()),
                    new ReportParameter("pOrderNumber", order.Order_number),
                    new ReportParameter("pDiscountCard", order.Customer.Discount_card ),
                    new ReportParameter("pCustomerName", order.Customer.Full_name),
                    new ReportParameter("pEmployeeName", order.Employee.Full_name),
                    new ReportParameter("pOrderDate", order.Order_date.ToShortDateString()),
                    new ReportParameter("pOrderCompletionDate", order.Completion_date.ToShortDateString()),
                    new ReportParameter("pReportDate", DateTime.Now.ToShortDateString()),
                    new ReportParameter("pTotal", order.Total_cost.ToString())

                };

                reportViewer.LocalReport.SetParameters(rParams);

            }

            reportViewer.RefreshReport();
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer.RefreshReport();

        }
    }
}
