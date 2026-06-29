using SistemaFerreteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer;

namespace SistemaFerreteria
{
    public partial class FormProductosAv : Form
    {
        private readonly ProductoDAO _productoDao = new ProductoDAO();
        private int paginaActual = 1;
        private int tamañoPagina = 10;
        public FormProductosAv()
        {
            InitializeComponent();
            btnEditar.Enabled = false;
            btnEditar.BackColor = Color.LightGray;

            btnEliminar.Enabled = false;
            btnEliminar.BackColor = Color.LightGray;
        }
        private readonly ProductoDAO productoDao = new ProductoDAO();

        private void FormProductosAv_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            CargarCombos();
        }
        private void RefrescarTabla()
        {
            try
            {
                // Traemos solo los 10 de la página actual
                dgvProductos.DataSource = _productoDao.ObtenerProductosPorPagina(paginaActual, tamañoPagina);

                // Muestra en la etiqueta en qué página vas
                lblPagina.Text = $"Página: {paginaActual}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCombos()
        {
            try
            {
                // 1. Cargar Categorías
                DataTable dtCat = _productoDao.ObtenerCategorias();
                cmbCategoria.DataSource = dtCat;
                cmbCategoria.DisplayMember = "nom_categoria";
                cmbCategoria.ValueMember = "id_categoria";
                cmbCategoria.SelectedIndex = -1;

                // 2. Cargar Proveedores
                DataTable dtProv = _productoDao.ObtenerProveedores();
                cmbProveedor.DataSource = dtProv;
                cmbProveedor.DisplayMember = "raz_proveedor";
                cmbProveedor.ValueMember = "ruc_proveedor";
                cmbProveedor.SelectedIndex = -1;

                // 3. Cargar Estantes
                DataTable dtEst = _productoDao.ObtenerEstantes();
                cmbEstante.DataSource = dtEst;
                cmbEstante.DisplayMember = "ubi_estante";
                cmbEstante.ValueMember = "id_estante";
                cmbEstante.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCodigoBarras.Text) ||
                cmbCategoria.SelectedValue == null || cmbProveedor.SelectedValue == null || cmbEstante.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione los elementos de las listas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string codigo = txtCodigoBarras.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                string rucProveedor = cmbProveedor.SelectedValue.ToString();
                int idEstante = Convert.ToInt32(cmbEstante.SelectedValue);
                decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

                bool exito = _productoDao.InsertarProducto(codigo, nombre, descripcion, idCategoria, rucProveedor, idEstante, precioCompra, precioVenta);

                if (exito)
                {
                    MessageBox.Show("¡Producto registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarTabla();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtCodigoBarras.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbEstante.SelectedIndex = -1;

            btnGuardar.Enabled = true;
            btnGuardar.BackColor = Color.White;

            btnEditar.Enabled = false;
            btnEditar.BackColor = Color.LightGray;

            btnEliminar.Enabled = false;
            btnEliminar.BackColor = Color.LightGray;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                txtIdProducto.Text = fila.Cells["ID"].Value.ToString();
                txtCodigoBarras.Text = fila.Cells["Código de Barras"].Value.ToString();
                txtNombre.Text = fila.Cells["Producto"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripción"].Value.ToString();
                txtPrecioCompra.Text = fila.Cells["P. Compra"].Value.ToString();
                txtPrecioVenta.Text = fila.Cells["P. Venta"].Value.ToString();

                // CORREGIDO: En lugar de buscar por los textos descriptivos que ya no se consultan,
                // mapeamos mediante SelectedValue si tuvieras los IDs ocultos en la grilla.
                // Si la consulta del DAO de la página no incluye IDs de llaves foráneas, dejamos los combos intactos para evitar caídas.
                if (dgvProductos.Columns.Contains("id_categoria") && fila.Cells["id_categoria"].Value != null)
                {
                    cmbCategoria.SelectedValue = fila.Cells["id_categoria"].Value;
                    cmbProveedor.SelectedValue = fila.Cells["ruc_proveedor"].Value;
                    cmbEstante.SelectedValue = fila.Cells["id_estante"].Value;
                }

                btnGuardar.Enabled = false;
                btnGuardar.BackColor = Color.LightGray;

                btnEditar.Enabled = true;
                btnEditar.BackColor = Color.White;

                btnEliminar.Enabled = true;
                btnEliminar.BackColor = Color.White;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCodigoBarras.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProducto = Convert.ToInt32(txtIdProducto.Text);
                string codigo = txtCodigoBarras.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                string rucProveedor = cmbProveedor.SelectedValue.ToString();
                int idEstante = Convert.ToInt32(cmbEstante.SelectedValue);
                decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

                bool exito = _productoDao.EditarProducto(idProducto, codigo, nombre, descripcion, idCategoria, rucProveedor, idEstante, precioCompra, precioVenta);

                if (exito)
                {
                    MessageBox.Show("¡Producto actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarTabla();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarTabla();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificar que haya un producto seleccionado
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Preguntar al usuario si realmente está seguro
            DialogResult resultado = MessageBox.Show("¿Está completamente seguro de eliminar este producto? Esta acción no se puede deshacer.",
                                                     "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int idProducto = Convert.ToInt32(txtIdProducto.Text);

                    // Llamamos al DAO
                    bool exito = productoDao.EliminarProducto(idProducto);

                    if (exito)
                    {
                        MessageBox.Show("¡Producto eliminado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarTabla(); // Recarga la grilla[cite: 2]
                        LimpiarCampos();   // Restablece cajas, botones y colores[cite: 2]
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvProductos.DataSource; //[cite: 4]
            if (dt == null || dt.Rows.Count == 0) //[cite: 4]
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); //[cite: 4]
                return; //[cite: 4]
            }

            // AJUSTADO: Ahora le pasamos el tipo "PRODUCTO" como segundo parámetro
            FormExportarImportar ventanaExportar = new FormExportarImportar("EXPORTAR", "PRODUCTO", dt); //
            ventanaExportar.ShowDialog(); //[cite: 4]
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            // AJUSTADO: Ahora le pasamos el tipo "PRODUCTO" y 'null' en la tabla
            FormExportarImportar ventanaImportar = new FormExportarImportar("IMPORTAR", "PRODUCTO", null); //
            if (ventanaImportar.ShowDialog() == DialogResult.OK) //[cite: 4]
            {
                RefrescarTabla(); // Si importó con éxito, refresca la grilla principal automáticamente[cite: 4]
            }
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Quieres BORRAR TODOS los productos de la base de datos para probar la importación?",
                                             "Prueba de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Ejecutamos la limpieza a través del objeto que ya usas en todo tu formulario
                    bool exito = productoDao.VaciarTablaProductos();

                    if (exito)
                    {
                        MessageBox.Show("¡Tabla de productos vaciada con éxito! Los IDs se reiniciaron a 1.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefrescarTabla(); // Borra visualmente la grilla principal
                        LimpiarCampos();   // Restablece los bloqueos de tus botones
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Obtenemos cuántos productos existen en toda la base de datos
            int totalProductos = _productoDao.ObtenerTotalProductos();

            // Si lo que ya mostramos es menor al total, significa que hay más data adelante
            if ((paginaActual * tamañoPagina) < totalProductos)
            {
                paginaActual++; // Avanzamos con seguridad
                RefrescarTabla();
            }
            else
            {
                MessageBox.Show("Ya no hay más productos en las siguientes páginas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--; // Restamos una página
                RefrescarTabla(); // Volvemos a cargar la grilla
            }
        }
    }
}
