using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormGestionPersonal : Form
    {
        private string connectionString = "Server=.; Database=Ferreteria; Integrated Security=True; TrustServerCertificate=True;";

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

        // =========================================================
        // 1. CONFIGURAR COLUMNAS ASIGNADAS AL SCRIPT SQL
        // =========================================================
        private void ConfigurarColumnas()
        {
            dgvPersonal.Columns.Clear();
            dgvPersonal.AutoGenerateColumns = false;

            AgregarColumna("dni_empleado", "DNI Personal");
            AgregarColumna("nom_empleado", "Nombre Completo");
            AgregarColumna("usu_empleado", "Nombre de Usuario");
            AgregarColumna("rol_empleado", "Rol de Acceso");
            AgregarColumna("EstadoTexto", "Estado");

            // Columna Botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "Acción";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvPersonal.Columns.Add(btnEditar);

            // Columna Botón Eliminar
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

        // =========================================================
        // 2. CARGAR PERSONAL DESDE TABLA Empleados
        // =========================================================
        public void CargarPersonal(string filtroBusqueda = "")
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            dni_empleado,
                            nom_empleado,
                            usu_empleado,
                            rol_empleado,
                            est_empleado,
                            CASE WHEN est_empleado = 1 THEN 'Activo' ELSE 'Inactivo' END AS EstadoTexto
                        FROM Empleados
                        WHERE 1=1";

                    // Añadir filtro dinámico si el TextBox tiene datos
                    if (!string.IsNullOrEmpty(filtroBusqueda))
                    {
                        query += " AND (nom_empleado LIKE @Filtro OR dni_empleado LIKE @Filtro OR usu_empleado LIKE @Filtro)";
                    }

                    query += " ORDER BY nom_empleado ASC";

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

        // ============================
        // 3. BUSCADOR EN TIEMPO REAL
        // ============================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Ejecuta el filtro directamente en la consulta a la base de datos local
            CargarPersonal(txtBuscar.Text.Trim());
        }

        // ====================
        // 4. ACCIONES DEL GRID 
        // ====================
        private void dgvPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos la fila seleccionada
                DataRowView filaSeleccionada = (DataRowView)dgvPersonal.Rows[e.RowIndex].DataBoundItem;

                string dniEmpleado = filaSeleccionada["dni_empleado"].ToString();
                string nombreEmpleado = filaSeleccionada["nom_empleado"].ToString();

                // Caso Botón Editar
                if (dgvPersonal.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    FormEditarPersonal formEdicion = new FormEditarPersonal(dniEmpleado);
                    formEdicion.ShowDialog();

                    // Al cerrar el diálogo, refrescamos los datos del grid
                    CargarPersonal();
                }

                // Caso Botón Eliminar
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

        // =========================================================
        // 5. ELIMINAR PERSONAL DE LA BASE DE DATOS
        // =========================================================
        private void EliminarPersonal(string dni)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

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
                // Captura el error si el empleado ya está asociado a un registro en la tabla Ventas
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