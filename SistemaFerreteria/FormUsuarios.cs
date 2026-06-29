using SistemaFerreteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormUsuarios : Form
    {
        private readonly EmpleadoDAO _empleadoDao = new EmpleadoDAO();
        private DataTable _dtEmpleados;
        public FormUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtId.ReadOnly = true;
            txtDni.ReadOnly = true;
            cmbCargo.Enabled = false;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarComboEmpleados();
            CargarComboCargos(); // Carga la lista general de Roles
            RefrescarGrid();
            LimpiarCampos();
        }
        private void CargarComboEmpleados()
        {
            try
            {
                _dtEmpleados = _empleadoDao.ObtenerEmpleadosActivos();
                cmbEmpleado.DataSource = _dtEmpleados;
                cmbEmpleado.DisplayMember = "nom_empleado";
                cmbEmpleado.ValueMember = "dni_empleado"; // El valor interno será su DNI
                cmbEmpleado.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void CargarComboCargos()
        {
            try
            {
                cmbCargo.DataSource = _empleadoDao.ObtenerRoles();
                cmbCargo.DisplayMember = "nom_rol";
                cmbCargo.ValueMember = "id_rol";
                cmbCargo.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void RefrescarGrid()
        {
            try { dgvUsuarios.DataSource = _empleadoDao.ObtenerUsuariosParaPanel(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedValue != null && cmbEmpleado.Focused)
            {
                string dni = cmbEmpleado.SelectedValue.ToString();
                txtDni.Text = dni;

                // Buscamos el id_rol del empleado seleccionado para pintarlo en el combo Cargo
                DataRow[] filas = _dtEmpleados.Select($"dni_empleado = '{dni}'");
                if (filas.Length > 0)
                {
                    cmbCargo.SelectedValue = filas[0]["id_rol"];
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, seleccione un empleado e ingrese usuario y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_empleadoDao.ActualizarCredenciales(txtDni.Text, txtUsuario.Text.Trim(), txtContraseña.Text.Trim()))
                {
                    MessageBox.Show("¡Credenciales asignadas con éxito!", "Éxito");
                    RefrescarGrid();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text)) return;

            try
            {
                if (_empleadoDao.ActualizarCredenciales(txtDni.Text, txtUsuario.Text.Trim(), txtContraseña.Text.Trim()))
                {
                    MessageBox.Show("¡Credenciales actualizadas correctamente!", "Éxito");
                    RefrescarGrid();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text)) return;

            if (MessageBox.Show("¿Desea revocar el acceso a este usuario? Se borrarán sus credenciales.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (_empleadoDao.ActualizarCredenciales(txtDni.Text, "", "")) // Deja en blanco el usuario y clave
                    {
                        MessageBox.Show("Acceso revocado correctamente.", "Éxito");
                        RefrescarGrid();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                txtId.Text = fila.Cells["ID"].Value.ToString();
                txtDni.Text = fila.Cells["DNI"].Value.ToString();
                txtUsuario.Text = fila.Cells["Usuario"].Value.ToString();
                txtContraseña.Text = fila.Cells["Contraseña"].Value.ToString();

                cmbEmpleado.Text = fila.Cells["Empleado"].Value.ToString();
                cmbCargo.Text = fila.Cells["Cargo"].Value.ToString();

                cmbEmpleado.Enabled = false; // Bloqueado, no puedes transferir el usuario de un empleado a otro

                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDni.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            cmbEmpleado.SelectedIndex = -1;
            cmbCargo.SelectedIndex = -1;
            cmbEmpleado.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvUsuarios.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Le pasamos el alias "USUARIO" para que tu ventana sepa qué plantilla usar
            FormExportarImportar ventanaExportar = new FormExportarImportar("EXPORTAR", "USUARIO", dt);
    ventanaExportar.ShowDialog();
        }
    }
}
