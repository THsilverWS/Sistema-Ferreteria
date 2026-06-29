namespace SistemaFerreteria
{
    partial class FormInventario
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            chkActivo = new CheckBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            lblId = new Label();
            btnEliminar = new Button();
            panel1 = new Panel();
            txtCodBarras = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.GridColor = Color.Gray;
            dgvProductos.Location = new Point(363, 0);
            dgvProductos.Margin = new Padding(5, 3, 5, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.Size = new Size(560, 644);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 140);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 17);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 183);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(48, 17);
            label2.TabIndex = 2;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 226);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 3;
            label3.Text = "Stock";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(107, 279);
            chkActivo.Margin = new Padding(5, 3, 5, 3);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(121, 21);
            chkActivo.TabIndex = 4;
            chkActivo.Text = "Visible/Ocultar";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(136, 140);
            txtNombre.Margin = new Padding(5, 3, 5, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(163, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(136, 183);
            txtPrecio.Margin = new Padding(5, 3, 5, 3);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(163, 23);
            txtPrecio.TabIndex = 6;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(136, 226);
            txtStock.Margin = new Padding(5, 3, 5, 3);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(163, 23);
            txtStock.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(43, 326);
            btnGuardar.Margin = new Padding(5, 3, 5, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(101, 31);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(198, 326);
            btnLimpiar.Margin = new Padding(5, 3, 5, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(101, 31);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(158, 93);
            lblId.Margin = new Padding(5, 0, 5, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(15, 17);
            lblId.TabIndex = 10;
            lblId.Text = "0";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(127, 374);
            btnEliminar.Margin = new Padding(5, 3, 5, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(101, 31);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(txtCodBarras);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtStock);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(chkActivo);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(txtPrecio);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(363, 644);
            panel1.TabIndex = 12;
            // 
            // txtCodBarras
            // 
            txtCodBarras.Location = new Point(128, 463);
            txtCodBarras.Name = "txtCodBarras";
            txtCodBarras.Size = new Size(100, 23);
            txtCodBarras.TabIndex = 13;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(65, 35);
            label4.Name = "label4";
            label4.Size = new Size(241, 36);
            label4.TabIndex = 12;
            label4.Text = "Editar Productos";
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 644);
            Controls.Add(dgvProductos);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 3, 5, 3);
            Name = "FormInventario";
            Text = "Form1";
            Load += FormInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblId;
        private Button btnEliminar;
        private Panel panel1;
        private Label label4;
        private TextBox txtCodBarras;
    }
}

