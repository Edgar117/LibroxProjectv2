using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2.Forms
{
    public partial class AdministrarComentarios : System.Web.UI.Page
    {
        LibrosDAO DetailComent = new LibrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }
        private void CargarGrid()
        {
            GVComentarios.DataSource = DetailComent.ConsultaComentariosLibrosAdmin();
            GVComentarios.DataBind();
        }
        protected void GVComentarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}