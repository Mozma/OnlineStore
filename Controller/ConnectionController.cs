using OnlineStore.View;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace OnlineStore.Controller
{
    class ConnectionController
    {
        /// <summary>
        /// Создание или обновление подключения 
        /// </summary>
        /// <param name="username">Логин</param>
        /// <param name="password">Пароль</param>
        public static SqlConnection MakeConnection(string username, string password)
        {
            var configConnectionString = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(configConnectionString);

            builder.UserID = username;
            builder.Password = password;
            builder.Pooling = true;

            //TODO: Убрать присвоение из логин формы.

            //  var context = new MarketDBEntities();
            // context.ChangeDatabase(userId: username, password: password);

            


            DataBaseConnection.Connection = new SqlConnection(builder.ToString());
            DataBaseConnection.Username = username;
            
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder();
            entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
            entityConnectionStringBuilder.ProviderConnectionString = builder.ToString();
            entityConnectionStringBuilder.Metadata = "res://*/marketModel.csdl|res://*/marketModel.ssdl|res://*/marketModel.msl";

            DataBaseConnection.EFConnection = entityConnectionStringBuilder.ToString();

            if (!Connect()) 
            {
                return null;
            }
            return new SqlConnection(builder.ToString());
        }

        public static bool Connect() 
        {
            try
            {
                DataBaseConnection.Connection.Open();
                return true;
            }
            catch (SqlException )
            { 
                return false;
            }finally
            {
                DataBaseConnection.Connection.Close();
            }
        }


        /// <summary>
        /// Проверка работы подключения.
        /// </summary>
        /// <returns>true - если подключение работает.</returns>
        public static bool TestConnection()
        {
            using (DataBaseConnection.Connection)
            {
                DataBaseConnection.Connection.Open();

                switch (DataBaseConnection.Connection.State.ToString())
                {
                    case "Open":
                        return true;
                    default:
                        return false;
                }


            }

        }

    }
}
