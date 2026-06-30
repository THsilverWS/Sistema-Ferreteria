using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaFerreteria.Model
{
    public class AlmacenDAO
    {
        private readonly Conexion conexionBase = new Conexion();

        // OBTENER ALMACENES 
        public DataTable ObtenerAlmacenes(string filtro = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        id_almacen AS [ID], 
                        nom_almacen AS [Nombre] 
                    FROM Almacen 
                    WHERE nom_almacen LIKE @filtro 
                    ORDER BY nom_almacen ASC;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
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
                        throw new Exception("Error al cargar los almacenes: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        // INSERTAR NUEVO ALMACÉN
        public bool InsertarAlmacen(string nombre)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "INSERT INTO Almacen (nom_almacen, dir_almacen, des_almacen) VALUES (@nombre, '', '');";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al guardar el almacén: " + ex.Message);
                    }
                }
            }
        }

        // MODIFICAR ALMACÉN
        public bool ModificarAlmacen(int id, string nombre)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "UPDATE Almacen SET nom_almacen = @nombre WHERE id_almacen = @id;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al actualizar el almacén: " + ex.Message);
                    }
                }
            }
        }

        // ELIMINAR ALMACÉN
        public bool EliminarAlmacen(int id)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "DELETE FROM Almacen WHERE id_almacen = @id;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se puede eliminar el almacén porque contiene historial logístico registrado.");
                    }
                }
            }
        }
    }
}