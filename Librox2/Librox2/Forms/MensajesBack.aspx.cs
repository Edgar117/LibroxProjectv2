using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {
                case "btneliminar":
                    int indexEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GridView1.Rows[indexEliminar];
                    string ID = Server.HtmlDecode(rowEliminar.Cells[0].Text);
                    if (ID == "")
                    {

                    }
                    else
                    {
                        if (OMensajes.DeleteMensaje(ID) == 1)
                        {
                            LoadMensajes();
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
                        }
                    }
                    break;
                default:break;
            }
        }
    }
}