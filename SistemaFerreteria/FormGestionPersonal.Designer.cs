namespace SistemaFerreteria
{
    partial class FormGestionPersonal
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
            txtBuscar = new TextBox();
            label1 = new Label();
            dgvPersonal = new DataGridView();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonal).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1055, 107);
            panel1.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(78, 43);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(114, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 19);
            label1.Name = "label1";
            label1.Size = new Size(156, 21);
            label1.TabIndex = 0;
            label1.Text = "Buscar por nombre";
            // 
            // dgvPersonal
            // 
            dgvPersonal.AllowUserToDeleteRows = false;
            dgvPersonal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonal.Dock = DockStyle.Fill;
            dgvPersonal.Location = new Point(55, 107);
            dgvPersonal.Name = "dgvPersonal";
            dgvPersonal.ReadOnly = true;
            dgvPersonal.RowHeadersVisible = false;
            dgvPersonal.Size = new Size(945, 528);
            dgvPersonal.TabIndex = 1;
            dgvPersonal.CellContentClick += dgvPersonal_CellContentClick;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 635);
            panel2.Name = "panel2";
            panel2.Size = new Size(1055, 95);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(55, 528);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1000, 107);
            panel4.Name = "panel4";
            panel4.Size = new Size(55, 528);
            panel4.TabIndex = 4;
            // 
            // FormGestionPersonal
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 730);
            Controls.Add(dgvPersonal);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGestionPersonal";
            Text = "FormGestionPersonal";
            Load += FormGestionPersonal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvPersonal;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TextBox txtBuscar;
        private Label label1;
    }
}