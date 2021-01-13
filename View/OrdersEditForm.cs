using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersEditForm : Form
    {
        public DataRow WorkRow { get; set; }
        private bool editRow;
        public OrdersEditForm()
        {
            InitializeComponent();
        }

        public OrdersEditForm(DataRow workRow, bool editRow = false) : this()
        {
            this.WorkRow = workRow;
            this.editRow = editRow;
        }

        private void OrdersEditForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillDataSet();
            ResetItems();

            if (editRow)
            {
                this.Text = "Редактирование записи";
                btnAccept.Text = "Изменить";

                FillItems();
            }
            else
            {
                this.Text = "Добавление новой записи";
                btnAccept.Text = "Добавить";
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateItems()) 
            {
                FillResultRow();

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetItems();
        }

        private void ResetItems()
        {
            if (editRow) 
            {
                FillItems();
            }
            else 
            {
                statuseComboBox.SelectedIndex = -1;
                userComboBox.SelectedIndex = -1;
                orderNumberTextBox.Text = "";
                orderDateDateTimePicker.Value = DateTime.Now;
                completionDateDateTimePicker.Value = DateTime.Now;
                totalCostTextBox.Text = "";
                paidTextBox.Text = "";
                cancellationSignTextBox.Text = "";

              //  FillCartView("-1");
            }
        }

        private void FillResultRow()
        {
            WorkRow[1] = userComboBox.SelectedValue;
            WorkRow[2] = orderNumberTextBox.Text;
            WorkRow[3] = orderDateDateTimePicker.Value;
            WorkRow[4] = completionDateDateTimePicker.Value;
            WorkRow[5] = statuseComboBox.SelectedValue;
            WorkRow[6] = Convert.ToDouble(totalCostTextBox.Text);
            WorkRow[7] = Convert.ToDouble(paidTextBox.Text);

            if (!String.IsNullOrWhiteSpace(cancellationSignTextBox.Text)) 
            {
                WorkRow[8] = cancellationSignTextBox.Text;
            }
        }
        private void FillItems()
        {
            userComboBox.SelectedValue = WorkRow[1];
            orderNumberTextBox.Text = WorkRow[2].ToString();
            orderDateDateTimePicker.Value = (DateTime)WorkRow[3];
            completionDateDateTimePicker.Value = (DateTime)WorkRow[4];
            statuseComboBox.SelectedValue = WorkRow[5];
            totalCostTextBox.Text = WorkRow[6].ToString();
            paidTextBox.Text = WorkRow[7].ToString();

        }
        private bool ValidateItems()
        {
            bool flag = true;
            string error = "Ошибка ввода: \n";

            if(userComboBox.SelectedIndex == -1) 
            {
                error += "Пользователь не выбран.\n";
                flag = false;
            }

            if (statuseComboBox.SelectedIndex == -1)
            {
                error += "Статус не выбран.\n";
                flag = false;
            }

            if (String.IsNullOrWhiteSpace(orderNumberTextBox.Text))
            {
                error += "Номер заказа не указан.\n";
                flag = false;
            }

            try
            {
                double tmp;

                tmp = Convert.ToDouble(totalCostTextBox.Text);
                tmp = Convert.ToDouble(paidTextBox.Text);

            }
            catch (FormatException)
            {

                error += "Данные в полях \"Полная стоимость\" или \"Оплачено\" указаны неверно.";
                flag = false;
            }

            if (flag == false) 
            {
                MessageBox.Show(this,error,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            return flag;

        }
        private void SetConnections()
        {
            usersTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            statusesTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            cartTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }
        private void FillDataSet()
        {
            this.usersTableAdapter.Fill(this.marketDBDataSet.Users);
            this.statusesTableAdapter.Fill(this.marketDBDataSet.Statuses);
            this.cartTableAdapter.Fill(this.marketDBDataSet.Cart);
        }

    }
}
