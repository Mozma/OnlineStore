using OnlineStore.Controller;
using OnlineStore.View.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersForm : Form
    {
        private int panelHeight;
        private bool panelHided;

        public OrdersForm()
        {
            InitializeComponent();
            panelHeight = pnlFilter.Height;
            pnlFilter.Height = 0;
            panelHided = true;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilter();
        }

        private void InvoiceToolStripButton_Click(object sender, EventArgs e)
        {
            using (var context = new MarketDBEntities())
            {
                try
                {
                    int index = ordersDataGridView.SelectedRows[0].Index;
                    Order order = context.Orders.Find(ordersDataGridView[0, index].Value);

                    if (order.Statuse_code == "З04")
                    {
                        var query = from cart in context.CartViews
                                    where cart.Order_id == order.Order_id
                                    select cart;

                        InoiceReportForm rptForm = new InoiceReportForm(order, query.ToList());
                        rptForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Helper.PostError(ex.Message);
                }
            }
        }

        private void tbTotalCostBeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ChangePanelHeight();
        }

        private void cbOrderDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpOrderDateBeg.Enabled = cbOrderDate.Checked ? true : false;
            dtpOrderDateEnd.Enabled = cbOrderDate.Checked ? true : false;
        }

        private void cbCompletionDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpCompletionDateBeg.Enabled = cbCompletionDate.Checked ? true : false;
            dtpCompletionDateEnd.Enabled = cbCompletionDate.Checked ? true : false;
        }

        /// <summary>
        /// Метод настройки названий и кнопок.
        /// </summary>
        void SetUpGUI()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                List<Status> statuses = (from Status in context.Statuses select Status).ToList();


                var entity = new Status();
                entity.Statuse_code = "_EMPTY_";
                entity.Statuse_name = "<Статус не выбран>";
                statuses.Insert(0, entity);

                cmbStatuses.DataSource = statuses;
                cmbStatuses.ValueMember = "Statuse_name";
                cmbStatuses.DisplayMember = "Statuse_name";
                cmbStatuses.SelectedItem = "<Статус не выбран>"; 

            }

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

            ordersDataGridView.Columns[0].Visible = false;

            ordersDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ordersDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ordersDataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Метод, который позволяет плавно изменить высоту панели с фильтрацией.
        /// </summary>
        private void ChangePanelHeight()
        {
            if (panelHided)
            {
                pnlFilter.Height = pnlFilter.Height + 7;
                if (pnlFilter.Height >= panelHeight)
                {
                    timer.Stop();
                    panelHided = false;
                    this.Refresh();
                }
            }
            else
            {
                pnlFilter.Height = pnlFilter.Height - 7;
                if (pnlFilter.Height <= 0)
                {
                    timer.Stop();
                    panelHided = true;
                    this.Refresh();
                }

            }
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
                        Helper.PostError(ex.GetBaseException().Message);
                    }
                }
            }
        }


        /// <summary>
        /// Применение фильтра.
        /// </summary>
        private void ApplyFilter()
        {
            String str = "";

            if (!String.IsNullOrEmpty(tbOrderNumber.Text))
            {
                str = String.Format("OrderNumber = '{0}'", tbOrderNumber.Text);
            }

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

                Decimal tmp;


                

                if (!String.IsNullOrWhiteSpace(tbFIOCustomer.Text))
                    query = query.Where(x => x.CustomerName.ToUpper().Contains(tbFIOCustomer.Text.Trim().ToUpper()));

                if (!String.IsNullOrWhiteSpace(tbFIOEmployee.Text))
                    query = query.Where(x => x.EmployeeName.ToUpper().Contains(tbFIOEmployee.Text.Trim().ToUpper()));

                if (!String.IsNullOrWhiteSpace(tbOrderNumber.Text))
                    query = query.Where(x => x.OrderNumber == tbOrderNumber.Text.Trim());

                if (cbOrderDate.Checked)
                    query = query.Where(x => x.OrderDate >= dtpOrderDateBeg.Value && x.OrderDate <= dtpOrderDateEnd.Value);

                if (cbCompletionDate.Checked)
                    query = query.Where(x => x.CompletionDate >= dtpCompletionDateBeg.Value && x.CompletionDate <= dtpCompletionDateBeg.Value);

                if (!cmbStatuses.SelectedValue.Equals("<Статус не выбран>"))
                    query = query.Where(x => x.Status.Equals(cmbStatuses.SelectedValue.ToString()));
                

                if (!String.IsNullOrWhiteSpace(tbTotalCostBeg.Text))
                {
                    tmp = Convert.ToDecimal(tbTotalCostBeg.Text);
                    query = query.Where(x => x.TotalCost >= tmp);
                }
                if (!String.IsNullOrWhiteSpace(tbTotalCostEnd.Text))
                {
                    tmp = Convert.ToDecimal(tbTotalCostEnd.Text);
                    query = query.Where(x => x.TotalCost <= tmp);
                }

                if (!String.IsNullOrWhiteSpace(tbPaidBeg.Text))
                {
                    tmp = Convert.ToDecimal(tbPaidBeg.Text);
                    query = query.Where(x => x.Paid >= tmp);
                }
                if (!String.IsNullOrWhiteSpace(tbPaidEnd.Text))
                {
                    tmp = Convert.ToDecimal(tbPaidEnd.Text);
                    query = query.Where(x => x.Paid <= tmp);
                }

                ordersDataGridView.DataSource = query.ToList();
           }
            ordersDataGridView.Refresh();

        }
        private void ResetFilter()
        {
            LoadData();
        }


    }
}
