using OnlineStore.Controller;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class RolesEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private String oldKey;
        private Role role;
        private bool isNewRow = false;

        public RolesEditForm()
        {
            InitializeComponent();
        }

        public RolesEditForm(Role role) : this()
        {
            isNewRow = role == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
                       
            if (isNewRow)
            {
                this.role = new Role();
            }
            else 
            {
                this.role = role;
                oldKey = role.Role_code;
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
                        context.Roles.Add(role);
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
                string sql = $"Update Admin.Roles SET " +
                        $"Role_code='{role.Role_code}'" +
                        $", Name='{role.Name}'" +
                        $", [Level]={Convert.ToInt32(role.Level)}" +
                        $" Where Role_code='{oldKey}'";

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
                roleCodeTextBox.Text = "";
                roleNameTextBox.Text = "";
                levelTextBox.Text = "";
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
            roleCodeTextBox.Text = role.Role_code;
            roleNameTextBox.Text = role.Name;
            levelTextBox.Text = role.Level.ToString();
        }

        /// <summary>
        ///  Заполнение экземпляра типа данными из полей формы.
        /// </summary>
        /// <returns>Возвращает true, если экземпляр типа заполнен успешно.</returns>
        private bool ConstructItem()
        {
            if (ValidateItems())
            {
                role.Role_code = roleCodeTextBox.Text;
                role.Name = roleNameTextBox.Text;
                role.Level = Convert.ToInt32(levelTextBox.Text);

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

            if (String.IsNullOrWhiteSpace(roleCodeTextBox.Text))
            {
                error += "Код не указан.\n";
                flag = false;
            }
            if (String.IsNullOrWhiteSpace(roleNameTextBox.Text))
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
