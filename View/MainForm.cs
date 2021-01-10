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
        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartForm cartForm = (CartForm)Application.OpenForms["cartForm"];
            OpenThisForm(cartForm);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = (UsersForm)Application.OpenForms["usersForm"];
            OpenThisForm(usersForm);
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

        public void PostError(string msg)
        {
            int state = 0;
            string errorMsg = msg;
            if (msg.Contains("DELETE")  && msg.Contains("REFERENCE")) 
            {
                errorMsg = "На данное значение существует ссылка.\n" +
                           "Удаление отменено.";
            }
            //if (msg.Contains("DELETE") && msg.Contains("REFERENCE"))
            //{
            //    errorMsg = "Нарушение уникальности первичного ключа.\n" +
            //               "Удаление отменено.";
            //}

            MessageBox.Show(this, errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }
}
