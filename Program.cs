using OnlineStore.View;
using System;
using System.Threading;
using System.Windows.Forms;

namespace OnlineStore
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            ProductsForm productsForm = new ProductsForm();
            productsForm.ShowDialog();
            */


            if (ShowLoginForm())
            {
                ShowMainForm();
            }
            

        }

        /// <summary>
        /// Метод для вызова формы аутентификации
        /// </summary>
        /// <returns>Возвращает true, если аутентификация прошла успешно.</returns>
        static private bool ShowLoginForm() 
        {

            LoginForm loginForm = new LoginForm();

            return (loginForm.ShowDialog() == DialogResult.OK);
        }

        /// <summary>
        /// Метод для вызова главной формы программы.
        /// </summary>
        static private void ShowMainForm()
        {
            try 
            {

                MainForm mainForm = new MainForm();
   
                mainForm.ShowDialog();
                
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
