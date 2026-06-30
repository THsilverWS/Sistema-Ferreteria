using SistemaFerreteria.Model;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, llena todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dtUsuario = empleadoDao.ValidarLogin(usuario, contrasena);

                if (dtUsuario.Rows.Count > 0)
                {
                    // 🌟 1. VALIDACIÓN INMEDIATA DE ESTADO DE EMPLEADO
                    bool estaActivo = Convert.ToBoolean(dtUsuario.Rows[0]["est_empleado"]);

                    if (!estaActivo)
                    {
                        MessageBox.Show("Tu cuenta de empleado se encuentra desactivada. Comunícate con el Administrador.",
                            "Acceso Denegado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop); // Icono de parada obligatoria
                        return; // Frenamos el login en seco aquí
                    }

                    // Si pasa la validación, continúa tu flujo normal sin cambios
                    string dniEmpleado = dtUsuario.Rows[0]["dni_empleado"].ToString();
                    string rolUsuario = dtUsuario.Rows[0]["nom_rol"].ToString().Trim();

                    UsuarioSesion.DniEmpleadoLogueado = dniEmpleado;

                    MessageBox.Show($"¡Bienvenido! Rol: {rolUsuario}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtUsuario.Clear();
                    txtContrasena.Clear();

                    if (rolUsuario == "Administrador")
                    {
                        Panel_Admin panel = new Panel_Admin();
                        panel.FormClosed += (s, args) => this.Close();
                        panel.Show();
                    }
                    else
                    {
                        UsuarioSesion.DniEmpleadoLogueado = dniEmpleado;

                        Form1 formularioPrincipal = new Form1(rolUsuario, dniEmpleado);
                        formularioPrincipal.FormClosed += (s, args) => this.Close();
                        formularioPrincipal.Show();

                        FormVentas formularioVentas = new FormVentas(dniEmpleado);
                        formularioVentas.Show();

                        this.Hide();
                    }
                    this.Hide();
                }
                else
                {
                    // 🌟 Mensaje corregido y limpio
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {


                // 🌟 JALAMOS LAS VARIABLES ACTUALES DE SETTINGS PARA VISUALIZARLAS
                string servidorActual = Properties.Settings.Default.ServidorSQL;
                string baseDatosActual = Properties.Settings.Default.BaseDatosSQL;

                // Armamos un mensaje senior detallado
                string mensajeError = $"Error de Sistema al conectar.\n\n" +
                                      $"=== PARÁMETROS ACTUALES ===\n" +
                                      $"• Servidor: \"{servidorActual}\"\n" +
                                      $"• Base de Datos: \"{baseDatosActual}\"\n\n" +
                                      $"=== DETALLE TÉCNICO ===\n" +
                                      $"{ex.Message}";

                MessageBox.Show(mensajeError, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show(ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}