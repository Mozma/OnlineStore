using OnlineStore.Controller;
using System;
using System.Linq;
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
            usersDataGridView.Columns[0].HeaderText = "Ид";
            usersDataGridView.Columns[1].HeaderText = "Логин";
            usersDataGridView.Columns[2].HeaderText = "Пароль";
            usersDataGridView.Columns[3].HeaderText = "Роль";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from user in context.Users
                            select new
                            {
                                UserID = user.User_id,
                                Login = user.Login,
                                Password = user.Password,
                                RoleName = user.Role.Name
                            };

                usersDataGridView.DataSource = query.ToList();
            }
            usersDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new UsersEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                usersDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (usersDataGridView.CurrentCell == null)
                return;

            if (usersDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = usersDataGridView.SelectedRows[0].Index;
                    User selectedItem = marketDBEntities.Users.Find(usersDataGridView[0, index].Value);

                    var editForm = new UsersEditForm(selectedItem);
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
                        int index = usersDataGridView.SelectedRows[0].Index;
                        User selectedItem = marketDBEntities.Users.Find(usersDataGridView[0, index].Value);

                        marketDBEntities.Users.Remove(selectedItem);
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
