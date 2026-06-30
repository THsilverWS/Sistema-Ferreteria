using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;
using System;
using System.Data;

namespace SistemaFerreteria
{
    public class Conexion
    {
        /// <summary>
        /// Genera dinámicamente la cadena de conexión usando los valores guardados en la raíz de Settings.
        /// </summary>
        private string ObtenerCadenaConexion()
        {
            // Corregido: Acceso directo a Settings en la raíz del proyecto
            string servidor = Properties.Settings.Default.ServidorSQL;
            string baseDatos = Properties.Settings.Default.BaseDatosSQL;

            // Armamos el String de Conexión con autenticación de Windows
            return $"Server={servidor};Database={baseDatos};Trusted_Connection=True;Encrypt=False;";
        }

        /// <summary>
        /// Método para obtener un objeto SqlConnection listo para ser utilizado.
        /// </summary>
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ObtenerCadenaConexion());
        }

        /// <summary>
        /// Verifica rápidamente si los parámetros actuales de servidor y base de datos son correctos.
        /// </summary>
        /// <returns>True si conecta con éxito, False si ocurre un error.</returns>
        public bool ProbarConexion()
        {
            using (SqlConnection con = ObtenerConexion())
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false; // Retorna false sin colgar la aplicación (Cumple RNF04)
                }
            }
        }
        public void AsignarContextoSeguridad(SqlConnection con)
        {
            // Si no hay ningún usuario logueado todavía (por ejemplo, en el login), no hacemos nada
            if (string.IsNullOrEmpty(UsuarioSesion.DniEmpleadoLogueado)) return;

            // Convertimos el DNI a su representación en cadena binaria/hexadecimal para CONTEXT_INFO
            string query = "SET CONTEXT_INFO @dniBinario;";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Convertimos el string del DNI (8 caracteres) a un arreglo de bytes (Binary)
                byte[] dniBytes = System.Text.Encoding.ASCII.GetBytes(UsuarioSesion.DniEmpleadoLogueado.PadRight(128, '\0'));

                cmd.Parameters.Add("@dniBinario", SqlDbType.VarBinary, 128).Value = dniBytes;

                try
                {
                    // Si la conexión está cerrada, la abrimos temporalmente
                    if (con.State != ConnectionState.Open) con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejo silencioso o log para evitar romper el flujo principal si falla el contexto
                    System.Diagnostics.Debug.WriteLine("Error asignando contexto de auditoría: " + ex.Message);
                }
            }
        }
    }
}