using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Librox2.Propety;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class Callback : System.Web.UI.Page
    {
        Usuarios OB = new Usuarios();
        public const string FaceBookAppKey = "4e077046a35aad9e2155c32e7b11dc68";
        private char[] userInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["access_token"])) return; //ERROR! No token returned from Facebook!!

            //let's send an http-request to facebook using the token            
            string json = GetFacebookUserJSON(Request.QueryString["access_token"]);
            //and Deserialize the JSON response
            JavaScriptSerializer js = new JavaScriptSerializer();
            FacebookUser oUser = js.Deserialize<FacebookUser>(json);
            if (oUser != null)
            {
             int Validar= OB.SaveUserFB(oUser);
                if (Validar==0)
                {
                    Response.Redirect("/GUI/Index.aspx");
                }
                else
                {

                }
            }

        }
        private static string GetFacebookUserJSON(string access_token)
        {
            string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link,birthday,cover,devices,gender", access_token);

            WebClient wc = new WebClient();
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }

    }
 }