using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class CartEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private Int32 oldKey;
        private readonly Int32 orderID; 
        private Cart cart;
        private bool isNewRow = false;

        public CartEditForm()
        {
            InitializeComponent();
        }

        public CartEditForm(Cart cart,Int32 orderID) : this()
        {
            isNewRow = cart == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;

            LoadData();

            if (isNewRow)
            {
                this.cart = new Cart();
            }
            else
            {
                this.cart = cart;
                oldKey = cart.Cart_id;
                FillItems();
            }

            this.orderID = orderID;

            btnAccept.Text = isNewRow ? "Добавить" : "Сохранить";
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
                        context.Carts.Add(cart);
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


        private void productCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productCodeComboBox.SelectedIndex != -1)
            {
                using (MarketDBEntities entities = new MarketDBEntities())
                {
                    var product = entities.Products.SingleOrDefault(b => b.Product_code == productCodeComboBox.SelectedValue.ToString());
                    priceTextBox.Text = product.Price.ToString();
                }
            }else
            {
                priceTextBox.Text = "";
            }
        }

        /// <summary>
        /// Отправка запроса на изменение данных. 
        /// </summary>
        private void UpdateItem()
        {
            using (MarketDBEntities entities = new MarketDBEntities())
            {
                var cart = entities.Carts.SingleOrDefault(b => b.Cart_id == oldKey);
                if (cart != null)
                {
                    cart.Cart_id = this.cart.Cart_id;
                    cart.Product_code = this.cart.Product_code;
                    cart.Amount = this.cart.Amount;
                    cart.Price = this.cart.Price;
                    cart.Order_id = this.cart.Order_id;

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
                List<Product> product = (from Product in entities.Products select Product).ToList();

                productCodeComboBox.DataSource = product;
                productCodeComboBox.DisplayMember = "Product_name";
                productCodeComboBox.ValueMember = "Product_code";
                productCodeComboBox.SelectedIndex = -1;

            }
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            if (isNewRow)
            {
                productCodeComboBox.SelectedIndex = -1;
                amountTextBox.Text = "";
                priceTextBox.Text = "";
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
            amountTextBox.Text = cart.Amount.ToString();
            priceTextBox.Text = cart.Price.ToString();
            productCodeComboBox.SelectedValue = cart.Product_code;
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
                        var newID = (from user in entities.Users select user.User_id).Max() + 1;
                        cart.Cart_id = newID;
                    }
                }
                else
                {
                    cart.Cart_id = oldKey;
                }

                cart.Product_code = productCodeComboBox.SelectedValue.ToString();
                cart.Amount = Convert.ToInt32(amountTextBox.Text);
                cart.Price = Convert.ToDecimal(priceTextBox.Text);
                cart.Order_id = orderID;

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

            cart.Cart_id = this.cart.Cart_id;
            cart.Product_code = this.cart.Product_code;
            cart.Amount = this.cart.Amount;
            cart.Price = this.cart.Price;
            cart.Order_id = this.cart.Order_id;


            if (String.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                error += "Количество не указано.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(priceTextBox.Text))
            {
                error += "Цена не указана.\n";
                flag = false;
            }

            if (productCodeComboBox.SelectedIndex == -1)
            {
                error += "Продукт не выбран.\n";
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
