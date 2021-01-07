using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersEditForm : Form
    {
        public DataRow WorkRow { get; set; }

        public OrdersEditForm()
        {
            InitializeComponent();
        }

        public OrdersEditForm(DataRow workRow, bool editRow = false) : this()
        {
            this.WorkRow = workRow;

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


        private void OrdersEditForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillDataSet();
            ResetItems();

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateItems()) 
            {
                FillItems();
                DialogResult = DialogResult.OK;
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetItems();
            DialogResult = DialogResult.Cancel;
        }

        private void ResetItems()
        {
            statuseComboBox.SelectedIndex = -1;
            userComboBox.SelectedIndex = -1;
        }

        private void FillItems()
        {
            throw new NotImplementedException();
        }

        private bool ValidateItems()
        {
            throw new NotImplementedException();
        }

        private void SetConnections()
        {
            usersTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            statusesTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        private void FillDataSet()
        {
            this.usersTableAdapter.Fill(this.marketDBDataSet.Users);
            this.statusesTableAdapter.Fill(this.marketDBDataSet.Statuses);
        }


    }
}
