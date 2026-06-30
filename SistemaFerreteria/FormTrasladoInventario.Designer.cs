namespace SistemaFerreteria
{
    partial class FormTrasladoInventario
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
            cboProducto = new ComboBox();
            cboAlmacenDestino = new ComboBox();
            cboAlmacenOrigen = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            numCantidad = new NumericUpDown();
            label4 = new Label();
            txtDescripcion = new TextBox();
            label5 = new Label();
            btnProcesar = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // cboProducto
            // 
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(87, 90);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(121, 23);
            cboProducto.TabIndex = 0;
            // 
            // cboAlmacenDestino
            // 
            cboAlmacenDestino.FormattingEnabled = true;
            cboAlmacenDestino.Location = new Point(87, 182);
            cboAlmacenDestino.Name = "cboAlmacenDestino";
            cboAlmacenDestino.Size = new Size(121, 23);
            cboAlmacenDestino.TabIndex = 1;
            // 
            // cboAlmacenOrigen
            // 
            cboAlmacenOrigen.FormattingEnabled = true;
            cboAlmacenOrigen.Location = new Point(87, 132);
            cboAlmacenOrigen.Name = "cboAlmacenOrigen";
            cboAlmacenOrigen.Size = new Size(121, 23);
            cboAlmacenOrigen.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 93);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "Producto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 135);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 4;
            label2.Text = "Origen:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 190);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 5;
            label3.Text = "Destino:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(88, 247);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(120, 23);
            numCantidad.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 249);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 7;
            label4.Text = "Cantidad:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(272, 116);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(205, 164);
            txtDescripcion.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(272, 98);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 9;
            label5.Text = "Descripcion o nota:";
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(189, 308);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(90, 23);
            btnProcesar.TabIndex = 10;
            btnProcesar.Text = "Aceptar";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(149, 34);
            label6.Name = "label6";
            label6.Size = new Size(191, 30);
            label6.TabIndex = 11;
            label6.Text = "Rellenar Inventario";
            // 
            // FormTrasladoInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 366);
            Controls.Add(label6);
            Controls.Add(btnProcesar);
            Controls.Add(label5);
            Controls.Add(txtDescripcion);
            Controls.Add(label4);
            Controls.Add(numCantidad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboAlmacenOrigen);
            Controls.Add(cboAlmacenDestino);
            Controls.Add(cboProducto);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormTrasladoInventario";
            Text = "Inventario";
            Load += FormTrasladoInventario_Load;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboProducto;
        private ComboBox cboAlmacenDestino;
        private ComboBox cboAlmacenOrigen;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numCantidad;
        private Label label4;
        private TextBox txtDescripcion;
        private Label label5;
        private Button btnProcesar;
        private Label label6;
    }
}