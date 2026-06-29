using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ServidorEscaneo
{
    private HttpListener listener;
    public event Action<string> OnCodigoRecibido;

    public void Iniciar(int puerto)
    {
        listener = new HttpListener();
        listener.Prefixes.Add($"http://*:{puerto}/");

        try
        {
            listener.Start();
            Task.Run(() => Escuchar());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al iniciar servidor: " + ex.Message);
        }
    }

    private void Escuchar()
    {
        while (listener.IsListening)
        {
            var context = listener.GetContext();

            // para que el celular no sea bloqueado
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST, OPTIONS");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.StatusCode = 200;
                context.Response.Close();
                continue;
            }

            // LEER DATOS
            string codigo = "";
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                codigo = reader.ReadToEnd();
            }

            // depuracion para ver si llega algo porque voy a entrar en locura r44423u4x3
            System.Diagnostics.Debug.WriteLine("Dato recibido del celular: " + codigo);

            if (!string.IsNullOrEmpty(codigo))
            {
                OnCodigoRecibido?.Invoke(codigo.Trim());
            }

            context.Response.StatusCode = 200;
            context.Response.Close();
        }
    }
}