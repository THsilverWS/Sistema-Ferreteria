namespace SistemaFerreteria
{
    partial class FormVentas
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
            txtDniCliente = new TextBox();
            txtCodBarras = new TextBox();
            label1 = new Label();
            label2 = new Label();
            nmCantidad = new NumericUpDown();
            btnAgregar = new Button();
            dgvCarrito = new DataGridView();
            lblTotal = new Label();
            btnFinalizarVenta = new Button();
            tabControl1 = new TabControl();
            Ventas = new TabPage();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            label8 = new Label();
            label7 = new Label();
            cmbTipoVenta = new ComboBox();
            label3 = new Label();
            cmbMetodoPago = new ComboBox();
            txtNomCliente = new TextBox();
            label6 = new Label();
            txtDireccion = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtTelCliente = new TextBox();
            panel1 = new Panel();
            tabPage2 = new TabPage();
            dgvHistorial = new DataGridView();
            panel5 = new Panel();
            btnRefrescar = new Button();
            ((System.ComponentModel.ISupportInitialize)nmCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            tabControl1.SuspendLayout();
            Ventas.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // txtDniCliente
            // 
            txtDniCliente.Location = new Point(119, 124);
            txtDniCliente.MaxLength = 8;
            txtDniCliente.Name = "txtDniCliente";
            txtDniCliente.Size = new Size(100, 23);
            txtDniCliente.TabIndex = 0;
            // 
            // txtCodBarras
            // 
            txtCodBarras.Location = new Point(119, 167);
            txtCodBarras.Name = "txtCodBarras";
            txtCodBarras.Size = new Size(100, 23);
            txtCodBarras.TabIndex = 1;
            txtCodBarras.KeyDown += txtCodBarras_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 124);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 2;
            label1.Text = "DNI/RUC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 170);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 3;
            label2.Text = "Codigo de barras";
            // 
            // nmCantidad
            // 
            nmCantidad.Location = new Point(99, 314);
            nmCantidad.Name = "nmCantidad";
            nmCantidad.Size = new Size(120, 23);
            nmCantidad.TabIndex = 4;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(131, 432);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.AllowUserToResizeColumns = false;
            dgvCarrito.AllowUserToResizeRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.Location = new Point(366, 93);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.Size = new Size(523, 332);
            dgvCarrito.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(224, 38);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 15);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total: S/. 0.00";
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.Anchor = AnchorStyles.Bottom;
            btnFinalizarVenta.Location = new Point(184, 37);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(154, 23);
            btnFinalizarVenta.TabIndex = 8;
            btnFinalizarVenta.Text = "Registrar Venta";
            btnFinalizarVenta.UseVisualStyleBackColor = true;
            btnFinalizarVenta.Click += btnFinalizarVenta_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Ventas);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(919, 552);
            tabControl1.TabIndex = 9;
            // 
            // Ventas
            // 
            Ventas.Controls.Add(dgvCarrito);
            Ventas.Controls.Add(panel4);
            Ventas.Controls.Add(panel3);
            Ventas.Controls.Add(panel2);
            Ventas.Controls.Add(panel1);
            Ventas.Location = new Point(4, 24);
            Ventas.Name = "Ventas";
            Ventas.Padding = new Padding(3);
            Ventas.Size = new Size(911, 524);
            Ventas.TabIndex = 0;
            Ventas.Text = "Ventas";
            Ventas.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnFinalizarVenta);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(366, 425);
            panel4.Name = "panel4";
            panel4.Size = new Size(523, 96);
            panel4.TabIndex = 22;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTotal);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(366, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(523, 90);
            panel3.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnAgregar);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtCodBarras);
            panel2.Controls.Add(txtDniCliente);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(nmCantidad);
            panel2.Controls.Add(cmbTipoVenta);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cmbMetodoPago);
            panel2.Controls.Add(txtNomCliente);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtTelCliente);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(363, 518);
            panel2.TabIndex = 20;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(87, 28);
            label8.Name = "label8";
            label8.Size = new Size(142, 25);
            label8.TabIndex = 19;
            label8.Text = "Registrar Venta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(195, 350);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 18;
            label7.Text = "Tipo de Venta:";
            // 
            // cmbTipoVenta
            // 
            cmbTipoVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoVenta.FormattingEnabled = true;
            cmbTipoVenta.Location = new Point(195, 377);
            cmbTipoVenta.Name = "cmbTipoVenta";
            cmbTipoVenta.Size = new Size(121, 23);
            cmbTipoVenta.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 75);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 9;
            label3.Text = "Nombre";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(26, 377);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(121, 23);
            cmbMetodoPago.TabIndex = 16;
            // 
            // txtNomCliente
            // 
            txtNomCliente.Location = new Point(119, 75);
            txtNomCliente.Name = "txtNomCliente";
            txtNomCliente.Size = new Size(100, 23);
            txtNomCliente.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 350);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 15;
            label6.Text = "Método de Pago:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(119, 216);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 267);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 14;
            label5.Text = "Telefono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 216);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 12;
            label4.Text = "Direccion";
            // 
            // txtTelCliente
            // 
            txtTelCliente.Location = new Point(119, 259);
            txtTelCliente.MaxLength = 9;
            txtTelCliente.Name = "txtTelCliente";
            txtTelCliente.Size = new Size(100, 23);
            txtTelCliente.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(889, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(19, 518);
            panel1.TabIndex = 19;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvHistorial);
            tabPage2.Controls.Add(panel5);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(911, 524);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Registro";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeColumns = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(3, 71);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.Size = new Size(905, 450);
            dgvHistorial.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnRefrescar);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(905, 68);
            panel5.TabIndex = 2;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top;
            btnRefrescar.Location = new Point(329, 26);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(207, 23);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Actualizar pedidos";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click_1;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 552);
            Controls.Add(tabControl1);
            Name = "FormVentas";
            Text = "FormVentas";
            Load += FormVentas_Load;
            ((System.ComponentModel.ISupportInitialize)nmCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            tabControl1.ResumeLayout(false);
            Ventas.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtDniCliente;
        private TextBox txtCodBarras;
        private Label label1;
        private Label label2;
        private NumericUpDown nmCantidad;
        private Button btnAgregar;
        private DataGridView dgvCarrito;
        private Label lblTotal;
        private Button btnFinalizarVenta;
        private TabControl tabControl1;
        private TabPage Ventas;
        private TabPage tabPage2;
        private Button btnRefrescar;
        private DataGridView dgvHistorial;
        private Label label4;
        private TextBox txtDireccion;
        private TextBox txtNomCliente;
        private Label label3;
        private Label label5;
        private TextBox txtTelCliente;
        private ComboBox cmbMetodoPago;
        private Label label6;
        private Label label7;
        private ComboBox cmbTipoVenta;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label label8;
        private Panel panel5;
    }
}