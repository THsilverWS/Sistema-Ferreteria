using SistemaFerreteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormEmpleadosAv : Form
    {
        private readonly EmpleadoDAO _empleadoDao = new EmpleadoDAO();

        public FormEmpleadosAv()
        {
            InitializeComponent();

            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormEmpleadosAv_Load(object sender, EventArgs e)
        {
            CargarComboRoles();
            RefrescarGrid();
            LimpiarCampos();
        }

        private void CargarComboRoles()
        {
            try
            {
                cmbCargo.DataSource = _empleadoDao.ObtenerRoles();
                cmbCargo.DisplayMember = "nom_rol";
                cmbCargo.ValueMember = "id_rol";
                cmbCargo.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error al cargar Cargos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RefrescarGrid()
        {
            try
            {
                dgvEmpleados.DataSource = _empleadoDao.ObtenerEmpleadosParaPanel();

                if (dgvEmpleados.Columns.Contains("ID")) dgvEmpleados.Columns["ID"].FillWeight = 40;
                if (dgvEmpleados.Columns.Contains("DNI")) dgvEmpleados.Columns["DNI"].FillWeight = 80;
                if (dgvEmpleados.Columns.Contains("Empleado")) dgvEmpleados.Columns["Empleado"].FillWeight = 160;
                if (dgvEmpleados.Columns.Contains("Cargo")) dgvEmpleados.Columns["Cargo"].FillWeight = 100;
                if (dgvEmpleados.Columns.Contains("Fecha de Añadido")) dgvEmpleados.Columns["Fecha de Añadido"].FillWeight = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Por favor, seleccione un empleado de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool estado = chkEstado.Checked;

                bool exito = _empleadoDao.ModificarEmpleadoConEstado(
                    txtDni.Text.Trim(),
            txtNombre.Text.Trim(),
            Convert.ToInt32(cmbCargo.SelectedValue),
            dtpFechaAñadido.Value,
            estado
        );

                if (exito)
                {
                    MessageBox.Show("¡Ficha de empleado actualizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarGrid();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error de Edición"); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Por favor, seleccione un empleado de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool estado = chkEstado.Checked;

                bool exito = _empleadoDao.ModificarEmpleadoConEstado(
                    txtDni.Text.Trim(),
            txtNombre.Text.Trim(),
            Convert.ToInt32(cmbCargo.SelectedValue),
            dtpFechaAñadido.Value,
            estado
        );

                if (exito)
                {
                    MessageBox.Show("¡Ficha de empleado actualizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarGrid();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error de Edición"); }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvEmpleados.Rows[e.RowIndex];

                if (dgvEmpleados.Columns.Contains("ID")) txtId.Text = fila.Cells["ID"].Value.ToString();
                txtDni.Text = fila.Cells["DNI"].Value.ToString();
                txtNombre.Text = fila.Cells["Empleado"].Value.ToString();

                var valorFecha = fila.Cells["Fecha de Añadido"].Value;
                if (valorFecha != null && valorFecha != DBNull.Value && !string.IsNullOrEmpty(valorFecha.ToString()))
                    dtpFechaAñadido.Value = Convert.ToDateTime(valorFecha);
                else
                    dtpFechaAñadido.Value = DateTime.Now;

                string cargoFila = fila.Cells["Cargo"].Value.ToString();
                cmbCargo.SelectedIndex = cmbCargo.FindStringExact(cargoFila);

                if (dgvEmpleados.Columns.Contains("Estado"))
                {
                    string estadoFila = fila.Cells["Estado"].Value.ToString();
                    chkEstado.Checked = (estadoFila == "Activo");
                }

                txtDni.ReadOnly = true;

                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarGrid();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDni.Clear();
            txtDni.ReadOnly = false;
            txtNombre.Clear();
            cmbCargo.SelectedIndex = -1;
            dtpFechaAñadido.Value = DateTime.Now;

            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }



    }
}