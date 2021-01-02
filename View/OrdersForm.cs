using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersForm : BorderlessWinForm
    {
        public SqlConnection Connection { get; set; }
       

        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            orderTableAdapter.Connection = Values.Connection;
            
            this.orderTableAdapter.Fill(this.marketDBDataSet.Order);

            lbTableName.Text = $"Обзор таблицы \"Заказы\"";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
