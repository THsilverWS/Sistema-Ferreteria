using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class Form1 : Form
    {
        private string rolLogueado;
        private string dniVendedorLogueado;

        private string connectionString = "Server=.; Database=Ferreteria; Integrated Security=True; TrustServerCertificate=True;";

        public Form1(string rol, string dniVendedor)
        {
            InitializeComponent();
            this.rolLogueado = rol;
            this.dniVendedorLogueado = dniVendedor;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    id_producto AS [ID],
                    cod_barras AS [Código],
                    nom_producto AS [Producto],
                    id_categoria AS [ID Categoría],
                    ruc_proveedor AS [RUC Proveedor],
                    id_estante AS [ID Pasillo],
                    pre_compra AS [P. Compra],
                    pre_venta AS [P. Venta]
                FROM Productos";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable tablaDatos = new DataTable();
                            adaptador.Fill(tablaDatos);

                            dgvProductos.DataSource = tablaDatos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (rolLogueado == "Vendedor")
            {
                this.Text = "Sistema Ferretería - Modo Vendedor";

                FormVentas pantallaVentas = new FormVentas(this.dniVendedorLogueado);

                pantallaVentas.Show();
                this.Hide();
            }
            else if (rolLogueado == "Administrador")
            {
                this.Text = "Sistema Ferretería - Módulo Administrador";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
    }
}