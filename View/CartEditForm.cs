using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class CartEditForm : Form
    {
        public DataRow WorkRow { get; set; }

        private bool editRow;

        public CartEditForm()
        {
            InitializeComponent();
        }

        public CartEditForm(DataRow workRow, bool editRow = false) : this()
        {
            this.WorkRow = workRow;
            this.editRow = editRow;

            SetConnections();
            FillDataSet();

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

        public void SetConnections()
        {
            productsTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            orderTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        public void FillDataSet()
        {
            this.orderTableAdapter.Fill(this.marketDBDataSet.Order);
            this.productsTableAdapter.Fill(this.marketDBDataSet.Products);
        }

        private void FillResultRow()
        {
            WorkRow[1] = productCodeComboBox.SelectedValue;
            WorkRow[2] = Convert.ToInt32(amountTextBox.Text);
            WorkRow[3] = Convert.ToDouble(priceTextBox.Text);
            WorkRow[4] = orderIdComboBox.SelectedValue;
        }

        private void FillItems()
        {
            productCodeComboBox.SelectedValue = WorkRow[1];
            amountTextBox.Text = WorkRow[2].ToString();
            priceTextBox.Text = WorkRow[3].ToString();
            orderIdComboBox.SelectedValue = WorkRow[4];
        }

        private void ResetItems()
        {
            productCodeComboBox.SelectedIndex = -1;
            amountTextBox.Text = "";
            priceTextBox.Text = "";
            orderIdComboBox.SelectedIndex = -1;
        }

        private bool ValidateItems()
        {
            bool flag = true;
            string error = "Ошибка ввода: \n";

            if (productCodeComboBox.SelectedIndex == -1)
            {
                error += "Товар не указан.\n";
                flag = false;
            }

            try
            {
                double a;
                int b;

                a = Convert.ToDouble(priceTextBox.Text);
                b = Convert.ToInt32(amountTextBox.Text);
                
            }
            catch (Exception)
            {
                error += "Данные в полях \"Количество\" или \"Цена\" указаны неверно.";
                flag = false;
            }



            if (orderIdComboBox.SelectedIndex == -1)
            {
                error += "Заказ не указан.\n";
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
