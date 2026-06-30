using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormTrasladoInventario : Form
    {
        private readonly HistorialInventarioDAO _historialDao = new HistorialInventarioDAO();
        private readonly Conexion _conexionBase = new Conexion();

        public FormTrasladoInventario()
        {
            InitializeComponent();
        }

        private void FormTrasladoInventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarAlmacenes();
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection con = _conexionBase.ObtenerConexion())
                {
                    string query = "SELECT id_producto, nom_producto FROM Productos ORDER BY nom_producto ASC;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboProducto.DataSource = dt;
                        cboProducto.DisplayMember = "nom_producto";
                        cboProducto.ValueMember = "id_producto";
                        cboProducto.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAlmacenes()
        {
            try
            {

                using (SqlConnection con = _conexionBase.ObtenerConexion())
                {
                    string query = "SELECT id_almacen, nom_almacen FROM Almacen ORDER BY nom_almacen ASC;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataTable dtOrigen = new DataTable();
                        da.Fill(dtOrigen);
                        cboAlmacenOrigen.DataSource = dtOrigen;
                        cboAlmacenOrigen.DisplayMember = "nom_almacen";
                        cboAlmacenOrigen.ValueMember = "id_almacen";
                        cboAlmacenOrigen.SelectedIndex = -1;
                        DataTable dtDestino = dtOrigen.Copy();
                        cboAlmacenDestino.DataSource = dtDestino;
                        cboAlmacenDestino.DisplayMember = "nom_almacen";
                        cboAlmacenDestino.ValueMember = "id_almacen";
                        cboAlmacenDestino.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar almacenes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione el producto a trasladar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboAlmacenOrigen.SelectedValue == null || cboAlmacenDestino.SelectedValue == null)
            {
                MessageBox.Show("Debe especificar tanto el Almacén de Origen como el de Destino.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idOrigen = Convert.ToInt32(cboAlmacenOrigen.SelectedValue);
            int idDestino = Convert.ToInt32(cboAlmacenDestino.SelectedValue);

            if (idOrigen == idDestino)
            {
                MessageBox.Show("El almacén de destino no puede ser el mismo que el de origen.", "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad a trasladar debe ser mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProducto = Convert.ToInt32(cboProducto.SelectedValue);
                int cantidad = Convert.ToInt32(numCantidad.Value);
                string descripcion = txtDescripcion.Text.Trim();

                if (string.IsNullOrEmpty(descripcion))
                {
                    descripcion = $"Traslado de {cantidad} unidades del almacén '{cboAlmacenOrigen.Text}' hacia '{cboAlmacenDestino.Text}'.";
                }

                bool exito = _historialDao.RegistrarTraslado(idProducto, idOrigen, idDestino, cantidad, descripcion);

                if (exito)
                {
                    MessageBox.Show("¡El traslado ha sido registrado de manera exitosa en el kárdex!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indica éxito al formulario padre para refrescar
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}