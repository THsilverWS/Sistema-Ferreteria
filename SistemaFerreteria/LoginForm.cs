using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class LoginForm : Form
    {
        private readonly EmpleadoDAO empleadoDao = new EmpleadoDAO();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validación de entradas en interfaz
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, llena todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Invocamos la lógica de negocio a través del DAO 
                DataTable dtUsuario = empleadoDao.ValidarLogin(usuario, contrasena);

                if (dtUsuario.Rows.Count > 0)
                {
                    // Extraemos los datos de la fila encontrada
                    string dniEmpleado = dtUsuario.Rows[0]["dni_empleado"].ToString();
                    string rolUsuario = dtUsuario.Rows[0]["nom_rol"].ToString().Trim();

                    // 🌟 CORREGIDO: Ahora usamos la variable que ya creaste arriba
                    UsuarioSesion.DniEmpleadoLogueado = dniEmpleado;

                    MessageBox.Show($"¡Bienvenido! Rol: {rolUsuario}",
                        "Acceso Concedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtUsuario.Clear();
                    txtContrasena.Clear();

                    // Direccionamiento según el nivel de acceso
                    if (rolUsuario == "Administrador")
                    {
                        Panel_Admin panel = new Panel_Admin();
                        panel.FormClosed += (s, args) => this.Close();
                        panel.Show();
                    }
                    else
                    {
                        Form1 formularioPrincipal = new Form1(rolUsuario, dniEmpleado);
                        formularioPrincipal.FormClosed += (s, args) => this.Close();
                        formularioPrincipal.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos (o empleado inactivo).",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores visuales controlados
                MessageBox.Show(ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}