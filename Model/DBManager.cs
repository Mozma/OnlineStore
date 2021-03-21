using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineStore.View
{
    // Класс для хранения настроек параметров соединения.
    static class DBManager
    {
        public static SqlConnection Connection { get; set; }
        public static MarketDBDataSet Market { get; set; }
       
    }
}
