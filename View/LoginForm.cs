using OnlineStore.Controller;
using OnlineStore.View;
using System;
using System.Windows.Forms;


namespace OnlineStore
{
    public partial class LoginForm : BorderlessWinForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Обработка кнопки "Вход"
        private void btnAccept_Click(object sender, EventArgs e)
        {
           
            if (String.IsNullOrWhiteSpace(tbUsername.Text) ||
               String.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show(this, "Поля не заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Создание подключения.
                try
                {
                    ConnectionController.MakeConnection(tbUsername.Text, tbPassword.Text);
                    ConnectionController.TestConnection();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception exp)
                {

                   MessageBox.Show(this, "Неправильный логин или пароль:\n" + exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
