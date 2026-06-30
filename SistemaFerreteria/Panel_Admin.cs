using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
namespace SistemaFerreteria
{
    public partial class Panel_Admin : Form
    {
        public Panel_Admin()
        {
            InitializeComponent();
        }
        private void AbrirFormEnPanel(object FormHijo)
        {
            panelContenedor.Controls.Clear();

            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(fh);
            panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormListaVentas());
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormGestionPersonal());
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormInventario());
            //AbrirFormEnPanel(new FormProductosAv());
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAvanzado formularioMenu = new FormAvanzado();

            // 2. Lo mostramos en pantalla completa
            formularioMenu.Show();
        }
    }
}