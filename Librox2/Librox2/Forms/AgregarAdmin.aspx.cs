using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using Librox2.BO;
namespace Librox2.Forms
{
    public partial class AgregarAdmin : System.Web.UI.Page
    {
        UsuarioBO ObUsuario = new UsuarioBO();
        Security OBSecurity = new Security();
        UsuariosDAO Register = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }

        }

        protected void btnRegisterAdminUser_Click(object sender, EventArgs e)
        {
            ObUsuario.Usuario = txtUsuario.Text;
            string contraseña = "";
            contraseña = OBSecurity.encrypt(txtContraseña.Text);
            ObUsuario.Contraseña = contraseña;
            ObUsuario.Correo = txtcorreo.Text;
            ObUsuario.Cumpleaños = "12/12/2020";
            ObUsuario.TipoUsuario = 1;
            ObUsuario.Nombre = "Admin";
            if (Register.SaveUserRegister(ObUsuario) == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                CargarGrid();
                CleanControls();
            }
        }
        private void CargarGrid()
        {
            GVUsersAdmin.DataSource = Register.ConsultarUsuariosAdmin();
            GVUsersAdmin.DataBind();
        }
        protected void GVUsersAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVUsersAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {
                case "btneliminar":
                    int indexEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GVUsersAdmin.Rows[indexEliminar];
                    string ID = Server.HtmlDecode(rowEliminar.Cells[1].Text);
                    if (ID == "")
                    {

                    }
                    else
                    {
                        ObUsuario.ID = int.Parse(ID);
                        if (Register.DeleteUser(ObUsuario) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "BorrarAdmin();", true);
                            CargarGrid();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        private void CleanControls()
        {
            txtContraseña.Text = "";
            txtcorreo.Text = "";
            txtUsuario.Text = "";
        }
    }
}