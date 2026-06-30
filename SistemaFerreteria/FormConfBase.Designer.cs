namespace SistemaFerreteria
{
    partial class FormConfBase
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
            txtServidor = new TextBox();
            txtBaseDatos = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(48, 46);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(112, 23);
            txtServidor.TabIndex = 0;
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.Location = new Point(241, 46);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(100, 23);
            txtBaseDatos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 28);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre de la Base de datos:";
            // 
            // button1
            // 
            button1.Location = new Point(122, 86);
            button1.Name = "button1";
            button1.Size = new Size(119, 23);
            button1.TabIndex = 3;
            button1.Text = "Aceptar Cambios";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, 28);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre del Servidor:";
            // 
            // FormConfBase
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 119);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txtBaseDatos);
            Controls.Add(txtServidor);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormConfBase";
            Text = "Configuracion";
            Load += FormConfBase_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServidor;
        private TextBox txtBaseDatos;
        private Label label1;
        private Button button1;
        private Label label2;
    }
}