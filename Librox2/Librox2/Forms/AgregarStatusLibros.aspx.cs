using Librox2.BO;
using Librox2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.Forms
{
    public partial class AgregarStatusLibros : System.Web.UI.Page
    {
        EstadoLibroBO OBStatusLibro = new EstadoLibroBO();
        EstatusLibroDAO StatusLibroDao = new EstatusLibroDAO();
        int CategoriaStatus = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategorias();
            }
        }
        private void LoadCategorias()
        {
            GridView1.DataSource = StatusLibroDao.ConsultarStatusLibro();
            GridView1.DataBind();
        }

        protected void btnRegisterCategoria_Click(object sender, EventArgs e)
        {
            OBStatusLibro.NombreStatus = txtEstadoLibro.Text;
            if (DPGeneraSc.Text == "SI")
            {
                CategoriaStatus = 1;
            }
            if (DPGeneraSc.Text == "NO")
            {
                CategoriaStatus = 0;
            }
            if (DPGeneraSc.Text == "Proximamente")
            {
                CategoriaStatus = 2;
            }
            OBStatusLibro.Status = CategoriaStatus;
            if (StatusLibroDao.SaveCategoria(OBStatusLibro) == 1)
            {
                LoadCategorias();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
        }
    }
}