﻿using System;
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
    public partial class OrdersForm : BorderlessWinForm
    {
        public SqlConnection Connection { get; set; }

        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
                DataSet dataSet = new DataSet();

                string command = "Select * From Admin.[Order]";

                SqlDataAdapter adapter = new SqlDataAdapter(command, Connection);
                adapter.TableMappings.Add("Table", "Order");

                adapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];
            

                lbTableName.Text = $"Обзор таблицы \"{dataSet.Tables[0].TableName}\"";
         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
