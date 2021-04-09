using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class CustomersEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private Int32 oldKey;
        private Customer customer;
        private bool isNewRow = false;

        public CustomersEditForm()
        {
            InitializeComponent();
        }

        public CustomersEditForm(Customer customer) : this()
        {
            isNewRow = customer == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
            
            LoadData();
            
            if (isNewRow)
            {
                this.customer = new Customer();
            }
            else 
            {
                this.customer = customer;
                oldKey = customer.Customer_id;
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
                        context.Customers.Add(customer);
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
                var customer = entities.Customers.SingleOrDefault(b => b.Customer_id == oldKey);
                if (customer != null)
                {
                    customer.Customer_id = this.customer.Customer_id;
                    customer.User_id = this.customer.User_id;
                    customer.Full_name = this.customer.Full_name;
                    customer.Email = this.customer.Email;
                    customer.Phone = this.customer.Phone;
                    customer.Adress = this.customer.Adress;
                    customer.Discount_card = this.customer.Discount_card;
                    customer.Registration_date = this.customer.Registration_date;

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
                List<User> user = (from User in entities.Users select User).ToList();

                userComboBox.DataSource = user;
                userComboBox.DisplayMember = "Login";
                userComboBox.ValueMember = "User_id";
                userComboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            if (isNewRow)
            {
                userComboBox.SelectedIndex = -1;

                fullNameTextBox.Text = "";
                emailTextBox.Text = "";
                phoneTextBox.Text = "";
                adressTextBox.Text = "";
                dicountCardTextBox.Text = "";

                registrationDateDateTimePicker.Value = DateTime.Now;
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
            fullNameTextBox.Text = customer.Full_name;
            emailTextBox.Text = customer.Email == null ? "" : customer.Email;
            phoneTextBox.Text = customer.Phone;
            adressTextBox.Text = customer.Adress == null ? "" : customer.Adress;
            dicountCardTextBox.Text = customer.Discount_card;

            registrationDateDateTimePicker.Value = customer.Registration_date;

            userComboBox.SelectedValue = customer.User_id;
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
                        var newID = (from customer in entities.Customers select customer.Customer_id).Max() + 1;
                        customer.Customer_id = newID;
                    }
                }
                else
                {
                    customer.Customer_id = oldKey;
                }
                customer.User_id = Convert.ToInt32(userComboBox.SelectedValue);
                customer.Full_name = fullNameTextBox.Text;
                customer.Email = emailTextBox.Text.Equals("") ? null : emailTextBox.Text;
                customer.Phone = phoneTextBox.Text;
                customer.Adress = adressTextBox.Text.Equals("") ? null : adressTextBox.Text;
                customer.Discount_card = dicountCardTextBox.Text;

                customer.Registration_date = registrationDateDateTimePicker.Value;

                userComboBox.SelectedIndex = -1;

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

            if (userComboBox.SelectedIndex == -1)
            {
                error += "Пользователь не выбран.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                error += "ФИО не указано.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                error += "Телефон не указан.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                error += "Номер карты не указан.\n";
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
