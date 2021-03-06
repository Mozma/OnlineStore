using OnlineStore.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    static class Program
    {
        static private DBManager manager = null;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            if (ShowLoginForm())
            {
                ShowMainForm();
            }

        }

        static private bool ShowLoginForm() 
        {
            try
            {
                manager = new DBManager();
            }
            catch (SqlException e) 
            {
                Console.WriteLine(e.StackTrace);
            }

            LoginForm loginForm = new LoginForm(manager);

            return (loginForm.ShowDialog() == DialogResult.OK);
        }

        static private void ShowMainForm()
        {
            Thread threadLoadingForm = new Thread(ShowLoadingForm)
            {
                Name = "LoadingForm",
                Priority = ThreadPriority.Lowest,
                IsBackground = true
            };


            MainForm mainForm;

            try 
            {
                threadLoadingForm.Start();

                mainForm = createMainForm(manager);
                Thread.Sleep(1000);
                threadLoadingForm.Abort();
                
                mainForm.ShowDialog();
                
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                threadLoadingForm.Abort();
            }
        }


        static private MainForm createMainForm(DBManager manager)
        {
            return new MainForm(manager);
        }

        static void ShowLoadingForm()
        {
            using (LoadingForm loadingForm = new LoadingForm())
            {
                loadingForm.ShowDialog();
            }
        }
    }
}
