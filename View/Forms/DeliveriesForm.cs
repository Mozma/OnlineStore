using OnlineStore.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class DeliveriesForm : Form
    {
        public DeliveriesForm()
        {
            InitializeComponent();
        }

        private void DeliveriesForm_Load(object sender, EventArgs e)
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
            deliveriesDataGridView.Columns[0].HeaderText = "Ид доставки";
            deliveriesDataGridView.Columns[1].HeaderText = "Трек номер";
            deliveriesDataGridView.Columns[2].HeaderText = "Телефон";
            deliveriesDataGridView.Columns[3].HeaderText = "Вид доставки";
            deliveriesDataGridView.Columns[4].HeaderText = "Дата доставки";
            deliveriesDataGridView.Columns[5].HeaderText = "Номер заказа";
            deliveriesDataGridView.Columns[6].HeaderText = "Статус";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from delivery in context.Deliveries
                            select new
                            {
                                DeliveryID = delivery.Delivery_id,
                                TrackNumber = delivery.Track_number,
                                Phone = delivery.Phone,
                                DeliveryType = delivery.Delivery_type,
                                DeliveryDate = delivery.Delivery_date,
                                OrderNumber = delivery.Order.Order_number,
                                StatusName = delivery.Status.Statuse_name,
                                
                            };

                deliveriesDataGridView.DataSource = query.ToList();
            }
            deliveriesDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new DeliveriesEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                deliveriesDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (deliveriesDataGridView.CurrentCell == null)
                return;

            if (deliveriesDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = deliveriesDataGridView.SelectedRows[0].Index;
                    Delivery selectedItem = marketDBEntities.Deliveries.Find(deliveriesDataGridView[0, index].Value);

                    var editForm = new DeliveriesEditForm(selectedItem);
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
                        int index = deliveriesDataGridView.SelectedRows[0].Index;
                        Delivery selectedItem = marketDBEntities.Deliveries.Find(deliveriesDataGridView[0, index].Value);

                        marketDBEntities.Deliveries.Remove(selectedItem);
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
