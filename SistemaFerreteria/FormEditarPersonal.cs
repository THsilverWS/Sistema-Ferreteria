using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;
namespace SistemaFerreteria
{
    public partial class FormEditarPersonal : Form
    {
        private readonly Conexion conexionBase = new Conexion();
        private string _dniEmpleado;

        public FormEditarPersonal(string dni)
        {
            InitializeComponent();
            _dniEmpleado = dni;

            this.Load += FormEditarPersonal_Load;
        }

        private void FormEditarPersonal_Load(object sender, EventArgs e)
        {
            ConfigurarOpcionesRol();
            CargarDatosEmpleado();
        }

        private void ConfigurarOpcionesRol()
        {
            DataTable dtRoles = new DataTable();
            dtRoles.Columns.Add("id_rol", typeof(int));
            dtRoles.Columns.Add("nom_rol", typeof(string));

            dtRoles.Rows.Add(1, "Administrador");
            dtRoles.Rows.Add(2, "Vendedor");

            cmbRol.DataSource = dtRoles;
            cmbRol.DisplayMember = "nom_rol";
            cmbRol.ValueMember = "id_rol";
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarDatosEmpleado()
        {
            string query = "SELECT nom_empleado, usu_empleado, id_rol, est_empleado FROM Empleados WHERE dni_empleado = @dni";

            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = _dniEmpleado;

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombre.Text = reader["nom_empleado"].ToString();
                            txtUsuario.Text = reader["usu_empleado"].ToString();

                            cmbRol.SelectedValue = Convert.ToInt32(reader["id_rol"]);

                            chkEstado.Checked = Convert.ToBoolean(reader["est_empleado"]);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos del usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la información del personal: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) || cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Por favor, rellene todos los campos obligatorios antes de guardar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE Empleados
                             SET nom_empleado = @nombre, 
                                 usu_empleado = @usuario, 
                                 id_rol = @idRol,
                                 est_empleado = @estado 
                             WHERE dni_empleado = @dni";

            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 250).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = txtUsuario.Text.Trim();
                cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = Convert.ToInt32(cmbRol.SelectedValue);
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = chkEstado.Checked;
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = _dniEmpleado;

                try
                {
                    conexion.Open();

                    conexionBase.AsignarContextoSeguridad(conexion);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Datos del personal actualizados con éxito en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el registro. Compruebe si el empleado sigue activo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar las modificaciones en SQL Server: " + ex.Message, "Error de Escritura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}