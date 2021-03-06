﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Librox2.Propety;
using Librox2.BO;
using Librox2.DAO;
namespace Librox2
{
    public partial class Login : System.Web.UI.Page
    {
        Security OBSecurity = new Security();
        UsuarioBO ObUsuario = new UsuarioBO();
        UsuariosDAO OB = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            //// check is secure connection used
            //if (!Request.IsSecureConnection)
            //{
            //    // redirect visitor to SSL connection
            //    Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
            //}

            ////string urll = HttpContext.Current.Request.RawUrl;
            ////string host = Request.ServerVariables["HTTP_HOST"];
            //Response.Redirect("https://www.escribox.com");
            Session["Panel"] = "";
            Session["Usuario"]=null;
            Session["Contraseña"] = "";
            Session["Imagen"] = "";
            Session["ALL"] = null;
            Session["LibroFisico"] = null;
            Session["FaceLogin"] = null;
            if (string.IsNullOrEmpty(Request.QueryString["access_token"])) return; //ERROR! No token returned from Facebook!!

            //let's send an http-request to facebook using the token            
            string json = GetFacebookUserJSON(Request.QueryString["access_token"]);

            //and Deserialize the JSON response
            System.Web.Script.Serialization.JavaScriptSerializer js = new JavaScriptSerializer();
            FacebookUser oUser = js.Deserialize<FacebookUser>(json);
            if (oUser != null)
            {
                int Validar = OB.SaveUserFB(oUser);
                if (Validar == 0)
                {
                    string test =oUser.picture;
                    Response.Redirect("/Forms/Home.aspx");
                }
                else
                {

                }
            }

        }
        private static string GetFacebookUserJSON(string access_token)
        {
            string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link", access_token);

            WebClient wc = new WebClient();
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusuario.Text.Length == 0 || txtpassword.Text.Length == 0)
                {
                    Response.Write("<script>alert('" + "El Usuario o la Contraseña no Existen" + "');</script>");
                }
                else
                {
                    ObUsuario.Usuario = txtusuario.Text;
                    ObUsuario.Contraseña = txtpassword.Text;
                    String[] substrings = OB.validarusuario(ObUsuario).Split('|');
                    //Usuario Administrador
                    if (ObUsuario.Contraseña == OBSecurity.desencrypt(substrings[0].ToString()) && substrings[1].ToString() == "1")
                    {
                        Session["Usuario"] = ObUsuario.Usuario;
                        Session["Contraseña"] = ObUsuario.Contraseña;
                        Session["Imagen"] = "~/images/" + substrings[2].ToString() + ".png";
                        //Session["Imagen"] = ObUsuario.ConsultaImagenParamedico(on);
                        Session["ALL"] = substrings;
                        Response.Redirect("/Forms/IndexBack.aspx");
                        //Response.Write("<script>alert('" + "Bienvendo a nuestro Sistema" + "');</script>");
                    }
                    else
                    {
                        //Usuario Normal 
                        if (ObUsuario.Contraseña == OBSecurity.desencrypt(substrings[0].ToString()) && substrings[1].ToString() == "0")
                        {
                            Session["Usuario"] = ObUsuario.Usuario;
                            Session["Panel"] = "Logeado";
                            Session["ALL"] = substrings;
                            Response.Redirect("/libros");

                        }
                        // Response.Write("<script>alert('" + "El Usuario o la Contraseña no existen" + "');</script>");
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('" + "Error de conexión, intenta de nuevo" + "');</script>");
                throw;
            }
        }
    }
}