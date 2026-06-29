namespace SistemaFerreteria
{
    partial class FormExportarImportar
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
            rbExcel = new RadioButton();
            rbNativo = new RadioButton();
            txtRuta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnBuscar = new Button();
            btnAccion = new Button();
            SuspendLayout();
            // 
            // rbExcel
            // 
            rbExcel.AutoSize = true;
            rbExcel.Location = new Point(54, 93);
            rbExcel.Name = "rbExcel";
            rbExcel.Size = new Size(82, 19);
            rbExcel.TabIndex = 0;
            rbExcel.TabStop = true;
            rbExcel.Text = "Excel (.csv)";
            rbExcel.UseVisualStyleBackColor = true;
            // 
            // rbNativo
            // 
            rbNativo.AutoSize = true;
            rbNativo.Location = new Point(161, 93);
            rbNativo.Name = "rbNativo";
            rbNativo.Size = new Size(172, 19);
            rbNativo.TabIndex = 1;
            rbNativo.TabStop = true;
            rbNativo.Text = "Nativo de datos (.dat o .bin)";
            rbNativo.UseVisualStyleBackColor = true;
            // 
            // txtRuta
            // 
            txtRuta.Location = new Point(65, 130);
            txtRuta.Name = "txtRuta";
            txtRuta.ReadOnly = true;
            txtRuta.Size = new Size(268, 23);
            txtRuta.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 133);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "Ruta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 45);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 4;
            label2.Text = "Tipo de Archivo";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(339, 133);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnAccion
            // 
            btnAccion.Location = new Point(161, 190);
            btnAccion.Name = "btnAccion";
            btnAccion.Size = new Size(75, 23);
            btnAccion.TabIndex = 6;
            btnAccion.Text = "...";
            btnAccion.UseVisualStyleBackColor = true;
            btnAccion.Click += btnAccion_Click;
            // 
            // FormExportarImportar
            // 
            AcceptButton = btnAccion;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 243);
            Controls.Add(btnAccion);
            Controls.Add(btnBuscar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRuta);
            Controls.Add(rbNativo);
            Controls.Add(rbExcel);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormExportarImportar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormExportarImportar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbExcel;
        private RadioButton rbNativo;
        private TextBox txtRuta;
        private Label label1;
        private Label label2;
        private Button btnBuscar;
        private Button btnAccion;
    }
}