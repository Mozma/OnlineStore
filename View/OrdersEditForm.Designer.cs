
namespace OnlineStore.View
{
    partial class OrdersEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersEditForm));
            this.paidTextBox = new System.Windows.Forms.TextBox();
            this.cancellationSignTextBox = new System.Windows.Forms.TextBox();
            this.totalCostTextBox = new System.Windows.Forms.TextBox();
            this.orderNumberTextBox = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.orderDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.completionDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.statuseComboBox = new System.Windows.Forms.ComboBox();
            this.statusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marketDBDataSet = new OnlineStore.MarketDBDataSet();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusesTableAdapter = new OnlineStore.MarketDBDataSetTableAdapters.StatusesTableAdapter();
            this.usersTableAdapter = new OnlineStore.MarketDBDataSetTableAdapters.UsersTableAdapter();
            this.cartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cartTableAdapter = new OnlineStore.MarketDBDataSetTableAdapters.CartTableAdapter();
            this.orderTableAdapter = new OnlineStore.MarketDBDataSetTableAdapters.OrderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // paidTextBox
            // 
            this.paidTextBox.Location = new System.Drawing.Point(131, 174);
            this.paidTextBox.Name = "paidTextBox";
            this.paidTextBox.Size = new System.Drawing.Size(172, 20);
            this.paidTextBox.TabIndex = 26;
            // 
            // cancellationSignTextBox
            // 
            this.cancellationSignTextBox.Location = new System.Drawing.Point(131, 200);
            this.cancellationSignTextBox.Name = "cancellationSignTextBox";
            this.cancellationSignTextBox.Size = new System.Drawing.Size(172, 20);
            this.cancellationSignTextBox.TabIndex = 25;
            // 
            // totalCostTextBox
            // 
            this.totalCostTextBox.Location = new System.Drawing.Point(131, 148);
            this.totalCostTextBox.Name = "totalCostTextBox";
            this.totalCostTextBox.Size = new System.Drawing.Size(172, 20);
            this.totalCostTextBox.TabIndex = 24;
            // 
            // orderNumberTextBox
            // 
            this.orderNumberTextBox.Location = new System.Drawing.Point(131, 43);
            this.orderNumberTextBox.Name = "orderNumberTextBox";
            this.orderNumberTextBox.Size = new System.Drawing.Size(172, 20);
            this.orderNumberTextBox.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(106, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 23);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(227, 256);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(115, 23);
            this.btnAccept.TabIndex = 37;
            this.btnAccept.Text = "Добавить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Ид пользователя:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Код статуса:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Дата заказа:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Полная стоимость:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Оплачено:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Дата завершения:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Причина отмены:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Номер заказа:";
            // 
            // orderDateDateTimePicker
            // 
            this.orderDateDateTimePicker.Location = new System.Drawing.Point(131, 96);
            this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
            this.orderDateDateTimePicker.Size = new System.Drawing.Size(172, 20);
            this.orderDateDateTimePicker.TabIndex = 47;
            // 
            // completionDateDateTimePicker
            // 
            this.completionDateDateTimePicker.Location = new System.Drawing.Point(131, 122);
            this.completionDateDateTimePicker.Name = "completionDateDateTimePicker";
            this.completionDateDateTimePicker.Size = new System.Drawing.Size(172, 20);
            this.completionDateDateTimePicker.TabIndex = 48;
            // 
            // statuseComboBox
            // 
            this.statuseComboBox.DataSource = this.statusesBindingSource;
            this.statuseComboBox.DisplayMember = "Statuse_name";
            this.statuseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statuseComboBox.FormattingEnabled = true;
            this.statuseComboBox.Location = new System.Drawing.Point(131, 69);
            this.statuseComboBox.Name = "statuseComboBox";
            this.statuseComboBox.Size = new System.Drawing.Size(172, 21);
            this.statuseComboBox.TabIndex = 49;
            this.statuseComboBox.ValueMember = "Statuse_code";
            // 
            // statusesBindingSource
            // 
            this.statusesBindingSource.DataMember = "Statuses";
            this.statusesBindingSource.DataSource = this.marketDBDataSet;
            // 
            // marketDBDataSet
            // 
            this.marketDBDataSet.DataSetName = "MarketDBDataSet";
            this.marketDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userComboBox
            // 
            this.userComboBox.DataSource = this.usersBindingSource;
            this.userComboBox.DisplayMember = "Login";
            this.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(131, 16);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(172, 21);
            this.userComboBox.TabIndex = 50;
            this.userComboBox.ValueMember = "User_id";
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.marketDBDataSet;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.userComboBox);
            this.panel1.Controls.Add(this.statuseComboBox);
            this.panel1.Controls.Add(this.orderNumberTextBox);
            this.panel1.Controls.Add(this.completionDateDateTimePicker);
            this.panel1.Controls.Add(this.totalCostTextBox);
            this.panel1.Controls.Add(this.orderDateDateTimePicker);
            this.panel1.Controls.Add(this.cancellationSignTextBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.paidTextBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 238);
            this.panel1.TabIndex = 51;
            // 
            // statusesTableAdapter
            // 
            this.statusesTableAdapter.ClearBeforeFill = true;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // cartBindingSource
            // 
            this.cartBindingSource.DataMember = "Cart";
            this.cartBindingSource.DataSource = this.marketDBDataSet;
            // 
            // cartTableAdapter
            // 
            this.cartTableAdapter.ClearBeforeFill = true;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // OrdersEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdersEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OrdersEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox paidTextBox;
        private System.Windows.Forms.TextBox cancellationSignTextBox;
        private System.Windows.Forms.TextBox totalCostTextBox;
        private System.Windows.Forms.TextBox orderNumberTextBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker orderDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker completionDateDateTimePicker;
        private System.Windows.Forms.ComboBox statuseComboBox;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Panel panel1;
        private MarketDBDataSetTableAdapters.StatusesTableAdapter statusesTableAdapter;
        private MarketDBDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private MarketDBDataSet marketDBDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.BindingSource statusesBindingSource;
        private System.Windows.Forms.BindingSource cartBindingSource;
        private MarketDBDataSetTableAdapters.CartTableAdapter cartTableAdapter;
        private MarketDBDataSetTableAdapters.OrderTableAdapter orderTableAdapter;
    }
}