
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.orderNumberlb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(411, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "cancellationSign";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "paid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "totalCost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "statuseCode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "completionDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "orderDate";
            // 
            // orderNumberlb
            // 
            this.orderNumberlb.AutoSize = true;
            this.orderNumberlb.Location = new System.Drawing.Point(408, 7);
            this.orderNumberlb.Name = "orderNumberlb";
            this.orderNumberlb.Size = new System.Drawing.Size(68, 13);
            this.orderNumberlb.TabIndex = 29;
            this.orderNumberlb.Text = "orderNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "userId";
            // 
            // paidTextBox
            // 
            this.paidTextBox.Location = new System.Drawing.Point(411, 141);
            this.paidTextBox.Name = "paidTextBox";
            this.paidTextBox.Size = new System.Drawing.Size(172, 20);
            this.paidTextBox.TabIndex = 26;
            // 
            // cancellationSignTextBox
            // 
            this.cancellationSignTextBox.Location = new System.Drawing.Point(411, 62);
            this.cancellationSignTextBox.Name = "cancellationSignTextBox";
            this.cancellationSignTextBox.Size = new System.Drawing.Size(172, 20);
            this.cancellationSignTextBox.TabIndex = 25;
            // 
            // totalCostTextBox
            // 
            this.totalCostTextBox.Location = new System.Drawing.Point(117, 141);
            this.totalCostTextBox.Name = "totalCostTextBox";
            this.totalCostTextBox.Size = new System.Drawing.Size(172, 20);
            this.totalCostTextBox.TabIndex = 24;
            // 
            // orderNumberTextBox
            // 
            this.orderNumberTextBox.Location = new System.Drawing.Point(411, 23);
            this.orderNumberTextBox.Name = "orderNumberTextBox";
            this.orderNumberTextBox.Size = new System.Drawing.Size(172, 20);
            this.orderNumberTextBox.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 23);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(499, 202);
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
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Ид пользователя:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Код статуса:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Дата заказа:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Полная стоимость:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(304, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Оплачено:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(304, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Дата завершения:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(304, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Причина отмены:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(304, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Номер заказа:";
            // 
            // orderDateDateTimePicker
            // 
            this.orderDateDateTimePicker.Location = new System.Drawing.Point(117, 101);
            this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
            this.orderDateDateTimePicker.Size = new System.Drawing.Size(172, 20);
            this.orderDateDateTimePicker.TabIndex = 47;
            // 
            // completionDateDateTimePicker
            // 
            this.completionDateDateTimePicker.Location = new System.Drawing.Point(411, 101);
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
            this.statuseComboBox.Location = new System.Drawing.Point(117, 62);
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
            this.userComboBox.Location = new System.Drawing.Point(117, 22);
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
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.orderNumberlb);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 184);
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
            // OrdersEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 237);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Name = "OrdersEditForm";
            this.Load += new System.EventHandler(this.OrdersEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marketDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label orderNumberlb;
        private System.Windows.Forms.Label label2;
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
    }
}