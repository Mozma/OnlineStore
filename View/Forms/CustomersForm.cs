using OnlineStore.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
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
            customersDataGridView.Columns[0].HeaderText = "Ид клиента";
            customersDataGridView.Columns[1].HeaderText = "Логин";
            customersDataGridView.Columns[2].HeaderText = "Email";
            customersDataGridView.Columns[3].HeaderText = "ФИО";
            customersDataGridView.Columns[4].HeaderText = "Телефон";
            customersDataGridView.Columns[5].HeaderText = "Адрес";
            customersDataGridView.Columns[6].HeaderText = "Скидочная карта";
            customersDataGridView.Columns[7].HeaderText = "Дата регистрации";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from customer in context.Customers
                            select new
                            {
                                CustomerID = customer.Customer_id,
                                Login = customer.User.Login,
                                Email = customer.Email,
                                FullName = customer.Full_name,
                                Phone = customer.Phone,
                                Adress = customer.Adress,
                                DiscountCard = customer.Discount_card,
                                RegistrationDate = customer.Registration_date
                            };

                customersDataGridView.DataSource = query.ToList();
            }
            customersDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new CustomersEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                customersDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (customersDataGridView.CurrentCell == null)
                return;

            if (customersDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = customersDataGridView.SelectedRows[0].Index;
                    Customer selectedItem = marketDBEntities.Customers.Find(customersDataGridView[0, index].Value);

                    var editForm = new CustomersEditForm(selectedItem);
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
                        int index = customersDataGridView.SelectedRows[0].Index;
                        Customer selectedItem = marketDBEntities.Customers.Find(customersDataGridView[0, index].Value);

                        marketDBEntities.Customers.Remove(selectedItem);
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
