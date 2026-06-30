using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormListaVentas : Form
    {
        private string connectionString = "Server=.; Database=Ferreteria; Integrated Security=True; TrustServerCertificate=True;";

        public FormListaVentas()
        {
            InitializeComponent();
        }

        public void CargarVentas(string filtroCliente = "", string filtroEmpleado = "")
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            V.id_venta AS [ID Venta],
                            V.fec_venta AS [Fecha Venta],
                            V.id_cliente AS [DNI/RUC Cliente],
                            C.nom_cliente AS [Nombre Cliente],
                            V.dni_empleado AS [DNI Empleado],
                            VD.nom_empleado AS [Nombre Empleado],
                            V.tot_venta AS [Total Venta]
                        FROM Ventas V
                        INNER JOIN Clientes C ON V.id_cliente = C.dni_ruc_cliente
                        INNER JOIN Empleados VD ON V.dni_empleado = VD.dni_empleado
                        WHERE 1=1";

                    if (!string.IsNullOrEmpty(filtroCliente))
                    {
                        query += " AND (V.id_cliente LIKE @FiltroCliente OR C.nom_cliente LIKE @FiltroCliente)";
                    }
                    if (!string.IsNullOrEmpty(filtroEmpleado))
                    {
                        query += " AND V.dni_empleado LIKE @FiltroEmpleado";
                    }

                    query += " ORDER BY V.fec_venta DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtroCliente))
                            cmd.Parameters.AddWithValue("@FiltroCliente", filtroCliente + "%");

                        if (!string.IsNullOrEmpty(filtroEmpleado))
                            cmd.Parameters.AddWithValue("@FiltroEmpleado", filtroEmpleado + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvVentas.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas desde SQL Server: " + ex.Message,
                                "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtBuscarCliente_TextChanged_1(object sender, EventArgs e)
        {
            CargarVentas(txtBuscarCliente.Text.Trim(), txtBuscarEmpleadoDNI.Text.Trim());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Clear();
            txtBuscarEmpleadoDNI.Clear();

            CargarVentas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una venta de la tabla para proceder a eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resp = MessageBox.Show("¿Seguro que deseas eliminar la venta seleccionada? Esto también removerá sus registros secundarios en el detalle de ventas.",
                                       "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            var selectedRow = dgvVentas.SelectedRows[0];
            object idObj = selectedRow.Cells["ID Venta"].Value;
            if (idObj == null || idObj == DBNull.Value) return;

            int idVenta = Convert.ToInt32(idObj);

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            // 1. Borramos primero los detalles asignados a esa boleta para evitar errores de FK
                            string queryDetalle = "DELETE FROM DetalleVentas WHERE id_venta = @IdVenta";
                            using (SqlCommand cmdDet = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDet.Parameters.AddWithValue("@IdVenta", idVenta);
                                cmdDet.ExecuteNonQuery();
                            }

                            // 2. Borramos la cabecera principal de la venta
                            string queryVenta = "DELETE FROM Ventas WHERE id_venta = @IdVenta";
                            using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion))
                            {
                                cmdVenta.Parameters.AddWithValue("@IdVenta", idVenta);
                                cmdVenta.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            MessageBox.Show("Venta y sus correspondientes registros de detalle eliminados correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exTrans)
                        {
                            transaccion.Rollback();
                            throw new Exception("Error interno en la transacción de borrado: " + exTrans.Message);
                        }
                    }
                }

                CargarVentas(txtBuscarCliente.Text.Trim(), txtBuscarEmpleadoDNI.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la venta de SQL Server: " + ex.Message, "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarEmpleadoDNI_TextChanged(object sender, EventArgs e)
        {
            CargarVentas(txtBuscarCliente.Text.Trim(), txtBuscarEmpleadoDNI.Text.Trim());
        }

        private void FormListaVentas_Load(object sender, EventArgs e)
        {
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            CargarVentas();
        }
    }
}