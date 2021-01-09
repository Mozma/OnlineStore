using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillDataSet();

            this.Text = $"Обзор таблицы \"Пользователи\"";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newRow = marketDBDataSet.Tables["Users"].NewRow();
            using (UsersEditForm usersEditForm = new UsersEditForm(newRow))
            {
                if (usersEditForm.ShowDialog(this) == DialogResult.OK)
                {
                    try { 
                        newRow = usersEditForm.WorkRow;
                        marketDBDataSet.Tables["Users"].Rows.Add(newRow);
                        usersTableAdapter.Update(marketDBDataSet);

                        MessageBox.Show(this, "Строка добавлена успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exp)
                    {
                        var mainForm = (MainForm)Application.OpenForms["mainForm"];
                        mainForm.PostError(exp.Message);

                        FillDataSet();
                    }
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //TODO: Сделать отлов ошибок при изменения строки.
            int index = usersDataGridView.CurrentCell.RowIndex;
            var workRow = marketDBDataSet.Tables["Users"].Rows[index];
            using (UsersEditForm usersEditForm = new UsersEditForm(workRow, true))
            {
                try
                {
                    if (usersEditForm.ShowDialog(this) == DialogResult.OK)
                    {

                        workRow.BeginEdit();
                        workRow = usersEditForm.WorkRow;
                        workRow.EndEdit();

                        usersTableAdapter.Update(marketDBDataSet);

                        MessageBox.Show(this, "Строка изменена успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                    
                catch (Exception exp)
                {
                    var mainForm = (MainForm)Application.OpenForms["mainForm"];
                    mainForm.PostError(exp.Message);

                    FillDataSet();
                }
        }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = usersDataGridView.CurrentCell.RowIndex;
            string msg = $"Вы действительно хотите удалить строку с Кодом = {marketDBDataSet.Tables["Users"].Rows[index][0]}?";

            if (MessageBox.Show(msg, "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try { 
                    marketDBDataSet.Tables["Users"].Rows[index].Delete();
                    usersTableAdapter.Update(marketDBDataSet);
                }
                catch (Exception exp)
                {
                    var mainForm = (MainForm)Application.OpenForms["mainForm"];
                    mainForm.PostError(exp.Message);

                    FillDataSet();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataSet();
        }

        public void SetConnections()
        {
            usersTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        public void FillDataSet()
        {
            this.usersTableAdapter.Fill(this.marketDBDataSet.Users);
        }

        


    }
}
