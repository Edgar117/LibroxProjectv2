using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;

namespace Librox2.GUI
{
    public partial class Libros : System.Web.UI.Page
    {
        LibrosDAO DAOLibros = new LibrosDAO();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLibros();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
        private void LoadLibros()
        {
            dt=DAOLibros.ConsultarLibros();
        }
    }
}