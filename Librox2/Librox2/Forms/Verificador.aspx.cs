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
            //Recivimos el json, verificar si mandamos mas datos.
            string json = Request.QueryString["details"];
            //Instancia al using para deserealizar json
            JavaScriptSerializer js = new JavaScriptSerializer();
            //Instancia de la clase paypal
            paypal oUser = js.Deserialize<paypal>(json);
            //Logica para convertir a Byte lo que recivimos de la base 64
            byte[] data = System.Convert.FromBase64String(oUser.status);
            //Lo volvemos al lenguaje español
            oUser.status = System.Text.ASCIIEncoding.ASCII.GetString(data);
            //Se aplica lo mismo
            data = System.Convert.FromBase64String(oUser.id);
            oUser.id = System.Text.ASCIIEncoding.ASCII.GetString(data);
            //Listo ya funciona

        }
    }
}