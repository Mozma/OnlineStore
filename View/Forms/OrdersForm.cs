using OnlineStore.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUpGUI();   
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
        void SetUpGUI() 
        {
            ordersDataGridView.Columns[0].HeaderText = "Ид";
            ordersDataGridView.Columns[1].HeaderText = "ФИО клиента";
            ordersDataGridView.Columns[2].HeaderText = "ФИО сотрудника";
            ordersDataGridView.Columns[3].HeaderText = "Номер заказа";
            ordersDataGridView.Columns[4].HeaderText = "Дата заказа";
            ordersDataGridView.Columns[5].HeaderText = "Дата завершения";
            ordersDataGridView.Columns[6].HeaderText = "Статус";
            ordersDataGridView.Columns[7].HeaderText = "Полная стоимость";
            ordersDataGridView.Columns[8].HeaderText = "Оплачено";
            ordersDataGridView.Columns[9].HeaderText = "Причина отмены";

            ordersDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ordersDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ordersDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from order in context.Orders
                            select new
                            {
                                OrderID = order.Order_id,
                                CustomerName = order.Customer.Full_name,
                                EmployeeName = order.Employee.Full_name,
                                OrderNumber = order.Order_number,
                                OrderDate = order.Order_date,
                                CompletionDate = order.Completion_date,
                                Status = order.Status.Statuse_name,
                                TotalCost = order.Total_cost,
                                Paid = order.Paid,
                                CancellationSign = order.Cancellation_sign
                            };

                ordersDataGridView.DataSource = query.ToList();
            }
            ordersDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new OrdersEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                ordersDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (ordersDataGridView.CurrentCell == null)
                return;

            if (ordersDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = ordersDataGridView.SelectedRows[0].Index;
                    Order selectedItem = marketDBEntities.Orders.Find(ordersDataGridView[0, index].Value);

                    var editForm = new OrdersEditForm(selectedItem);
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
                        int index = ordersDataGridView.SelectedRows[0].Index;
                        Order selectedItem = marketDBEntities.Orders.Find(ordersDataGridView[0, index].Value); 

                        marketDBEntities.Orders.Remove(selectedItem);
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
