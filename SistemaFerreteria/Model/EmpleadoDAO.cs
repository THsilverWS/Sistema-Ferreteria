using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;

namespace SistemaFerreteria.Model
{
    public class EmpleadoDAO
    {
        private readonly Conexion conexionBase = new Conexion();

        /// <summary>
        /// Valida las credenciales del usuario y obtiene sus datos de perfil con su rol correspondiente.
        /// </summary>
        public DataTable ValidarLogin(string usuario, string contrasena)
        {
            DataTable resultado = new DataTable();

            // Consulta adaptada a los roles dinámicos (RF01 y RF02)
            string query = @"SELECT E.dni_empleado, R.nom_rol 
                             FROM Empleados E
                             INNER JOIN Roles R ON E.id_rol = R.id_rol
                             WHERE E.usu_empleado = @user 
                               AND E.con_empleado = @pass 
                               AND E.est_empleado = 1";

            // try-with-resources (using) asegura el cierre inmediato de la conexión (Exigido en la rúbrica)
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = usuario;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = contrasena; // Ampliado para soportar hash cifrado

                    try
                    {
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(resultado);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Manejo controlado de excepciones sin romper la app (RNF04)
                        throw new Exception("Error en la base de datos al validar credenciales: " + ex.Message);
                    }
                }
            }
            return resultado;
        }
    }
}
