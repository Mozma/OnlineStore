using System;
using System.Threading;

namespace OnlineStore.View
{
    public partial class LoadingForm : BorderlessWinForm
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.AllowTransparency = true;
            //this.BackColor = Color.AliceBlue;
            //this.TransparencyKey = this.BackColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        static public Thread State = new Thread(ShowLoadingForm)
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

    }
}
