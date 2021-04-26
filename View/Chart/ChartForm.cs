using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OnlineStore.View.Chart
{
    public partial class ChartForm : Form
    {

        
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() {

            String paramValue = "Cмартфоны";

            SqlConnection connection = new SqlConnection(DataBaseConnection.Connection.ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[Admin].[GetChart]";

            SqlParameter param1 = new SqlParameter("@category", SqlDbType.VarChar);
            command.Parameters.Add(param1);
            command.Parameters["@category"].Value = paramValue;

            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            chart1.DataSource = reader;


            chart1.Series[0].Name = paramValue;
            chart1.Series[0].XValueMember = "Per";
            chart1.Series[0].YValueMembers = "Amount";
            chart1.Series[0].BorderWidth = 2;

            chart1.DataBind();

        }
    }
}
