using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaFerreteria
{
    public partial class FormDashboard : Form
    {
        private const string ConnectionString = "Server=.; Database=Ferreteria; Integrated Security=True; TrustServerCertificate=True;";

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load_1(object sender, EventArgs e)
        {
            CargarMetricasDashboard();
        }

        private void CargarMetricasDashboard()
        {
            // Consultas SQL
            string queryTotal = "SELECT COUNT(*) FROM Ventas";
            string queryPendientes = "SELECT COUNT(*) FROM Ventas WHERE estado_venta = 'Pendiente'";
            string queryEntregados = "SELECT COUNT(*) FROM Ventas WHERE estado_venta = 'Entregado'";
            string queryCancelados = "SELECT COUNT(*) FROM Ventas WHERE estado_venta = 'Cancelado'";

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                try
                {
                    conexion.Open();

                    // 1. Pedidos Totales
                    using (SqlCommand cmd = new SqlCommand(queryTotal, conexion))
                    {
                        lblTotal.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 2. Pendientes
                    using (SqlCommand cmd = new SqlCommand(queryPendientes, conexion))
                    {
                        lblPendientes.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. Entregados
                    using (SqlCommand cmd = new SqlCommand(queryEntregados, conexion))
                    {
                        lblEntregados.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 4. Cancelados
                    using (SqlCommand cmd = new SqlCommand(queryCancelados, conexion))
                    {
                        lblCancelados.Text = cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar métricas del panel: " + ex.Message,
                        "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}