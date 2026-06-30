using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormAuditoria : Form
    {
        private readonly AuditoriaDAO _auditoriaDao = new AuditoriaDAO();

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

            // Bloqueamos los campos superiores informativos de tu diseño
            txtCargo.ReadOnly = true;
            txtNombreEquip.ReadOnly = true;
            txtId.ReadOnly = true;
            txtTablaAfectada.ReadOnly = true;
            txtFecha.ReadOnly = true;
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            CargarHistorialCompleto();
        }

        private void CargarHistorialCompleto()
        {
            try
            {
                dgvAuditoria.DataSource = _auditoriaDao.ObtenerHistorial();

                // 🌟 TRUCO: Ocultamos las columnas de valores en el dgv para que no ocupen espacio
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

        // 🖱️ EVENTO CLICK EN LA GRILLA
        private void dgvAuditoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAuditoria.Rows[e.RowIndex];

                // Llenamos los TextBox de la parte superior que ya tenías diseñados
                txtId.Text = fila.Cells["ID"].Value.ToString();
                txtTablaAfectada.Text = fila.Cells["Tabla Afectada"].Value.ToString();
                txtNombreEquip.Text = fila.Cells["Nombre Equipo"].Value.ToString();
                txtCargo.Text = fila.Cells["Cargo"].Value.ToString();

                // Muestra la Fecha y Hora juntas directamente en tu campo de fecha si deseas
                txtFecha.Text = fila.Cells["Fecha y Hora"].Value.ToString();

                // 🌟 MANDAMOS LOS DATOS LARGOS A LOS TEXTBOX MULTILÍNEA INDEPENDIENTES
                txtValoresAnteriores.Text = fila.Cells["valores_anteriores"].Value != DBNull.Value
                    ? fila.Cells["valores_anteriores"].Value.ToString()
                    : "--- SIN DATOS ANTERIORES (INSERT) ---";

                txtValoresNuevos.Text = fila.Cells["valores_nuevos"].Value != DBNull.Value
                    ? fila.Cells["valores_nuevos"].Value.ToString()
                    : "--- SIN DATOS NUEVOS (DELETE) ---";
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            CargarHistorialCompleto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cboEmpleado.SelectedIndex = -1;
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
