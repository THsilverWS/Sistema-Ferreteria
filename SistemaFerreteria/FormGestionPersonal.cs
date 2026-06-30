using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormGestionPersonal : Form
    {
        private readonly Conexion conexionBase = new Conexion();

        public FormGestionPersonal()
        {
            InitializeComponent();
        }

        private void FormGestionPersonal_Load(object sender, EventArgs e)
        {
            dgvPersonal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonal.MultiSelect = false;
            dgvPersonal.RowHeadersVisible = false;

            ConfigurarColumnas();
            CargarPersonal();
        }

        private void ConfigurarColumnas()
        {
            dgvPersonal.Columns.Clear();
            dgvPersonal.AutoGenerateColumns = false;

            AgregarColumna("dni_empleado", "DNI Personal");
            AgregarColumna("nom_empleado", "Nombre Completo");
            AgregarColumna("usu_empleado", "Nombre de Usuario");
            AgregarColumna("nom_rol", "Rol de Acceso");
            AgregarColumna("EstadoTexto", "Estado");

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "Acción";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvPersonal.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "btnEliminar";
            btnEliminar.HeaderText = "Acción";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvPersonal.Columns.Add(btnEliminar);
        }

        private void AgregarColumna(string dataPropertyName, string headerText)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = dataPropertyName;
            col.HeaderText = headerText;
            col.DataPropertyName = dataPropertyName;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPersonal.Columns.Add(col);
        }

        public void CargarPersonal(string filtroBusqueda = "")
        {
            try
            {
                using (SqlConnection conexion = conexionBase.ObtenerConexion())
                {
                    string query = @"
                        SELECT 
                            E.dni_empleado,
                            E.nom_empleado,
                            E.usu_empleado,
                            R.nom_rol,
                            E.est_empleado,
                            CASE WHEN E.est_empleado = 1 THEN 'Activo' ELSE 'Inactivo' END AS EstadoTexto
                        FROM Empleados E
                        INNER JOIN Roles R ON E.id_rol = R.id_rol
                        WHERE 1=1";

                    if (!string.IsNullOrEmpty(filtroBusqueda))
                    {
                        query += " AND (E.nom_empleado LIKE @Filtro OR E.dni_empleado LIKE @Filtro OR E.usu_empleado LIKE @Filtro)";
                    }

                    query += " ORDER BY E.nom_empleado ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtroBusqueda))
                        {
                            cmd.Parameters.AddWithValue("@Filtro", "%" + filtroBusqueda + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPersonal.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del personal: " + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPersonal(txtBuscar.Text.Trim());
        }

        private void dgvPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView filaSeleccionada = (DataRowView)dgvPersonal.Rows[e.RowIndex].DataBoundItem;

                string dniEmpleado = filaSeleccionada["dni_empleado"].ToString();
                string nombreEmpleado = filaSeleccionada["nom_empleado"].ToString();

                if (dgvPersonal.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    FormEditarPersonal formEdicion = new FormEditarPersonal(dniEmpleado);
                    formEdicion.ShowDialog();
                    CargarPersonal();
                }

                if (dgvPersonal.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    DialogResult dr = MessageBox.Show($"¿Seguro que quieres eliminar al usuario {nombreEmpleado} del sistema?",
                                                      "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        EliminarPersonal(dniEmpleado);
                    }
                }
            }
        }

        private void EliminarPersonal(string dni)
        {
            try
            {
                using (SqlConnection conexion = conexionBase.ObtenerConexion())
                {
                    conexion.Open();

                    conexionBase.AsignarContextoSeguridad(conexion);

                    string query = "DELETE FROM Empleados WHERE dni_empleado = @dni";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario de personal eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPersonal();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("No se puede eliminar a este empleado porque tiene boletas registradas a su nombre en el historial técnico.",
                                "Restricción de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar el registro: " + ex.Message, "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}