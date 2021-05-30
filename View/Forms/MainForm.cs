using OnlineStore.View.Chart;
using OnlineStore.View.Report;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class MainForm : BorderlessWinForm
    {
        private static Thread th;
        public MainForm()
        {

            InitializeComponent();
        }

        public SqlConnection Connection { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            switch (DataBaseConnection.Username) 
            {
                case "Admin":
                    rolesToolStripMenuItem.Visible = true;
                    usersToolStripMenuItem.Visible = true;
                    adminToolStripSeparator.Visible = true;
                    break;
                default:
                    rolesToolStripMenuItem.Visible = false;
                    usersToolStripMenuItem.Visible = false;
                    adminToolStripSeparator.Visible = false;
                    break;

            }
            this.Text += $" ({DataBaseConnection.Username})";
        }

        
        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<OrdersForm>("ordersForm");
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<UsersForm>("usersForm");
        }
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<RolesForm>("rolesForm");
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<ProductsForm>("productsForm");
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<CategoriesForm>("categoriesForm");
        }

        private void statusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<StatusesForm>("statusesForm");
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<CustomersForm>("customersForm");
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<EmployeesForm>("employeesForm");
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<DeliveriesForm>("deliveriesForm");
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<ReportForm>("reportForm");
        }

        private void sellsChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<ChartForm>("chartForm");
        }

        private void OpenThisForm<T>(string formName) where T: Form, new()
        {
            try
            {

                T form = (T)Application.OpenForms[formName];
                if (form == null) 
                {
                    th = new Thread(new ThreadStart(splash));
                    th.Start();

                    form = new T();

                    form.Show();

                    Application.OpenForms["LoadingForm"].Hide();
                    
                    th.Abort();

                    form.Activate();
                }
                else 
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void splash()
        {
            Application.Run(new LoadingForm());
        }


    }
}
