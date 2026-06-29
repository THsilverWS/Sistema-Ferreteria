using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormMantenedorComun : Form
    {
        private readonly MantenimientoComunDAO _dao = new MantenimientoComunDAO();
        private readonly string _tipoMantenimiento;
        public FormMantenedorComun( string tipo)
        {
            InitializeComponent();
            _tipoMantenimiento = tipo;

        }

        private void FormMantenedorComun_Load(object sender, EventArgs e)
        {
            this.Text = "Gestión de " + InicialMayuscula(_tipoMantenimiento.Replace("_", " "));
            RefrescarTabla();
            EstadoBotonesInicial();

        }
        private void RefrescarTabla(string filtro = "")
        {
            try
            {
                dgvDatos.DataSource = _dao.ListarDatos(_tipoMantenimiento, filtro);

                // Forzamos el nombre de la cabecera de la grilla para que quede limpio
                if (dgvDatos.Columns.Contains("Nombre"))
                {
                    dgvDatos.Columns["Nombre"].HeaderText = _tipoMantenimiento == "ESTANTE" ? "Ubicación Estante" : "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];
                txtId.Text = fila.Cells["ID"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

                // Cambios de estado de botones dinámicos
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())) return;

            try
            {
                if (_dao.Insertar(_tipoMantenimiento, txtNombre.Text.Trim()))
                {
                    RefrescarTabla();
                    Limpiar();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            try
            {
                int id = Convert.ToInt32(txtId.Text);
                if (_dao.Modificar(_tipoMantenimiento, id, txtNombre.Text.Trim()))
                {
                    RefrescarTabla();
                    Limpiar();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(txtId.Text);
                    if (_dao.Eliminar(_tipoMantenimiento, id))
                    {
                        RefrescarTabla();
                        Limpiar();
                    }
                }
                catch (Exception ex) { MessageBox.Show("No se puede eliminar porque está en uso en otra tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarTabla();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            EstadoBotonesInicial();
        }

        private void EstadoBotonesInicial()
        {
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        private string InicialMayuscula(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            RefrescarTabla(txtNombre.Text.Trim());
        }
    }
}
