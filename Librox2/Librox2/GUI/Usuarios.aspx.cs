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
            }
        }
        private void LoadUsuarios()
        {
            GridView1.DataSource = ob.ConsultarUsuarios();
            GridView1.DataBind();
        }
    }
}