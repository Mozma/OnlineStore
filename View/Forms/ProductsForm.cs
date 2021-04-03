using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;

using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class ProductsForm : Form
    {

        BindingSource bindingSource = new BindingSource();

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            loadData();

            productsDataGridView.Columns[0].HeaderText = "Код товара";
            productsDataGridView.Columns[1].HeaderText = "Название товара";
            productsDataGridView.Columns[2].HeaderText = "Цена";
            productsDataGridView.Columns[3].HeaderText = "Код категории";
            productsDataGridView.Columns[3].HeaderText = "Название категории";
            productsDataGridView.Columns[4].HeaderText = "Описание";
            
            this.Text = $"Обзор таблицы \"Товары\"";           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new ProductsEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK) 
            {
                loadData();
                productsDataGridView.Refresh();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        public void SetConnections()
        {

        }

        public void loadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from product in context.Products
                            select new
                            {
                                ProductCode = product.Product_code,
                                ProductName = product.Product_name,
                                Price = product.Price,
                                CategoryName = product.Category.Category_name,
                                Description = product.Description
                            };

                productsDataGridView.DataSource = query.ToList();
            }
        }

        /// <summary>
        /// Метод вызова формы для добавления элемента.
        /// </summary>
        public void AddProudct() 
        {


        }


        
    }
}
