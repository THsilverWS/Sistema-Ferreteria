using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using SistemaFerreteria.Model;

namespace SistemaFerreteria
{
    public partial class FormVentas : Form
    {
        private readonly Conexion conexionBase = new Conexion();
        private string dniEmpleadoLogueado;
        private DataTable carrito;

        public FormVentas(string dniEmpleado)
        {
            InitializeComponent();
            this.dniEmpleadoLogueado = string.IsNullOrEmpty(dniEmpleado) ? UsuarioSesion.DniEmpleadoLogueado : dniEmpleado;
            ConfigurarCarrito();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarHistorialPedidos();
            CargarTiposVenta();
            CargarMetodosPago();
        }

        private void ConfigurarCarrito()
        {
            carrito = new DataTable();
            carrito.Columns.Add("id_producto", typeof(int));
            carrito.Columns.Add("Código");
            carrito.Columns.Add("Producto");
            carrito.Columns.Add("Cantidad", typeof(int));
            carrito.Columns.Add("Precio", typeof(decimal));
            carrito.Columns.Add("Subtotal", typeof(decimal), "Cantidad * Precio");

            dgvCarrito.DataSource = carrito;

            if (dgvCarrito.Columns["id_producto"] != null)
            {
                dgvCarrito.Columns["id_producto"].Visible = false;
            }
        }

        private void ProcesarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;

            string query = "SELECT id_producto, nom_producto, pre_venta FROM Productos WHERE cod_barras = @cod";

            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add("@cod", SqlDbType.VarChar, 50).Value = codigo;
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idProd = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            decimal precio = reader.GetDecimal(2);
                            int cant = (int)nmCantidad.Value;

                            carrito.Rows.Add(idProd, codigo, nombre, cant, precio);
                            CalcularTotalVenta();

                            txtCodBarras.Clear();
                            nmCantidad.Value = 1;
                            txtCodBarras.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Código no encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProcesarCodigo(txtCodBarras.Text.Trim());
        }

        private void CalcularTotalVenta()
        {
            decimal total = 0;
            foreach (DataRow fila in carrito.Rows)
            {
                total += Convert.ToDecimal(fila["Subtotal"]);
            }
            lblTotal.Text = $"Total: S/. {total:N2}";
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (carrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDniCliente.Text) || string.IsNullOrWhiteSpace(txtNomCliente.Text))
            {
                MessageBox.Show("Debe ingresar obligatoriamente el DNI/RUC y el Nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dni = txtDniCliente.Text.Trim();
            string nombre = txtNomCliente.Text.Trim();
            string telephone = string.IsNullOrWhiteSpace(txtTelCliente.Text) ? "Sin Teléfono" : txtTelCliente.Text.Trim();
            string direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? "Dirección no especificada" : txtDireccion.Text.Trim();

            decimal totalVenta = 0;
            foreach (DataRow fila in carrito.Rows) totalVenta += Convert.ToDecimal(fila["Subtotal"]);

            // 🌟 Ajustado con conexionBase
            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    // =========================================================================
                    // 🌟 AQUÍ FIRMAMOS LA CONEXIÓN PARA LOS TRIGGERS ANTES DE EMPEZAR LA TRANSACCIÓN
                    // =========================================================================
                    conexionBase.AsignarContextoSeguridad(conexion);

                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        string queryCheckCliente = "SELECT COUNT(1) FROM Clientes WHERE dni_ruc_cliente = @dni";
                        int existeCliente = 0;
                        using (SqlCommand cmdCheck = new SqlCommand(queryCheckCliente, conexion, transaccion))
                        {
                            cmdCheck.Parameters.Add("@dni", SqlDbType.VarChar, 11).Value = dni;
                            existeCliente = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        }

                        if (existeCliente == 0)
                        {
                            string queryInsertCliente = "INSERT INTO Clientes (dni_ruc_cliente, nom_cliente, tel_cliente) VALUES (@dni, @nom, @tel)";
                            using (SqlCommand cmdInsCliente = new SqlCommand(queryInsertCliente, conexion, transaccion))
                            {
                                cmdInsCliente.Parameters.Add("@dni", SqlDbType.VarChar, 11).Value = dni;
                                cmdInsCliente.Parameters.Add("@nom", SqlDbType.VarChar, 100).Value = nombre;
                                cmdInsCliente.Parameters.Add("@tel", SqlDbType.VarChar, 15).Value = telephone;
                                cmdInsCliente.ExecuteNonQuery();
                            }
                        }

                        int idMetodoSeleccionado = Convert.ToInt32(cmbMetodoPago.SelectedValue);
                        string tipoVentaSeleccionado = cmbTipoVenta.SelectedItem.ToString();
                        string estadoInicial = (tipoVentaSeleccionado == "Factura") ? "Pendiente" : "Entregado";

                        string queryVenta = @"INSERT INTO Ventas (fec_venta, dni_empleado, id_cliente, id_metodo, tot_venta, estado_venta, tipo_venta) 
                                              VALUES (GETDATE(), @dniVend, @idCli, @metodo, @tot, @estado, @tipo); 
                                              SELECT SCOPE_IDENTITY();";

                        int idVentaGenerado;
                        using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion))
                        {
                            cmdVenta.Parameters.Add("@dniVend", SqlDbType.VarChar, 8).Value = dniEmpleadoLogueado;
                            cmdVenta.Parameters.Add("@idCli", SqlDbType.VarChar, 11).Value = dni;
                            cmdVenta.Parameters.Add("@metodo", SqlDbType.Int).Value = idMetodoSeleccionado;
                            cmdVenta.Parameters.Add("@tot", SqlDbType.Decimal).Value = totalVenta;
                            cmdVenta.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estadoInicial;
                            cmdVenta.Parameters.Add("@tipo", SqlDbType.VarChar, 20).Value = tipoVentaSeleccionado;

                            idVentaGenerado = Convert.ToInt32(cmdVenta.ExecuteScalar());
                        }

