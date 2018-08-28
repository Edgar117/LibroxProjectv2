using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.BO
{
    public class LibrosBO
    {
        public string Titulo { get; set; }
        public string Sinpsis { get; set; }
        public string Autor_ID { get; set; }
        public string Precio { get; set; }
        public string ImagenPòrtada { get; set; }
        public int Ranking { get; set; }
        public string Categoria { get; set; }
    }
}