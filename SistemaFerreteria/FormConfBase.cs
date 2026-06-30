using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaFerreteria
{
    public partial class FormConfBase : Form
    {
        private readonly Conexion conexionBase = new Conexion();
        public FormConfBase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text) || string.IsNullOrWhiteSpace(txtBaseDatos.Text))
            {
                MessageBox.Show("Por favor, complete tanto el nombre del Servidor como el de la Base de Datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos temporalmente los valores actuales por si la prueba falla y queremos revertir
            string servidorAnterior = Properties.Settings.Default.ServidorSQL; 
            string baseDatosAnterior = Properties.Settings.Default.BaseDatosSQL;

            try
            {
                // Asignamos provisionalmente los nuevos textos a tus variables de Settings
                Properties.Settings.Default.ServidorSQL = txtServidor.Text.Trim();
                Properties.Settings.Default.BaseDatosSQL = txtBaseDatos.Text.Trim();

                // 🌟 ATENCIÓN SENIOR: Probamos si la nueva configuración conecta con éxito[cite: 16]
                if (conexionBase.ProbarConexion())
                {
                    // Si conecta, asentamos los cambios definitivamente en el archivo local de configuración
                    Properties.Settings.Default.Save();

                    MessageBox.Show("¡Conexión establecida con éxito! Los parámetros han sido actualizados.",
                                    "Configuración Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerramos la ventana de ajuste
                }
                else
                {
                    // Si la prueba falla, regresamos los valores a como estaban antes para no romper el sistema
                    Properties.Settings.Default.ServidorSQL = servidorAnterior;
                    Properties.Settings.Default.BaseDatosSQL = baseDatosAnterior;

                    MessageBox.Show("No se pudo conectar al servidor de SQL Server con los datos ingresados. " +
                                    "Por favor, verifique el nombre del servidor o si la base de datos existe.",
                                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Revertimos ante cualquier error inesperado del sistema
                Properties.Settings.Default.ServidorSQL = servidorAnterior;
                Properties.Settings.Default.BaseDatosSQL = baseDatosAnterior;

                MessageBox.Show("Ocurrió un error inesperado al aplicar los cambios: " + ex.Message,
                                "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormConfBase_Load(object sender, EventArgs e)
        {
            txtServidor.Text = Properties.Settings.Default.ServidorSQL;
            txtBaseDatos.Text = Properties.Settings.Default.BaseDatosSQL;
        }
    }
}
