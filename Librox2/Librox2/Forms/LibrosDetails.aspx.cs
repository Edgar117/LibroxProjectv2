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
                    string strEmployeeName = Convert.ToString(ht["Titulo"]);
                    //string strDesignation = ht.ContainsKey("Precio") ? Convert.ToString(ht["Precio"]) : "";

                    lblTitulo.Text = strEmployeeName;
                    //lblPrecio.Text = strDesignation;
                }
            }
        }
    }
}