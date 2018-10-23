using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using Librox2.BO;
namespace Librox2.GUI
{
 
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        UsuarioBO ObUsuario = new UsuarioBO();
        Security OBSecurity = new Security();
        UsuariosDAO Register = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void GetData()
        {
            string contraseña = "";
            contraseña = OBSecurity.encrypt(txtcontraseña.Value);
            ObUsuario.Contraseña = contraseña;
            ObUsuario.Cumpleaños = "";
            ObUsuario.Correo = txtemail.Value;
            ObUsuario.Nombre = txtNombre.Value;
            ObUsuario.Usuario = txtusuario.Value;
            int TU = 0;
            TU = ObUsuario.TipoUsuario;
            ObUsuario.DescriptionUser = txtdescription.Value;
            ObUsuario.Cumpleaños = txtFechaNaci.Value;
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    if (Page.IsValid)
                    {
                        GetData();
                        if (Register.SaveUserRegister(ObUsuario) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroGood();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroFail();", true);
                            //Algo salio mal :(
                        }
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroFail();", true);
                //Algo salio mal :(
            }
        }
    }
}