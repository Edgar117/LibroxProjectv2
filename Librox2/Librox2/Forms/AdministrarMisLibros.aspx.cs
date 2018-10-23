using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;

namespace Librox2.Forms
{
 
    public partial class AdministrarMisLibros : System.Web.UI.Page
    {
        int ID = 0;
        DataTable dt = new DataTable();
        String[] cart1 = new String[0];
        UsuariosDAO DAOLibros = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cart1 = (String[])Session["ALL"];
                    ID = int.Parse(cart1[5]);
                    //Aqui recuperamos el dt
                    // dt = DAOLibros.ConsultarMisLibrosToEdit(ID);
                    GridView1.DataSource = DAOLibros.ConsultarMisLibrosToEdit(ID);
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {

                    Response.Redirect("../Login.aspx");
                }
               
            }
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}