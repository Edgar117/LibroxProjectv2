using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.Forms
{
    public partial class Verificador : System.Web.UI.Page
    {
        public class paypal
        {
            public string status { get; set; }
            public string id { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //No funcionó esto :´v hay que seguir investigando
            //this.Label1.Text = Request.QueryString["estatus"];
            object details = Request.QueryString["details"];
            System.Collections.Generic.Dictionary<String, Object[]> Collection;
            Collection = details as System.Collections.Generic.Dictionary<String, Object[]>;
            //string status = Collection["status"] as String;
            //this.Label1.Text = status;
        }
    }
}