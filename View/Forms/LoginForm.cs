using OnlineStore.Controller;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{

    public partial class LoginForm : BorderlessWinForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private SqlConnection connection;

        // Обработка кнопки "Вход"
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Authenticate())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        /// <summary>
        /// Метод для аутентификации пользователя.
        /// </summary>
        /// <returns>Возвращает true, если данные введены верно.</returns>
        private bool Authenticate()
        {
            String login, password;    

            try
            {
                login = tbUsername.Text.Trim();
                password = tbPassword.Text;

                if (login.Length == 0 || password.Length == 0)
                {
                    throw new Exception("Логин и/или пароль не указаны.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Ошибка ввода данных",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPassword.Text = null;
                return false;
            }

            // Попытка авторизации.
            try
            {
                connection = ConnectionController.MakeConnection(login, password);
                if (connection == null)
                {
                    throw new Exception("Логин, пароли или имя БД указаны не верно.");
                }
                
                DataBaseConnection.Connection = connection;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Ошибка входа в систему",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPassword.Text = null;
                return false;
            }

            return true;
        }
    }
}
