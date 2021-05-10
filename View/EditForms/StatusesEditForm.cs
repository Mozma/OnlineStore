using OnlineStore.Controller;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class StatusesEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private String oldKey;
        private Status status;
        private bool isNewRow = false;

        public StatusesEditForm()
        {
            InitializeComponent();
        }

        public StatusesEditForm(Status status) : this()
        {
            isNewRow = status == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
                       
            if (isNewRow)
            {
                this.status = new Status();
            }
            else 
            {
                this.status = status;
                oldKey = status.Statuse_code;
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
                        context.Statuses.Add(status);
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
            using (SqlConnection connection = new SqlConnection(DataBaseConnection.Connection.ConnectionString))
            {
                string sql = $"Update Admin.Statuses SET " +
                        $"Statuse_code='{status.Statuse_code}'" +
                        $", Statuse_name='{status.Statuse_name}'" +
                        $", Description={(status.Description == null ? "NULL" : '\'' + status.Description + '\'') }" +
                        $" Where Statuse_code='{oldKey}'";

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
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            if (isNewRow)
            {
                statusCodeTextBox.Text = "";
                statusNameTextBox.Text = "";
                descriptionTextBox.Text = "";
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
            statusCodeTextBox.Text = status.Statuse_code;
            statusNameTextBox.Text = status.Statuse_name;
            descriptionTextBox.Text = status.Description == null ? "":status.Description;
        }

        /// <summary>
        ///  Заполнение экземпляра типа данными из полей формы.
        /// </summary>
        /// <returns>Возвращает true, если экземпляр типа заполнен успешно.</returns>
        private bool ConstructItem()
        {
            if (ValidateItems())
            {
                status.Statuse_code = statusCodeTextBox.Text;
                status.Statuse_name = statusNameTextBox.Text;
                status.Description = descriptionTextBox.Text.Equals("") ? null : descriptionTextBox.Text;

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

            if (String.IsNullOrWhiteSpace(statusCodeTextBox.Text))
            {
                error += "Код не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(statusNameTextBox.Text))
            {
                error += "Название не указано.\n";
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
