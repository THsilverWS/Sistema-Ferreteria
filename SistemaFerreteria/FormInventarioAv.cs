using SistemaFerreteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public FormInventarioAv()
        {
            InitializeComponent();
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.BackgroundColor = Color.White;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione una fila del inventario para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int nuevoStock = Convert.ToInt32(numStockActual.Value);
                int nuevoMinimo = Convert.ToInt32(numStockMinimo.Value);

                bool exito = _inventarioDao.UpdateStock(idProductoSeleccionado, nuevoStock, nuevoMinimo);

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

                if (dgvInventario.Columns.Contains("ID Producto"))
                    dgvInventario.Columns["ID Producto"].Visible = false;
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

                idProductoSeleccionado = Convert.ToInt32(fila.Cells["ID Producto"].Value);

                txtProducto.Text = fila.Cells["Producto"].Value.ToString();
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
            txtProducto.Clear();

            numStockActual.Value = 0;
            numStockMinimo.Value = 5;
            txtIdProducto.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            paginaActual = 1;
            RefrescarTabla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = "Reporte_Inventario_Completo_Ferreteria.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dtCompleto = _inventarioDao.ObtenerTodoElInventario();

                    if (dtCompleto.Rows.Count == 0)
                    {
                        MessageBox.Show("No existen registros en la base de datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < dtCompleto.Columns.Count; i++)
                    {
                        sb.Append(dtCompleto.Columns[i].ColumnName + (i == dtCompleto.Columns.Count - 1 ? "" : ","));
                    }
                    sb.AppendLine();

                    foreach (DataRow fila in dtCompleto.Rows)
                    {
                        for (int j = 0; j < dtCompleto.Columns.Count; j++)
                        {
                            string valor = fila[j]?.ToString() ?? "";
                            valor = valor.Replace("\r\n", " ").Replace("\n", " ").Replace(",", ";");
                            sb.Append(valor + (j == dtCompleto.Columns.Count - 1 ? "" : ","));
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show($"¡Éxito! Se han exportado los {dtCompleto.Rows.Count} productos del inventario correctamente.",
                                    "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el inventario completo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos CSV (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lineas = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                    if (lineas.Length <= 1)
                    {
                        MessageBox.Show("El archivo seleccionado está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int procesados = 0;
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        string[] datos = lineas[i].Split(',');
                        if (datos.Length >= 4)
                        {
                            if (int.TryParse(datos[0], out int idProd) &&
                                int.TryParse(datos[2], out int stock) &&
                                int.TryParse(datos[3], out int minimo))
                            {
                                _inventarioDao.UpdateStock(idProd, stock, minimo);
                                procesados++;
                            }
                        }
                    }

                    MessageBox.Show($"¡Importación finalizada! Se actualizaron {procesados} registros.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar el archivo CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un registro de la tabla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGuardar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un registro para eliminar/reiniciar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = $"¿Está seguro de que desea reiniciar a cero las existencias de '{txtProducto.Text}'?";
            DialogResult dr = MessageBox.Show(mensaje, "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    bool exito = _inventarioDao.UpdateStock(idProductoSeleccionado, 0, 5);
                    if (exito)
                    {
                        MessageBox.Show("Las existencias del producto seleccionado han sido reiniciadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarTabla();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la operación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}