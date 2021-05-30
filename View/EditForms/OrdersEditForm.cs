using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;

using System.Windows.Forms;
using System.Linq;
using System.Data.Entity.Validation;

namespace OnlineStore.View
{
    public partial class OrdersEditForm : Form
    {

        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private int oldKey;
        private int newID;
        private Order order;
        private bool isNewRow = false;
        //private bool isItemAdded = false;

        public OrdersEditForm()
        {
            InitializeComponent();
        }

        public OrdersEditForm(Order order) : this()
        {
            isNewRow = order == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;

            LoadData();

            if (isNewRow)
            {
                this.order = new Order();
            }
            else
            {
                this.order = order;
                oldKey = order.Order_id;
                FillItems();
            }

            SetUpGUI();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (!ConstructItem())
                return;

            using (var context = new MarketDBEntities())
            {
                try
                {
                    if (isNewRow)
                    {
                        context.Orders.Add(order);
                        context.SaveChanges();

                        isNewRow = false;
                        ResetItems();
                    }
                    else
                    {
                        UpdateItem();
                    }
                }
                catch (DbUpdateException ex)
                {
                    Helper.PostError(ex.InnerException.InnerException.Message);
                }
                catch (Exception ex)
                {
                    Helper.PostError(ex.Message);
                }

            }

            ChangeWindowState();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text.Equals("Выход"))
                DialogResult = DialogResult.OK;

            ResetItems();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCartItem(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCartItem();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCartItem();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCartData();
        }


        private void SetUpGUI()
        {
            btnAccept.Text = isNewRow ? "Добавить" : "Изменить";
            cancellationSignTextBox.Enabled = isNewRow ? false : true;
            paidTextBox.Enabled = isNewRow ? false : true;

            if (!isNewRow)
            {
                SetUpCart();
            }
        }
        private void SetUpCart() 
        {
            cartDataGridView.Columns[0].HeaderText = "Ид";
            cartDataGridView.Columns[1].HeaderText = "Название товара";
            cartDataGridView.Columns[2].HeaderText = "Количество";
            cartDataGridView.Columns[3].HeaderText = "Цена";
        }

        private void ChangeWindowState()
        {
            if (btnAccept.Text.Equals("Добавить") || btnAccept.Text.Equals("Изменить"))
            {
                btnAccept.Enabled = false;
                orderPanel.Enabled = false;
                cartPanel.Enabled = true;
            }
            else
            {
                orderPanel.Enabled = true;
                cartPanel.Enabled = false;
            }
            SetUpGUI();
            btnCancel.Text = "Выход";
        }


