using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormInventario : Form
    {
        private readonly Conexion conexionBase = new Conexion();

        public FormInventario()
        {
            InitializeComponent();
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            CargarStock();
        }

        public void CargarStock()
        {
            try
            {

                using (SqlConnection conexion = conexionBase.ObtenerConexion())
                {
                    string query = @"
                        SELECT 
                            P.id_producto AS [Id],
                            P.cod_barras AS [Código Barras],
                            P.nom_producto AS [Nombre],
                            P.pre_venta AS [Precio],
                            ISNULL(I.stock_actual, 0) AS [Stock]
                        FROM Productos P
                        LEFT JOIN Inventario I ON P.id_producto = I.id_producto
                        ORDER BY P.id_producto DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvProductos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar stock desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodBarras.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos (Código, Nombre, Precio y Stock).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
            {
                MessageBox.Show("Por favor, ingresa un precio numérico válido y positivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
            {
                MessageBox.Show("Por favor, ingresa un stock numérico válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    conexionBase.AsignarContextoSeguridad(conexion);

                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(lblId.Text))
                            {
                                string queryProd = @"INSERT INTO Productos (cod_barras, nom_producto, pre_compra, pre_venta, id_categoria, id_estante) 
                                                     VALUES (@cod, @nom, @preC, @preV, 1, 1);
                                                     SELECT SCOPE_IDENTITY();";

                                int idProductoGenerado;
                                using (SqlCommand cmdProd = new SqlCommand(queryProd, conexion, transaccion))
                                {
                                    cmdProd.Parameters.AddWithValue("@cod", txtCodBarras.Text.Trim());
                                    cmdProd.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
                                    cmdProd.Parameters.AddWithValue("@preC", precio * 0.7m);
                                    cmdProd.Parameters.AddWithValue("@preV", precio);

                                    idProductoGenerado = Convert.ToInt32(cmdProd.ExecuteScalar());
                                }

                                string queryInv = @"INSERT INTO Inventario (id_producto, stock_actual, stock_minimo, fec_actualizacion) 
                                                    VALUES (@idProd, @stock, 5, GETDATE());";

                                using (SqlCommand cmdInv = new SqlCommand(queryInv, conexion, transaccion))
                                {
                                    cmdInv.Parameters.AddWithValue("@idProd", idProductoGenerado);
                                    cmdInv.Parameters.AddWithValue("@stock", stock);
                                    cmdInv.ExecuteNonQuery();
                                }

                                MessageBox.Show("¡Producto e Inventario inicializados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                int idExistente = Convert.ToInt32(lblId.Text);

                                string queryUpdProd = @"UPDATE Productos 
                                                        SET cod_barras = @cod, nom_producto = @nom, pre_venta = @preV 
                                                        WHERE id_producto = @idProd";

                                using (SqlCommand cmdUpd = new SqlCommand(queryUpdProd, conexion, transaccion))
                                {
                                    cmdUpd.Parameters.AddWithValue("@cod", txtCodBarras.Text.Trim());
                                    cmdUpd.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
                                    cmdUpd.Parameters.AddWithValue("@preV", precio);
                                    cmdUpd.Parameters.AddWithValue("@idProd", idExistente);
                                    cmdUpd.ExecuteNonQuery();
                                }

                                string queryUpdInv = @"UPDATE Inventario 
                                                       SET stock_actual = @stock, fec_actualizacion = GETDATE() 
                                                       WHERE id_producto = @idProd";

                                using (SqlCommand cmdUpdInv = new SqlCommand(queryUpdInv, conexion, transaccion))
                                {
                                    cmdUpdInv.Parameters.AddWithValue("@stock", stock);
                                    cmdUpdInv.Parameters.AddWithValue("@idProd", idExistente);
                                    cmdUpdInv.ExecuteNonQuery();
                                }

                                MessageBox.Show("¡Datos del producto actualizados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            transaccion.Commit();
                            CargarStock();
                            Limpiar();
                        }
                        catch (Exception exTrans)
                        {
                            transaccion.Rollback();
                            throw new Exception("Operación revertida debido a un conflicto de datos: " + exTrans.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en SQL Server: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                lblId.Text = fila.Cells["Id"].Value.ToString();
                txtCodBarras.Text = fila.Cells["Código Barras"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
            }
        }

        private void Limpiar()
        {
            lblId.Text = "";
            txtCodBarras.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtCodBarras.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {
                MessageBox.Show("Por favor, selecciona un producto de la tabla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreProducto = txtNombre.Text.Trim();

            if (MessageBox.Show($"¿Estás seguro de eliminar el producto '{nombreProducto}'? Esto borrará permanentemente sus existencias en inventario.",
                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idProducto = Convert.ToInt32(lblId.Text);

                using (SqlConnection conexion = conexionBase.ObtenerConexion())
                {
                    try
                    {
                        conexion.Open();

                        conexionBase.AsignarContextoSeguridad(conexion);

                        using (SqlTransaction transaccion = conexion.BeginTransaction())
                        {
                            try
                            {
                                string queryInv = "DELETE FROM Inventario WHERE id_producto = @idProd";
                                using (SqlCommand cmdInv = new SqlCommand(queryInv, conexion, transaccion))
                                {
                                    cmdInv.Parameters.AddWithValue("@idProd", idProducto);
                                    cmdInv.ExecuteNonQuery();
                                }

                                string queryProd = "DELETE FROM Productos WHERE id_producto = @idProd";
                                using (SqlCommand cmdProd = new SqlCommand(queryProd, conexion, transaccion))
                                {
                                    cmdProd.Parameters.AddWithValue("@idProd", idProducto);
                                    cmdProd.ExecuteNonQuery();
                                }

                                transaccion.Commit();
                                MessageBox.Show("Producto eliminado correctamente de la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CargarStock();
                                Limpiar();
                            }
                            catch (Exception exTrans)
                            {
                                transaccion.Rollback();
                                throw new Exception("No se puede eliminar el artículo. Posiblemente ya cuenta con registros de ventas en el historial: " + exTrans.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}