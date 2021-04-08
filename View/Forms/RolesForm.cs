using OnlineStore.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class RolesForm : Form
    {
        public RolesForm()
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
            rolesDataGridView.Columns[0].HeaderText = "Код роли";
            rolesDataGridView.Columns[1].HeaderText = "Название роли";
            rolesDataGridView.Columns[2].HeaderText = "Уровень доступа";
            //productsDataGridView.Columns[3].HeaderText = "Код категории";
            //productsDataGridView.Columns[3].HeaderText = "Название категории";
            //productsDataGridView.Columns[4].HeaderText = "Описание";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from role in context.Roles
                            select new
                            {
                                RoleCode = role.Role_code,
                                RoleName = role.Name,
                                Level = role.Level
                             };
                ;

                rolesDataGridView.DataSource = query.ToList();
            }
            rolesDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new RolesEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                rolesDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (rolesDataGridView.CurrentCell == null)
                return;

            if (rolesDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = rolesDataGridView.SelectedRows[0].Index;
                    Role selectedProduct = marketDBEntities.Roles.Find(rolesDataGridView[0, index].Value.ToString());

                    var editForm = new RolesEditForm(selectedProduct);
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
                        int index = rolesDataGridView.SelectedRows[0].Index;
                        Role selectedProduct = marketDBEntities.Roles.Find(rolesDataGridView[0, index].Value.ToString());

                        marketDBEntities.Roles.Remove(selectedProduct);
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
