using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormHistorialInventario : Form
    {
        private readonly HistorialInventarioDAO _historialDao = new HistorialInventarioDAO();
        private readonly Conexion _conexionBase = new Conexion();

        public FormHistorialInventario()
        {
            InitializeComponent();
            ConfigurarComponentes();
        }

        private void ConfigurarComponentes()
        {
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtCargo.ReadOnly = true;
            txtTablaAfectada.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtId.ReadOnly = true;
        }


        private void CargarProductosEnCombo()
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

                        DataRow filaDefecto = dt.NewRow();
                        filaDefecto["id_producto"] = 0;
                        filaDefecto["nom_producto"] = "-- Seleccione un Producto --";
                        dt.Rows.InsertAt(filaDefecto, 0);

                        cboEmpleado.DataSource = dt;
                        cboEmpleado.DisplayMember = "nom_producto";
                        cboEmpleado.ValueMember = "id_producto";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos en el filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarKardexGlobal()
        {
            try
            {
                dgvHistorial.DataSource = _historialDao.ObtenerKardexCompleto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvHistorial.Rows[e.RowIndex];

                txtId.Text = fila.Cells["ID"].Value?.ToString();
                txtTablaAfectada.Text = fila.Cells["Movimiento"].Value?.ToString(); 
                txtFecha.Text = fila.Cells["Fecha y Hora"].Value?.ToString();
                txtCargo.Text = $"Cant: {fila.Cells["Cantidad"].Value}";

                if (fila.Cells["Producto"].Value != null)
                {
                    cboEmpleado.Text = fila.Cells["Producto"].Value.ToString();
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboEmpleado.SelectedIndex <= 0)
            {
                MessageBox.Show("Por favor, seleccione un producto válido para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dtKardex = _historialDao.ObtenerKardexCompleto();
                DataView dv = new DataView(dtKardex);

                string productoSeleccionado = cboEmpleado.Text;
                dv.RowFilter = $"[Producto] = '{productoSeleccionado}'";

                dgvHistorial.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar el kárdex: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = "Kardex_Movimientos_Inventario.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Encabezados de columnas
                    for (int i = 0; i < dgvHistorial.Columns.Count; i++)
                    {
                        sb.Append(dgvHistorial.Columns[i].HeaderText + (i == dgvHistorial.Columns.Count - 1 ? "" : ","));
                    }
                    sb.AppendLine();

                    // Filas de datos
                    foreach (DataGridViewRow fila in dgvHistorial.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            for (int j = 0; j < dgvHistorial.Columns.Count; j++)
                            {
                                string valor = fila.Cells[j].Value?.ToString() ?? "";
                                valor = valor.Replace("\r\n", " ").Replace("\n", " ").Replace(",", ";");
                                sb.Append(valor + (j == dgvHistorial.Columns.Count - 1 ? "" : ","));
                            }
                            sb.AppendLine();
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("¡Kárdex de inventario exportado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarKardexGlobal();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboEmpleado.SelectedIndex = 0;
            txtTablaAfectada.Clear();
            txtFecha.Clear();
            txtCargo.Clear();
            txtId.Clear();
            CargarKardexGlobal();
        }

        private void FormHistorialInventario_Load(object sender, EventArgs e)
        {
            CargarProductosEnCombo(); 
            CargarKardexGlobal();
        }
    }
}