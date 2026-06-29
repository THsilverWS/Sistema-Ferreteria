using SistemaFerreteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormInventarioAv : Form
    {
        private readonly InventarioDAO _inventarioDao = new InventarioDAO();
        private int paginaActual = 1;
        private int tamañoPagina = 10;

        private int idProductoSeleccionado = -1;
        private int idAlmacenSeleccionado = -1;

        public FormInventarioAv()
        {
            InitializeComponent();
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.BackgroundColor = Color.White;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == -1 || idAlmacenSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione una fila del inventario para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int nuevoStock = Convert.ToInt32(numStockActual.Value);
                int nuevoMinimo = Convert.ToInt32(numStockMinimo.Value);

                // Modifica el stock de esa combinación exacta
                bool exito = _inventarioDao.UpdateStock(idProductoSeleccionado, idAlmacenSeleccionado, nuevoStock, nuevoMinimo);

                if (exito)
                {
                    MessageBox.Show("¡Inventario actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarTabla();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefrescarTabla()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();
                dgvInventario.DataSource = _inventarioDao.ObtenerInventarioPorPagina(paginaActual, tamañoPagina, filtro);
                lblPagina.Text = $"Página: {paginaActual}";

                // Ocultamos los IDs internos para que el usuario no se confunda
                //if (dgvInventario.Columns.Contains("ID Producto")) dgvInventario.Columns["ID Producto"].Visible = false;
                if (dgvInventario.Columns.Contains("ID Almacen")) dgvInventario.Columns["ID Almacen"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                RefrescarTabla();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalRegistros = _inventarioDao.ObtenerTotalInventario(txtBuscar.Text.Trim());

            if ((paginaActual * tamañoPagina) < totalRegistros)
            {
                paginaActual++;
                RefrescarTabla();
            }
            else
            {
                MessageBox.Show("Ya estás en la última página.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInventario.Rows[e.RowIndex];

                // Guardamos los IDs reales en memoria de forma segura[cite: 3]
                idProductoSeleccionado = Convert.ToInt32(fila.Cells["ID Producto"].Value);
                idAlmacenSeleccionado = Convert.ToInt32(fila.Cells["ID Almacen"].Value);

                // Rellenamos las cajas de texto (txtProducto y txtAlmacen deben estar bloqueados/ReadOnly)[cite: 3]
                txtProducto.Text = fila.Cells["Producto"].Value.ToString();
                txtAlmacen.Text = fila.Cells["Almacén"].Value.ToString();
                numStockActual.Value = Convert.ToInt32(fila.Cells["Stock Actual"].Value);
                numStockMinimo.Value = Convert.ToInt32(fila.Cells["Stock Mínimo"].Value);
                txtIdProducto.Text = fila.Cells["ID Producto"].Value.ToString();
            }
        }

        private void FormInventarioAv_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void LimpiarCampos()
        {
            idProductoSeleccionado = -1;
            idAlmacenSeleccionado = -1;
            txtProducto.Clear();
            txtAlmacen.Clear();
            numStockActual.Value = 0;
            numStockMinimo.Value = 5;
            txtIdProducto.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            paginaActual = 1;
            RefrescarTabla();
        }
    }
}
