namespace SistemaFerreteria
{
    partial class FormInventarioAv
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
            dgvInventario = new DataGridView();
            panel3 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            lblPagina = new Label();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            panel1 = new Panel();
            numStockMinimo = new NumericUpDown();
            numStockActual = new NumericUpDown();
            label4 = new Label();
            label6 = new Label();
            btnEditar = new Button();
            label1 = new Label();
            btnImportar = new Button();
            txtBuscar = new TextBox();
            btnExportar = new Button();
            label2 = new Label();
            btnLimpiar = new Button();
            btnActualizar = new Button();
            txtProducto = new TextBox();
            btnEliminar = new Button();
            btnGuardar = new Button();
            label5 = new Label();
            txtIdProducto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockActual).BeginInit();
            SuspendLayout();
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToResizeColumns = false;
            dgvInventario.AllowUserToResizeRows = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(10, 251);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(780, 423);
            dgvInventario.TabIndex = 31;
            dgvInventario.CellClick += dgvInventario_CellClick;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 251);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 423);
            panel3.TabIndex = 34;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(790, 251);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 423);
            panel2.TabIndex = 33;
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
            panel4.TabIndex = 35;
            // 
            // lblPagina
            // 
            lblPagina.Anchor = AnchorStyles.Bottom;
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(394, 37);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(55, 15);
            lblPagina.TabIndex = 31;
            lblPagina.Text = "Página: 0";
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Bottom;
            btnAnterior.Location = new Point(291, 33);
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
            btnSiguiente.Location = new Point(467, 33);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 23);
            btnSiguiente.TabIndex = 0;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(numStockMinimo);
            panel1.Controls.Add(numStockActual);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnImportar);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(btnExportar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(txtProducto);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtIdProducto);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 251);
            panel1.TabIndex = 32;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(425, 108);
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(120, 23);
            numStockMinimo.TabIndex = 32;
            // 
            // numStockActual
            // 
            numStockActual.Location = new Point(425, 73);
            numStockActual.Name = "numStockActual";
            numStockActual.Size = new Size(120, 23);
            numStockActual.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(335, 75);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 29;
            label4.Text = "Stock Actual";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(335, 110);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 30;
            label6.Text = "Stock Minimo";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar";
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
            // txtBuscar
            // 
            txtBuscar.Location = new Point(75, 23);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(362, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 81);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 2;
            label2.Text = "Producto";
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
            // btnActualizar
            // 
            btnActualizar.Location = new Point(362, 202);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 23;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(72, 73);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(212, 23);
            txtProducto.TabIndex = 5;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(467, 27);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 7;
            label5.Text = "ID";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(491, 24);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(100, 23);
            txtIdProducto.TabIndex = 9;
            // 
            // FormInventarioAv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 756);
            Controls.Add(dgvInventario);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "FormInventarioAv";
            Text = "FormInventarioAv";
            Load += FormInventarioAv_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockActual).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvInventario;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Label lblPagina;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Panel panel1;
        private Button btnEditar;
        private Label label1;
        private Button btnImportar;
        private TextBox txtBuscar;
        private Button btnExportar;
        private Label label2;
        private Button btnLimpiar;
        private Button btnActualizar;
        private TextBox txtProducto;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label label5;
        private TextBox txtIdProducto;
        private NumericUpDown numStockMinimo;
        private NumericUpDown numStockActual;
        private Label label4;
        private Label label6;
    }
}