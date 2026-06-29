namespace SistemaFerreteria
{
    partial class FormProductosAv
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
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtPrecioCompra = new TextBox();
            txtPrecioVenta = new TextBox();
            label5 = new Label();
            txtIdProducto = new TextBox();
            cmbProveedor = new ComboBox();
            cmbCategoria = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtCodigoBarras = new TextBox();
            label9 = new Label();
            cmbEstante = new ComboBox();
            dgvProductos = new DataGridView();
            Descripcion = new Label();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnLimpiar = new Button();
            btnExportar = new Button();
            btnImportar = new Button();
            panel1 = new Panel();
            btnPrueba = new Button();
            btnEditar = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            lblPagina = new Label();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(75, 23);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(362, 23);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 81);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Precio Compra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(245, 116);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 3;
            label3.Text = "Precio Venta";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Location = new Point(337, 73);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(100, 23);
            txtPrecioCompra.TabIndex = 5;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(337, 113);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(500, 152);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 7;
            label5.Text = "ID";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(548, 144);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(100, 23);
            txtIdProducto.TabIndex = 9;
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(75, 113);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(149, 23);
            cmbProveedor.TabIndex = 10;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(76, 70);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(148, 23);
            cmbCategoria.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 116);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 12;
            label6.Text = "Proveedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 73);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 13;
            label7.Text = "Categoria";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(245, 150);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 14;
            label8.Text = "Codigo Barras";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(337, 147);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(100, 23);
            txtCodigoBarras.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 150);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 16;
            label9.Text = "Estante";
            // 
            // cmbEstante
            // 
            cmbEstante.FormattingEnabled = true;
            cmbEstante.Location = new Point(75, 147);
            cmbEstante.Name = "cmbEstante";
            cmbEstante.Size = new Size(149, 23);
            cmbEstante.TabIndex = 17;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(10, 251);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(780, 423);
            dgvProductos.TabIndex = 18;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // Descripcion
            // 
            Descripcion.AutoSize = true;
            Descripcion.Location = new Point(473, 81);
            Descripcion.Name = "Descripcion";
            Descripcion.Size = new Size(69, 15);
            Descripcion.TabIndex = 19;
            Descripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(548, 73);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(240, 65);
            txtDescripcion.TabIndex = 20;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(22, 202);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(137, 202);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(362, 202);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 23;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(473, 202);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 24;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(703, 202);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 25;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(590, 202);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(75, 23);
            btnImportar.TabIndex = 26;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnPrueba);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnImportar);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(btnExportar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(txtPrecioCompra);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(txtPrecioVenta);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(txtIdProducto);
            panel1.Controls.Add(Descripcion);
            panel1.Controls.Add(cmbProveedor);
            panel1.Controls.Add(cmbCategoria);
            panel1.Controls.Add(cmbEstante);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtCodigoBarras);
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 251);
            panel1.TabIndex = 27;
            // 
            // btnPrueba
            // 
            btnPrueba.Location = new Point(603, 32);
            btnPrueba.Name = "btnPrueba";
            btnPrueba.Size = new Size(75, 23);
            btnPrueba.TabIndex = 28;
            btnPrueba.Text = "Prueba";
            btnPrueba.UseVisualStyleBackColor = true;
            btnPrueba.Click += btnPrueba_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(245, 202);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 27;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(790, 251);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 423);
            panel2.TabIndex = 28;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 251);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 423);
            panel3.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(lblPagina);
            panel4.Controls.Add(btnAnterior);
            panel4.Controls.Add(btnSiguiente);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 674);
            panel4.Name = "panel4";
            panel4.Size = new Size(800, 82);
            panel4.TabIndex = 30;
            // 
            // lblPagina
            // 
            lblPagina.Anchor = AnchorStyles.Bottom;
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(346, 42);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(55, 15);
            lblPagina.TabIndex = 31;
            lblPagina.Text = "Página: 0";
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Bottom;
            btnAnterior.Location = new Point(242, 38);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Bottom;
            btnSiguiente.Location = new Point(418, 38);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 23);
            btnSiguiente.TabIndex = 0;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // FormProductosAv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 756);
            Controls.Add(dgvProductos);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "FormProductosAv";
            Text = "FormProductosAv";
            Load += FormProductosAv_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPrecioCompra;
        private TextBox txtPrecioVenta;
        private Label label5;
        private TextBox txtIdProducto;
        private ComboBox cmbProveedor;
        private ComboBox cmbCategoria;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtCodigoBarras;
        private Label label9;
        private ComboBox cmbEstante;
        private DataGridView dgvProductos;
        private Label Descripcion;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnLimpiar;
        private Button btnExportar;
        private Button btnImportar;
        private Panel panel1;
        private Button btnEditar;
        private Button btnPrueba;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Label lblPagina;
    }
}