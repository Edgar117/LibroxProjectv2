using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.BO;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class Categorias : System.Web.UI.Page
    {
        CategoriasBO OBCategorias = new CategoriasBO();
        CategoriaDAO OBCategoriasDao = new CategoriaDAO();
        int CategoriaStatus = 0;
            protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Codigo Insertar Categoria
            OBCategorias.NombreCategoria = txtCategorias.Text;
            OBCategorias.Status = CategoriaStatus;
            if (OBCategoriasDao.SaveUserRegister)
            {

            }
        }
    }
}