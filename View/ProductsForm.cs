﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            SetConnections();
            FillDataSet();

            this.Text = $"Обзор таблицы \"Товары\"";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newRow = marketDBDataSet.Tables["Products"].NewRow();
            using (ProductsEditForm productsEditForm = new ProductsEditForm(newRow))
            {
                if (productsEditForm.ShowDialog(this) == DialogResult.OK)
                {
                    newRow = productsEditForm.WorkRow;

                    try
                    {
                        marketDBDataSet.Tables["Products"].Rows.Add(newRow);
                        productsTableAdapter.Update(marketDBDataSet);

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
            int index = productsDataGridView.CurrentCell.RowIndex;
            var workRow = marketDBDataSet.Tables["Products"].Rows[index];
            using (ProductsEditForm productsEditForm = new ProductsEditForm(workRow, true))
            {
                try
                {
                    if (productsEditForm.ShowDialog(this) == DialogResult.OK)
                    {
                        workRow.BeginEdit();
                        workRow = productsEditForm.WorkRow;
                        workRow.EndEdit();
                        productsTableAdapter.Update(marketDBDataSet);

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
            int index = productsDataGridView.CurrentCell.RowIndex;
            string msg = $"Вы действительно хотите удалить строку с Кодом = {marketDBDataSet.Tables["Products"].Rows[index][0]}?";

            if (MessageBox.Show(msg, "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    marketDBDataSet.Tables["Products"].Rows[index].Delete();
                    productsTableAdapter.Update(marketDBDataSet);
                }
                catch (Exception exp)
                {
                    var mainForm = (MainForm)Application.OpenForms["mainForm"];
                    mainForm.PostError(exp.Message);

                    FillDataSet();
                }
            }
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataSet();
        }

        public void SetConnections()
        {
            productsTableAdapter.Connection = new SqlConnection(Values.Connection.ConnectionString);
        }

        public void FillDataSet()
        {
            this.productsTableAdapter.Fill(this.marketDBDataSet.Products);
        }
    }
}