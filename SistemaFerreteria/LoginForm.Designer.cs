namespace SistemaFerreteria
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtUsuario = new TextBox();
            btnIngresar = new Button();
            xd3 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            panel5 = new Panel();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            txtContrasena = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Location = new Point(2, 10);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(303, 14);
            txtUsuario.TabIndex = 0;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(255, 249, 176);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.Black;
            btnIngresar.Location = new Point(54, 416);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(327, 37);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // xd3
            // 
            xd3.AutoSize = true;
            xd3.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xd3.Location = new Point(52, 251);
            xd3.Name = "xd3";
            xd3.Size = new Size(54, 17);
            xd3.TabIndex = 3;
            xd3.Text = "Usuario";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnIngresar);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(xd3);
            panel1.Location = new Point(263, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(431, 652);
            panel1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(155, 607);
            label3.Name = "label3";
            label3.Size = new Size(111, 16);
            label3.TabIndex = 9;
            label3.Text = "Trabajo en proceso";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 117);
            label2.Name = "label2";
            label2.Size = new Size(164, 16);
            label2.TabIndex = 8;
            label2.Text = "La mejor ferreteria de tu cerro";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(146, 484);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(147, 17);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Olvide mi contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(52, 323);
            label5.Name = "label5";
            label5.Size = new Size(84, 17);
            label5.TabIndex = 5;
            label5.Text = "Contraseña";
            // 
            // panel5
            // 
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(pictureBox3);
            panel5.Controls.Add(txtContrasena);
            panel5.Location = new Point(52, 344);
            panel5.Name = "panel5";
            panel5.Size = new Size(329, 36);
            panel5.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 249, 176);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(329, 1);
            panel4.TabIndex = 2;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(309, 7);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(20, 20);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.None;
            txtContrasena.Location = new Point(2, 10);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(303, 14);
            txtContrasena.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtUsuario);
            panel2.Location = new Point(52, 272);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 36);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 249, 176);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(329, 1);
            panel3.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(309, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(96, 186);
            label4.Name = "label4";
            label4.Size = new Size(229, 23);
            label4.TabIndex = 2;
            label4.Text = "¡Bienvenido de nuevo!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(169, 51);
            label1.Name = "label1";
            label1.Size = new Size(190, 66);
            label1.TabIndex = 1;
            label1.Text = "Ferreteria \r\nIntegral S.A.C";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(96, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(76, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(950, 650);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            FormClosed += LoginForm_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsuario;
        private Button btnIngresar;
        private Label xd3;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Label label5;
        private Panel panel5;
        private Panel panel4;
        private PictureBox pictureBox3;
        private TextBox txtContrasena;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label3;
    }
}