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

            string servidorAnterior = Properties.Settings.Default.ServidorSQL; 
            string baseDatosAnterior = Properties.Settings.Default.BaseDatosSQL;

            try
            {
                Properties.Settings.Default.ServidorSQL = txtServidor.Text.Trim();
                Properties.Settings.Default.BaseDatosSQL = txtBaseDatos.Text.Trim();

                if (conexionBase.ProbarConexion())
                {
                    Properties.Settings.Default.Save();

                    MessageBox.Show("¡Conexión establecida con éxito! Los parámetros han sido actualizados.",
                                    "Configuración Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    Properties.Settings.Default.ServidorSQL = servidorAnterior;
                    Properties.Settings.Default.BaseDatosSQL = baseDatosAnterior;

                    MessageBox.Show("No se pudo conectar al servidor de SQL Server con los datos ingresados. " +
                                    "Por favor, verifique el nombre del servidor o si la base de datos existe.",
                                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
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
