
using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.Controller
{
    static class Helper
    {
        public static void ChangeDatabase(
                this MarketDBEntities source,
                string initialCatalog = "",
                string dataSource = "",
                string userId = "",
                string password = "",
                bool integratedSecuity = true
            )
        {
            string configConnectionStringName = "MarketDB";

            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                var entityCnxStringBuilder = new EntityConnectionStringBuilder
                    (System.Configuration.ConfigurationManager
                        .ConnectionStrings[configNameEf].ConnectionString);

                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (entityCnxStringBuilder.ProviderConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void PostError(string msg)
        {
            int state = 0;
            string errorMsg = msg;

            if (msg.Contains("DELETE") && msg.Contains("REFERENCE"))
            {
                errorMsg = "На данное значение существует ссылка.\n" +
                           "Удаление отменено.";

            }
            else if (msg.Contains("insert") && msg.Contains("Violation of PRIMARY KEY"))
            {
                errorMsg = "Заданный ключ уже существует.\n" +
                           "Операция отменена.";
            }

            MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
