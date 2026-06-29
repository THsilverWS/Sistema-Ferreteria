namespace SistemaFerreteria
{
    partial class FormListaVentas
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
            dgvVentas = new DataGridView();
            groupBox1 = new GroupBox();
            txtNuevoTotal = new NumericUpDown();
            btnEliminar = new Button();
            btnActualizar = new Button();
            txtBuscarCliente = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            txtBuscarEmpleadoDNI = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNuevoTotal).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.Location = new Point(289, 0);
            dgvVentas.Margin = new Padding(4, 3, 4, 3);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.Size = new Size(644, 519);
            dgvVentas.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNuevoTotal);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Location = new Point(14, 25);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(258, 135);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acciones";
            // 
            // txtNuevoTotal
            // 
            txtNuevoTotal.Location = new Point(60, 103);
            txtNuevoTotal.Name = "txtNuevoTotal";
            txtNuevoTotal.Size = new Size(120, 23);
            txtNuevoTotal.TabIndex = 3;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(28, 70);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(198, 27);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar Registro";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(28, 37);
            btnActualizar.Margin = new Padding(4, 3, 4, 3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(198, 27);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar Ventas";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(84, 214);
            txtBuscarCliente.Margin = new Padding(4, 3, 4, 3);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(116, 23);
            txtBuscarCliente.TabIndex = 2;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 163);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 3;
            label1.Text = "Busqueda por DNI o RUC";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtBuscarEmpleadoDNI);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBuscarCliente);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(289, 519);
            panel1.TabIndex = 4;
            // 
            // txtBuscarEmpleadoDNI
            // 
            txtBuscarEmpleadoDNI.Location = new Point(84, 288);
            txtBuscarEmpleadoDNI.Margin = new Padding(4, 3, 4, 3);
            txtBuscarEmpleadoDNI.Name = "txtBuscarEmpleadoDNI";
            txtBuscarEmpleadoDNI.Size = new Size(116, 23);
            txtBuscarEmpleadoDNI.TabIndex = 4;
            txtBuscarEmpleadoDNI.TextChanged += txtBuscarEmpleadoDNI_TextChanged;
            // 
            // FormListaVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(dgvVentas);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormListaVentas";
            Text = "FormListaPedidos";
            Load += FormListaVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNuevoTotal).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private TextBox txtBuscarEmpleadoDNI;
        private NumericUpDown txtNuevoTotal;
    }
}