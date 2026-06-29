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
                // 🌟 CORREGIDO: Eliminamos el INNER JOIN con Almacen y sus columnas de la consulta
                string query = @"
                    SELECT 
                        i.id_producto AS [ID Producto],
                        p.nom_producto AS [Producto],
                        i.stock_actual AS [Stock Actual],
                        i.stock_minimo AS [Stock Mínimo],
                        i.fec_actualizacion AS [Última Actualización]
                    FROM Inventario i
                    INNER JOIN Productos p ON i.id_producto = p.id_producto
                    WHERE p.nom_producto LIKE @Buscar
                    ORDER BY i.id_producto
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
        public bool UpdateStock(int idProducto, int stockActual, int stockMinimo)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                // Quitamos id_almacen del WHERE ya que el stock ahora es global por producto
                string query = @"UPDATE Inventario 
                         SET stock_actual = @StockActual, 
                             stock_minimo = @StockMinimo, 
                             fec_actualizacion = GETDATE()
                         WHERE id_producto = @IdProducto;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StockActual", stockActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    try
                    {
                        con.Open();
                        // Inyectamos el contexto para la auditoría que acabamos de armar
                        conexionBase.AsignarContextoSeguridad(con);
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
