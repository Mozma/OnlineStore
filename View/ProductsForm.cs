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
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {

                var query = from product in context.Products
                            join category in context.Categories
                            on product.Category_code
                            equals category.Category_Code
                            select new
                            {
                                ProductCode = product.Product_code,
                                ProductName = product.Product_name,
                                Price = product.Price,
                                CategoryCode = category.Category_Code,
                                CategoryName = category.Category_name,
                                Description = product.Description
                            };
                
                productsDataGridView.DataSource = query.ToList();



                productsDataGridView.Columns[0].HeaderText = "Код товара";
                productsDataGridView.Columns[1].HeaderText = "Название товара";
                productsDataGridView.Columns[2].HeaderText = "Цена";
                productsDataGridView.Columns[3].HeaderText = "Код категории";
                productsDataGridView.Columns[4].HeaderText = "Название категории";
                productsDataGridView.Columns[5].HeaderText = "Описание";


                //          market.Products.Load();
                //        this.productBindingSource.DataSource = market.Products.Local.ToBindingList();
            }
            this.Text = $"Обзор таблицы \"Товары\"";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataSet();
        }

        public void SetConnections()
        {

        }

        public void FillDataSet()
        {
            
        }

        /// <summary>
        /// Метод вызова формы для добавления элемента.
        /// </summary>
        public void AddProudct() 
        {


        }

    }
}
