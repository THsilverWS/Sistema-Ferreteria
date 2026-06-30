using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormAuditoria : Form
    {
        private readonly AuditoriaDAO _auditoriaDao = new AuditoriaDAO();
        private readonly Conexion _conexionBase = new Conexion();

        public FormAuditoria()
        {
            InitializeComponent();
            ConfigurarComponentes();
        }

        private void ConfigurarComponentes()
        {
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtCargo.ReadOnly = true;
            txtNombreEquip.ReadOnly = true;
            txtId.ReadOnly = true;
            txtTablaAfectada.ReadOnly = true;
            txtFecha.ReadOnly = true;
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarHistorialCompleto();
        }

        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection con = _conexionBase.ObtenerConexion())
                {
                    string query = "SELECT dni_empleado, nom_empleado FROM Empleados ORDER BY nom_empleado ASC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DataRow filaDefecto = dt.NewRow();
                        filaDefecto["dni_empleado"] = "0";
                        filaDefecto["nom_empleado"] = "-- Seleccione un Empleado --";
                        dt.Rows.InsertAt(filaDefecto, 0);

                        cboEmpleado.DataSource = dt;
                        cboEmpleado.DisplayMember = "nom_empleado";
                        cboEmpleado.ValueMember = "dni_empleado";  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialCompleto()
        {
            try
            {
                dgvAuditoria.DataSource = _auditoriaDao.ObtenerHistorial();

                if (dgvAuditoria.Columns.Contains("valores_anteriores"))
                    dgvAuditoria.Columns["valores_anteriores"].Visible = false;

                if (dgvAuditoria.Columns.Contains("valores_nuevos"))
                    dgvAuditoria.Columns["valores_nuevos"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAuditoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAuditoria.Rows[e.RowIndex];

                txtId.Text = fila.Cells["ID"].Value?.ToString();
                txtTablaAfectada.Text = fila.Cells["Tabla Afectada"].Value?.ToString();
                txtNombreEquip.Text = fila.Cells["Nombre Equipo"].Value?.ToString();
                txtCargo.Text = fila.Cells["Cargo"].Value?.ToString();
                txtFecha.Text = fila.Cells["Fecha y Hora"].Value?.ToString();

                if (fila.Cells["Empleado"].Value != DBNull.Value)
                {
                    cboEmpleado.Text = fila.Cells["Empleado"].Value.ToString();
                }

                txtValoresAnteriores.Text = fila.Cells["valores_anteriores"].Value != DBNull.Value
                    ? fila.Cells["valores_anteriores"].Value.ToString()
                    : "--- SIN DATOS ANTERIORES (INSERT) ---";

                txtValoresNuevos.Text = fila.Cells["valores_nuevos"].Value != DBNull.Value
                    ? fila.Cells["valores_nuevos"].Value.ToString()
                    : "--- SIN DATOS NUEVOS (DELETE) ---";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboEmpleado.SelectedIndex <= 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado válido para realizar la búsqueda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dtAuditoria = _auditoriaDao.ObtenerHistorial();
                DataView dv = new DataView(dtAuditoria);

                string nombreEmpleado = cboEmpleado.Text;

                dv.RowFilter = $"[Empleado] = '{nombreEmpleado}'";

                dgvAuditoria.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvAuditoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para poder exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = "Reporte_Auditoria_Ferreteria.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < dgvAuditoria.Columns.Count; i++)
                    {
                        sb.Append(dgvAuditoria.Columns[i].HeaderText + (i == dgvAuditoria.Columns.Count - 1 ? "" : ","));
                    }
                    sb.AppendLine();

                    foreach (DataGridViewRow fila in dgvAuditoria.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            for (int j = 0; j < dgvAuditoria.Columns.Count; j++)
                            {
                                string valorCelda = fila.Cells[j].Value?.ToString() ?? "";
                                valorCelda = valorCelda.Replace("\r\n", " ").Replace(",", ";");
                                sb.Append(valorCelda + (j == dgvAuditoria.Columns.Count - 1 ? "" : ","));
                            }
                            sb.AppendLine();
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("¡Historial de auditoría exportado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarHistorialCompleto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cboEmpleado.SelectedIndex = 0;
            txtTablaAfectada.Clear();
            txtFecha.Clear();
            txtCargo.Clear();
            txtNombreEquip.Clear();
            txtId.Clear();
            txtValoresAnteriores.Clear();
            txtValoresNuevos.Clear();
            CargarHistorialCompleto();
        }
    }
}