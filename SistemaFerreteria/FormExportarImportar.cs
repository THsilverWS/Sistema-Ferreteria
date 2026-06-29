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
        private string _tipoMantenimiento; // "CATEGORIA", "METODO_PAGO", "ESTANTE" o "PRODUCTO"
        private DataTable _tablaDatos; // Datos actuales cargados en la grilla del padre
        
        // DAOs para procesar según corresponda
        private readonly MantenimientoComunDAO _comunDao = new MantenimientoComunDAO();
        private readonly ProductoDAO _productoDao = new ProductoDAO();
        public FormExportarImportar(string tipoOperacion, string tipoMantenimiento, DataTable tablaDatos)
        {
            InitializeComponent();
            _tipoOperacion = tipoOperacion.ToUpper();
            _tipoMantenimiento = tipoMantenimiento.ToUpper();
            _tablaDatos = tablaDatos; // Recibe la grilla actual 

            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            if (_tipoOperacion == "EXPORTAR")
            {
                this.Text = "Exportar Datos - " + _tipoMantenimiento;
                btnAccion.Text = "Exportar";
            }
            else 
            {
                this.Text = "Importar Datos - " + _tipoMantenimiento;
                btnAccion.Text = "Importar";
                rbExcel.Checked = true; // Por defecto arranca seleccionado Excel
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = rbExcel.Checked ? "Archivos de Excel (*.csv)|*.csv" : "Archivos Nativos (*.dat)|*.dat";  

            if (_tipoOperacion == "EXPORTAR")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = filtro;
                sfd.FileName = $"Data_{_tipoMantenimiento}_" + DateTime.Now.ToString("yyyyMMdd");  
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
                ProcesarExportacion();
            else
                ProcesarImportacion();
        }
        private void ProcesarExportacion()
        {
            try
            {
                List<string> lineas = new List<string>();  

                // ==========================================
                // CASO ESPECIAL: VIENE DESDE MANTENEDOR COMÚN
                // ==========================================
                if (_tipoMantenimiento != "PRODUCTO")
                {
                    if (rbExcel.Checked) // CSV
                    {
                        lineas.Add("ID;Nombre_Ubicacion");
                        foreach (DataRow fila in _tablaDatos.Rows)
                        {
                            lineas.Add($"{fila["ID"]};{fila["Nombre"]}");
                        }
                        System.IO.File.WriteAllLines(txtRuta.Text, lineas, Encoding.UTF8);
                    }
                    else // .DAT
                    {
                        foreach (DataRow fila in _tablaDatos.Rows)
                        {
                            lineas.Add($"{fila["ID"]}|{fila["Nombre"]}");
                        }
                        System.IO.File.WriteAllLines(txtRuta.Text, lineas, Encoding.Unicode);
                    }
                }
                // ==========================================
                // CASO ORIGINAL: VIENE DESDE TU TABLA PRODUCTOS
                // ==========================================
                else
                {
                    if (rbExcel.Checked)  
                    {
                        string encabezado = "cod_barras;nom_producto;des_producto;id_categoria;ruc_proveedor;id_estante;pre_compra;pre_venta";  
                        lineas.Add(encabezado);  

                        foreach (DataRow fila in _tablaDatos.Rows)  
                        {
                            string linea = $"{fila["Código de Barras"]};{fila["Producto"]};{fila["Descripción"]};1;20112233003;1;{fila["P. Compra"]};{fila["P. Venta"]}";  
                            lineas.Add(linea);  
                        }
                        System.IO.File.WriteAllLines(txtRuta.Text, lineas, Encoding.UTF8);  
                    }
                    else  
                    {
                        foreach (DataRow fila in _tablaDatos.Rows)  
                        {
                            string linea = $"{fila["Código de Barras"]}|{fila["Producto"]}|{fila["Descripción"]}|{fila["P. Compra"]}|{fila["P. Venta"]}";  
                            lineas.Add(linea);  
                        }
                        System.IO.File.WriteAllLines(txtRuta.Text, lineas, Encoding.Unicode);  
                    }
                }

                MessageBox.Show("¡Datos exportados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                this.Close();  
            }
            catch (Exception ex) { MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ProcesarImportacion()
        {
            try
            {
                string[] lineas = System.IO.File.ReadAllLines(txtRuta.Text);  
                int insertados = 0, errores = 0;  

                // ==========================================
                // IMPORTACIÓN PARA CATEGORIAS/ESTANTES/PAGOS
                // ==========================================
                if (_tipoMantenimiento != "PRODUCTO")
                {
                    char separador = rbExcel.Checked ? ';' : '|';
                    int inicioLinea = rbExcel.Checked ? 1 : 0; // Se salta cabecera en Excel

                    for (int i = inicioLinea; i < lineas.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lineas[i])) continue;
                        string[] celdas = lineas[i].Split(separador);

                        if (celdas.Length >= 2)
                        {
                            if (_comunDao.Insertar(_tipoMantenimiento, celdas[1].Trim()))
                                insertados++;
                            else
                                errores++;
                        }
                    }
                }
                // ==========================================
                // IMPORTACIÓN ORIGINAL PARA TU TABLA PRODUCTOS
                // ==========================================
                else
                {
                    if (rbExcel.Checked)  
                    {
                        for (int i = 1; i < lineas.Length; i++)  
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
                                catch { errores++; }
                                 
                            }
                        }
                    }
                    else  
                    {
                        for (int i = 0; i < lineas.Length; i++)  
                        {
                            if (string.IsNullOrWhiteSpace(lineas[i])) continue;  
                            string[] celdas = lineas[i].Split('|');  
                            if (celdas.Length >= 5)  
                            {
                                try
                                {
                                    if (_productoDao.InsertarProducto(celdas[0].Trim(), celdas[1].Trim(), celdas[2].Trim(), 1, "20112233003", 1, Convert.ToDecimal(celdas[3]), Convert.ToDecimal(celdas[4])))  
                                        insertados++;  
                                }
                                catch { errores++; }
                                 
                            }
                        }
                    }
                }

                MessageBox.Show($"Importación finalizada.\nÉxito: {insertados}\nErrores u omitidos: {errores}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                this.DialogResult = DialogResult.OK;  
                this.Close();  
            }
            catch (Exception ex) { MessageBox.Show("Error al importar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
             
        }
    }
    
}
