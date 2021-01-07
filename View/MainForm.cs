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

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = (OrdersForm)Application.OpenForms["ordersForm"];
            OpenThisForm(ordersForm);
        }
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = (ProductsForm)Application.OpenForms["productsForm"];
            OpenThisForm(productsForm);
        }

        private void OpenThisForm<T>(T form) where T: Form, new() 
        {
            if (form == null) 
            {
                form = new T();
                form.Show();
            }
            else 
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
            }
        }


    }
}
