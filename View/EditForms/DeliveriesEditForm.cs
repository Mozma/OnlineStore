using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class DeliveriesEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private Int32 oldKey;
        private Delivery delivery;
        private bool isNewRow = false;

        public DeliveriesEditForm()
        {
            InitializeComponent();
        }

        public DeliveriesEditForm(Delivery delivery) : this()
        {
            isNewRow = delivery == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
            
            LoadData();
            
            if (isNewRow)
            {
                this.delivery = new Delivery();
            }
            else 
            {
                this.delivery = delivery;
                oldKey = delivery.Delivery_id;
                FillItems();
            }

            btnAccept.Text = isNewRow ? "Добавить" : "Изменить";

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
                        context.Deliveries.Add(delivery);
                        context.SaveChanges();
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

            DialogResult = DialogResult.OK;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
             ResetItems();
        }

        /// <summary>
        /// Отправка запроса на изменение данных. 
        /// </summary>
        private void UpdateItem()
        {
            using ( MarketDBEntities entities = new MarketDBEntities())
            {
                var delivery = entities.Deliveries.SingleOrDefault(b => b.Delivery_id == oldKey);
                if (delivery != null)
                {
                    delivery.Delivery_id = this.delivery.Delivery_id;
                    delivery.Track_number = this.delivery.Track_number;
                    delivery.Phone = this.delivery.Phone;
                    delivery.Delivery_type = this.delivery.Delivery_type;
                    delivery.Delivery_date = this.delivery.Delivery_date;
                    delivery.Order_id = this.delivery.Order_id;
                    delivery.Statuse_code = this.delivery.Statuse_code;

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
                List<Status> status = (from Status in entities.Statuses select Status).ToList();

                statusComboBox.DataSource = status;
                statusComboBox.DisplayMember = "Statuse_name";
                statusComboBox.ValueMember = "Statuse_code";
                statusComboBox.SelectedIndex = -1;
                
                List<Order> order = (from Order in entities.Orders select Order).ToList();

                orderNumberComboBox.DataSource = order;
                orderNumberComboBox.DisplayMember = "Order_number";
                orderNumberComboBox.ValueMember = "Order_id";
                orderNumberComboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            if (isNewRow)
            {
                statusComboBox.SelectedIndex = -1;
                orderNumberComboBox.SelectedIndex = -1;

                trackNumberTextBox.Text = "";
                phoneTextBox.Text = "";
                deliveryTypeTextBox.Text = "";
                
                deliveryDateDateTimePicker.Value = DateTime.Now;
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
            statusComboBox.SelectedValue = delivery.Statuse_code;
            orderNumberComboBox.SelectedValue = delivery.Order_id;

            trackNumberTextBox.Text = delivery.Track_number;
            phoneTextBox.Text = delivery.Phone;
            deliveryTypeTextBox.Text = delivery.Delivery_type;

            deliveryDateDateTimePicker.Value = delivery.Delivery_date;
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
                        var newID = (from delivery in entities.Deliveries select delivery.Delivery_id).Max() + 1;
                        delivery.Delivery_id = newID;
                    }
                }
                else
                {
                    delivery.Delivery_id = oldKey;
                }

                delivery.Track_number = trackNumberTextBox.Text;
                delivery.Phone = phoneTextBox.Text;
                delivery.Delivery_type = deliveryTypeTextBox.Text;

                delivery.Delivery_date = deliveryDateDateTimePicker.Value;

                delivery.Statuse_code = statusComboBox.SelectedValue.ToString();
                delivery.Order_id = Convert.ToInt32(orderNumberComboBox.SelectedValue);

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

            if (String.IsNullOrWhiteSpace(trackNumberTextBox.Text))
            {
                error += "Трек номер не указан.\n";
                flag = false;
            }


            if (String.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                error += "Телефон не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(deliveryTypeTextBox.Text))
            {
                error += "Вид доставки не указан.\n";
                flag = false;
            }

            if (orderNumberComboBox.SelectedIndex == -1)
            {
                error += "Заказ не выбран.\n";
                flag = false;
            }

            if (statusComboBox.SelectedIndex == -1)
            {
                error += "Статус не выбран.\n";
                flag = false;
            }

            if (flag == false)
            {
                MessageBox.Show(this, error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }


    }
}
