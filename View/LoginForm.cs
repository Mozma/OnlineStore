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

        private DBManager manager;
        private SqlConnection connection;

        public LoginForm(DBManager manager) : this()
        {
            this.manager = manager;
        }

        // Обработка кнопки "Вход"
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Authenticate())
            {
                DialogResult = DialogResult.OK;
            }


            //if (String.IsNullOrWhiteSpace(tbUsername.Text) ||
            //   String.IsNullOrWhiteSpace(tbPassword.Text))
            //{
            //    MessageBox.Show(this, "Поля не заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    // Создание подключения.
            //    try
            //    {
            //        Values.Connection = ConnectionController.MakeConnection(tbUsername.Text, tbPassword.Text);
            //        DialogResult = DialogResult.OK;
            //    }
            //    catch (Exception exp)
            //    {

            //       MessageBox.Show(this, "Неправильный логин или пароль:\n" + exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }


       
        }
        private bool Authenticate()
        {
            String login = null;
            String password = null;
            // Получение логина и пароля.
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
               connection = ConnectionController.MakeConnection(login,password);
                if(connection == null) 
                {
                    throw new Exception("Логин, пароли или имя БД указаны не верно.");
                }
                manager.Connection = connection;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Ошибка ввхода в систему",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPassword.Text = null;
                return false;
            }

            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
