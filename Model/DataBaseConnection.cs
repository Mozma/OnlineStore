using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineStore.View
{
    // Класс для хранения настроек параметров соединения.
    static class DataBaseConnection
    {
        public static SqlConnection Connection { get; set; }
        //public static string InitialCatalog { get; set; }
        //public static string DataSource { get; set; }


        //static DataBaseConnection() 
        //{
        //    InitialCatalog = "MarketDB";
        //    DataSource = @"USERPC";
        //}

    }
}
