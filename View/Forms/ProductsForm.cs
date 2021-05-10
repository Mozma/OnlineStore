using OnlineStore.Controller;
using System;
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
            LoadData();
            SetUpGui();   
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateItem();           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Метод настройки названий и кнопок.
        /// </summary>
        void SetUpGui() 
        {
            productsDataGridView.Columns[0].HeaderText = "Код товара";
            productsDataGridView.Columns[1].HeaderText = "Название товара";
            productsDataGridView.Columns[2].HeaderText = "Цена";
            productsDataGridView.Columns[3].HeaderText = "Код категории";
            productsDataGridView.Columns[3].HeaderText = "Название категории";
            productsDataGridView.Columns[4].HeaderText = "Описание";

            productsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productsDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
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
            productsDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new ProductsEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                productsDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (productsDataGridView.CurrentCell == null)
                return;

            if (productsDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = productsDataGridView.SelectedRows[0].Index;
                    Product selectedProduct = marketDBEntities.Products.Find(productsDataGridView[0, index].Value.ToString());

                    var editForm = new ProductsEditForm(selectedProduct);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        /// <summary>
        /// Удаление выбранной строки с подтверждением удаления и контролем ошибок.
        /// </summary>
        void DeleteItem() 
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    try
                    {
                        int index = productsDataGridView.SelectedRows[0].Index;
                       // Product product = productsDataGridView.DataSource.
                        Product selectedProduct = marketDBEntities.Products.Find(productsDataGridView[0, index].Value.ToString());

                        marketDBEntities.Products.Remove(selectedProduct);
                        marketDBEntities.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        Helper.PostError(ex.Message);
                    }
                }
            }
        }
    }
}
