using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.Controller
{
    public static class ConnectionController
    {
        
        static SqlConnection connection;

        static string initialCatalog = "OnlineStore";
        static string dataSource = @"USERPC";
        static bool State { 
            get
            { 
                return connection.State.ToString().Equals("Open") ? true : false; 
            }
        } 

        /// <summary>
        /// Создание или обновление подключения 
        /// </summary>
        /// <param name="username">Логин</param>
        /// <param name="password">Пароль</param>
        public static void MakeConnection(string username, string password)
        {
          
                var connectionString = new SqlConnectionStringBuilder();

                connectionString.DataSource = dataSource;
                connectionString.InitialCatalog = initialCatalog;
                connectionString.UserID = username;
                connectionString.Password = password;

                connection = new SqlConnection(connectionString.ToString());
        }

        /// <summary>
        /// Проверка работы подключения.
        /// </summary>
        /// <returns>true - если подключение работает.</returns>
        public static bool TestConnection() 
        {
            using(connection) 
            {
                connection.Open();

                switch (connection.State.ToString())
                {
                    case "Open" : 
                        return true;
                    default: 
                        return false;
                }
                
                //MessageBox.Show(connection.State.ToString());   // Для отладки.
            }

        }


   }
}
