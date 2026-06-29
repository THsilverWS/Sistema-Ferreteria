using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormEditarPersonal : Form
    {
        private const string ConnectionString = "Server=.; Database=Ferreteria; Integrated Security=True; TrustServerCertificate=True;";
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

        // =========================================================
        // 1. CONFIGURAR LAS OPCIONES DEL COMBOBOX DE ROL
        // =========================================================
        private void ConfigurarOpcionesRol()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Vendedor");
            cmbRol.Items.Add("Administrador");
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // =============================
        // 2. BUSCAR Y CARGAR LOS DATOS 
        // =============================
        private void CargarDatosEmpleado()
        {
            string query = "SELECT nom_empleado, usu_empleado, rol_empleado, est_empleado FROM Empleados WHERE dni_empleado = @dni";

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
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

                            string rol = reader["rol_empleado"].ToString().Trim();
                            cmbRol.SelectedItem = rol;

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

        // =========================
        // 3. GUARDAR LOS CAMBIOS 
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) || cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, rellene todos los campos obligatorios antes de guardar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE Empleados
                             SET nom_empleado = @nombre, 
                                 usu_empleado = @usuario, 
                                 rol_empleado = @rol,
                                 est_empleado = @estado 
                             WHERE dni_empleado = @dni";

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 250).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = txtUsuario.Text.Trim();
                cmd.Parameters.Add("@rol", SqlDbType.VarChar, 200).Value = cmbRol.SelectedItem.ToString();
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = chkEstado.Checked;
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = _dniEmpleado;

                try
                {
                    conexion.Open();
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