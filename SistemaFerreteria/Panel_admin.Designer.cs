namespace SistemaFerreteria
{
    partial class Panel_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_Admin));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            button1 = new Button();
            button7 = new Button();
            button6 = new Button();
            btnProductos = new Button();
            btnPersonal = new Button();
            btnVentas = new Button();
            btnDashboard = new Button();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            panelContenedor = new Panel();
            dgvPedidos = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Moccasin;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(btnProductos);
            panel1.Controls.Add(btnPersonal);
            panel1.Controls.Add(btnVentas);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 700);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(15, 280);
            button1.Name = "button1";
            button1.Size = new Size(262, 45);
            button1.TabIndex = 10;
            button1.Text = "  Avanzado";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Bottom;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.Black;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(15, 583);
            button7.Name = "button7";
            button7.Size = new Size(262, 45);
            button7.TabIndex = 9;
            button7.Text = "  Ajustes";
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Bottom;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.Black;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(15, 628);
            button6.Name = "button6";
            button6.Size = new Size(262, 72);
            button6.TabIndex = 8;
            button6.Text = "  Salir";
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // btnProductos
            // 
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.ForeColor = Color.Black;
            btnProductos.Image = (Image)resources.GetObject("btnProductos.Image");
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(15, 235);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(262, 45);
            btnProductos.TabIndex = 7;
            btnProductos.Text = "  Productos";
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnPersonal
            // 
            btnPersonal.Cursor = Cursors.Hand;
            btnPersonal.Dock = DockStyle.Top;
            btnPersonal.FlatAppearance.BorderSize = 0;
            btnPersonal.FlatStyle = FlatStyle.Flat;
            btnPersonal.ForeColor = Color.Black;
            btnPersonal.Image = (Image)resources.GetObject("btnPersonal.Image");
            btnPersonal.ImageAlign = ContentAlignment.MiddleLeft;
            btnPersonal.Location = new Point(15, 190);
            btnPersonal.Name = "btnPersonal";
            btnPersonal.Size = new Size(262, 45);
            btnPersonal.TabIndex = 5;
            btnPersonal.Text = "  Personal";
            btnPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPersonal.UseVisualStyleBackColor = true;
            btnPersonal.Click += btnPersonal_Click;
            // 
            // btnVentas
            // 
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.ForeColor = Color.Black;
            btnVentas.Image = (Image)resources.GetObject("btnVentas.Image");
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(15, 145);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(262, 45);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "  Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.Black;
            btnDashboard.Image = (Image)resources.GetObject("btnDashboard.Image");
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(15, 100);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(262, 45);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(15, 100);
            panel4.Name = "panel4";
            panel4.Size = new Size(262, 600);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(15, 600);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Moccasin;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 100);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(64, 38);
            label1.Name = "label1";
            label1.Size = new Size(167, 21);
            label1.TabIndex = 1;
            label1.Text = "Panel Administrador";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Moccasin;
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(277, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(923, 56);
            panel5.TabIndex = 1;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(dgvPedidos);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(277, 56);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(923, 644);
            panelContenedor.TabIndex = 2;
            // 
            // dgvPedidos
            // 
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPedidos.BackgroundColor = SystemColors.Control;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPedidos.DefaultCellStyle = dataGridViewCellStyle1;
            dgvPedidos.Dock = DockStyle.Fill;
            dgvPedidos.Location = new Point(0, 0);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.Size = new Size(923, 644);
            dgvPedidos.TabIndex = 0;
            dgvPedidos.Visible = false;
            // 
            // Panel_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelContenedor);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Panel_Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel Admin";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnDashboard;
        private Panel panel4;
        private Panel panel3;
        private Button button7;
        private Button button6;
        private Button btnProductos;
        private Button btnPersonal;
        private Button btnVentas;
        private Panel panel5;
        private Panel panelContenedor;
        private DataGridView dgvPedidos;
        private Button button1;
    }
}