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
        public string LibroFisico { get; set; }
        public int ID_LIBRO { get; set; }
        public int EstatusLibro { get; set; }
        public bool Action { get; set; }
    }
}