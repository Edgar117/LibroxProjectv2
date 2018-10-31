using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;
using Librox2.BO;
namespace Librox2.Forms
{
 
    public partial class AdministrarMisLibros : System.Web.UI.Page
    {
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        LibrosDAO DAOLibrosToedit = new LibrosDAO();
       // LibrosDAO DAOLibros = new LibrosDAO();
        LibrosBO OBLibros = new LibrosBO();
        int ID = 0;
        DataTable dt = new DataTable();
        String[] cart1 = new String[0];
        UsuariosDAO DAOLibros = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cart1 = (String[])Session["ALL"];
                    ID = int.Parse(cart1[5]);
                    //Aqui recuperamos el dt
                    // dt = DAOLibros.ConsultarMisLibrosToEdit(ID);
                    LoadGrid(ID);
                    LoadCategorias();
                }
                catch (Exception ex)
                {

                    Response.Redirect("../Login.aspx");
                }
               
            }
           
        }
        private void LoadGrid(int ID)
        {
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarMisLibrosToEdit(ID);
            //DataRow dr = new DataRow[dt.Rows[1]];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void LoadCategorias()
        {
            // llenamos el dropdownlist de acuerdo a las categorias Disponibles (Visibles en el admin)
            this.dpCategorias.DataSource = DAOCategorias.ConsultarCategoriasLibrosVista();//Metodo que consulta las categorias disponibles para el usuario
            this.dpCategorias.DataValueField = "NombreCategoria";//Nombre que tiene el field en la base de datos
            this.dpCategorias.DataTextField = "NombreCategoria";//Nombre que tendra en el Drop
            this.dpCategorias.DataBind();//Se le pasa los datos para que se llene de nuevo
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {
                case "btneliminar":
                    int indexEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GridView1.Rows[indexEliminar];
                    string ID = Server.HtmlDecode(rowEliminar.Cells[3].Text);
                    if (ID == "")
                    {

                    }
                    else
                    {
                       // RankingBO.ID = int.Parse(ID);
                        //if (RanKingDao.DeletePrecio(RankingBO) == 1)
                        //{
                        ////    LoadCategorias();
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
                        //}
                    }
                    break;
                case "btnActualizar":
                    int indexUpdate = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowUpdate = GridView1.Rows[indexUpdate];
                    //   SelectCategoria();
                    OBLibros.ID_LIBRO = int.Parse(Server.HtmlDecode(rowUpdate.Cells[3].Text));
                    OBLibros.Titulo = txtNombre.Value;
                    OBLibros.Sinpsis = txtSinopsis.Value;
                    OBLibros.Categoria = dpCategorias.SelectedValue;
                    if (DAOLibrosToedit.UpdateBookWithOutImage(OBLibros) == 1)
                    {
                        cart1 = (String[])Session["ALL"];
                        ID = int.Parse(cart1[5]).ToString();
                        LoadGrid(int.Parse(ID));
                       // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    }
                    break;
                case "btnSeleccionar":
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                    txtNombre.Value = Server.HtmlDecode(row.Cells[4].Text);
                    txtSinopsis.Value = Server.HtmlDecode(row.Cells[5].Text);
                    dpCategorias.Text = Server.HtmlDecode(row.Cells[6].Text);
                    ImagenUsuario.Src= "../LibrosPortadas/"+ Server.HtmlDecode(row.Cells[7].Text);
                    //  this.DPGeneraSc.Text = Server.HtmlDecode(row.Cells[4].Text);
                    break;

                default:
                    break;
            }
        }
    }
}