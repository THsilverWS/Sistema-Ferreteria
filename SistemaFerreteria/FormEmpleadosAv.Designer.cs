namespace SistemaFerreteria
{
    partial class FormEmpleadosAv
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
            panel1 = new Panel();
            panel4 = new Panel();
            label5 = new Label();
            btnEditar = new Button();
            dtpFechaAñadido = new DateTimePicker();
            cmbCargo = new ComboBox();
            txtId = new TextBox();
            label4 = new Label();
            btnLimpiar = new Button();
            btnExportar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            txtDni = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            dgvEmpleados = new DataGridView();
            chkEstado = new CheckBox();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 24);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(chkEstado);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(btnEditar);
            panel4.Controls.Add(dtpFechaAñadido);
            panel4.Controls.Add(cmbCargo);
            panel4.Controls.Add(txtId);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(btnLimpiar);
            panel4.Controls.Add(btnExportar);
            panel4.Controls.Add(btnActualizar);
            panel4.Controls.Add(btnEliminar);
            panel4.Controls.Add(btnGuardar);
            panel4.Controls.Add(txtDni);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtNombre);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 424);
            panel4.Name = "panel4";
            panel4.Size = new Size(630, 265);
            panel4.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(318, 102);
            label5.Name = "label5";
            label5.Size = new Size(131, 15);
            label5.TabIndex = 17;
            label5.Text = "Fecha de incorporación";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(106, 186);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // dtpFechaAñadido
            // 
            dtpFechaAñadido.Format = DateTimePickerFormat.Short;
            dtpFechaAñadido.Location = new Point(455, 97);
            dtpFechaAñadido.Name = "dtpFechaAñadido";
            dtpFechaAñadido.Size = new Size(104, 23);
            dtpFechaAñadido.TabIndex = 15;
            // 
            // cmbCargo
            // 
            cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(72, 56);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(218, 23);
            cmbCargo.TabIndex = 14;
            // 
            // txtId
            // 
            txtId.Location = new Point(147, 100);
            txtId.MaxLength = 8;
            txtId.Name = "txtId";
            txtId.Size = new Size(143, 23);
            txtId.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 103);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 12;
            label4.Text = "ID: ";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(433, 188);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(541, 188);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 10;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(335, 188);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(215, 188);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 186);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(377, 53);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(239, 23);
            txtDni.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(341, 57);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 4;
            label3.Text = "DNI:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Cargo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(72, 19);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(548, 23);
            txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 400);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(620, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 400);
            panel3.TabIndex = 5;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Dock = DockStyle.Fill;
            dgvEmpleados.Location = new Point(10, 24);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(610, 400);
            dgvEmpleados.TabIndex = 6;
            dgvEmpleados.CellClick += dgvEmpleados_CellClick;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Location = new Point(269, 144);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(113, 19);
            chkEstado.TabIndex = 18;
            chkEstado.Text = "Activo / Inactivo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // FormEmpleadosAv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 689);
            Controls.Add(dgvEmpleados);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "FormEmpleadosAv";
            Text = "Empleados";
            Load += FormEmpleadosAv_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtDni;
        private Label label3;
        private Label label2;
        private TextBox txtNombre;
        private Label label1;
        private Button btnExportar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnLimpiar;
        private DataGridView dgvEmpleados;
        private DateTimePicker dtpFechaAñadido;
        private ComboBox cmbCargo;
        private Label label5;
        private Button btnEditar;
        private TextBox txtId;
        private Label label4;
        private CheckBox chkEstado;
    }
}