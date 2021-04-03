
using System.Windows.Forms;

namespace OnlineStore.Controller
{
    class Helper
    {
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
