using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class OrdersForm : BorderlessWinForm
    {
        // Флаг для блокировки события SelectedChange во время заполнения таблицы данными.
        bool blockFlag;
        public OrdersForm()
        {
            InitializeComponent();
        }
        
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillDataSet();
            ordersDataGridView.Rows[0].Selected = true;

            this.Text = $"Обзор таблицы \"Заказы\"";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          //  Close();
        }

        #region Обработка Lookup полей.

        // Обработчик для создания Lookup полей.
        private void ordersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Lookup-поле для Statuse_code.
            if (ordersDataGridView.Columns[e.ColumnIndex].Name.Equals("Statuse_name"))
            {

                e.Value = GetStatusNameLookupValue(
                    ordersDataGridView.Rows[e.RowIndex].Cells["statusecodeDataGridViewTextBoxColumn"].Value.ToString());
            }
        }

        /// <summary>
        /// Возвращает значение поля Statuse_name из таблицы Statuses.
        /// </summary>
        /// <param name="status_code">Ключ для поиска.</param>
        /// <returns></returns>
        public string GetStatusNameLookupValue(string status_code)
        {
            string status_name = "";


            DataTable dt = marketDBDataSet.Tables[5];

            foreach (DataRow row in dt.Rows)
            {
                // получаем все ячейки строки
                var cells = row.ItemArray;

                if (cells[0].ToString().Equals(status_code))
                {
                    status_name = cells[1].ToString();
                    break;
                }

            }
            return status_name;
        }

        #endregion

        #region Кнопки

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newRow = marketDBDataSet.Tables["Order"].NewRow();
            using (OrdersEditForm ordersEditForm = new OrdersEditForm(newRow))
            {
                if (ordersEditForm.ShowDialog(this) == DialogResult.OK)
                {
                    try { 
                        newRow = ordersEditForm.WorkRow;

                        marketDBDataSet.Tables["Order"].Rows.Add(newRow);
                        orderTableAdapter.Update(marketDBDataSet);

                        MessageBox.Show(this, "Строка добавлена успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exp)
                    {
                        var mainForm = (MainForm)Application.OpenForms["mainForm"];
                        mainForm.PostError(exp.Message);

                        FillDataSet();
                    }

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = ordersDataGridView.CurrentCell.RowIndex;
            var workRow = marketDBDataSet.Tables["Order"].Rows[index];
            using (OrdersEditForm ordersEditForm = new OrdersEditForm(workRow, true))
            {
                try { 
                    if (ordersEditForm.ShowDialog(this) == DialogResult.OK)
                    {
                        workRow.BeginEdit();
                        workRow = ordersEditForm.WorkRow;
                        workRow.EndEdit();
                        orderTableAdapter.Update(marketDBDataSet);

                        MessageBox.Show(this, "Строка изменена успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exp)
                {
                    var mainForm = (MainForm)Application.OpenForms["mainForm"];
                    mainForm.PostError(exp.Message);

                    FillDataSet();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = ordersDataGridView.CurrentCell.RowIndex;
            string msg = $"Вы действительно хотите удалить строку с Кодом = {marketDBDataSet.Tables["Order"].Rows[index][0]}?";

            if (MessageBox.Show(msg, "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    marketDBDataSet.Tables["Order"].Rows[index].Delete();
                    orderTableAdapter.Update(marketDBDataSet);
                }
                catch (Exception exp)
                {
                    var mainForm = (MainForm)Application.OpenForms["mainForm"];
                    mainForm.PostError(exp.Message);

                    FillDataSet();
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataSet();
        }
        #endregion

        #region Дополнительные методы.
        private void SetConnections()
        {
            orderTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            statusesTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
            cartTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        private void FillDataSet() 
        {
            blockFlag = true;
            this.statusesTableAdapter.Fill(this.marketDBDataSet.Statuses);
            this.orderTableAdapter.Fill(this.marketDBDataSet.Order);
            this.cartTableAdapter.Fill(this.marketDBDataSet.Cart);
            blockFlag = false;
        }


        #endregion

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!blockFlag)
            {
                string orderId = ordersDataGridView.Rows[ordersDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
                DataView dv = marketDBDataSet.Tables["Cart"].DefaultView;
                dv.RowFilter = string.Format("Order_id = '{0}'", orderId);

                cartDataGridView.DataSource = dv.ToTable();
                cartDataGridView.ClearSelection();
            }
        }
    }
}
