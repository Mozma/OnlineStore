using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.View
{
    public partial class ProductsEditForm : Form, IEditForm
    {
        public DataRow WorkRow { get; set; }

        public ProductsEditForm()
        {
            InitializeComponent();
        }

        public ProductsEditForm(DataRow workRow, bool editRow = false)
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

        public void SetConnections()
        {
            throw new NotImplementedException();
        }

        public void FillDataSet()
        {
            throw new NotImplementedException();
        }

        public void ResetItems()
        {
            throw new NotImplementedException();
        }

        public void FillItems()
        {
            throw new NotImplementedException();
        }
    }
}
