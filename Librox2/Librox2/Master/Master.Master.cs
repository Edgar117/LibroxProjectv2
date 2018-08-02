using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.Master
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Panel"].ToString() == "Logeado")
            {
                navbarSupportedContent.Visible = false;
                testloco.Visible = true;
            }
        }
    }
}