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
            label2 = new Label();
            dtpFechaAñadido = new DateTimePicker();
            chkEstado = new CheckBox();
            cmbCargo = new ComboBox();
            txtNombre = new TextBox();
            txtDni = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnEditar = new Button();
            txtId = new TextBox();
            label4 = new Label();
            btnLimpiar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            dgvEmpleados = new DataGridView();
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
            panel4.Controls.Add(label2);
            panel4.Controls.Add(dtpFechaAñadido);
            panel4.Controls.Add(chkEstado);
            panel4.Controls.Add(cmbCargo);
            panel4.Controls.Add(txtNombre);
            panel4.Controls.Add(txtDni);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(btnEditar);
            panel4.Controls.Add(txtId);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(btnLimpiar);
            panel4.Controls.Add(btnActualizar);
            panel4.Controls.Add(btnEliminar);
            panel4.Controls.Add(btnGuardar);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 424);
            panel4.Name = "panel4";
            panel4.Size = new Size(630, 265);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 118);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 28;
            label2.Text = "Fecha de registro:";
            // 
            // dtpFechaAñadido
            // 
            dtpFechaAñadido.Format = DateTimePickerFormat.Short;
            dtpFechaAñadido.Location = new Point(335, 122);
            dtpFechaAñadido.Name = "dtpFechaAñadido";
            dtpFechaAñadido.Size = new Size(119, 23);
            dtpFechaAñadido.TabIndex = 27;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Location = new Point(268, 151);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(113, 19);
            chkEstado.TabIndex = 26;
            chkEstado.Text = "Activo / Inactivo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // cmbCargo
            // 
            cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(366, 19);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(218, 23);
            cmbCargo.TabIndex = 25;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(88, 19);
            txtNombre.MaxLength = 200;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(218, 23);
            txtNombre.TabIndex = 24;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(366, 68);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(143, 23);
            txtDni.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(330, 71);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 22;
            label5.Text = "DNI:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(318, 22);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 19;
            label6.Text = "Cargo:";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(149, 192);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(147, 65);
            txtId.MaxLength = 8;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(159, 23);
            txtId.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 68);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 12;
            label4.Text = "ID: ";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(476, 194);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(378, 194);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(258, 194);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(55, 192);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
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
        private TextBox txtNombre;
        private Label label1;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnLimpiar;
        private DataGridView dgvEmpleados;
        private Button btnEditar;
        private TextBox txtId;
        private Label label4;
        private Label label6;
        private TextBox txtDni;
        private Label label5;
        private ComboBox cmbCargo;
        private CheckBox chkEstado;
        private DateTimePicker dtpFechaAñadido;
        private Label label2;
    }
}