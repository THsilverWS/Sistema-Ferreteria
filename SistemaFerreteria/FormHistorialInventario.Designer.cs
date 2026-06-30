namespace SistemaFerreteria
{
    partial class FormHistorialInventario
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
            dgvHistorial = new DataGridView();
            panel3 = new Panel();
            panel1 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            btnExportar = new Button();
            btnLimpiar = new Button();
            button2 = new Button();
            btnBuscar = new Button();
            label7 = new Label();
            txtId = new TextBox();
            txtFecha = new TextBox();
            label5 = new Label();
            txtTablaAfectada = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCargo = new TextBox();
            cboEmpleado = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToResizeColumns = false;
            dgvHistorial.AllowUserToResizeRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(10, 187);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.Size = new Size(940, 332);
            dgvHistorial.TabIndex = 8;
            dgvHistorial.CellClick += dgvHistorial_CellClick;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 187);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 332);
            panel3.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(950, 187);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 332);
            panel1.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 519);
            panel4.Name = "panel4";
            panel4.Size = new Size(960, 76);
            panel4.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnExportar);
            panel2.Controls.Add(btnLimpiar);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(txtFecha);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtTablaAfectada);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtCargo);
            panel2.Controls.Add(cboEmpleado);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(960, 187);
            panel2.TabIndex = 5;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(607, 158);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 17;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(490, 158);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(372, 158);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 15;
            button2.Text = "Actualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(259, 158);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(393, 108);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 13;
            label7.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Location = new Point(419, 105);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(71, 23);
            txtId.TabIndex = 12;
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(414, 64);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(159, 23);
            txtFecha.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(372, 64);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 9;
            label5.Text = "Fecha:";
            // 
            // txtTablaAfectada
            // 
            txtTablaAfectada.Location = new Point(449, 26);
            txtTablaAfectada.Name = "txtTablaAfectada";
            txtTablaAfectada.ReadOnly = true;
            txtTablaAfectada.Size = new Size(201, 23);
            txtTablaAfectada.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(368, 26);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 4;
            label3.Text = "Movimiento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 59);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Cargo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 26);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Empleado:";
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(148, 56);
            txtCargo.Name = "txtCargo";
            txtCargo.ReadOnly = true;
            txtCargo.Size = new Size(201, 23);
            txtCargo.TabIndex = 1;
            // 
            // cboEmpleado
            // 
            cboEmpleado.FormattingEnabled = true;
            cboEmpleado.Location = new Point(148, 23);
            cboEmpleado.Name = "cboEmpleado";
            cboEmpleado.Size = new Size(201, 23);
            cboEmpleado.TabIndex = 0;
            // 
            // FormHistorialInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 595);
            Controls.Add(dgvHistorial);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Name = "FormHistorialInventario";
            Text = "FormHistorialInventario";
            Load += FormHistorialInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHistorial;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private Panel panel2;
        private Button btnExportar;
        private Button btnLimpiar;
        private Button button2;
        private Button btnBuscar;
        private Label label7;
        private TextBox txtId;
        private TextBox txtFecha;
        private Label label5;
        private TextBox txtTablaAfectada;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCargo;
        private ComboBox cboEmpleado;
    }
}