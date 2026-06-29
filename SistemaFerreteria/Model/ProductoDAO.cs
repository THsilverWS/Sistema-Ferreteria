using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaFerreteria.Model
{
    public class ProductoDAO
    {
        private readonly Conexion conexionBase = new Conexion();

        /// <summary>
        /// Lista todos los productos mapeando las llaves foráneas y trayendo el stock desde Inventario.
        /// </summary>
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            // Corregido: Prov.raz_proveedor y Est.ubi_estante según tus scripts reales
            string query = @"SELECT P.id_producto AS [ID], 
                            P.cod_barras AS [Código de Barras], 
                            P.nom_producto AS [Producto], 
                            P.des_producto AS [Descripción], 
                            C.nom_categoria AS [Categoría], 
                            Prov.raz_proveedor AS [Proveedor],
                            Est.ubi_estante AS [Estante],
                            P.pre_compra AS [P. Compra], 
                            P.pre_venta AS [P. Venta],
                            ISNULL(I.stock_actual, 0) AS [Stock Actual]
                     FROM Productos P
                     INNER JOIN Categorias C ON P.id_categoria = C.id_categoria
                     INNER JOIN Proveedores Prov ON P.ruc_proveedor = Prov.ruc_proveedor
                     INNER JOIN Estantes Est ON P.id_estante = Est.id_estante
                     LEFT JOIN Inventario I ON P.id_producto = I.id_producto";

            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabla);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al listar los productos: " + ex.Message);
                    }
                }
            }
            return tabla;
        }

        /// <summary>
        /// Inserta un producto basándose estrictamente en las columnas de tu tabla real (Cumple RF04).
        /// </summary>
        public bool InsertarProducto(string codigoBarras, string nombre, string descripcion, int idCategoria,
                                      string rucProveedor, int idEstante, decimal precioCompra, decimal precioVenta)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string queryProducto = @"INSERT INTO Productos (cod_barras, nom_producto, des_producto, id_categoria, ruc_proveedor, id_estante, pre_compra, pre_venta) 
                                         VALUES (@codigo, @nombre, @descripcion, @idCat, @rucProv, @idEst, @pCompra, @pVenta);";

                using (SqlCommand cmdProd = new SqlCommand(queryProducto, con))
                {
                    cmdProd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = codigoBarras;
                    cmdProd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmdProd.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = descripcion;
                    cmdProd.Parameters.Add("@idCat", SqlDbType.Int).Value = idCategoria;
                    cmdProd.Parameters.Add("@rucProv", SqlDbType.VarChar, 11).Value = string.IsNullOrEmpty(rucProveedor) ? (object)DBNull.Value : rucProveedor;
                    cmdProd.Parameters.Add("@idEst", SqlDbType.Int).Value = idEstante;
                    cmdProd.Parameters.Add("@pCompra", SqlDbType.Decimal).Value = precioCompra;
                    cmdProd.Parameters.Add("@pVenta", SqlDbType.Decimal).Value = precioVenta;

                    try
                    {
                        con.Open();
                        cmdProd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al registrar el producto en SQL Server: " + ex.Message);
                    }
                }
            }
        }
        public DataTable ObtenerProductosPorPagina(int numeroPagina, int tamañoPagina)
        {
            DataTable tabla = new DataTable();
            // Fórmula: si estás en la página 1, se salta (1-1)*10 = 0 registros.
            // Si estás en la página 2, se salta (2-1)*10 = 10 registros.
            int registrosSaltados = (numeroPagina - 1) * tamañoPagina;

            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                // IMPORTANTE: OFFSET requiere obligatoriamente un ORDER BY
                string query = @"SELECT id_producto AS [ID], 
                        cod_barras AS [Código de Barras], 
                        nom_producto AS [Producto], 
                        des_producto AS [Descripción],
                        pre_compra AS [P. Compra], 
                        pre_venta AS [P. Venta],
                        id_categoria,   
                        ruc_proveedor,  
                        id_estante      
                 FROM Productos
                 ORDER BY id_producto
                 OFFSET @Saltar ROWS
                 FETCH NEXT @Traer ROWS ONLY;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Saltar", registrosSaltados);
                    cmd.Parameters.AddWithValue("@Traer", tamañoPagina);

                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al paginar: " + ex.Message);
                    }
                }
            }
            return tabla;
        }
        public DataTable ObtenerCategorias()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT id_categoria, nom_categoria FROM Categorias";
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try { con.Open(); using (SqlDataAdapter ad = new SqlDataAdapter(cmd)) ad.Fill(tabla); }
                    catch (SqlException ex) { throw new Exception("Error al cargar categorías: " + ex.Message); }
                }
            }
            return tabla;
        }
        public int ObtenerTotalProductos()
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Productos;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
        }

        public DataTable ObtenerProveedores()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT ruc_proveedor, raz_proveedor FROM Proveedores"; // 'raz_proveedor'
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try { con.Open(); using (SqlDataAdapter ad = new SqlDataAdapter(cmd)) ad.Fill(tabla); }
                    catch (SqlException ex) { throw new Exception("Error al cargar proveedores: " + ex.Message); }
                }
            }
            return tabla;
        }

        public DataTable ObtenerEstantes()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT id_estante, ubi_estante FROM Estantes"; // 'ubi_estante' 
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try { con.Open(); using (SqlDataAdapter ad = new SqlDataAdapter(cmd)) ad.Fill(tabla); }
                    catch (SqlException ex) { throw new Exception("Error al cargar estantes: " + ex.Message); }
                }
            }
            return tabla;
        }
        /// <summary>
        /// Modifica los datos de un producto existente basándose en su ID (UPDATE).
        /// </summary>
        public bool EditarProducto(int idProducto, string codigoBarras, string nombre, string descripcion,
                                    int idCategoria, string rucProveedor, int idEstante, decimal precioCompra, decimal precioVenta)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"UPDATE Productos 
                         SET cod_barras = @codigo, 
                             nom_producto = @nombre, 
                             des_producto = @descripcion, 
                             id_categoria = @idCat, 
                             ruc_proveedor = @rucProv, 
                             id_estante = @idEst, 
                             pre_compra = @pCompra, 
                             pre_venta = @pVenta
                         WHERE id_producto = @idProd;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idProd", SqlDbType.Int).Value = idProducto;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = codigoBarras;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = descripcion;
                    cmd.Parameters.Add("@idCat", SqlDbType.Int).Value = idCategoria;
                    cmd.Parameters.Add("@rucProv", SqlDbType.VarChar, 11).Value = string.IsNullOrEmpty(rucProveedor) ? (object)DBNull.Value : rucProveedor;
                    cmd.Parameters.Add("@idEst", SqlDbType.Int).Value = idEstante;
                    cmd.Parameters.Add("@pCompra", SqlDbType.Decimal).Value = precioCompra;
                    cmd.Parameters.Add("@pVenta", SqlDbType.Decimal).Value = precioVenta;

                    try
                    {
                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al actualizar el producto en SQL Server: " + ex.Message);
                    }
                }
            }


        }
        /// <summary>
        /// Elimina físicamente un producto de la base de datos utilizando su ID.
        /// </summary>
        public bool EliminarProducto(int idProducto)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "DELETE FROM Productos WHERE id_producto = @idProd";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@idProd", SqlDbType.Int).Value = idProducto;

                    try
                    {
                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                    catch (SqlException ex)
                    {
                        // Si el producto está en otra tabla (llave foránea), saltará aquí
                        if (ex.Number == 547) // Código de error de restricción FK en SQL Server
                        {
                            throw new Exception("No se puede eliminar este producto porque tiene movimientos de inventario o ventas asociadas.");
                        }
                        throw new Exception("Error al eliminar el producto: " + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Vacía por completo la tabla de productos y reinicia el contador de IDs.
        /// </summary>
        public bool VaciarTablaProductos()
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                // Limpiamos absolutamente todo el historial de pruebas en el orden correcto
                string query = @"DELETE FROM HistorialInventario;
                         DELETE FROM Inventario;
                         DELETE FROM DetalleVentas;
                         DELETE FROM Productos;
                         DBCC CHECKIDENT ('Productos', RESEED, 0);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error en la limpieza profunda: " + ex.Message);
                    }
                }
            }
        }
    }
}
