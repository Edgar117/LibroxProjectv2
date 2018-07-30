using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.Master
{
    public partial class MasterBack : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                nom.InnerText = Session["Usuario"].ToString();
                logo.Src = Session["Imagen"].ToString();
            }
            catch (Exception)
            {

                Response.Redirect("/Login.aspx");
            }
            
        }
    }
}