        /// <summary>
        /// Отправка запроса на изменение данных. 
        /// </summary>
        private void UpdateItem()
        {

            using (MarketDBEntities entities = new MarketDBEntities())
            {
                var order = entities.Orders.SingleOrDefault(b => b.Order_id == oldKey);
                if (order != null)
                {
                    order.Customer_id = this.order.Customer_id;
                    order.Employee_id = this.order.Employee_id;
                    order.Order_number = this.order.Order_number;
                    order.Order_date = this.order.Order_date;
                    order.Completion_date = this.order.Completion_date;
                    order.Total_cost = this.order.Total_cost;
                    order.Paid = this.order.Paid;
                    order.Statuse_code = this.order.Statuse_code;
                    order.Cancellation_sign = this.order.Cancellation_sign;

                    entities.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Загрузка данных в контекст для выпадающего списка.
        /// </summary>
        private void LoadData()
        {

            using (MarketDBEntities entities = new MarketDBEntities())
            {
                List<Customer> customers = (from Customer in entities.Customers select Customer).ToList();
                customerComboBox.DataSource = customers;
                customerComboBox.DisplayMember = "Full_name";
                customerComboBox.ValueMember = "Customer_id";
                customerComboBox.SelectedIndex = -1;


                List<Employee> employees = (from Employee in entities.Employees select Employee).ToList();

                var entity = new Employee();
                entity.Employee_id = -1;
                entity.Full_name = "<Сотрудник не выбран>";
                employees.Insert(0, entity);

                employeeComboBox.DataSource = employees;
                employeeComboBox.DisplayMember = "Full_name";
                employeeComboBox.ValueMember = "Employee_id";
                employeeComboBox.SelectedIndex = 0;

                List<Status> statuses = (from Status in entities.Statuses select Status).ToList();
                statusComboBox.DataSource = statuses;
                statusComboBox.DisplayMember = "Statuse_name";
                statusComboBox.ValueMember = "Statuse_code";
                statusComboBox.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            if (isNewRow)
            {
                customerComboBox.SelectedValue = -1;
                employeeComboBox.SelectedValue = 0;
                statusComboBox.SelectedValue = 1;

                orderNumberTextBox.Text = "";
                orderDateDateTimePicker.Value = DateTime.Now;
                completionDateDateTimePicker.Value = DateTime.Now;
                totalCostTextBox.Text = "";
                paidTextBox.Text = "";
                cancellationSignTextBox.Text = "";
            }
            else
            {
                FillItems();
            }

        }

        /// <summary>
        /// Заполнение полей формы данными из экземпляра типа.
        /// </summary>
        private void FillItems()
        {
            customerComboBox.SelectedValue = order.Customer_id;
            if (order.Employee_id != null)
            {
                employeeComboBox.SelectedValue = order.Employee_id;
            }
            else 
            {
                employeeComboBox.SelectedIndex = 0;

            }

            statusComboBox.SelectedValue = order.Statuse_code;
            
            orderNumberTextBox.Text = order.Order_number;
            orderDateDateTimePicker.Value = order.Order_date;
            completionDateDateTimePicker.Value = order.Completion_date;

            totalCostTextBox.Text = order.Total_cost.ToString();
            paidTextBox.Text = order.Paid.ToString();

            if (order.Cancellation_sign != null)
                cancellationSignTextBox.Text = order.Cancellation_sign;

            LoadCartData();
        }

        /// <summary>
        ///  Заполнение экземпляра типа данными из полей формы.
        /// </summary>
        /// <returns>Возвращает true, если экземпляр типа заполнен успешно.</returns>
        private bool ConstructItem()
        {
            if (ValidateItems())
            {

                if (isNewRow)
                {
                    using (MarketDBEntities entities = new MarketDBEntities())
                    {
                        newID = (from order in entities.Orders select order.Order_id).Max() + 1;
                        order.Order_id = newID;
                    }
                }
                else
                {
                    order.Order_id = oldKey;
                }

                order.Customer_id = Convert.ToInt32(customerComboBox.SelectedValue);
                if (employeeComboBox.SelectedIndex == 0)
                {
                    order.Employee_id = null;  
                }
                else
                {
                    order.Employee_id = Convert.ToInt32(employeeComboBox.SelectedValue);
                }


                order.Order_number = orderNumberTextBox.Text;
                order.Order_date = orderDateDateTimePicker.Value;
                order.Completion_date = completionDateDateTimePicker.Value;

                order.Total_cost = totalCostTextBox.Text.Equals("") ? 0 : Convert.ToDecimal(totalCostTextBox.Text);
                order.Paid = paidTextBox.Text.Equals("") ? 0 : Convert.ToDecimal(paidTextBox.Text);
                order.Statuse_code = statusComboBox.SelectedValue.ToString();

                if (!String.IsNullOrWhiteSpace(cancellationSignTextBox.Text))
                {
                    order.Cancellation_sign = cancellationSignTextBox.Text;
                }
                else
                {
                    order.Cancellation_sign = null;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка заполнения данных в поля формы. 
        /// </summary>
        /// <returns>True если все поля заполнены правильно. False, если ошибка. </returns>
        private bool ValidateItems()
        {
            bool flag = true;
            string error = "Ошибка ввода: \n";

            if (customerComboBox.SelectedIndex == -1)
            {
                error += "Пользователь не выбран.\n";
                flag = false;
            }

            if (statusComboBox.SelectedIndex == -1)
            {
                error += "Статус не выбран.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(orderNumberTextBox.Text))
            {
                error += "Номер заказа не указан.\n";
                flag = false;
            }

            if (flag == false)
            {
                MessageBox.Show(this, error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;

        }

        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadCartData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from cart in context.Carts
                            where cart.Order_id == order.Order_id
                            select new
                            {
                                CartID = cart.Cart_id,
                                ProductName = cart.Product.Product_name,
                                Amount = cart.Amount,
                                Price = cart.Price
                            };

                cartDataGridView.DataSource = query.ToList();
            }
            cartDataGridView.Refresh();
        }

        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddCartItem()
        {
            var editForm = new CartEditForm(null, order.Order_id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCartData();
                cartDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateCartItem()
        {
            if (cartDataGridView.CurrentCell == null)
                return;

            if (cartDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = cartDataGridView.SelectedRows[0].Index;
                    Cart selectedItem = marketDBEntities.Carts.Find(cartDataGridView[0, index].Value);

                    var editForm = new CartEditForm(selectedItem, selectedItem.Order_id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCartData();
                    }
                }
            }
        }

        /// <summary>
        /// Удаление выбранной строки с подтверждением удаления и контролем ошибок.
        /// </summary>
        void DeleteCartItem()
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    try
                    {
                        int index = cartDataGridView.SelectedRows[0].Index;
                        Cart selectedItem = marketDBEntities.Carts.Find(cartDataGridView[0, index].Value);

                        marketDBEntities.Carts.Remove(selectedItem);
                        marketDBEntities.SaveChanges();
                        LoadCartData();
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
