using System;

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
    }
}
