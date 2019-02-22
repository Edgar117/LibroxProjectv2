using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class IndexBack : System.Web.UI.Page
    {
        LibrosDAO Contar = new LibrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContarLibros();
                ContarUsuarios();
            }
        }
        public void ContarLibros()
        {
            Libros.InnerText = Contar.CONTARLIBROS().ToString();
        }
        public void ContarUsuarios()
        {
            Usuarios.InnerText = Contar.ContarUsuarios().ToString();
            VentasLibros.InnerText = Contar.ContarVentas().ToString();
        }
    }
}