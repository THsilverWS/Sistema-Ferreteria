using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaFerreteria.Model
{
    public class InventarioDAO
    {
        private readonly Conexion conexionBase = new Conexion(); // Ajusta al nombre de tu clase de conexión

        // 1. Obtener inventario paginado uniendo los nombres legibles de productos y almacenes
        public DataTable ObtenerInventarioPorPagina(int numeroPagina, int tamañoPagina, string buscar = "")
        {
            DataTable tabla = new DataTable();
            int registrosSaltados = (numeroPagina - 1) * tamañoPagina;

            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        i.id_producto AS [ID Producto],
                        p.nom_producto AS [Producto],
                        i.id_almacen AS [ID Almacen],
                        a.nom_almacen AS [Almacén], -- Ajusta si el campo en la tabla Almacen se llama diferente
                        i.stock_actual AS [Stock Actual],
                        i.stock_minimo AS [Stock Mínimo],
                        i.fec_actualizacion AS [Última Actualización]
                    FROM Inventario i
                    INNER JOIN Productos p ON i.id_producto = p.id_producto
                    INNER JOIN Almacen a ON i.id_almacen = a.id_almacen
                    WHERE p.nom_producto LIKE @Buscar
                    ORDER BY i.id_producto, i.id_almacen
                    OFFSET @Saltar ROWS
                    FETCH NEXT @Traer ROWS ONLY;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Buscar", "%" + buscar + "%");
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
                        throw new Exception("Error al cargar inventario: " + ex.Message);
                    }
                }
            }
            return tabla;
        }

        // 2. Contar el total de registros para la paginación
        public int ObtenerTotalInventario(string buscar = "")
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) FROM Inventario i 
                                INNER JOIN Productos p ON i.id_producto = p.id_producto
                                WHERE p.nom_producto LIKE @Buscar;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Buscar", "%" + buscar + "%");
                    try
                    {
                        con.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch { return 0; }
                }
            }
        }

        // 3. Actualizar los niveles de stock (Fijando la PK compuesta)
        public bool UpdateStock(int idProducto, int idAlmacen, int stockActual, int stockMinimo)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"UPDATE Inventario 
                                 SET stock_actual = @StockActual, 
                                     stock_minimo = @StockMinimo, 
                                     fec_actualizacion = GETDATE()
                                 WHERE id_producto = @IdProducto AND id_almacen = @IdAlmacen;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StockActual", stockActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al actualizar inventario: " + ex.Message);
                    }
                }
            }
        }
    }
}
