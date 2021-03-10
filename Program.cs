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
                LoadingForm.State.Start();

                MainForm mainForm = new MainForm();
                Thread.Sleep(500); 

                LoadingForm.State.Abort();
   
                mainForm.ShowDialog();
                
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadingForm.State.Abort();
            }
        }
    }
}
