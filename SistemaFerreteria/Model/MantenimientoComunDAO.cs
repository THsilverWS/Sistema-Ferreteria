using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaFerreteria.Model
{
    public class MantenimientoComunDAO
    {
        private readonly Conexion conexionBase = new Conexion(); // Tu clase de conexión

        // Método auxiliar para obtener los nombres reales de las columnas según el tipo
        private void ObtenerConfiguracionTabla(string tipo, out string nombreTabla, out string campoId, out string campoTexto)
        {
            switch (tipo.ToUpper())
            {
                case "CATEGORIA":
                    nombreTabla = "Categorias"; campoId = "id_categoria"; campoTexto = "nom_categoria";
                    break;
                case "METODO_PAGO":
                    nombreTabla = "MetodosPago"; campoId = "id_metodo"; campoTexto = "nom_metodo";
                    break;
                case "ESTANTE":
                    nombreTabla = "Estantes"; campoId = "id_estante"; campoTexto = "ubi_estante";
                    break;
                default:
                    throw new ArgumentException("Tipo de mantenimiento no válido.");
            }
        }

        // 1. LISTAR / FILTRAR DATOS
        public DataTable ListarDatos(string tipo, string filtro = "")
        {
            DataTable dt = new DataTable();
            ObtenerConfiguracionTabla(tipo, out string tabla, out string id, out string texto);

            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = $"SELECT {id} AS [ID], {texto} AS [Nombre] FROM {tabla} WHERE {texto} LIKE @Filtro ORDER BY {id};";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");
                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                    catch (Exception ex) { throw new Exception("Error al listar: " + ex.Message); }
                }
            }
            return dt;
        }

        // 2. INSERTAR
        public bool Insertar(string tipo, string valorTexto)
        {
            ObtenerConfiguracionTabla(tipo, out string tabla, out string id, out string texto);
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = $"INSERT INTO {tabla} ({texto}) VALUES (@Valor);";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Valor", valorTexto);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 3. MODIFICAR
        public bool Modificar(string tipo, int idRegistro, string nuevoTexto)
        {
            ObtenerConfiguracionTabla(tipo, out string tabla, out string id, out string texto);
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = $"UPDATE {tabla} SET {texto} = @NuevoTexto WHERE {id} = @Id;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NuevoTexto", nuevoTexto);
                    cmd.Parameters.AddWithValue("@Id", idRegistro);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. ELIMINAR
        public bool Eliminar(string tipo, int idRegistro)
        {
            ObtenerConfiguracionTabla(tipo, out string tabla, out string id, out string texto);
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = $"DELETE FROM {tabla} WHERE {id} = @Id;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idRegistro);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
