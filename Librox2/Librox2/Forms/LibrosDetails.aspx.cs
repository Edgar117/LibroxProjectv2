using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;
using Librox2.BO;

namespace Librox2.Forms
{
    public partial class LibrosDetails : System.Web.UI.Page
    {
        LibrosDAO DAOLibros = new LibrosDAO();
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LibroDetalle"]!= null)
                {
                    System.Collections.Hashtable ht = new System.Collections.Hashtable();
                    ht = (System.Collections.Hashtable)Session["LibroDetalle"];
                    string titulo = Convert.ToString(ht["Titulo"]);
                    string categoria = Convert.ToString(ht["Categoria"]);
                    string precio = Convert.ToString(ht["Precio"]);
                    string autor = Convert.ToString(ht["Autor"]);
                    string sinopsis = Convert.ToString(ht["Sinopsis"]);
                    string imgPath = Convert.ToString(ht["ImagenPortada"]);
                    //string strDesignation = ht.ContainsKey("Precio") ? Convert.ToString(ht["Precio"]) : "";

                    lblTitulo.Text = titulo;
                    imgPortada.ImageUrl = imgPath;
                    //lblPrecio.Text = strDesignation;
                }
            }
        }
    }
}