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
            tabPage1 = new TabPage();
            label5 = new Label();
            txtTelCliente = new TextBox();
            label4 = new Label();
            txtDireccion = new TextBox();
            txtNomCliente = new TextBox();
            label3 = new Label();
            tabPage2 = new TabPage();
            btnRefrescar = new Button();
            dgvHistorial = new DataGridView();
            label6 = new Label();
            cmbMetodoPago = new ComboBox();
            cmbTipoVenta = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nmCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // txtDniCliente
            // 
            txtDniCliente.Location = new Point(109, 72);
            txtDniCliente.Name = "txtDniCliente";
            txtDniCliente.Size = new Size(100, 23);
            txtDniCliente.TabIndex = 0;
            // 
            // txtCodBarras
            // 
            txtCodBarras.Location = new Point(109, 115);
            txtCodBarras.Name = "txtCodBarras";
            txtCodBarras.Size = new Size(100, 23);
            txtCodBarras.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 72);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 2;
            label1.Text = "DNI/RUC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 118);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 3;
            label2.Text = "Codigo de barras";
            // 
            // nmCantidad
            // 
            nmCantidad.Location = new Point(109, 252);
            nmCantidad.Name = "nmCantidad";
            nmCantidad.Size = new Size(120, 23);
            nmCantidad.TabIndex = 4;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(121, 380);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(413, 72);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(340, 232);
            dgvCarrito.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(538, 35);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 15);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total: S/. 0.00";
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.Location = new Point(494, 359);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(154, 23);
            btnFinalizarVenta.TabIndex = 8;
            btnFinalizarVenta.Text = "Registrar Venta";
            btnFinalizarVenta.UseVisualStyleBackColor = true;
            btnFinalizarVenta.Click += btnFinalizarVenta_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(cmbTipoVenta);
            tabPage1.Controls.Add(cmbMetodoPago);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtTelCliente);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtDireccion);
            tabPage1.Controls.Add(txtNomCliente);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(nmCantidad);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(btnFinalizarVenta);
            tabPage1.Controls.Add(txtDniCliente);
            tabPage1.Controls.Add(txtCodBarras);
            tabPage1.Controls.Add(dgvCarrito);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btnAgregar);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 215);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 14;
            label5.Text = "Telefono";
            // 
            // txtTelCliente
            // 
            txtTelCliente.Location = new Point(109, 207);
            txtTelCliente.Name = "txtTelCliente";
            txtTelCliente.Size = new Size(100, 23);
            txtTelCliente.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 164);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 12;
            label4.Text = "Direccion";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(109, 164);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 11;
            // 
            // txtNomCliente
            // 
            txtNomCliente.Location = new Point(109, 23);
            txtNomCliente.Name = "txtNomCliente";
            txtNomCliente.Size = new Size(100, 23);
            txtNomCliente.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 23);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 9;
            label3.Text = "Nombre";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnRefrescar);
            tabPage2.Controls.Add(dgvHistorial);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top;
            btnRefrescar.Location = new Point(269, 51);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(207, 23);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Actualizar pedidos";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click_1;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Bottom;
            dgvHistorial.Location = new Point(3, 128);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.Size = new Size(786, 291);
            dgvHistorial.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 298);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 15;
            label6.Text = "Método de Pago:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(16, 325);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(121, 23);
            cmbMetodoPago.TabIndex = 16;
            // 
            // cmbTipoVenta
            // 
            cmbTipoVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoVenta.FormattingEnabled = true;
            cmbTipoVenta.Location = new Point(185, 325);
            cmbTipoVenta.Name = "cmbTipoVenta";
            cmbTipoVenta.Size = new Size(121, 23);
            cmbTipoVenta.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(185, 298);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 18;
            label7.Text = "Tipo de Venta:";
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "FormVentas";
            Text = "FormVentas";
            Load += FormVentas_Load;
            ((System.ComponentModel.ISupportInitialize)nmCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
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
        private TabPage tabPage1;
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
    }
}