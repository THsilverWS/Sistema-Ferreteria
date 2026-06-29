using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormAvanzado : Form
    {
        public FormAvanzado()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductosAv frmProductos = new FormProductosAv();
            frmProductos.MdiParent = this;
            frmProductos.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbierto = Application.OpenForms["FormInventarioAv"];

            if (frmAbierto != null)
            {
                frmAbierto.Activate(); // Si ya está abierto, lo trae al frente
            }
            else
            {
                FormInventarioAv frmInv = new FormInventarioAv();
                frmInv.MdiParent = this; // Se incrusta en el menú principal
                frmInv.Show();
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMantenedorComun frm = new FormMantenedorComun("CATEGORIA");
            frm.MdiParent = this;
            frm.Show();
        }

        private void metodosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMantenedorComun frm = new FormMantenedorComun("METODO_PAGO");
            frm.MdiParent = this;
            frm.Show();
        }

        private void estantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMantenedorComun frm = new FormMantenedorComun("ESTANTE");
            frm.MdiParent = this;
            frm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmpleadosAv frm = new FormEmpleadosAv();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
