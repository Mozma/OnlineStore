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
    public partial class OrdersEditForm : Form
    {
        public OrdersEditForm()
        {
            InitializeComponent();
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void OrdersEditForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillData();
            FillComboBoxes();

        }

        private void FillComboBoxes()
        {
           statuseComboBox.SelectedIndex = -1;
           userComboBox.SelectedIndex = -1;
        }

        private void SetConnections()
        {
            usersTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            statusesTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        private void FillData()
        {
            this.usersTableAdapter.Fill(this.marketDBDataSet.Users);
            this.statusesTableAdapter.Fill(this.marketDBDataSet.Statuses);
        }
    }
}
