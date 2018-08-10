using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.BO;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class Categorias : System.Web.UI.Page
    {
        CategoriasBO OBCategorias = new CategoriasBO();
        CategoriaDAO OBCategoriasDao = new CategoriaDAO();
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
            GridView1.DataSource = OBCategoriasDao.ConsultarCategorias();
            GridView1.DataBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Codigo Insertar Categoria
            OBCategorias.NombreCategoria = txtCategorias.Text;
            if (DPGeneraSc.Text=="SI")
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
            OBCategorias.Status = CategoriaStatus;
            if (OBCategoriasDao.SaveCategoria(OBCategorias)==1)
            {
                LoadCategorias();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
                      
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {  
                case "btneliminar":
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //GridViewRow row = GridView1.Rows[index];
                    //lblid.Text = Server.HtmlDecode(row.Cells[1].Text);
                    //if (lblid.Text == "")
                    //{

                    //}
                    //else
                    //{
                    //    datos.Clave = int.Parse(lblid.Text);
                    //    if (ctr.BajaAsignatura(datos) == 1)
                    //    {
                    //        string script = "<script language=\"javascript\">DatosCom2();</script>";
                    //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DatosCom2", script, false);
                    //        mostrar();
                    //    }
                    //}
                    break;
                case "btnactualizar":
                    break;
                case "btnseleccionar":
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                      txtCategorias.Text = Server.HtmlDecode(row.Cells[3].Text);
                    switch (Server.HtmlDecode(row.Cells[4].Text))
                    {
                        case "Activo":
                            DPGeneraSc.Text = "SI";
                            break;
                        case "No Activo":
                            DPGeneraSc.Text = "NO";
                            break;
                        case "Proximamente":
                            DPGeneraSc.Text = "Proximamente";
                            break;

                        default:
                            break;
                    }
                    //this.DPGeneraSc.Text = Convert.ToString(this.GridView1.Rows[GridView1.SelectedIndex].Cells[4].Text);
                    break;

                default:
                    break;
            }
        }
    }
}