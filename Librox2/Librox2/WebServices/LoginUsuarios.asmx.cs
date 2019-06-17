using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Librox2.DAO;
using Librox2.BO;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
namespace Librox2.WebServices
{
    /// <summary>
    /// Descripción breve de LoginUsuarios
    /// </summary>
    [WebService(Namespace = "https://www.escribox.com/WebServices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginUsuarios : System.Web.Services.WebService
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ValidUser(string US1, string PASS)
        {
            UsuariosDAO US = new UsuariosDAO();
            UserBoWebService OBJson = new UserBoWebService
            { ID = int.Parse(US.validarusuarioApp(US1, PASS)) };
           // string outputJSON = ser.Serialize(OBJson);
            //return outputJSON;
             return  new ser.Serialize(OBJson);
            
        }
    }
}
