using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;
using System;
using System.Data;

namespace SistemaFerreteria
{
    public class Conexion
    {

        private string ObtenerCadenaConexion()
        {
            string servidor = Properties.Settings.Default.ServidorSQL;
            string baseDatos = Properties.Settings.Default.BaseDatosSQL;

            return $"Server={servidor};Database={baseDatos};Trusted_Connection=True;Encrypt=False;";
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ObtenerCadenaConexion());
        }
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
                    return false;
                }
            }
        }
        public void AsignarContextoSeguridad(SqlConnection con)
        {
            if (string.IsNullOrEmpty(UsuarioSesion.DniEmpleadoLogueado)) return;

            string query = "SET CONTEXT_INFO @dniBinario;";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                byte[] dniBytes = System.Text.Encoding.ASCII.GetBytes(UsuarioSesion.DniEmpleadoLogueado.PadRight(128, '\0'));

                cmd.Parameters.Add("@dniBinario", SqlDbType.VarBinary, 128).Value = dniBytes;

                try
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error asignando contexto de auditoría: " + ex.Message);
                }
            }
        }
    }
}