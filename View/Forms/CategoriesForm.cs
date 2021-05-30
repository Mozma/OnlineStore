using OnlineStore.Controller;
using OnlineStore.View.EditForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
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
            categoriesDataGridView.Columns[0].HeaderText = "Код категории";
            categoriesDataGridView.Columns[1].HeaderText = "Название категории";
            categoriesDataGridView.Columns[2].HeaderText = "Описание";
            categoriesDataGridView.Columns[3].HeaderText = "Родительская категория";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from category in context.Categories
                            select new
                            {
                                CategoryCode = category.Category_Code,
                                CategoryName = category.Category_name,
                                Description = category.Description,
                                ParentCategoryName = category.Category1.Category_name
                            };

                categoriesDataGridView.DataSource = query.ToList();
            }
            categoriesDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new CategoriesEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                categoriesDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (categoriesDataGridView.CurrentCell == null)
                return;

            if (categoriesDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = categoriesDataGridView.SelectedRows[0].Index;
                    Category selectedItem = marketDBEntities.Categories.Find(categoriesDataGridView[0, index].Value.ToString());

                    var editForm = new CategoriesEditForm(selectedItem);
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
                        int index = categoriesDataGridView.SelectedRows[0].Index;
                        Category selectedItem = marketDBEntities.Categories.Find(categoriesDataGridView[0, index].Value.ToString());

                        marketDBEntities.Categories.Remove(selectedItem);
                        marketDBEntities.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        Helper.PostError(ex.GetBaseException().Message);
                    }
                }
            }
        }
    }
}
