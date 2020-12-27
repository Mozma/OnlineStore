using OnlineStore.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersForm : Form
    {
        public SqlConnection Connection { get; set; }

        public OrdersForm()
        {
            InitializeComponent();
        }

        public OrdersForm(SqlConnection Connection) : this()
        {
            this.Connection = Connection;
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            this.productViewTableAdapter.Connection = Connection;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketDBDataSet.ProductView". При необходимости она может быть перемещена или удалена.
            this.productViewTableAdapter.Fill(this.marketDBDataSet.ProductView);

        }
    }
}
