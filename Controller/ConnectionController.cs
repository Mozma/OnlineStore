using OnlineStore.Model;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Odbc;

namespace OnlineStore.Controller
{
    class ConnectionController
    {
        /// <summary>
        /// Создание или обновление подключения 
        /// </summary>
        /// <param name="username">Логин</param>
        /// <param name="password">Пароль</param>
       /* public static SqlConnection MakeConnection(string username, string password)
        {
            var connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = DataBaseConnection.DataSource;
            connectionString.InitialCatalog = DataBaseConnection.InitialCatalog;
            connectionString.UserID = username;
            connectionString.Password = password;
            DataBaseConnection.Connection = new SqlConnection(connectionString.ToString());

            return new SqlConnection(connectionString.ToString());
        }
       */
        public static OdbcConnection MakeConnection(string username, string password)
        {
            var connectionString = new OdbcConnectionStringBuilder();

            connectionString.Dsn = "OnlineStore";
            connectionString.Add("Uid", username);
            connectionString.Add("Pwd", password);
            
            return new OdbcConnection(connectionString.ToString());
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

                //MessageBox.Show(connection.State.ToString());   // Для отладки.
            }

        }


    }
}
