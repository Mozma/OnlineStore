
namespace OnlineStore.View
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.orderidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completiondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusecodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statuse_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalcostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancellationsignDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marketDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marketDBDataSet = new OnlineStore.MarketDBDataSet();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbTableName = new System.Windows.Forms.Label();
            this.orderTableAdapter = new OnlineStore.MarketDBDataSetTableAdapters.OrderTableAdapter();
            this.statusesTableAdapter = new OnlineStore.MarketDBDataSetTableAdapters.StatusesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AllowUserToAddRows = false;
            this.ordersDataGridView.AllowUserToDeleteRows = false;
            this.ordersDataGridView.AllowUserToResizeRows = false;
            this.ordersDataGridView.AutoGenerateColumns = false;
            this.ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ordersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ordersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ordersDataGridView.ColumnHeadersHeight = 50;
            this.ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderidDataGridViewTextBoxColumn,
            this.useridDataGridViewTextBoxColumn,
            this.ordernumberDataGridViewTextBoxColumn,
            this.orderdateDataGridViewTextBoxColumn,
            this.completiondateDataGridViewTextBoxColumn,
            this.statusecodeDataGridViewTextBoxColumn,
            this.Statuse_name,
            this.totalcostDataGridViewTextBoxColumn,
            this.paidDataGridViewTextBoxColumn,
            this.cancellationsignDataGridViewTextBoxColumn});
            this.ordersDataGridView.DataSource = this.orderBindingSource;
            this.ordersDataGridView.Location = new System.Drawing.Point(15, 42);
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.ReadOnly = true;
            this.ordersDataGridView.Size = new System.Drawing.Size(894, 406);
            this.ordersDataGridView.TabIndex = 0;
            this.ordersDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ordersDataGridView_CellFormatting);
            // 
            // orderidDataGridViewTextBoxColumn
            // 
            this.orderidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orderidDataGridViewTextBoxColumn.DataPropertyName = "Order_id";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderidDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.orderidDataGridViewTextBoxColumn.HeaderText = "Ид заказа";
            this.orderidDataGridViewTextBoxColumn.Name = "orderidDataGridViewTextBoxColumn";
            this.orderidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // useridDataGridViewTextBoxColumn
            // 
            this.useridDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.useridDataGridViewTextBoxColumn.DataPropertyName = "User_id";
            this.useridDataGridViewTextBoxColumn.HeaderText = "Ид пользователя";
            this.useridDataGridViewTextBoxColumn.Name = "useridDataGridViewTextBoxColumn";
            this.useridDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordernumberDataGridViewTextBoxColumn
            // 
            this.ordernumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ordernumberDataGridViewTextBoxColumn.DataPropertyName = "Order_number";
            this.ordernumberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.ordernumberDataGridViewTextBoxColumn.Name = "ordernumberDataGridViewTextBoxColumn";
            this.ordernumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderdateDataGridViewTextBoxColumn
            // 
            this.orderdateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orderdateDataGridViewTextBoxColumn.DataPropertyName = "Order_date";
            this.orderdateDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.orderdateDataGridViewTextBoxColumn.Name = "orderdateDataGridViewTextBoxColumn";
            this.orderdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // completiondateDataGridViewTextBoxColumn
            // 
            this.completiondateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.completiondateDataGridViewTextBoxColumn.DataPropertyName = "Completion_date";
            this.completiondateDataGridViewTextBoxColumn.HeaderText = "Дата завершения";
            this.completiondateDataGridViewTextBoxColumn.Name = "completiondateDataGridViewTextBoxColumn";
            this.completiondateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusecodeDataGridViewTextBoxColumn
            // 
            this.statusecodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusecodeDataGridViewTextBoxColumn.DataPropertyName = "Statuse_code";
            this.statusecodeDataGridViewTextBoxColumn.HeaderText = "Код статуса";
            this.statusecodeDataGridViewTextBoxColumn.Name = "statusecodeDataGridViewTextBoxColumn";
            this.statusecodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Statuse_name
            // 
            this.Statuse_name.HeaderText = "Статус";
            this.Statuse_name.Name = "Statuse_name";
            this.Statuse_name.ReadOnly = true;
            // 
            // totalcostDataGridViewTextBoxColumn
            // 
            this.totalcostDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalcostDataGridViewTextBoxColumn.DataPropertyName = "Total_cost";
            this.totalcostDataGridViewTextBoxColumn.HeaderText = "Полная стоимость";
            this.totalcostDataGridViewTextBoxColumn.Name = "totalcostDataGridViewTextBoxColumn";
            this.totalcostDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalcostDataGridViewTextBoxColumn.Visible = false;
            // 
            // paidDataGridViewTextBoxColumn
            // 
            this.paidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paidDataGridViewTextBoxColumn.DataPropertyName = "Paid";
            this.paidDataGridViewTextBoxColumn.HeaderText = "Оплачено";
            this.paidDataGridViewTextBoxColumn.Name = "paidDataGridViewTextBoxColumn";
            this.paidDataGridViewTextBoxColumn.ReadOnly = true;
            this.paidDataGridViewTextBoxColumn.Visible = false;
            // 
            // cancellationsignDataGridViewTextBoxColumn
            // 
            this.cancellationsignDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cancellationsignDataGridViewTextBoxColumn.DataPropertyName = "Cancellation_sign";
            this.cancellationsignDataGridViewTextBoxColumn.HeaderText = "Причина отмены";
            this.cancellationsignDataGridViewTextBoxColumn.Name = "cancellationsignDataGridViewTextBoxColumn";
            this.cancellationsignDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.marketDBDataSetBindingSource;
            // 
            // marketDBDataSetBindingSource
            // 
            this.marketDBDataSetBindingSource.DataSource = this.marketDBDataSet;
            this.marketDBDataSetBindingSource.Position = 0;
            // 
            // marketDBDataSet
            // 
            this.marketDBDataSet.DataSetName = "MarketDBDataSet";
            this.marketDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(883, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 31);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTableName
            // 
            this.lbTableName.AutoSize = true;
            this.lbTableName.Location = new System.Drawing.Point(12, 10);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(0, 13);
            this.lbTableName.TabIndex = 7;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // statusesTableAdapter
            // 
            this.statusesTableAdapter.ClearBeforeFill = true;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 488);
            this.Controls.Add(this.lbTableName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ordersDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrdersForm";
            this.Text = "OrdersForm";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ordersDataGridView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTableName;
        private System.Windows.Forms.BindingSource marketDBDataSetBindingSource;
        private MarketDBDataSet marketDBDataSet;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private MarketDBDataSetTableAdapters.OrderTableAdapter orderTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn useridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completiondateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusecodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statuse_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalcostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancellationsignDataGridViewTextBoxColumn;
        private MarketDBDataSetTableAdapters.StatusesTableAdapter statusesTableAdapter;
    }
}