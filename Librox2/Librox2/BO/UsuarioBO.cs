using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.BO
{
    public class UsuarioBO
    {
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Cumpleaños { get; set; }
        public string Nombre { get; set; }
        public int TipoUsuario { get; set; }
    }
}