                        foreach (DataRow fila in carrito.Rows)
                        {
                            string queryDetalle = @"INSERT INTO DetalleVentas (id_venta, id_producto, cant_detalle, pre_compra_historico, pre_unitario_venta, dir_cliente_venta) 
                                                    VALUES (@idVenta, @idProd, @cant, (SELECT COALESCE(pre_compra, 0.00) FROM Productos WHERE id_producto = @idProd), @precio, @dir);";

                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDetalle.Parameters.Add("@idVenta", SqlDbType.Int).Value = idVentaGenerado;
                                cmdDetalle.Parameters.Add("@idProd", SqlDbType.Int).Value = fila["id_producto"];
                                cmdDetalle.Parameters.Add("@cant", SqlDbType.Int).Value = fila["Cantidad"];
                                cmdDetalle.Parameters.Add("@precio", SqlDbType.Decimal).Value = fila["Precio"];
                                cmdDetalle.Parameters.Add("@dir", SqlDbType.VarChar, 200).Value = direccion;

                                cmdDetalle.ExecuteNonQuery();
                            }

                            // 🌟 CORREGIDO: Eliminado 'id_almacen = 1' ya que la tabla de Inventario ahora es global por producto
                            string queryStock = "UPDATE Inventario SET stock_actual = stock_actual - @cant WHERE id_producto = @idProd AND stock_actual >= @cant";
                            using (SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaccion))
                            {
                                cmdStock.Parameters.Add("@cant", SqlDbType.Int).Value = fila["Cantidad"];
                                cmdStock.Parameters.Add("@idProd", SqlDbType.Int).Value = fila["id_producto"];

                                if (cmdStock.ExecuteNonQuery() == 0)
                                    throw new Exception($"Stock insuficiente para el producto ID: {fila["id_producto"]}");
                            }
                        }

                        transaccion.Commit();
                        MessageBox.Show($"Venta registrada con éxito bajo tipo [{tipoVentaSeleccionado}] con Estado inicial [{estadoInicial}].", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        carrito.Clear();
                        lblTotal.Text = "Total: S/. 0.00";
                        CargarHistorialPedidos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la transacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarHistorialPedidos()
        {
            string query = @"SELECT V.id_venta AS [Nro Boleta], V.fec_venta AS [Fecha/Hora], V.tipo_venta AS [Tipo], V.estado_venta AS [Estado], VD.nom_empleado AS [Empleado], C.nom_cliente AS [Cliente], V.tot_venta AS [Total Cobrado]
                             FROM Ventas V INNER JOIN Empleados VD ON V.dni_empleado = VD.dni_empleado INNER JOIN Clientes C ON V.id_cliente = C.dni_ruc_cliente";

            // 🌟 Ajustado con conexionBase
            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            using (SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion))
            {
                DataTable tabla = new DataTable();
                try { adaptador.Fill(tabla); dgvHistorial.DataSource = tabla; } catch { }
            }
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e) => CargarHistorialPedidos();

        private void CargarTiposVenta()
        {
            cmbTipoVenta.Items.Clear();
            cmbTipoVenta.Items.Add("Ticket");
            cmbTipoVenta.Items.Add("Factura");
            cmbTipoVenta.SelectedIndex = 0;
        }

        private void CargarMetodosPago()
        {
            string query = "SELECT id_metodo, nom_metodo FROM MetodosPago ORDER BY id_metodo";

            // 🌟 Ajustado con conexionBase
            using (SqlConnection conexion = conexionBase.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(lector);

                            cmbMetodoPago.DataSource = dt;
                            cmbMetodoPago.DisplayMember = "nom_metodo";
                            cmbMetodoPago.ValueMember = "id_metodo";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            // 🌟 Barcode to PC enviará la tecla Enter al finalizar la escritura del código
            if (e.KeyCode == Keys.Enter)
            {
                // Detiene el sonido "beep" por defecto de Windows al pulsar Enter
                e.SuppressKeyPress = true;

                string codigoEscaneado = txtCodBarras.Text.Trim();

                // Si el celular leyó con éxito, ejecutamos tu lógica de búsqueda e inserción
                if (!string.IsNullOrEmpty(codigoEscaneado))
                {
                    ProcesarCodigo(codigoEscaneado);
        }
            }
        }
    }
}