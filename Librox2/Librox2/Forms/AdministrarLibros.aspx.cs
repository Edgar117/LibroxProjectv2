using Librox2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.Forms
{
    public partial class AdministrarLibros : System.Web.UI.Page
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
            GVLibros.DataSource = DetailComent.ConsultarLibrosAdmin();
            GVLibros.DataBind();
        }

        protected void GVLibros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {
                case "btneliminar":
                    int indexEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GVLibros.Rows[indexEliminar];
                    string ID = Server.HtmlDecode(rowEliminar.Cells[1].Text);
                    if (ID == "")
                    {

                    }
                    else
                    {
                        int ID_LI= int.Parse(ID);
                        if (DetailComent.EliminarComentariosAdmin(ID_LI) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "EliminarLibroAdmin();", true);
                            CargarGrid();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        protected void GVLibros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVLibros.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
    }
}