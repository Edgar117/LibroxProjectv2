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
            //Sirve para mantener el menu abierto y que no se cierre cuando es class Treeview
            //String activepage = Request.RawUrl;
            //switch (activepage)
            //{
            //    case "/DBTestSite/Configure_Test.aspx":
            //        test.Attributes.Add("class", "treeview active menu-open");
            //        //ULTest.Attributes.Add("class", "sidebar-menu .active > .treeview-menu");
            //        EMPTY.Attributes.Add("class", "active");
            //        break;
            //    case "/DBTestSite/Configure_Scripts.aspx":
            //        test.Attributes.Add("class", "treeview active menu-open");
            //        Script.Attributes.Add("class", "active");
            //        break;
            //    case "/DBTestSite/Configure_Scripts_ftp.aspx":
            //        test.Attributes.Add("class", "treeview active menu-open");
            //        ScriptFTP.Attributes.Add("class", "active");
            //        break;
            //    case "/DBTestSite/Test_Sass_server.aspx":
            //        test.Attributes.Add("class", "treeview active menu-open");
            //        SassServer.Attributes.Add("class", "active");
            //        break;
            //    default:
            //        ULTest.Attributes.Add("class", "treeview-menu");
            //        break;
            //}
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