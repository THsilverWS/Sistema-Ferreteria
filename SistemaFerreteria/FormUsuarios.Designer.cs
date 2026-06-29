namespace SistemaFerreteria
{
    partial class FormUsuarios
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
            dgvUsuarios = new DataGridView();
            panel3 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            cmbCargo = new ComboBox();
            label3 = new Label();
            txtContraseña = new TextBox();
            label2 = new Label();
            cmbEmpleado = new ComboBox();
            txtUsuario = new TextBox();
            txtDni = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnEditar = new Button();
            txtId = new TextBox();
            label4 = new Label();
            btnLimpiar = new Button();
            btnExportar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(10, 24);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(610, 400);
            dgvUsuarios.TabIndex = 11;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(620, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 400);
            panel3.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 400);
            panel2.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.Controls.Add(cmbCargo);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtContraseña);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(cmbEmpleado);
            panel4.Controls.Add(txtUsuario);
            panel4.Controls.Add(txtDni);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(btnEditar);
            panel4.Controls.Add(txtId);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(btnLimpiar);
            panel4.Controls.Add(btnExportar);
            panel4.Controls.Add(btnActualizar);
            panel4.Controls.Add(btnEliminar);
            panel4.Controls.Add(btnGuardar);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 424);
            panel4.Name = "panel4";
            panel4.Size = new Size(630, 265);
            panel4.TabIndex = 8;
            // 
            // cmbCargo
            // 
            cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(387, 54);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(218, 23);
            cmbCargo.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(318, 54);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 28;
            label3.Text = "Cargo:";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(88, 48);
            txtContraseña.MaxLength = 200;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(218, 23);
            txtContraseña.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 26;
            label2.Text = "Contraseña:";
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(387, 19);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(218, 23);
            cmbEmpleado.TabIndex = 25;
            cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(88, 19);
            txtUsuario.MaxLength = 200;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(218, 23);
            txtUsuario.TabIndex = 24;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(353, 106);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(143, 23);
            txtDni.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(317, 109);
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
            label6.Size = new Size(63, 15);
            label6.TabIndex = 19;
            label6.Text = "Empleado:";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(106, 195);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(193, 106);
            txtId.MaxLength = 8;
            txtId.Name = "txtId";
            txtId.Size = new Size(97, 23);
            txtId.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(163, 109);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 12;
            label4.Text = "ID: ";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(433, 197);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(541, 197);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 10;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(335, 197);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(215, 197);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 195);
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
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 24);
            panel1.TabIndex = 7;
            // 
            // FormUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 689);
            Controls.Add(dgvUsuarios);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "FormUsuarios";
            Text = "Usuarios";
            Load += FormUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private TextBox textBox2;
        private Label label7;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label8;
        private Button button1;
        private TextBox textBox5;
        private Label label9;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label10;
        private TextBox txtContraseña;
        private Label label2;
        private ComboBox cmbEmpleado;
        private TextBox txtUsuario;
        private TextBox txtDni;
        private Label label5;
        private Label label6;
        private Button btnEditar;
        private TextBox txtId;
        private Label label4;
        private Button btnLimpiar;
        private Button btnExportar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label label1;
        private Panel panel1;
        private ComboBox cmbCargo;
        private Label label3;
    }
}