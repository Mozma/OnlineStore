﻿using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class ProductsEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private String oldKey;
        private Product product;
        private bool isNewRow = false;

        public ProductsEditForm()
        {
            InitializeComponent();
        }

        public ProductsEditForm(Product product) : this()
        {
            isNewRow = product == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
            
            LoadData();
            
            if (isNewRow)
            {
                this.product = new Product();
            }
            else 
            {
                this.product = product;
                oldKey = product.Product_code;
                FillItems();
            }

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
                        context.Products.Add(product);
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
           if (isNewRow)
            {
                ResetItems();
            }
            else
            {
                FillItems();
            }
        }

        /// <summary>
        /// Отправка запроса на изменение данных. Используется ADO т.к. было необходимо изменять код продукта.
        /// </summary>
        private void UpdateItem()
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnection.Connection.ConnectionString))
            {
                string sql = $"Update Admin.Products SET " +
                        $"Product_code='{product.Product_code}'" +
                        $", Product_name='{product.Product_name}'" +
                        $", Price={Convert.ToDouble(product.Price)}" +
                        $", Category_code='{product.Category_code}'" +
                        $", Description={(product.Description == null ? "NULL" : '\'' + product.Description + '\'') }" +
                        $" Where Product_code='{oldKey}'";


                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Загрузка данных в контекст для выпадающего списка.
        /// </summary>
        private void LoadData()
        {
            MarketDBEntities entities = new MarketDBEntities();

            List<Category> categories = (from Category in entities.Categories select Category).ToList();

            categoryComboBox.DataSource = categories;
            categoryComboBox.SelectedIndex = -1;
            categoryComboBox.DisplayMember = "Category_name";
            categoryComboBox.ValueMember = "Category_Code";
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            categoryComboBox.SelectedIndex = -1;
            productCodeTextBox.Text = "";
            productNameTextBox.Text = "";
            priceTextBox.Text = "";
            descriptionTextBox.Text = "";
           
        }

        /// <summary>
        /// Заполнение полей формы данными из экземпляра типа.
        /// </summary>
        private void FillItems()
        {
            productCodeTextBox.Text = product.Product_code;
            productNameTextBox.Text = product.Product_name;
            priceTextBox.Text = product.Price.ToString();
            categoryComboBox.SelectedValue = product.Category_code;

            if (product.Description != null)
                descriptionTextBox.Text = product.Description;

        }

        /// <summary>
        ///  Заполнение экземпляра типа данными из полей формы.
        /// </summary>
        /// <returns>Возвращает true, если экземпляр типа заполнен успешно.</returns>
        private bool ConstructItem()
        {
            if (ValidateItems())
            {
                product.Product_code = productCodeTextBox.Text;
                product.Product_name = productNameTextBox.Text;
                product.Price = Convert.ToDecimal(priceTextBox.Text);
                product.Category_code = categoryComboBox.SelectedValue.ToString();

                if (!String.IsNullOrWhiteSpace(descriptionTextBox.Text)) 
                {
                    product.Description = descriptionTextBox.Text;
                }
                else 
                {
                    product.Description = null;
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

            if (String.IsNullOrWhiteSpace(productCodeTextBox.Text))
            {
                error += "Код не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(productNameTextBox.Text))
            {
                error += "Название не указано.\n";
                flag = false;
            }


            if (categoryComboBox.SelectedIndex == -1)
            {
                error += "Категория не выбрана.\n";
                flag = false;
            }

            try
            {
                double tmp = Convert.ToDouble(priceTextBox.Text);
            }
            catch (FormatException)
            {
                error += "Цена указана неправильно.";
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
