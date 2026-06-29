namespace SistemaFerreteria
{
    partial class FormAuditoria
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
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label7 = new Label();
            txtId = new TextBox();
            txtFecha = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtHora = new TextBox();
            txtNombreEquip = new TextBox();
            txtTablaAfectada = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCargo = new TextBox();
            cboEmpleado = new ComboBox();
            panel3 = new Panel();
            panel4 = new Panel();
            dgvAuditoria = new DataGridView();
            txtValoresAnteriores = new TextBox();
            txtValoresNuevos = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(950, 187);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 332);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtValoresNuevos);
            panel2.Controls.Add(txtValoresAnteriores);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(txtFecha);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtHora);
            panel2.Controls.Add(txtNombreEquip);
            panel2.Controls.Add(txtTablaAfectada);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtCargo);
            panel2.Controls.Add(cboEmpleado);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(960, 187);
            panel2.TabIndex = 1;
            // 
            // button4
            // 
            button4.Location = new Point(607, 158);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 17;
            button4.Text = "Exportar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(490, 158);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 16;
            button3.Text = "Limpiar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
            // button1
            // 
            button1.Location = new Point(259, 158);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 14;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(784, 46);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 13;
            label7.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Location = new Point(810, 43);
            txtId.Name = "txtId";
            txtId.Size = new Size(71, 23);
            txtId.TabIndex = 12;
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(664, 26);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(89, 23);
            txtFecha.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(622, 57);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 10;
            label6.Text = "Hora:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(622, 26);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 9;
            label5.Text = "Fecha:";
            // 
            // txtHora
            // 
            txtHora.Location = new Point(664, 54);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(89, 23);
            txtHora.TabIndex = 8;
            // 
            // txtNombreEquip
            // 
            txtNombreEquip.Location = new Point(393, 51);
            txtNombreEquip.Name = "txtNombreEquip";
            txtNombreEquip.Size = new Size(201, 23);
            txtNombreEquip.TabIndex = 7;
            // 
            // txtTablaAfectada
            // 
            txtTablaAfectada.Location = new Point(393, 18);
            txtTablaAfectada.Name = "txtTablaAfectada";
            txtTablaAfectada.ReadOnly = true;
            txtTablaAfectada.Size = new Size(201, 23);
            txtTablaAfectada.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(301, 51);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 5;
            label4.Text = "Nombre Equip. :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(301, 21);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 4;
            label3.Text = "Tabla afectada:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Cargo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Empleado:";
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(81, 51);
            txtCargo.Name = "txtCargo";
            txtCargo.ReadOnly = true;
            txtCargo.Size = new Size(201, 23);
            txtCargo.TabIndex = 1;
            // 
            // cboEmpleado
            // 
            cboEmpleado.FormattingEnabled = true;
            cboEmpleado.Location = new Point(81, 18);
            cboEmpleado.Name = "cboEmpleado";
            cboEmpleado.Size = new Size(201, 23);
            cboEmpleado.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 187);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 332);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 519);
            panel4.Name = "panel4";
            panel4.Size = new Size(960, 76);
            panel4.TabIndex = 2;
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.AllowUserToResizeColumns = false;
            dgvAuditoria.AllowUserToResizeRows = false;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditoria.Dock = DockStyle.Fill;
            dgvAuditoria.Location = new Point(10, 187);
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.Size = new Size(940, 332);
            dgvAuditoria.TabIndex = 3;
            dgvAuditoria.CellClick += dgvAuditoria_CellClick;
            // 
            // txtValoresAnteriores
            // 
            txtValoresAnteriores.Location = new Point(81, 114);
            txtValoresAnteriores.Name = "txtValoresAnteriores";
            txtValoresAnteriores.Size = new Size(201, 23);
            txtValoresAnteriores.TabIndex = 18;
            // 
            // txtValoresNuevos
            // 
            txtValoresNuevos.Location = new Point(552, 114);
            txtValoresNuevos.Name = "txtValoresNuevos";
            txtValoresNuevos.Size = new Size(201, 23);
            txtValoresNuevos.TabIndex = 19;
            // 
            // FormAuditoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 595);
            Controls.Add(dgvAuditoria);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Name = "FormAuditoria";
            Text = "Registro";
            Load += FormAuditoria_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private TextBox txtCargo;
        private ComboBox cboEmpleado;
        private DataGridView dgvAuditoria;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtNombreEquip;
        private TextBox txtTablaAfectada;
        private Label label7;
        private TextBox txtId;
        private TextBox txtFecha;
        private Label label6;
        private Label label5;
        private TextBox txtHora;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox txtValoresNuevos;
        private TextBox txtValoresAnteriores;
    }
}