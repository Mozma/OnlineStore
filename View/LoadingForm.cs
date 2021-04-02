using System;
using System.Threading;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class LoadingForm :Form//: BorderlessWinForm
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

/*        public Thread State = new Thread(ShowLoadingForm)
        {
            Name = "LoadingForm",
            Priority = ThreadPriority.Lowest,
            IsBackground = true
        };
        static void ShowLoadingForm()
        {
            using (LoadingForm loadingForm = new LoadingForm())
            {
                loadingForm.ShowDialog();
            }
        }
*/
    }
}
