using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillDataSet();

            this.Text = $"Обзор таблицы \"Корзина\"";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newRow = marketDBDataSet.Tables["Cart"].NewRow();
            using (CartEditForm cartEditForm = new CartEditForm(newRow))
            {
                if (cartEditForm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        newRow = cartEditForm.WorkRow;
                        marketDBDataSet.Tables["Cart"].Rows.Add(newRow);
                        cartTableAdapter.Update(marketDBDataSet);

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
            int index = cartDataGridView.CurrentCell.RowIndex;
            var workRow = marketDBDataSet.Tables["Cart"].Rows[index];
            using (CartEditForm cartEditForm = new CartEditForm(workRow, true))
            {
                try
                {
                    if (cartEditForm.ShowDialog(this) == DialogResult.OK)
                    {

                        workRow.BeginEdit();
                        workRow = cartEditForm.WorkRow;
                        workRow.EndEdit();

                        cartTableAdapter.Update(marketDBDataSet);

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
            int index = cartDataGridView.CurrentCell.RowIndex;
            string msg = $"Вы действительно хотите удалить строку с Кодом = {marketDBDataSet.Tables["Users"].Rows[index][0]}?";

            if (MessageBox.Show(msg, "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    marketDBDataSet.Tables["Cart"].Rows[index].Delete();
                    cartTableAdapter.Update(marketDBDataSet);
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
            cartTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        public void FillDataSet()
        {
            this.cartTableAdapter.Fill(this.marketDBDataSet.Cart);
        }



    }
}
