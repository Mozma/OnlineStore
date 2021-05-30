using OnlineStore.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUpGui();   
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateItem();           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Метод настройки названий и кнопок.
        /// </summary>
        void SetUpGui() 
        {
            employeesDataGridView.Columns[0].HeaderText = "Ид сотрудника";
            employeesDataGridView.Columns[1].HeaderText = "Логин";
            employeesDataGridView.Columns[2].HeaderText = "ФИО";
            employeesDataGridView.Columns[3].HeaderText = "Телефон";
            employeesDataGridView.Columns[4].HeaderText = "Должность";
        }  


        /// <summary>
        /// Загрузка данных в контекст.
        /// </summary>
        void LoadData()
        {
            using (MarketDBEntities context = new MarketDBEntities())
            {
                var query = from employee in context.Employees
                            select new
                            {
                                EmployeeID = employee.Employee_id,
                                Login = employee.User.Login,
                                FullName = employee.Full_name,
                                Phone = employee.Phone,
                                Position = employee.Position
                            };

                employeesDataGridView.DataSource = query.ToList();
            }
            employeesDataGridView.Refresh();
        }
        
        /// <summary>
        /// Вызов формы для добавления записи с контролем ошибок.
        /// </summary>
        void AddItem() 
        {
            var editForm = new EmployeesEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                employeesDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Вызов формы для обновление выбранной записи с контролем ошибок.
        /// </summary>
        void UpdateItem() 
        {
            if (employeesDataGridView.CurrentCell == null)
                return;

            if (employeesDataGridView.SelectedRows.Count > 0)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    int index = employeesDataGridView.SelectedRows[0].Index;
                    Employee selectedItem = marketDBEntities.Employees.Find(employeesDataGridView[0, index].Value);

                    var editForm = new EmployeesEditForm(selectedItem);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        /// <summary>
        /// Удаление выбранной строки с подтверждением удаления и контролем ошибок.
        /// </summary>
        void DeleteItem() 
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (var marketDBEntities = new MarketDBEntities())
                {
                    try
                    {
                        int index = employeesDataGridView.SelectedRows[0].Index;
                        Employee selectedItem = marketDBEntities.Employees.Find(employeesDataGridView[0, index].Value);

                        marketDBEntities.Employees.Remove(selectedItem);
                        marketDBEntities.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        Helper.PostError(ex.GetBaseException().Message);
                    }
                }
            }
        }
    }
}
