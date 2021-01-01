using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                if (loginForm.DialogResult == DialogResult.OK) {
                    Connection = loginForm.Connection;
                }
                else
                {
                    Close();
                }
            }
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ordersForm = new OrdersForm())
            {
                ordersForm.Connection = Connection;
                ordersForm.ShowDialog();
            }
        }
    }
}
