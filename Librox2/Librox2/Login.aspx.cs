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
        UsuarioBO ObUsuario = new UsuarioBO();
        Usuarios OB = new Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    Response.Redirect("/GUI/Index.aspx");
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
            if (txtusuario.Text.Length == 0 || txtpassword.Text.Length == 0)
            {
                Response.Write("<script>alert('" + "El Usuario o la Contraseña no Existen" + "');</script>");
            }
            else
            {
                ObUsuario.Usuario = txtusuario.Text;
                ObUsuario.Contraseña = txtpassword.Text;
                String[] substrings = OB.validarusuario(ObUsuario).Split('|');
                if (ObUsuario.Contraseña == substrings[0].ToString() && substrings[1].ToString()=="1")
                {
                    Session["Usuario"] = ObUsuario.Usuario;
                    Session["Contraseña"] = ObUsuario.Contraseña;
                    //Session["Imagen"] = ObUsuario.ConsultaImagenParamedico(on);
                    Response.Redirect("/GUI/IndexBack.aspx");
                    //Response.Write("<script>alert('" + "Bienvendo a nuestro Sistema" + "');</script>");
                }
                else
                {
                    if (ObUsuario.Contraseña == substrings[0].ToString() && substrings[1].ToString() == "0")
                    {
                        Response.Redirect("/GUI/Index.aspx");
                    }
                   // Response.Write("<script>alert('" + "El Usuario o la Contraseña no existen" + "');</script>");
                }
            }
        }
    }
}