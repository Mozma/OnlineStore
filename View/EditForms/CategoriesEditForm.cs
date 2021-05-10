using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View.EditForms
{
    public partial class CategoriesEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private String oldKey;
        private Category category;
        private bool isNewRow = false;

        public CategoriesEditForm()
        {
            InitializeComponent();
        }

        public CategoriesEditForm(Category category) : this()
        {
            isNewRow = category == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;

            LoadData();

            if (isNewRow)
            {
                this.category = new Category();
            }
            else
            {
                this.category = category;
                oldKey = category.Category_Code;
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
                        context.Categories.Add(category);
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
                string sql = $"Update Admin.Categories SET " +
                        $"Category_Code='{category.Category_Code}'" +
                        $", Category_name='{category.Category_name}'" +
                        $", Description={(category.Description == null ? "NULL" : '\'' + category.Description + '\'') }" +
                        $", Parentcategory_code='{category.Parentcategory_code}'" +
                        $" Where Category_Code='{oldKey}'";


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
       
            parentCategoryComboBox.DataSource = categories;
            parentCategoryComboBox.SelectedIndex = -1;
            parentCategoryComboBox.DisplayMember = "Category_name";
            parentCategoryComboBox.ValueMember = "Category_Code";
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            parentCategoryComboBox.SelectedIndex = -1;
            categoryCodeTextBox.Text = "";
            categoryNameTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        /// <summary>
        /// Заполнение полей формы данными из экземпляра типа.
        /// </summary>
        private void FillItems()
        {
            categoryCodeTextBox.Text = category.Category_Code;
            categoryNameTextBox.Text = category.Category_name;
            parentCategoryComboBox.SelectedValue = category.Parentcategory_code;

            if (category.Description != null)
                descriptionTextBox.Text = category.Description;

        }

        /// <summary>
        ///  Заполнение экземпляра типа данными из полей формы.
        /// </summary>
        /// <returns>Возвращает true, если экземпляр типа заполнен успешно.</returns>
        private bool ConstructItem()
        {
            if (ValidateItems())
            {
                category.Category_Code = categoryCodeTextBox.Text;
                category.Category_name = categoryNameTextBox.Text;
                category.Parentcategory_code = parentCategoryComboBox.SelectedValue.ToString();

                if (!String.IsNullOrWhiteSpace(descriptionTextBox.Text))
                {
                    category.Description = descriptionTextBox.Text;
                }
                else
                {
                    category.Description = null;
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

            if (String.IsNullOrWhiteSpace(categoryCodeTextBox.Text))
            {
                error += "Код не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(categoryNameTextBox.Text))
            {
                error += "Название не указано.\n";
                flag = false;
            }


            if (parentCategoryComboBox.SelectedIndex == -1)
            {
                error += "Родительская категория не выбрана.\n";
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
