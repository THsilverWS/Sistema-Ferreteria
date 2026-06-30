using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaFerreteria.Model
{
    public class HistorialInventarioDAO
    {
        private readonly Conexion conexionBase = new Conexion();

        public DataTable ObtenerKardexCompleto()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        H.id_historial_inv AS [ID],
                        P.nom_producto AS [Producto],
                        H.tipo_movimiento AS [Movimiento],
                        H.cantidad AS [Cantidad],
                        H.stock_anterior AS [Stock Ant.],
                        H.stock_posterior AS [Stock Post.],
                        ISNULL(AO.nom_almacen, '---') AS [Origen],
                        ISNULL(AD.nom_almacen, '---') AS [Destino],
                        CONVERT(VARCHAR(19), H.fec_movimiento, 120) AS [Fecha y Hora],
                        H.descripcion AS [Descripción]
                    FROM HistorialInventario H
                    INNER JOIN Productos P ON H.id_producto = P.id_producto
                    LEFT JOIN Almacen AO ON H.id_almacen_origen = AO.id_almacen
                    LEFT JOIN Almacen AD ON H.id_almacen_destino = AD.id_almacen
                    ORDER BY H.fec_movimiento DESC;";

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
                        throw new Exception("Error al cargar el kárdex de inventario: " + ex.Message);
                    }
                }
            }
            return dt;
        }
        public bool RegistrarTraslado(int idProducto, int idOrigen, int idDestino, int cantidad, string descripcion)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                con.Open();
                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        int stockAnterior = 0;
                        string queryStock = "SELECT ISNULL(stock_actual, 0) FROM Inventario WHERE id_producto = @idProducto;";
                        using (SqlCommand cmdStock = new SqlCommand(queryStock, con, transaccion))
                        {
                            cmdStock.Parameters.AddWithValue("@idProducto", idProducto);
                            object res = cmdStock.ExecuteScalar();
                            if (res != null) stockAnterior = Convert.ToInt32(res);
                        }

                        // Como es un traslado interno, el stock global neto sigue siendo el mismo, 
                        // pero dejamos constancia del movimiento en las variables del Kárdex.
                        int stockPosterior = stockAnterior;

                        // 2. Insertar el registro definitivo en el Historial de Inventario
                        string queryHistorial = @"
                    INSERT INTO HistorialInventario 
                        (id_producto, id_almacen_origen, id_almacen_destino, tipo_movimiento, cantidad, stock_anterior, stock_posterior, fec_movimiento, descripcion)
                    VALUES 
                        (@idProducto, @idOrigen, @idDestino, 'TRASLADO', @cantidad, @stockAnterior, @stockPosterior, GETDATE(), @descripcion);";

                        using (SqlCommand cmdHistorial = new SqlCommand(queryHistorial, con, transaccion))
                        {
                            cmdHistorial.Parameters.AddWithValue("@idProducto", idProducto);
                            cmdHistorial.Parameters.AddWithValue("@idOrigen", idOrigen);
                            cmdHistorial.Parameters.AddWithValue("@idDestino", idDestino);
                            cmdHistorial.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdHistorial.Parameters.AddWithValue("@stockAnterior", stockAnterior);
                            cmdHistorial.Parameters.AddWithValue("@stockPosterior", stockPosterior);
                            cmdHistorial.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion);

                            cmdHistorial.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error interno al procesar el traslado: " + ex.Message);
                    }
                }
            }
        }
    }
}