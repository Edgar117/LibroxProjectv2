using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Librox2.DAO;
using Librox2.BO;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Data;

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
        public void ValidUser(string US1, string PASS)
        {
            UsuariosDAO US = new UsuariosDAO();
            UserBoWebService OBJson = new UserBoWebService
            { ID = int.Parse(US.validarusuarioApp(US1, PASS)) };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetInformationUser(string UserId)
        {
            UsuariosDAO US = new UsuariosDAO();
            DataTable dtuser = new DataTable();
            dtuser = US.GetInformationUserApp(UserId);
            UserGetApp OBJson = new UserGetApp
            { categoria= dtuser.Rows[0]["Categoria"].ToString(),Descripcion= dtuser.Rows[0]["DescriptionUser"].ToString(),Seguidores= dtuser.Rows[0]["SEGUIDORES"].ToString(),ImagenUsuario= dtuser.Rows[0]["ImagenUsuario"].ToString(),TotalLibros= dtuser.Rows[0]["TotalLibros"].ToString(),UserName= dtuser.Rows[0]["Usuario"].ToString() };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));

        }
    }
}
