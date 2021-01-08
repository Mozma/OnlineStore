using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class ProductsEditForm : Form
    {
        public DataRow WorkRow { get; set; }
        bool editRow;

        public ProductsEditForm()
        {
            InitializeComponent();
        }

        public ProductsEditForm(DataRow workRow, bool editRow = false) : this()
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

        private void ProductsEditForm_Load(object sender, EventArgs e)
        {
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
            ResetItems();
        }

        private void FillResultRow()
        {
            WorkRow[0] = productCodeTextBox.Text;
            WorkRow[1] = productNameTextBox.Text;
            WorkRow[2] = Convert.ToDouble(priceTextBox.Text);
            WorkRow[3] = categoryComboBox.SelectedValue;

            if (!String.IsNullOrWhiteSpace(descriptionTextBox.Text)) 
            {
                WorkRow[4] = descriptionTextBox.Text;
            }
        }

        public void SetConnections()
        {
            categoriesTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        public void FillDataSet()
        {
            this.categoriesTableAdapter.Fill(this.marketDBDataSet.Categories);
        }

        public void ResetItems()
        {
            if (editRow)
            {
                FillItems();
            }
            else
            {
                categoryComboBox.SelectedIndex = -1;
                productCodeTextBox.Text = "";
                productNameTextBox.Text = "";
                priceTextBox.Text = "";
                descriptionTextBox.Text = "";
            }
        }

        public void FillItems()
        {
            productCodeTextBox.Text = WorkRow[0].ToString();
            productNameTextBox.Text = WorkRow[1].ToString();
            priceTextBox.Text = WorkRow[2].ToString();
            categoryComboBox.SelectedValue = WorkRow[3];

            if (WorkRow[4] != null)
                descriptionTextBox.Text = WorkRow[4].ToString();

        }

        private bool ValidateItems()
        {
            bool flag = true;
            string error = "Ошибка ввода: \n";

            if (String.IsNullOrWhiteSpace(productCodeTextBox.Text)) 
            {
                error += "Код не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(productNameTextBox.Text))
            {
                error += "Название не указано.\n";
                flag = false;
            }


            if(categoryComboBox.SelectedIndex == -1) 
            {
                error += "Категория не выбрана.\n";
                flag = false;
            }

            try
            {
                double tmp = Convert.ToDouble(priceTextBox.Text);
            }
            catch (FormatException)
            {
                error += "Цена указана неправильно.";
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
