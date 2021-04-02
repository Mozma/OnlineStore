﻿using System;
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

        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        
        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   OpenThisForm<OrdersForm>("ordersForm");
        }
        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  OpenThisForm<CartForm>("cartForm");
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
         //  OpenThisForm<UsersForm>("usersForm");
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThisForm<ProductsForm>("productsForm");
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

                    th.Abort();

            }
            else 
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
            }
            }
                catch (Exception) { }
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


        public void splash()
        {
            Application.Run(new LoadingForm());
        }
    }
}
