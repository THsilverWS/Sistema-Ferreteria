namespace SistemaFerreteria
{
    partial class FormAlmacenes
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
            btnFiltrar = new Button();
            btnImportar = new Button();
            btnExportar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            txtNombre = new TextBox();
            dgvAlmacenes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAlmacenes).BeginInit();
            SuspendLayout();
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(148, 348);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 25;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(13, 198);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(75, 23);
            btnImportar.TabIndex = 24;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(277, 198);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 23;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(257, 319);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 22;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(214, 393);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(148, 319);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(50, 319);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 19;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(92, 393);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 239);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 17;
            label2.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(108, 236);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(75, 23);
            txtId.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 268);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 15;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(108, 265);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(234, 23);
            txtNombre.TabIndex = 14;
            // 
            // dgvAlmacenes
            // 
            dgvAlmacenes.AllowUserToAddRows = false;
            dgvAlmacenes.AllowUserToResizeColumns = false;
            dgvAlmacenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlmacenes.BackgroundColor = SystemColors.Control;
            dgvAlmacenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlmacenes.Location = new Point(22, 12);
            dgvAlmacenes.Name = "dgvAlmacenes";
            dgvAlmacenes.ReadOnly = true;
            dgvAlmacenes.RowHeadersVisible = false;
            dgvAlmacenes.Size = new Size(320, 171);
            dgvAlmacenes.TabIndex = 13;
            dgvAlmacenes.CellClick += dgvAlmacenes_CellClick_1;
            // 
            // FormAlmacenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 444);
            Controls.Add(btnFiltrar);
            Controls.Add(btnImportar);
            Controls.Add(btnExportar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(dgvAlmacenes);
            Name = "FormAlmacenes";
            Text = "FormAlmacenes";
            Load += FormAlmacenes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlmacenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFiltrar;
        private Button btnImportar;
        private Button btnExportar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnEditar;
        private Button btnGuardar;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private TextBox txtNombre;
        private DataGridView dgvAlmacenes;
    }
}