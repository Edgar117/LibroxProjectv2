using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuariosDAO ob = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsuarios();
                pnAviso.Visible = false;    //El panel se inicia de manera invisible, solamente es visible al invocarlo
            }
        }
        private void LoadUsuarios()
        {
            GridView1.DataSource = ob.ConsultarUsuarios();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string action = Convert.ToString(e.CommandName);
            switch (action) {
                case "btnSeleccionar":
                    pnAviso.Visible = true; //Aparee panel al seleccionar un usuario del Grid
                    int index = Convert.ToInt32(e.CommandArgument); //Operación conversión de argumento válido del Grid
                    GridViewRow row = GridView1.Rows[index]; //Se asigna una fila del grid (pendiente try-catch)
                    txtCorreo.Text = Server.HtmlDecode(row.Cells[7].Text);  //Se recupera correo del usuario seleccionado y se ajusta a un TextBox del mismo nombre
                    
                    //Próxima rutina de envío de correo electrónico
                    break;
            }
        }
    }
}