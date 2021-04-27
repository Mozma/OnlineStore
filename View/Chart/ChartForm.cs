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
            
            LoadData(categoriesComboBox.Text);
        }

        private void LoadData(string paramValue) {

            

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
            sellsChart.DataSource = reader;


            sellsChart.Series[0].Name = paramValue;
            sellsChart.Series[0].XValueMember = "Per";
            sellsChart.Series[0].YValueMembers = "Amount";
            sellsChart.Series[0].BorderWidth = 2;

            sellsChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            sellsChart.DataBind();

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(categoriesComboBox.Text);
        }
    }
}
