using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.Master
{
    public partial class MasterPro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Panel"].ToString() == "Logeado")
            {
                panelLogeado.Visible = true;
                PanelNormal.Visible = false;
            }
            else
            {
                panelLogeado.Visible = false;
                PanelNormal.Visible = true;
            }
            //Aqui hay que agrgar la logica para que cuando se entre a la pagina de perfil se ponga la correcta
            String activepage = Request.RawUrl;
            switch (activepage)
            {
                case "/GUI/Perfil.aspx":
                    CSSBody.Attributes.Add("class", "profile-page sidebar-collapse");
                    //ULTest.Attributes.Add("class", "sidebar-menu .active > .treeview-menu");
                    //EMPTY.Attributes.Add("class", "active");
                    break;
                //case "/DBTestSite/Configure_Scripts.aspx":
                //    test.Attributes.Add("class", "treeview active menu-open");
                //    Script.Attributes.Add("class", "active");
                //    break;
                //case "/DBTestSite/Configure_Scripts_ftp.aspx":
                //    test.Attributes.Add("class", "treeview active menu-open");
                //    ScriptFTP.Attributes.Add("class", "active");
                //    break;
                //case "/DBTestSite/Test_Sass_server.aspx":
                //    test.Attributes.Add("class", "treeview active menu-open");
                //    SassServer.Attributes.Add("class", "active");
                //    break;
                default:
                   // ULTest.Attributes.Add("class", "treeview-menu");
                    break;
            }
            //try
            //{
            //    if (Session["User"].ToString() == "Admin")
            //    {
            //        Session["User"] = "Admin";
            //        Session["datos"] = true;
            //    }
            //    else
            //    {
            //        Session["User"] = "Defualt User";
            //        Session["datos"] = true;
            //        masteradmin.Visible = false;
            //        Admin.Visible = false;
            //    }
            //    nom.InnerText = Session["User"].ToString();
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("Index.aspx");
            //}

            //if (true)
            //{
            //    

            //}
        }
    }
}