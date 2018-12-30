using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.BO
{
    public class ComentariosBO
    {
     public   string Usuario { get; set; }
      public  string Comentarios { get; set; }
      public  DateTime HoraComentario { get; set; }
        public string Libro { get; set; }
        public int IDComentario { get; set; }

    }
}