using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2.Forms
{
    public partial class PagosPorRealizar : System.Web.UI.Page
    {
        LibrosDAO Detail = new LibrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPagos();
            }
        }
        private void CargarPagos()
        {
            GridView1.DataSource = Detail.ConsultarPagosPendientes();
            GridView1.DataBind();
        }
    }
}