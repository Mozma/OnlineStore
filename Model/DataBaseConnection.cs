using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace OnlineStore.View
{
    // Класс для хранения настроек параметров соединения.
    static class DataBaseConnection
    {
        public static SqlConnection Connection { get; set; }
        public static string EFConnection { get; set; }
        public static string Username { get; set; }

    }
}
