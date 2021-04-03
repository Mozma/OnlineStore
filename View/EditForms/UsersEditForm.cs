using System;
using System.Data;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class UsersEditForm : Form
    {
        public UsersEditForm()
        {
            InitializeComponent();
        }

        public DataRow WorkRow { get; set; }

        private bool editRow;

        public UsersEditForm(DataRow workRow, bool editRow = false) : this()
        {
            this.WorkRow = workRow;
            this.editRow = editRow;

            ResetItems();

            if (editRow)
            {
                this.Text = "Редактирование записи";
                btnAccept.Text = "Изменить";

                FillItems();
            }
            else
            {
                this.Text = "Добавление новой записи";
                btnAccept.Text = "Добавить";
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateItems())
            {
                FillResultRow();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (editRow) 
            {
                FillItems();
            }
            else 
            {
                ResetItems();
            }
        }

        private void FillResultRow()
        {
            WorkRow[1] = loginTextBox.Text;
            WorkRow[2] = passwordTextBox.Text;
            
            if (!(String.IsNullOrWhiteSpace(emailTextBox.Text)))
            {
                WorkRow[3] = emailTextBox.Text;
            }

            WorkRow[4] = fullNameTextBox.Text;
            WorkRow[5] = phoneTextBox.Text;

            if (!(String.IsNullOrWhiteSpace(adressTextBox.Text)))
            {
                WorkRow[6] = adressTextBox.Text;
            }

            WorkRow[7] = discountCardTextBox.Text;
            WorkRow[8] = registraitionDateDateTimePicker.Value;

        }
            private void FillItems()
        {
            loginTextBox.Text = WorkRow[1].ToString();
            passwordTextBox.Text = WorkRow[2].ToString();
            emailTextBox.Text = WorkRow[3].ToString();
            fullNameTextBox.Text = WorkRow[4].ToString();
            phoneTextBox.Text = WorkRow[5].ToString();
            adressTextBox.Text = WorkRow[6].ToString();
            discountCardTextBox.Text = WorkRow[7].ToString();
            registraitionDateDateTimePicker.Value = (DateTime)WorkRow[8];
        }

        private void ResetItems()
        {
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
            emailTextBox.Text = "";
            phoneTextBox.Text = "";
            fullNameTextBox.Text = "";
            adressTextBox.Text = "";
            discountCardTextBox.Text = "";
            registraitionDateDateTimePicker.Value = DateTime.Now;
        }

        private bool ValidateItems()
        {
            bool flag = true;
            string error = "Ошибка ввода: \n";

            if (String.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                error += "Логин не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                error += "Пароль не указан.\n";
                flag = false;
            }
            
            if (String.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                error += "ФИО не указано.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                error += "Email не указан.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(discountCardTextBox.Text))
            {
                error += "Номер скидочной карты не указан.\n";
                flag = false;
            }

            if (flag == false)
            {
                MessageBox.Show(this, error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }


    }
}
