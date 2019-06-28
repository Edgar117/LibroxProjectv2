using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Librox2.DAO;
using Librox2.BO;
using System.Data;

namespace Librox2.WebServices
{
    /// <summary>
    /// Descripción breve de ApiService
    /// </summary>
    [WebService(Namespace = "https://www.escribox.com/WebServices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ApiService : System.Web.Services.WebService
    {

        JavaScriptSerializer ser = new JavaScriptSerializer();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertUserApi(string Nombre,string User,string Email,string FechaNaci,string Pass,string DescriptionUser)
        {
            UsuarioBO ObUsuario = new UsuarioBO();
            UsuariosDAO Register = new UsuariosDAO();
            Security OBSecurity = new Security();
            string contraseña = "";
            contraseña = OBSecurity.encrypt(Pass);
            ObUsuario.Contraseña = contraseña;
            //ObUsuario.Cumpleaños = "";
            ObUsuario.Correo =Email;
            ObUsuario.Nombre = Nombre;
            ObUsuario.Usuario = User;
            int TU = 0;
            TU = ObUsuario.TipoUsuario;
            ObUsuario.DescriptionUser =DescriptionUser;
            ObUsuario.Cumpleaños = FechaNaci;
            //string Result =Register.SaveUserRegister(ObUsuario).ToString();
            JsonResult OBJson = new JsonResult
            { Result = Register.SaveUserRegister(ObUsuario) };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetAllBooks()
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarLibrosApp();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }

        //string test2 = test;
    }
}
