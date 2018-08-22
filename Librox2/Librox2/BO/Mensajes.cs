using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.BO
{
    public class Mensajes
    {
      public int IDMensaje {get;set;}
        public string Mensaje { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}