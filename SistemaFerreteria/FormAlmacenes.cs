using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormAlmacenes : Form
    {
        private readonly AlmacenDAO _almacenDao = new AlmacenDAO();

        public FormAlmacenes()
        {
            InitializeComponent();
            ConfigurarComponentes();
        }

        private void ConfigurarComponentes()
        {
            dgvAlmacenes.AllowUserToAddRows = false;
            dgvAlmacenes.ReadOnly = true;
            dgvAlmacenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlmacenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtId.ReadOnly = true;
        }


        private void RefrescarGrid(string filtro = "")
        {
            try
            {
                dgvAlmacenes.DataSource = _almacenDao.ObtenerAlmacenes(filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del almacén.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_almacenDao.InsertarAlmacen(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("¡Almacén registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarGrid();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Seleccione un registro válido y complete el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(txtId.Text);
                if (_almacenDao.ModificarAlmacen(id, txtNombre.Text.Trim()))
                {
                    MessageBox.Show("¡Almacén actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarGrid();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult dr = MessageBox.Show($"¿Desea eliminar definitivamente el almacén '{txtNombre.Text}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(txtId.Text);
                    if (_almacenDao.EliminarAlmacen(id))
                    {
                        MessageBox.Show("Almacén eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarGrid();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            RefrescarGrid(txtNombre.Text.Trim());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarGrid();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable dtOriginal = null;

            if (dgvAlmacenes.DataSource is DataTable table)
            {
                dtOriginal = table;
            }
            else if (dgvAlmacenes.DataSource is DataView view)
            {
                dtOriginal = view.ToTable();
            }

            if (dtOriginal == null || dtOriginal.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtClon = dtOriginal.Copy();
            if (dtClon.Columns.Contains("Nombre"))
            {
                dtClon.Columns["Nombre"].ColumnName = "Nombre_Ubicacion";
            }

            FormExportarImportar ventanaExportar = new FormExportarImportar("EXPORTAR", "ALMACEN", dtClon);
            ventanaExportar.ShowDialog();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            FormExportarImportar ventanaImportar = new FormExportarImportar("IMPORTAR", "ALMACEN", null);
            if (ventanaImportar.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrid();
            }
        }

        private void FormAlmacenes_Load(object sender, EventArgs e)
        {
            RefrescarGrid();
            LimpiarCampos();
        }

        private void dgvAlmacenes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlmacenes.Rows[e.RowIndex];
                txtId.Text = fila.Cells["ID"].Value?.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();

                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
    }
}