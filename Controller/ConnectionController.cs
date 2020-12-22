using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.Controller
{
   public class ConnectionController
   {
        
        SqlConnection connection;

        readonly string initialCatalog = "OnlineStore";
        readonly string dataSource = @"USERPC";

        public void MakeConnection(string username, string password)
        {
            var connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = dataSource;
            connectionString.InitialCatalog = initialCatalog;
            connectionString.UserID = username;
            connectionString.Password = password;

            connection = new SqlConnection(connectionString.ToString());
        }


        public void TestConnection() 
        {
            using(connection) 
            {
                connection.Open();

                MessageBox.Show(connection.State.ToString());
            }
            MessageBox.Show(connection.State.ToString());
        }


   }
}
