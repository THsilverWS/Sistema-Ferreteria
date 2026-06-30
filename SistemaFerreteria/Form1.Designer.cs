namespace SistemaFerreteria
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            btnCargar = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 100);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.Size = new Size(800, 350);
            dgvProductos.TabIndex = 0;
            // 
            // btnCargar
            // 
            btnCargar.Anchor = AnchorStyles.Top;
            btnCargar.Location = new Point(331, 38);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(136, 23);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "Cargar Inventario";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCargar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProductos);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnCargar;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Panel panel1;
    }
}
