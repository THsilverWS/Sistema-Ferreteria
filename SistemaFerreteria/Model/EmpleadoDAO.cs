using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;

namespace SistemaFerreteria.Model
{
    public class EmpleadoDAO
    {
        private readonly Conexion conexionBase = new Conexion();

        public DataTable ValidarLogin(string usuario, string contrasena)
        {
            DataTable resultado = new DataTable();

            string query = @"SELECT E.dni_empleado, R.nom_rol, E.est_empleado 
                     FROM Empleados E
                     INNER JOIN Roles R ON E.id_rol = R.id_rol
                     WHERE E.usu_empleado = @user 
                       AND E.con_empleado = @pass";

            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = usuario;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = contrasena;

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
                        throw new Exception("Error en la base de datos al validar credenciales: " + ex.Message);
                    }
                }
            }
            return resultado;
        }
        public DataTable ObtenerEmpleadosParaPanel()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY E.fec_añadido ASC) AS [ID],
                E.dni_empleado AS [DNI],
                E.nom_empleado AS [Empleado],
                R.nom_rol AS [Cargo],
                CONVERT(VARCHAR(10), E.fec_añadido, 103) AS [Fecha de Añadido],
                CASE WHEN E.est_empleado = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado]
            FROM Empleados E
            INNER JOIN Roles R ON E.id_rol = R.id_rol;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                    catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
                }
            }
            return dt;
        }
        public DataTable ObtenerRoles()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "SELECT id_rol, nom_rol FROM Roles ORDER BY nom_rol ASC;";

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
                        throw new Exception("Error al obtener los roles/cargos: " + ex.Message);
                    }
                }
            }
            return dt;
        }
        public bool InsertarEmpleado(string dni, string nombre, string usuario, string contraseña, int idRol, DateTime fechaAñadido)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                // Nota que incluimos fec_añadido en la consulta SQL
                string query = @"
            INSERT INTO Empleados (dni_empleado, nom_empleado, usu_empleado, con_empleado, id_rol, est_empleado, fec_añadido)
            VALUES (@dni, @nombre, @usuario, @contraseña, @idRol, 1, @fecha);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario); // Mandará "" según el formulario
                    cmd.Parameters.AddWithValue("@contraseña", contraseña); // Mandará "" según el formulario
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@fecha", fechaAñadido);

                    try
                    {
                        con.Open();
                        conexionBase.AsignarContextoSeguridad(con);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error base de datos (Insertar): " + ex.Message);
                    }
                }
            }
        }



        public bool ModificarEmpleadoConEstado(string dni, string nombre, int idRol, DateTime fechaAñadido, bool estado)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
            UPDATE Empleados 
            SET nom_empleado = @nombre, 
                id_rol = @idRol,
                est_empleado = @estado
            WHERE dni_empleado = @dni;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@estado", estado ? 1 : 0);

                    try
                    {
                        con.Open();

                        conexionBase.AsignarContextoSeguridad(con);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex) { throw new Exception("Error en Modificar: " + ex.Message); }
                }
            }
        }

        public DataTable ObtenerUsuariosParaPanel()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY E.nom_empleado ASC) AS [ID],
                        E.dni_empleado AS [DNI],
                        E.nom_empleado AS [Empleado],
                        E.usu_empleado AS [Usuario],
                        E.con_empleado AS [Contraseña],
                        R.nom_rol AS [Cargo]
                    FROM Empleados E
                    INNER JOIN Roles R ON E.id_rol = R.id_rol
                    WHERE E.est_empleado = 1 AND E.usu_empleado <> '';";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                    catch (Exception ex) { throw new Exception("Error al cargar usuarios: " + ex.Message); }
                }
            }
            return dt;
        }

        public DataTable ObtenerEmpleadosActivos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "SELECT dni_empleado, nom_empleado, id_rol FROM Empleados WHERE est_empleado = 1;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                    catch (Exception ex) { throw new Exception("Error al cargar lista de empleados: " + ex.Message); }
                }
            }
            return dt;
        }

        public bool ActualizarCredenciales(string dni, string usuario, string contraseña)
        {
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = @"
                    UPDATE Empleados 
                    SET usu_empleado = @usuario, 
                        con_empleado = @contraseña
                    WHERE dni_empleado = @dni;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    try
                    {
                        con.Open();
                        conexionBase.AsignarContextoSeguridad(con);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex) { throw new Exception("Error al actualizar credenciales: " + ex.Message); }
                }
            }
        }
        public DataTable ObtenerTodosLosEmpleadosBase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexionBase.ObtenerConexion())
            {
                string query = "SELECT dni_empleado, nom_empleado, usu_empleado, con_empleado, id_rol, est_empleado FROM Empleados;";

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
                        throw new Exception("Error al consultar datos base de empleados: " + ex.Message);
                    }
                }
            }
            return dt;
        }

    }
}
