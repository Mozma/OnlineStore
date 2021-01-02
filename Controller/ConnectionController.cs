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
        public static SqlConnection MakeConnection(string username, string password)
        {
            var configConnectionString = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(configConnectionString);

            builder.UserID = username;
            builder.Password = password;

//            DataBaseConnection.Connection = new SqlConnection(builder.ToString());

            return new SqlConnection(builder.ToString());
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
