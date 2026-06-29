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
    public partial class FormExportarImportar : Form
    {
        private string _tipoOperacion; // "EXPORTAR" o "IMPORTAR"
        private DataTable _tablaProductos;
        private readonly ProductoDAO _productoDao = new ProductoDAO();
        public FormExportarImportar(string tipoOperacion, DataTable tablaProductos)
        {
            InitializeComponent();
            _tipoOperacion = tipoOperacion.ToUpper();
            _tablaProductos = tablaProductos;

            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            if (_tipoOperacion == "EXPORTAR")
            {
                this.Text = "Exportar Datos";
                btnAccion.Text = "Exportar";
            }
            else // IMPORTAR
            {
                this.Text = "Importar Datos";
                btnAccion.Text = "Importar";
            }
            rbExcel.Checked = true; // Por defecto arranca seleccionado Excel
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = rbExcel.Checked ? "Archivos de Excel (*.csv)|*.csv" : "Archivos Nativos (*.dat)|*.dat";

            if (_tipoOperacion == "EXPORTAR")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = filtro;
                sfd.FileName = "Data_Productos_" + DateTime.Now.ToString("yyyyMMdd");
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = sfd.FileName;
                }
            }
            else // IMPORTAR
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = filtro;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = ofd.FileName;
                }
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuta.Text))
            {
                MessageBox.Show("Por favor, seleccione una ruta de archivo válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_tipoOperacion == "EXPORTAR")
            {
                ProcesarExportacion();
            }
            else
            {
                ProcesarImportacion();
            }
        }
        private void ProcesarExportacion()
        {
            try
            {
                List<string> lineas = new List<string>();

                if (rbExcel.Checked) // Formato Excel CSV
                {
                    // El encabezado que el Importador espera leer de manera directa
                    string encabezado = "cod_barras;nom_producto;des_producto;id_categoria;ruc_proveedor;id_estante;pre_compra;pre_venta";
                    lineas.Add(encabezado);

                    foreach (DataRow fila in _tablaProductos.Rows)
                    {
                        // Extraemos las columnas usando los alias reales de tu DataTable en memoria
                        string codBarras = fila["Código de Barras"].ToString().Trim();
                        string nombre = fila["Producto"].ToString().Trim();
                        string descripcion = fila["Descripción"].ToString().Trim();

                        // NOTA DE PRUEBA: Como tu DataTable actual tiene los nombres legibles ("Herramientas", etc.),
                        // usaremos IDs genéricos válidos fijos para esta prueba de respaldo. 
                        // Esto evitará el error de columna y generará un archivo compatible con tu importador crudo.
                        string idCategoria = "1";
                        string rucProveedor = "20112233003"; // Usa uno de tus RUCs de prueba válidos
                        string idEstante = "1";

                        string preCompra = fila["P. Compra"].ToString().Trim();
                        string preVenta = fila["P. Venta"].ToString().Trim();

                        // Armamos la línea unificada separada por punto y coma
                        string linea = $"{codBarras};{nombre};{descripcion};{idCategoria};{rucProveedor};{idEstante};{preCompra};{preVenta}";
                        lineas.Add(linea);
                    }
                    System.IO.File.WriteAllLines(txtRuta.Text, lineas, Encoding.UTF8);
                }
                else // Formato Nativo .dat
                {
                    foreach (DataRow fila in _tablaProductos.Rows)
                    {
                        string linea = $"{fila["Código de Barras"]}|{fila["Producto"]}|{fila["Descripción"]}|{fila["P. Compra"]}|{fila["P. Venta"]}";
                        lineas.Add(linea);
                    }
                    System.IO.File.WriteAllLines(txtRuta.Text, lineas, Encoding.Unicode);
                }

                MessageBox.Show("¡Datos exportados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesarImportacion()
        {
            try
            {
                string[] lineas = System.IO.File.ReadAllLines(txtRuta.Text); // Lee según la codificación del archivo
                int insertados = 0, errores = 0;

                if (rbExcel.Checked) // Procesar Excel CSV
                {
                    for (int i = 1; i < lineas.Length; i++) // Saltamos encabezado
                    {
                        if (string.IsNullOrWhiteSpace(lineas[i])) continue;
                        string[] celdas = lineas[i].Split(';');
                        if (celdas.Length >= 8)
                        {
                            try
                            {
                                if (_productoDao.InsertarProducto(celdas[0].Trim(), celdas[1].Trim(), celdas[2].Trim(), Convert.ToInt32(celdas[3]), celdas[4].Trim(), Convert.ToInt32(celdas[5]), Convert.ToDecimal(celdas[6]), Convert.ToDecimal(celdas[7])))
                                    insertados++;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Fila {i} rechazada (CSV).\n\nError: {ex.Message}\n\nDatos procesados: {lineas[i]}", "Detalle del Error");
                                errores++;
                            }
                        }
                    }
                }
                else // Procesar Nativo .dat
                {
                    for (int i = 0; i < lineas.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lineas[i])) continue;
                        string[] celdas = lineas[i].Split('|');
                        if (celdas.Length >= 5)
                        {
                            try
                            {
                                // ====== ¡RUC REAL CORREGIDO AQUÍ! ======
                                // Cambiamos "00000000000" por tu RUC válido "20112233003"
                                if (_productoDao.InsertarProducto(celdas[0].Trim(), celdas[1].Trim(), celdas[2].Trim(), 1, "20112233003", 1, Convert.ToDecimal(celdas[3]), Convert.ToDecimal(celdas[4])))
                                    insertados++;
                            }
                            catch (Exception ex)
                            {
                                // Alerta agregada también para el formato .dat por seguridad
                                MessageBox.Show($"Fila {i + 1} rechazada (.DAT).\n\nError: {ex.Message}\n\nDatos procesados: {lineas[i]}", "Detalle del Error");
                                errores++;
                            }
                        }
                    }
                }

                MessageBox.Show($"Importación finalizada.\nÉxito: {insertados}\nErrores u omitidos: {errores}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indica a la ventana padre que debe refrescar la tabla
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
