namespace ControlMensualidadCentroDiurno
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.payments_panel = new System.Windows.Forms.Panel();
            this.comboBox_months = new System.Windows.Forms.ComboBox();
            this.textBox_searchSenores = new System.Windows.Forms.TextBox();
            this.radioButton_does_not_cancel = new System.Windows.Forms.RadioButton();
            this.radioButton_all = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItem_listPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_management = new System.Windows.Forms.ToolStripMenuItem();
            this.management_panel = new System.Windows.Forms.Panel();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.dataGridView_panel = new System.Windows.Forms.Panel();
            this.radioButton_cancel = new System.Windows.Forms.RadioButton();
            this.dataGridView_senores = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_generateBill = new System.Windows.Forms.Button();
            this.button_add_payment = new System.Windows.Forms.Button();
            this.button_monthlyPaymentsTotal = new System.Windows.Forms.Button();
            this.generateBills = new System.Windows.Forms.Button();
            this.payments_panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.management_panel.SuspendLayout();
            this.dataGridView_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_senores)).BeginInit();
            this.SuspendLayout();
            // 
            // payments_panel
            // 
            this.payments_panel.BackColor = System.Drawing.Color.Transparent;
            this.payments_panel.Controls.Add(this.comboBox_months);
            this.payments_panel.Controls.Add(this.textBox_searchSenores);
            this.payments_panel.Location = new System.Drawing.Point(0, 30);
            this.payments_panel.Name = "payments_panel";
            this.payments_panel.Size = new System.Drawing.Size(798, 151);
            this.payments_panel.TabIndex = 0;
            // 
            // comboBox_months
            // 
            this.comboBox_months.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_months.FormattingEnabled = true;
            this.comboBox_months.Location = new System.Drawing.Point(337, 49);
            this.comboBox_months.Name = "comboBox_months";
            this.comboBox_months.Size = new System.Drawing.Size(121, 21);
            this.comboBox_months.TabIndex = 2;
            this.comboBox_months.SelectedValueChanged += new System.EventHandler(this.comboBox_months_SelectedValueChanged);
            // 
            // textBox_searchSenores
            // 
            this.textBox_searchSenores.AccessibleDescription = "";
            this.textBox_searchSenores.AccessibleName = "";
            this.textBox_searchSenores.Location = new System.Drawing.Point(305, 107);
            this.textBox_searchSenores.Name = "textBox_searchSenores";
            this.textBox_searchSenores.Size = new System.Drawing.Size(203, 20);
            this.textBox_searchSenores.TabIndex = 1;
            this.textBox_searchSenores.Tag = "";
            this.textBox_searchSenores.TextChanged += new System.EventHandler(this.textBox_searchSenores_TextChanged);
            this.textBox_searchSenores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_searchSenores_KeyPress);
            // 
            // radioButton_does_not_cancel
            // 
            this.radioButton_does_not_cancel.AutoSize = true;
            this.radioButton_does_not_cancel.Location = new System.Drawing.Point(650, 104);
            this.radioButton_does_not_cancel.Name = "radioButton_does_not_cancel";
            this.radioButton_does_not_cancel.Size = new System.Drawing.Size(78, 17);
            this.radioButton_does_not_cancel.TabIndex = 4;
            this.radioButton_does_not_cancel.Text = "Pendientes";
            this.radioButton_does_not_cancel.UseVisualStyleBackColor = true;
            this.radioButton_does_not_cancel.CheckedChanged += new System.EventHandler(this.radioButton_does_not_cancel_CheckedChanged);
            // 
            // radioButton_all
            // 
            this.radioButton_all.AutoSize = true;
            this.radioButton_all.Checked = true;
            this.radioButton_all.Location = new System.Drawing.Point(650, 82);
            this.radioButton_all.Name = "radioButton_all";
            this.radioButton_all.Size = new System.Drawing.Size(70, 17);
            this.radioButton_all.TabIndex = 3;
            this.radioButton_all.TabStop = true;
            this.radioButton_all.Text = "Ver todos";
            this.radioButton_all.UseVisualStyleBackColor = true;
            this.radioButton_all.CheckedChanged += new System.EventHandler(this.radioButton_all_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_listPayments,
            this.menuItem_management});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItem_listPayments
            // 
            this.menuItem_listPayments.Name = "menuItem_listPayments";
            this.menuItem_listPayments.Size = new System.Drawing.Size(107, 20);
            this.menuItem_listPayments.Text = "Pagos y Facturas";
            this.menuItem_listPayments.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // menuItem_management
            // 
            this.menuItem_management.Name = "menuItem_management";
            this.menuItem_management.Size = new System.Drawing.Size(114, 20);
            this.menuItem_management.Text = "Gestionar Clientes";
            this.menuItem_management.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // management_panel
            // 
            this.management_panel.BackColor = System.Drawing.Color.Transparent;
            this.management_panel.Controls.Add(this.button_delete);
            this.management_panel.Controls.Add(this.button_clean);
            this.management_panel.Controls.Add(this.button_update);
            this.management_panel.Controls.Add(this.button_add);
            this.management_panel.Controls.Add(this.textBox_lastName);
            this.management_panel.Controls.Add(this.textBox_name);
            this.management_panel.Location = new System.Drawing.Point(0, 27);
            this.management_panel.Name = "management_panel";
            this.management_panel.Size = new System.Drawing.Size(798, 154);
            this.management_panel.TabIndex = 5;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Gray;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_delete.Location = new System.Drawing.Point(496, 119);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Eliminar";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_clean
            // 
            this.button_clean.BackColor = System.Drawing.Color.Gray;
            this.button_clean.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_clean.Location = new System.Drawing.Point(406, 119);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 4;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = false;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.DimGray;
            this.button_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_update.Location = new System.Drawing.Point(305, 119);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 3;
            this.button_update.Text = "Actualizar";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.Gray;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_add.Location = new System.Drawing.Point(213, 119);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Agregar";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(333, 70);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(138, 20);
            this.textBox_lastName.TabIndex = 1;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(333, 26);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(138, 20);
            this.textBox_name.TabIndex = 0;
            // 
            // dataGridView_panel
            // 
            this.dataGridView_panel.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_panel.Controls.Add(this.radioButton_cancel);
            this.dataGridView_panel.Controls.Add(this.dataGridView_senores);
            this.dataGridView_panel.Controls.Add(this.radioButton_does_not_cancel);
            this.dataGridView_panel.Controls.Add(this.radioButton_all);
            this.dataGridView_panel.Location = new System.Drawing.Point(29, 175);
            this.dataGridView_panel.Name = "dataGridView_panel";
            this.dataGridView_panel.Size = new System.Drawing.Size(750, 267);
            this.dataGridView_panel.TabIndex = 12;
            // 
            // radioButton_cancel
            // 
            this.radioButton_cancel.AutoSize = true;
            this.radioButton_cancel.Location = new System.Drawing.Point(650, 127);
            this.radioButton_cancel.Name = "radioButton_cancel";
            this.radioButton_cancel.Size = new System.Drawing.Size(81, 17);
            this.radioButton_cancel.TabIndex = 5;
            this.radioButton_cancel.Text = "Cancelados";
            this.radioButton_cancel.UseVisualStyleBackColor = true;
            this.radioButton_cancel.CheckedChanged += new System.EventHandler(this.radioButton_cancel_CheckedChanged);
            // 
            // dataGridView_senores
            // 
            this.dataGridView_senores.AllowUserToAddRows = false;
            this.dataGridView_senores.AllowUserToDeleteRows = false;
            this.dataGridView_senores.AllowUserToResizeColumns = false;
            this.dataGridView_senores.AllowUserToResizeRows = false;
            this.dataGridView_senores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Playball", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_senores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_senores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_senores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.lastName,
            this.monthPayment});
            this.dataGridView_senores.Location = new System.Drawing.Point(26, 12);
            this.dataGridView_senores.MultiSelect = false;
            this.dataGridView_senores.Name = "dataGridView_senores";
            this.dataGridView_senores.ReadOnly = true;
            this.dataGridView_senores.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_senores.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_senores.RowTemplate.Height = 30;
            this.dataGridView_senores.Size = new System.Drawing.Size(610, 242);
            this.dataGridView_senores.TabIndex = 1;
            this.dataGridView_senores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_senores_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Apellidos";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // monthPayment
            // 
            this.monthPayment.HeaderText = "Mensualidad";
            this.monthPayment.Name = "monthPayment";
            this.monthPayment.ReadOnly = true;
            // 
            // button_generateBill
            // 
            this.button_generateBill.Location = new System.Drawing.Point(134, 453);
            this.button_generateBill.Name = "button_generateBill";
            this.button_generateBill.Size = new System.Drawing.Size(105, 23);
            this.button_generateBill.TabIndex = 13;
            this.button_generateBill.Text = "Generar Factura";
            this.button_generateBill.UseVisualStyleBackColor = true;
            this.button_generateBill.Click += new System.EventHandler(this.button_generateBill_Click);
            // 
            // button_add_payment
            // 
            this.button_add_payment.Location = new System.Drawing.Point(258, 453);
            this.button_add_payment.Name = "button_add_payment";
            this.button_add_payment.Size = new System.Drawing.Size(98, 23);
            this.button_add_payment.TabIndex = 14;
            this.button_add_payment.Text = "Agregar Pago";
            this.button_add_payment.UseVisualStyleBackColor = true;
            this.button_add_payment.Click += new System.EventHandler(this.button_add_payment_Click);
            // 
            // button_monthlyPaymentsTotal
            // 
            this.button_monthlyPaymentsTotal.Location = new System.Drawing.Point(375, 453);
            this.button_monthlyPaymentsTotal.Name = "button_monthlyPaymentsTotal";
            this.button_monthlyPaymentsTotal.Size = new System.Drawing.Size(123, 23);
            this.button_monthlyPaymentsTotal.TabIndex = 15;
            this.button_monthlyPaymentsTotal.Text = "Info Mensualidades";
            this.button_monthlyPaymentsTotal.UseVisualStyleBackColor = true;
            this.button_monthlyPaymentsTotal.Click += new System.EventHandler(this.button_monthlyPaymentsTotal_Click);
            // 
            // generateBills
            // 
            this.generateBills.Location = new System.Drawing.Point(515, 453);
            this.generateBills.Name = "generateBills";
            this.generateBills.Size = new System.Drawing.Size(150, 23);
            this.generateBills.TabIndex = 16;
            this.generateBills.Text = "Generar Todas las Facturas";
            this.generateBills.UseVisualStyleBackColor = true;
            this.generateBills.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.generateBills);
            this.Controls.Add(this.button_monthlyPaymentsTotal);
            this.Controls.Add(this.button_add_payment);
            this.Controls.Add(this.button_generateBill);
            this.Controls.Add(this.dataGridView_panel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.payments_panel);
            this.Controls.Add(this.management_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Pago de mensualidad";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.payments_panel.ResumeLayout(false);
            this.payments_panel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.management_panel.ResumeLayout(false);
            this.management_panel.PerformLayout();
            this.dataGridView_panel.ResumeLayout(false);
            this.dataGridView_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_senores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel payments_panel;
        private System.Windows.Forms.TextBox textBox_searchSenores;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_listPayments;
        private System.Windows.Forms.ToolStripMenuItem menuItem_management;
        private System.Windows.Forms.Panel management_panel;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_lastName;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Panel dataGridView_panel;
        private System.Windows.Forms.DataGridView dataGridView_senores;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_generateBill;
        private System.Windows.Forms.ComboBox comboBox_months;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthPayment;
        private System.Windows.Forms.Button button_add_payment;
        private System.Windows.Forms.Button button_monthlyPaymentsTotal;
        private System.Windows.Forms.Button generateBills;
        private System.Windows.Forms.RadioButton radioButton_does_not_cancel;
        private System.Windows.Forms.RadioButton radioButton_all;
        private System.Windows.Forms.RadioButton radioButton_cancel;
    }
}

