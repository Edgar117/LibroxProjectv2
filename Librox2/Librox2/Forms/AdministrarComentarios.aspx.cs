using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using Librox2.BO;
namespace Librox2.Forms
{
    public partial class AdministrarComentarios : System.Web.UI.Page
    {
        LibrosDAO DetailComent = new LibrosDAO();
        ComentariosBO Comen = new ComentariosBO();
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
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {
                case "btneliminar":
                    int indexEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GVComentarios.Rows[indexEliminar];
                    string ID = Server.HtmlDecode(rowEliminar.Cells[1].Text);
                    if (ID == "")
                    {

                    }
                    else
                    {
                        Comen.IDComentario = int.Parse(ID);
                        if (DetailComent.EliminarComentariosAdmin(Comen) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "BorrarComentarios();", true);
                            CargarGrid();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}