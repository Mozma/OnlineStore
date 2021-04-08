using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class UsersEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private Int32 oldKey;
        private User user;
        private bool isNewRow = false;

        public UsersEditForm()
        {
            InitializeComponent();
        }

        public UsersEditForm(User user) : this()
        {
            isNewRow = user == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
            
            LoadData();
            
            if (isNewRow)
            {
                this.user = new User();
            }
            else 
            {
                this.user = user;
                oldKey = user.User_id;
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
                        context.Users.Add(user);
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
                var user = entities.Users.SingleOrDefault(b => b.User_id == oldKey);
                if (user != null)
                {
                    user.User_id = this.user.User_id;
                    user.Login = this.user.Login;
                    user.Password = this.user.Password;
                    user.Role_code = this.user.Role_code;

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
                List<Role> roles = (from role in entities.Roles select role).ToList();

                roleComboBox.DataSource = roles;
                roleComboBox.SelectedIndex = -1;
                roleComboBox.DisplayMember = "Name";
                roleComboBox.ValueMember = "Role_code";
            }
        }

        /// <summary>
        /// Сброс к начальным значениям.
        /// </summary>
        private void ResetItems()
        {
            if (isNewRow)
            {
                roleComboBox.SelectedIndex = -1;
                loginTextBox.Text = "";
                passwordTextBox.Text = "";
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
            loginTextBox.Text = user.Login;
            passwordTextBox.Text = user.Password;
            roleComboBox.SelectedValue = user.Role_code;
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
                        user.User_id = newID;
                    }
                }
                else
                {
                    user.User_id = oldKey;
                }
                
                user.Login = loginTextBox.Text;
                user.Password = passwordTextBox.Text;
                user.Role_code = roleComboBox.SelectedValue.ToString();

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


            if (String.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                error += "Логин не указан.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                error += "Пароль не указан.\n";
                flag = false;
            }

            if (roleComboBox.SelectedIndex == -1)
            {
                error += "Роль не выбрана.\n";
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
