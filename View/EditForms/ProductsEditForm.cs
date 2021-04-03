using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class ProductsEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private String oldKey;
        private Product product;
        private bool isNewRow = false;

        public ProductsEditForm()
        {
            InitializeComponent();
        }


        public ProductsEditForm(Product product):this()
        {
            isNewRow = product == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;

            if (isNewRow)
            {
                this.product = new Product();
            }
            else 
            {
                this.product = product;
                oldKey = product.Product_code;
            }
            LoadData();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            if (!ConstructItem())
                return;

            using (var context = new MarketDBEntities())
            {

                if (isNewRow)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else 
                {
                    var result = context.Products.SingleOrDefault(p => p.Product_code == oldKey);
                    if (result != null)
                    {
                        result = product;
                        context.SaveChanges();
                    }
                }
            }

            DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
          /*  if (editRow)
            {
                FillItems();
            }
            else
            {
                ResetItems();
            }*/
        }

        private void FillResultRow()
        {
            //WorkRow[0] = productCodeTextBox.Text;
            //WorkRow[1] = productNameTextBox.Text;
            //WorkRow[2] = Convert.ToDouble(priceTextBox.Text);
            //WorkRow[3] = categoryComboBox.SelectedValue;

            //if (!String.IsNullOrWhiteSpace(descriptionTextBox.Text)) 
            //{
            //    WorkRow[4] = descriptionTextBox.Text;
            //}
        }

        public void SetConnections()
        {
        }

        public void LoadData()
        {
            MarketDBEntities entities = new MarketDBEntities();

            List<Category> categories = (from Category in entities.Categories select Category).ToList();

            categoryComboBox.DataSource = categories;
            categoryComboBox.SelectedIndex = -1;
            categoryComboBox.DisplayMember = "Category_name";
            categoryComboBox.ValueMember = "Category_Code";
        }

        public void ResetItems()
        {
            //if (editRow)
            //{
            //    FillItems();
            //}
            //else
            //{
            //    categoryComboBox.SelectedIndex = -1;
            //    productCodeTextBox.Text = "";
            //    productNameTextBox.Text = "";
            //    priceTextBox.Text = "";
            //    descriptionTextBox.Text = "";
            //}
        }

        public void FillItems()
        {

            //productCodeTextBox.Text = WorkRow[0].ToString();
            //productNameTextBox.Text = WorkRow[1].ToString();
            //priceTextBox.Text = WorkRow[2].ToString();
            //categoryComboBox.SelectedValue = WorkRow[3];

            //if (WorkRow[4] != null)
            //    descriptionTextBox.Text = WorkRow[4].ToString();

        }

        private bool ConstructItem()
        {
            if (ValidateItems())
            {
                product.Product_code = productCodeTextBox.Text;
                product.Product_name = productNameTextBox.Text;
                product.Price = Convert.ToDecimal(priceTextBox.Text);
                product.Category_code = categoryComboBox.SelectedValue.ToString();

                if (!String.IsNullOrWhiteSpace(descriptionTextBox.Text)) 
                {
                    product.Description = descriptionTextBox.Text;
                }
                return true;
            }
            else 
            {
                return false;
            }
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


            if (categoryComboBox.SelectedIndex == -1)
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

        public Product getProduct() 
        {
            return product;
        }
    }
}
