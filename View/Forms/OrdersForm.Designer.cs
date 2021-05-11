
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.InvoiceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.tbFIOCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFIOEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dtpOrderDateBeg = new System.Windows.Forms.DateTimePicker();
            this.dtpCompletionDateBeg = new System.Windows.Forms.DateTimePicker();
            this.dtpCompletionDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDateEnd = new System.Windows.Forms.DateTimePicker();
            this.cbOrderDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCompletionDate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbStatuses = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AllowUserToAddRows = false;
            this.ordersDataGridView.AllowUserToDeleteRows = false;
            this.ordersDataGridView.AllowUserToResizeRows = false;
            this.ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ordersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ordersDataGridView.ColumnHeadersHeight = 46;
            this.ordersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ordersDataGridView.MultiSelect = false;
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.ReadOnly = true;
            this.ordersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDataGridView.Size = new System.Drawing.Size(1182, 433);
            this.ordersDataGridView.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnUpdate,
            this.btnDelete,
            this.btnRefresh,
            this.InvoiceToolStripButton,
            this.toolStripSeparator1,
            this.tsbFilter});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1182, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 22);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 22);
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeftAutoMirrorImage = true;
            this.btnDelete.Size = new System.Drawing.Size(71, 22);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(77, 22);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // InvoiceToolStripButton
            // 
            this.InvoiceToolStripButton.Image = global::OnlineStore.Properties.Resources.printer;
            this.InvoiceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InvoiceToolStripButton.Name = "InvoiceToolStripButton";
            this.InvoiceToolStripButton.Size = new System.Drawing.Size(64, 22);
            this.InvoiceToolStripButton.Text = "Печать";
            this.InvoiceToolStripButton.Click += new System.EventHandler(this.InvoiceToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFilter
            // 
            this.tsbFilter.Image = global::OnlineStore.Properties.Resources.filter;
            this.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilter.Name = "tsbFilter";
            this.tsbFilter.Size = new System.Drawing.Size(89, 22);
            this.tsbFilter.Text = "Фильтрация";
            this.tsbFilter.Click += new System.EventHandler(this.tsbFilter_Click);
            // 
            // tbFIOCustomer
            // 
            this.tbFIOCustomer.Location = new System.Drawing.Point(109, 54);
            this.tbFIOCustomer.Name = "tbFIOCustomer";
            this.tbFIOCustomer.Size = new System.Drawing.Size(209, 20);
            this.tbFIOCustomer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ФИО клиента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ФИО сотрудника";
            // 
            // tbFIOEmployee
            // 
            this.tbFIOEmployee.Location = new System.Drawing.Point(109, 77);
            this.tbFIOEmployee.Name = "tbFIOEmployee";
            this.tbFIOEmployee.Size = new System.Drawing.Size(209, 20);
            this.tbFIOEmployee.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Номер заказа";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(109, 7);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(209, 20);
            this.textBox3.TabIndex = 11;
            // 
            // dtpOrderDateBeg
            // 
            this.dtpOrderDateBeg.Enabled = false;
            this.dtpOrderDateBeg.Location = new System.Drawing.Point(461, 7);
            this.dtpOrderDateBeg.Name = "dtpOrderDateBeg";
            this.dtpOrderDateBeg.Size = new System.Drawing.Size(168, 20);
            this.dtpOrderDateBeg.TabIndex = 13;
            // 
            // dtpCompletionDateBeg
            // 
            this.dtpCompletionDateBeg.Enabled = false;
            this.dtpCompletionDateBeg.Location = new System.Drawing.Point(461, 31);
            this.dtpCompletionDateBeg.Name = "dtpCompletionDateBeg";
            this.dtpCompletionDateBeg.Size = new System.Drawing.Size(168, 20);
            this.dtpCompletionDateBeg.TabIndex = 14;
            // 
            // dtpCompletionDateEnd
            // 
            this.dtpCompletionDateEnd.Enabled = false;
            this.dtpCompletionDateEnd.Location = new System.Drawing.Point(658, 31);
            this.dtpCompletionDateEnd.Name = "dtpCompletionDateEnd";
            this.dtpCompletionDateEnd.Size = new System.Drawing.Size(168, 20);
            this.dtpCompletionDateEnd.TabIndex = 18;
            // 
            // dtpOrderDateEnd
            // 
            this.dtpOrderDateEnd.Enabled = false;
            this.dtpOrderDateEnd.Location = new System.Drawing.Point(658, 7);
            this.dtpOrderDateEnd.Name = "dtpOrderDateEnd";
            this.dtpOrderDateEnd.Size = new System.Drawing.Size(168, 20);
            this.dtpOrderDateEnd.TabIndex = 17;
            // 
            // cbOrderDate
            // 
            this.cbOrderDate.AutoSize = true;
            this.cbOrderDate.Location = new System.Drawing.Point(330, 10);
            this.cbOrderDate.Name = "cbOrderDate";
            this.cbOrderDate.Size = new System.Drawing.Size(91, 17);
            this.cbOrderDate.TabIndex = 19;
            this.cbOrderDate.Text = "Дата заказа";
            this.cbOrderDate.UseVisualStyleBackColor = true;
            this.cbOrderDate.CheckedChanged += new System.EventHandler(this.cbOrderDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "по";
            // 
            // cbCompletionDate
            // 
            this.cbCompletionDate.AutoSize = true;
            this.cbCompletionDate.Location = new System.Drawing.Point(330, 33);
            this.cbCompletionDate.Name = "cbCompletionDate";
            this.cbCompletionDate.Size = new System.Drawing.Size(117, 17);
            this.cbCompletionDate.TabIndex = 21;
            this.cbCompletionDate.Text = "Дата завершения";
            this.cbCompletionDate.UseVisualStyleBackColor = true;
            this.cbCompletionDate.CheckedChanged += new System.EventHandler(this.cbCompletionDate_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(633, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "по";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "c";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "c";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "c";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(445, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "c";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(633, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "по";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(633, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "по";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(460, 54);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(168, 20);
            this.textBox4.TabIndex = 33;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(658, 54);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(168, 20);
            this.textBox5.TabIndex = 34;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(460, 77);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(168, 20);
            this.textBox6.TabIndex = 35;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(658, 77);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(168, 20);
            this.textBox7.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(349, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Стоимость";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(349, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Оплачено";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.button2);
            this.pnlFilter.Controls.Add(this.button1);
            this.pnlFilter.Controls.Add(this.cmbStatuses);
            this.pnlFilter.Controls.Add(this.label14);
            this.pnlFilter.Controls.Add(this.textBox5);
            this.pnlFilter.Controls.Add(this.label13);
            this.pnlFilter.Controls.Add(this.tbFIOCustomer);
            this.pnlFilter.Controls.Add(this.label12);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.textBox7);
            this.pnlFilter.Controls.Add(this.tbFIOEmployee);
            this.pnlFilter.Controls.Add(this.textBox6);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.textBox3);
            this.pnlFilter.Controls.Add(this.textBox4);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.label8);
            this.pnlFilter.Controls.Add(this.dtpOrderDateBeg);
            this.pnlFilter.Controls.Add(this.label9);
            this.pnlFilter.Controls.Add(this.dtpCompletionDateBeg);
            this.pnlFilter.Controls.Add(this.label10);
            this.pnlFilter.Controls.Add(this.dtpOrderDateEnd);
            this.pnlFilter.Controls.Add(this.label11);
            this.pnlFilter.Controls.Add(this.dtpCompletionDateEnd);
            this.pnlFilter.Controls.Add(this.label7);
            this.pnlFilter.Controls.Add(this.cbOrderDate);
            this.pnlFilter.Controls.Add(this.label6);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.cbCompletionDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 25);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1182, 105);
            this.pnlFilter.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(832, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 22);
            this.button2.TabIndex = 42;
            this.button2.Text = "Сбросить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(832, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 22);
            this.button1.TabIndex = 41;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbStatuses
            // 
            this.cmbStatuses.FormattingEnabled = true;
            this.cmbStatuses.Location = new System.Drawing.Point(109, 30);
            this.cmbStatuses.Name = "cmbStatuses";
            this.cmbStatuses.Size = new System.Drawing.Size(209, 21);
            this.cmbStatuses.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Статус заказа";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ordersDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 433);
            this.panel2.TabIndex = 40;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 563);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(667, 362);
            this.Name = "OrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Книга заказов";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ordersDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton InvoiceToolStripButton;
        private System.Windows.Forms.TextBox tbFIOCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFIOEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DateTimePicker dtpOrderDateBeg;
        private System.Windows.Forms.DateTimePicker dtpCompletionDateBeg;
        private System.Windows.Forms.DateTimePicker dtpCompletionDateEnd;
        private System.Windows.Forms.DateTimePicker dtpOrderDateEnd;
        private System.Windows.Forms.CheckBox cbOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbCompletionDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cmbStatuses;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}