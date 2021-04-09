using OnlineStore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class EmployeesEditForm : Form
    {
        private String titleAdd = "Добавление новой записи";
        private String titleEdit = "Редактирование записи";

        private Int32 oldKey;
        private Employee employee;
        private bool isNewRow = false;

        public EmployeesEditForm()
        {
            InitializeComponent();
        }

        public EmployeesEditForm(Employee employee) : this()
        {
            isNewRow = employee == null ? true : false;
            this.Text = isNewRow ? titleAdd : titleEdit;
            
            LoadData();
            
            if (isNewRow)
            {
                this.employee = new Employee();
            }
            else 
            {
                this.employee = employee;
                oldKey = employee.Employee_id;
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
                        context.Employees.Add(employee);
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
                var employee = entities.Employees.SingleOrDefault(b => b.Employee_id == oldKey);
                if (employee != null)
                {
                    employee.Employee_id = this.employee.Employee_id;
                    employee.User_id = this.employee.User_id;
                    employee.Full_name = this.employee.Full_name;
                    employee.Phone = this.employee.Phone;
                    employee.Position = this.employee.Position;

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
                phoneTextBox.Text = "";
                positionTextBox.Text = "";
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
            fullNameTextBox.Text = employee.Full_name;
            phoneTextBox.Text = employee.Phone;
            positionTextBox.Text = employee.Position;

            userComboBox.SelectedValue = employee.User_id;
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
                        var newID = (from employee in entities.Employees select employee.Employee_id).Max() + 1;
                        employee.Employee_id = newID;
                    }
                }
                else
                {
                    employee.Employee_id = oldKey;
                }
                employee.User_id = Convert.ToInt32(userComboBox.SelectedValue);
                employee.Full_name = fullNameTextBox.Text;
                employee.Phone = phoneTextBox.Text;
                employee.Position = positionTextBox.Text;

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

            if (String.IsNullOrWhiteSpace(positionTextBox.Text))
            {
                error += "Должность не указана.\n";
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
