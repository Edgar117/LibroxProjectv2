using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using Librox2.BO;
using System.IO;

namespace Librox2.GUI
{
    public partial class Perfil : System.Web.UI.Page
    {
        UsuarioBO OBUsuario = new UsuarioBO();
        Usuarios ActualizarDAO = new Usuarios();
        int ID = 0;
        String[] cart1 = new String[0];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cart1 = (String[])Session["ALL"];
                if (!IsPostBack)
                {
                    NameUser.InnerText = Session["Usuario"].ToString();                 
                    
                    Categoria.InnerText = cart1[4].ToString();
                    about.InnerText = cart1[3].ToString();
                    ImagenUsuario.Src = "/images/Users/" + cart1[2].ToString();
                    Imagen.Src = "/images/Users/" + cart1[2].ToString();
                    ID = int.Parse(cart1[5]);
                    txtdescription.InnerText = cart1[3].ToString().Trim();
                }
                
            }
            catch (Exception EX)
            {

                Response.Redirect("../Login.aspx");
            }
            
        }
        private void EnviarDatos()
        {
            OBUsuario.DescriptionUser = txtdescription.Value;
            OBUsuario.Categoria = dpCategoria.Text;
            OBUsuario.ID = int.Parse(cart1[5]);
        }
        private void DeletePhoto()
        {
            File.Delete(Server.MapPath("~/images/Users/" + cart1[2].ToString()));
        }
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            EnviarDatos();
            if (FileUpload1.HasFile) // Si el usuario tiene un archivo
            {
                    //DeletePhoto();
                    string filename2 = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/images/Users/") + filename2); // archivo.jpg
                    OBUsuario.Imagen = filename2;
                    if (ActualizarDAO.UpdateUser(OBUsuario) == 1)
                    {
                        Response.Write("<script>alert('" + "La proxima vez que inicies session se observaran los cambios" + "');</script>");
                    }
            }
                else
                {
                    //string filename = Path.GetFileName(FileUpload1.FileName);
                    //FileUpload1.SaveAs(Server.MapPath("~/img/") + filename); // archivo.jpg
                    //if (ctr.ActualizarPerfil(ob) == 1)
                    //{
                    //    LlenarDatos();
                    //    lblmensaje.Visible = true;
                    //    lblmensaje.Text = "Nuevos Datos de tu Perfil ";
                    //    Response.Write("<script>alert('" + "La proxima vez que inicies session se observaran los cambios" + "');</script>");
                    //}
                }

        }
    }
}