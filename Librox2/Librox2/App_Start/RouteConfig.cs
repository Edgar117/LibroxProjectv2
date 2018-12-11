using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Librox2.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("default", "", "~/Login.aspx");
            routes.MapPageRoute("home", "home", "~/Forms/IndexMaybe.aspx");
            routes.MapPageRoute("libros", "libros", "~/Forms/Libros.aspx");
            routes.MapPageRoute("newbook", "newbook", "~/Forms/AgregarLibro.aspx");
            routes.MapPageRoute("mybooks", "mybooks", "~/Forms/AdministrarMisLibros.aspx");
            routes.MapPageRoute("profile", "profile", "~/Forms/Perfil.aspx");
            routes.MapPageRoute("about", "about", "~/Forms/AcercaDe.aspx");
            routes.MapPageRoute("contact", "contact", "~/Forms/Contactanos.aspx");
            routes.MapPageRoute("register", "register", "~/Forms/RegistroUsuario.aspx");
            routes.MapPageRoute("privacy", "privacy", "~/Forms/TerminosyCondiciones.aspx");
        }
    }
}