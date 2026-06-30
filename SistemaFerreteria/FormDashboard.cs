using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormDashboard : Form
    {
        private readonly Conexion conexionBase = new Conexion();

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
            string queryMétricas = @"
                SELECT 
                    COUNT(*) AS Total,
                    SUM(CASE WHEN estado_venta = 'Pendiente' THEN 1 ELSE 0 END) AS Pendientes,
                    SUM(CASE WHEN estado_venta = 'Entregado' THEN 1 ELSE 0 END) AS Entregados,
                    SUM(CASE WHEN estado_venta = 'Cancelado' THEN 1 ELSE 0 END) AS Cancelados
                FROM Ventas;";

            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(queryMétricas, conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTotal.Text = reader["Total"].ToString();
                            lblPendientes.Text = reader["Pendientes"].ToString();
                            lblEntregados.Text = reader["Entregados"].ToString();
                            lblCancelados.Text = reader["Cancelados"].ToString();
                        }
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