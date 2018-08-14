using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.GUI
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NameUser.InnerText = Session["Usuario"].ToString();
                String[] cart1 = new String[0];
                cart1 = (String[])Session["ALL"];
                Categoria.InnerText = cart1[4].ToString();
                about.InnerText = cart1[3].ToString();
                ImagenUsuario.Src = "/images/Users/" + cart1[2].ToString();
                Imagen.Src = "/images/Users/" + cart1[2].ToString();
            }
            catch (Exception EX)
            {

                Response.Redirect("../Login.aspx");
            }
            
        }
    }
}