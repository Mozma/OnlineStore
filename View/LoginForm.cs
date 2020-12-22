using OnlineStore.Controller;
using OnlineStore.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class LoginForm : BorderlessWinForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var connection = new ConnectionController();

            connection.MakeConnection(tbUsername.Text, tbPassword.Text);
            connection.TestConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
