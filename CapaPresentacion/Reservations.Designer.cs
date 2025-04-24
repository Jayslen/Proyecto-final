namespace CapaPresentacion
{
    partial class Reservations
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
            this.ServicesInput = new System.Windows.Forms.ComboBox();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicesDataSet = new CapaPresentacion.ServicesDataSet();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ReservationGrid = new System.Windows.Forms.DataGridView();
            this.UserCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.HourInput = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.servicesTableAdapter = new CapaPresentacion.ServicesDataSetTableAdapters.servicesTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.QuequeBtn = new System.Windows.Forms.Button();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.GeneratePDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServicesInput
            // 
            this.ServicesInput.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.servicesBindingSource, "service_id", true));
            this.ServicesInput.DataSource = this.servicesBindingSource;
            this.ServicesInput.DisplayMember = "service_name";
            this.ServicesInput.FormattingEnabled = true;
            this.ServicesInput.Location = new System.Drawing.Point(16, 69);
            this.ServicesInput.Name = "ServicesInput";
            this.ServicesInput.Size = new System.Drawing.Size(263, 21);
            this.ServicesInput.TabIndex = 30;
            this.ServicesInput.ValueMember = "service_id";
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataMember = "services";
            this.servicesBindingSource.DataSource = this.servicesDataSet;
            // 
            // servicesDataSet
            // 
            this.servicesDataSet.DataSetName = "ServicesDataSet";
            this.servicesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBtn.Location = new System.Drawing.Point(3, 3);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(110, 127);
            this.DeleteBtn.TabIndex = 29;
            this.DeleteBtn.Text = "Eliminar reserva";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click_1);
            // 
            // ReservationGrid
            // 
            this.ReservationGrid.AllowUserToAddRows = false;
            this.ReservationGrid.AllowUserToDeleteRows = false;
            this.ReservationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReservationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserCol,
            this.ServiceCol,
            this.DateCol,
            this.StateCol,
            this.ServiceId});
            this.ReservationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReservationGrid.Location = new System.Drawing.Point(0, 0);
            this.ReservationGrid.Name = "ReservationGrid";
            this.ReservationGrid.ReadOnly = true;
            this.ReservationGrid.Size = new System.Drawing.Size(540, 304);
            this.ReservationGrid.TabIndex = 28;
            // 
            // UserCol
            // 
            this.UserCol.HeaderText = "Usuario";
            this.UserCol.Name = "UserCol";
            this.UserCol.ReadOnly = true;
            // 
            // ServiceCol
            // 
            this.ServiceCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServiceCol.HeaderText = "Servicio";
            this.ServiceCol.Name = "ServiceCol";
            this.ServiceCol.ReadOnly = true;
            // 
            // DateCol
            // 
            this.DateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateCol.HeaderText = "Fecha";
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            // 
            // StateCol
            // 
            this.StateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StateCol.HeaderText = "Estado";
            this.StateCol.Name = "StateCol";
            this.StateCol.ReadOnly = true;
            // 
            // ServiceId
            // 
            this.ServiceId.HeaderText = "ServiceId";
            this.ServiceId.Name = "ServiceId";
            this.ServiceId.ReadOnly = true;
            this.ServiceId.Visible = false;
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(16, 121);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(200, 20);
            this.Date.TabIndex = 27;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(16, 199);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(106, 35);
            this.ConfirmBtn.TabIndex = 26;
            this.ConfirmBtn.Text = "Confirmar";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click_1);
            // 
            // HourInput
            // 
            this.HourInput.FormattingEnabled = true;
            this.HourInput.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.HourInput.Location = new System.Drawing.Point(16, 172);
            this.HourInput.Name = "HourInput";
            this.HourInput.Size = new System.Drawing.Size(106, 21);
            this.HourInput.TabIndex = 25;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(11, 144);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 25);
            this.label.TabIndex = 24;
            this.label.Text = "Hora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Seleccione el servio deseado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, -5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 45);
            this.label4.TabIndex = 21;
            this.label4.Text = "Reservas";
            // 
            // servicesTableAdapter
            // 
            this.servicesTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ReservationGrid);
            this.panel1.Location = new System.Drawing.Point(16, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 304);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.GeneratePDF);
            this.panel2.Controls.Add(this.DoneBtn);
            this.panel2.Controls.Add(this.QuequeBtn);
            this.panel2.Controls.Add(this.DeleteBtn);
            this.panel2.Location = new System.Drawing.Point(562, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 304);
            this.panel2.TabIndex = 33;
            // 
            // QuequeBtn
            // 
            this.QuequeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuequeBtn.Location = new System.Drawing.Point(3, 242);
            this.QuequeBtn.Name = "QuequeBtn";
            this.QuequeBtn.Size = new System.Drawing.Size(110, 53);
            this.QuequeBtn.TabIndex = 32;
            this.QuequeBtn.Text = "Espera";
            this.QuequeBtn.UseVisualStyleBackColor = true;
            this.QuequeBtn.Visible = false;
            this.QuequeBtn.Click += new System.EventHandler(this.QuequeBtn_Click);
            // 
            // DoneBtn
            // 
            this.DoneBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneBtn.Location = new System.Drawing.Point(3, 186);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(110, 51);
            this.DoneBtn.TabIndex = 33;
            this.DoneBtn.Text = "Completada";
            this.DoneBtn.UseVisualStyleBackColor = true;
            this.DoneBtn.Visible = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click_1);
            // 
            // GeneratePDF
            // 
            this.GeneratePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneratePDF.Location = new System.Drawing.Point(3, 131);
            this.GeneratePDF.Name = "GeneratePDF";
            this.GeneratePDF.Size = new System.Drawing.Size(110, 53);
            this.GeneratePDF.TabIndex = 34;
            this.GeneratePDF.Text = "Generar PDF";
            this.GeneratePDF.UseVisualStyleBackColor = true;
            this.GeneratePDF.Click += new System.EventHandler(this.GeneratePDF_Click);
            // 
            // Reservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 557);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ServicesInput);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.HourInput);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reservations";
            this.Text = "Reservations";
            this.Load += new System.EventHandler(this.Reservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ServicesInput;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.DataGridView ReservationGrid;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.ComboBox HourInput;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private ServicesDataSet servicesDataSet;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private ServicesDataSetTableAdapters.servicesTableAdapter servicesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button QuequeBtn;
        private System.Windows.Forms.Button GeneratePDF;
        private System.Windows.Forms.Button DoneBtn;
    }
}