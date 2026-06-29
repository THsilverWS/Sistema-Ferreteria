using System;
using Microsoft.Data.SqlClient;

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
            string servidor = Settings.Default.ServidorSQL;
            string baseDatos = Settings.Default.BaseDatosSQL;

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
    }
}
