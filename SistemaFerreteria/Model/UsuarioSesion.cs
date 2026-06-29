using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFerreteria.Model
{
    public static class UsuarioSesion
    {
        // Guardará el DNI del empleado que inició sesión (Ej: "12345678")
        public static string DniEmpleadoLogueado { get; set; } = "";
    }
}
