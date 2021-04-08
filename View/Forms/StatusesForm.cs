using OnlineStore.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class StatusesForm : Form
    {
        public StatusesForm()
        {
            InitializeComponent();
        }

        private void StatusesForm_Load(object sender, EventArgs e)
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
            statusesDataGridView.Columns[0].HeaderText = "Код роли";
            statusesDataGridView.Columns[1].HeaderText = "Название роли";
            statusesDataGridView.Columns[2].HeaderText = "Уровень доступа";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from status in context.Statuses
                            select new
                            {
                                StatusCode = status.Statuse_code,
                                StatusName = status.Statuse_name,
                                Description = status.Description
                             };
                ;

                statusesDataGridView.DataSource = query.ToList();
            }
            statusesDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new StatusesEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                statusesDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (statusesDataGridView.CurrentCell == null)
                return;

            if (statusesDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = statusesDataGridView.SelectedRows[0].Index;
                    Status selectedItem = marketDBEntities.Statuses.Find(statusesDataGridView[0, index].Value.ToString());

                    var editForm = new StatusesEditForm(selectedItem);
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
                        int index = statusesDataGridView.SelectedRows[0].Index;
                        Status selectedItem = marketDBEntities.Statuses.Find(statusesDataGridView[0, index].Value.ToString());

                        marketDBEntities.Statuses.Remove(selectedItem);
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
