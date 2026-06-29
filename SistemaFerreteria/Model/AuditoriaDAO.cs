using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaFerreteria.Model
{
    public class AuditoriaDAO
    {
        private readonly Conexion conexionBase = new Conexion();

        public DataTable ObtenerHistorial()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                // Trae los campos exactos, uniendo Empleados y Roles para sacar Nombre y Cargo
                string query = @"
                    SELECT 
                        A.id_auditoria AS [ID],
                        ISNULL(E.nom_empleado, 'Sistema / Interno') AS [Empleado],
                        ISNULL(R.nom_rol, 'N/A') AS [Cargo],
                        A.accion AS [Acción],
                        CONVERT(VARCHAR(19), A.fec_cambio, 120) AS [Fecha y Hora],
                        HOST_NAME() AS [Nombre Equipo], -- Saca el nombre de la PC actual
                        A.tabla_afectada AS [Tabla Afectada],
                        A.valores_anteriores, -- Lo traemos oculto para pasarlo a los TextBox
                        A.valores_nuevos      -- Lo traemos oculto para pasarlo a los TextBox
                    FROM HistorialAuditoria A
                    LEFT JOIN Empleados E ON A.dni_empleado = E.dni_empleado
                    LEFT JOIN Roles R ON E.id_rol = R.id_rol
                    ORDER BY A.fec_cambio DESC;";

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
                        throw new Exception("Error al cargar la auditoría: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}
