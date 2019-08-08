using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.BO
{
    public class LibroDetalleBO
    {
        public string IDLibro { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Autor { get; set; }
        public int PRECIO { get; set; }
        public string LibroPortada { get; set; }
        public int Ranking { get; set; }
        public string Categoria { get; set; }
        public string NombreEstatus { get; set; }
        public string FotoAutor { get; set; }
        //public string LibroFisico { get; set; }
        public string TotalPaginas { get; set; }

    }
}