using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            
            loginForm.ShowDialog();
            
            if(loginForm.DialogResult == DialogResult.Cancel) 
            {
                Close();
            }
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ordersForm = new OrdersForm();

            ordersForm.ShowDialog();
        }
    }
}
