using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Librox2
{
    public class Global : System.Web.HttpApplication
    {
        void rutasAmigables()
        {
           // RouteTable.Routes.MapPageRoute("Inicio", "categoria/{idCategoria}", "~/GUI/IndexMaybe.aspx");
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            //rutasAmigables();test
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}