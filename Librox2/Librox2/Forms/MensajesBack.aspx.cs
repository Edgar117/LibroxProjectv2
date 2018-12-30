using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class MensajesBack : System.Web.UI.Page
    {
        MensajesDAO OMensajes = new MensajesDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMensajes();
            }
        }
        public void LoadMensajes()
        {
            GridView1.DataSource = OMensajes.ConsultarCategorias();
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadMensajes();
        }
    }
}