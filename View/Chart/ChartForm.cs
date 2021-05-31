using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

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
            using (MarketDBEntities entities = new MarketDBEntities())
            {
                List<Category> category = (from Category in entities.Categories select Category).ToList();
                
                categoriesComboBox.DataSource = category;
                categoriesComboBox.DisplayMember = "Category_name";
                categoriesComboBox.ValueMember = "Category_Code";
                categoriesComboBox.SelectedIndex = 1;
            }


            dtpBeg.Value = new DateTime(dtpEnd.Value.Year - 1,dtpEnd.Value.Month, dtpEnd.Value.Day);
        }

        private void LoadData(string categoryName, DateTime dateBeg, DateTime dateEnd) {

            

            SqlConnection connection = new SqlConnection(DataBaseConnection.Connection.ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[Admin].[GetChart]";

            SqlParameter param1 = new SqlParameter("@category", SqlDbType.VarChar);
            command.Parameters.Add(param1);
            command.Parameters["@category"].Value = categoryName;

            SqlParameter param2 = new SqlParameter("@Start", SqlDbType.Date);
            command.Parameters.Add(param2);
            command.Parameters["@Start"].Value = dateBeg;

            SqlParameter param3 = new SqlParameter("@End", SqlDbType.Date);
            command.Parameters.Add(param3);
            command.Parameters["@End"].Value = dateEnd;

            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            sellsChart.DataSource = reader;


            sellsChart.Series[0].Name = categoryName;
            sellsChart.Series[0].XValueMember = "Per";
            sellsChart.Series[0].YValueMembers = "Amount";
            sellsChart.Series[0].BorderWidth = 2;
            
            sellsChart.ChartAreas[0].AxisY.MajorGrid.Interval = 1;
            sellsChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            sellsChart.DataBind();

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(categoriesComboBox.Text,dtpBeg.Value, dtpEnd.Value);
        }
    }
}
