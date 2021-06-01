using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStore.View.EditForms
{
    public partial class ProductSelectorForm : Form
    {
        public ProductSelectorForm()
        {
            InitializeComponent();
            SetUpListBoxs();
        }

        bool flag = false;
        public string ProductCode;

        /// <summary>
        /// Загрузка данных в контекст для cписков.
        /// </summary>
        private void SetUpListBoxs()
        {
            MarketDBEntities entities = new MarketDBEntities();

            List<Category> categories = (from Category in entities.Categories select Category).ToList();

            lbCategories.DataSource = categories;
            lbCategories.SelectedIndex = 0;
            lbCategories.DisplayMember = "Category_name";
            lbCategories.ValueMember = "Category_Code";

            lbProducts.DisplayMember = "DisplayValue";
            lbProducts.ValueMember = "ProductCode";

            flag = true;

            LoadProducts();
        }

        private void LoadProducts()
        {
            MarketDBEntities entities = new MarketDBEntities();

            var prod = entities.Products
                    .Where(x => x.Category_code == lbCategories.SelectedValue.ToString())
                    .AsEnumerable().OrderBy(y => y.Product_name)
                    .Select(s => new
                    {
                        ProductCode = s.Product_code,
                        DisplayValue = s.Product_name + " | " + String.Format("{0:n} руб.", s.Price)
                    }
                    ).ToList();

            lbProducts.DataSource = prod;

            if (prod.Count != 0)
            {
                lbProducts.SelectedIndex = 0;
            }
        }




        private void lbProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbProducts.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                ProductCode = lbProducts.SelectedValue.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                LoadProducts();
            }
        }
    }
}
