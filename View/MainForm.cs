using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class MainForm : BorderlessWinForm
    {
        public MainForm()
        {
            InitializeComponent();
        }


        public SqlConnection Connection { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var loginForm = new LoginForm())
            {

                loginForm.ShowDialog();

                if (loginForm.DialogResult == DialogResult.Cancel) {
                    Close();
                }
            }
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        // Вызов формы OrdersForm.
        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OrdersForm ordersForm = (OrdersForm)Application.OpenForms["ordersForm"];
            if (ordersForm == null)
            {
                ordersForm = new OrdersForm();
                ordersForm.Show();
            }
            else
            {
                ordersForm.WindowState = FormWindowState.Normal;
                ordersForm.Activate();
            }
                
        }
    }
}
