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
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        UsuarioBO ObUsuario = new UsuarioBO();
        Security OBSecurity = new Security();
        Usuarios Register = new Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetData()
        {
            string contraseña = "";
            contraseña = OBSecurity.encrypt(txtContraseña.Value);
            ObUsuario.Contraseña = contraseña;
            ObUsuario.Cumpleaños = txtcumpleaños.Value;
            ObUsuario.Correo = txtemail.Value;
            ObUsuario.Nombre = txtnombre.Value;
            ObUsuario.Usuario = txtusuario.Value;
            int TU = 0;
            TU= ObUsuario.TipoUsuario;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetData();
            if (Register.SaveUserRegister(ObUsuario)==1)
            {

            }
            else
            {

            }
           
        }
    }
}