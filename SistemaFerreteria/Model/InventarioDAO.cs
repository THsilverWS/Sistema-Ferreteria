using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaFerreteria.Model
{
    public class InventarioDAO
    {
        private readonly Conexion conexionBase = new Conexion();

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

        public bool UpdateStock(int idProducto, int stockActual, int stockMinimo)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
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
        public DataTable ObtenerTodoElInventario()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
            SELECT 
                P.id_producto AS [ID Producto],
                P.nom_producto AS [Producto],
                ISNULL(I.stock_actual, 0) AS [Stock Actual],
                ISNULL(I.stock_minimo, 5) AS [Stock Mínimo]
            FROM Productos P
            LEFT JOIN Inventario I ON P.id_producto = I.id_producto
            ORDER BY P.nom_producto ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener inventario completo: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}
