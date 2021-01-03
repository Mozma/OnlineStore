using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersForm : BorderlessWinForm
    {
        //   public SqlConnection Connection { get; set; }

        public OrdersForm()
        {
            InitializeComponent();
        }
        

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            orderTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            statusesTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);

            this.statusesTableAdapter.Fill(this.marketDBDataSet.Statuses);
            this.orderTableAdapter.Fill(this.marketDBDataSet.Order);

            lbTableName.Text = $"Обзор таблицы \"Заказы\"";
        }
        private void OrdersForm_Shown(object sender, EventArgs e)
        {
        //    orderTableAdapter.Connection = Values.Connection;
        //    this.orderTableAdapter.Fill(this.marketDBDataSet.Order);

        //    lbTableName.Text = $"Обзор таблицы \"Заказы\"";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ordersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ordersDataGridView.Columns[e.ColumnIndex].Name.Equals("Statuse_name"))
            {

                e.Value = GetStatusNameLookupValue(
                    ordersDataGridView.Rows[e.RowIndex].Cells["statusecodeDataGridViewTextBoxColumn"].Value.ToString());
            }
        }

        public string GetStatusNameLookupValue(string status_code) 
        {
            string status_name = "";


            DataTable dt = marketDBDataSet.Tables[5];

            foreach (DataRow row in dt.Rows)
            {
                // получаем все ячейки строки
                var cells = row.ItemArray;

                if (cells[0].ToString().Equals(status_code)) 
                {
                    status_name = cells[1].ToString();                    
                    break;
                }

            }
            return status_name;



            //string sql =
            //    "select Statuse_name from Admin.Statuses where Statuse_code = @code;";

            //using (SqlConnection con = new SqlConnection(Values.Connection.ConnectionString))
            //{

            //    SqlCommand cmd = new SqlCommand(sql, con);
            //    cmd.Parameters.Add("@code", SqlDbType.VarChar);
            //    cmd.Parameters["@code"].Value = status_code;
            //    try
            //    {
            //        con.Open();
            //        status_name = cmd.ExecuteScalar().ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            // }

        }


    }
}
