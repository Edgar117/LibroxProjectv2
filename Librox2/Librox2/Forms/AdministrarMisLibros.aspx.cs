using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;
using Librox2.BO;
using System.Drawing;
namespace Librox2.Forms
{

    public partial class AdministrarMisLibros : System.Web.UI.Page
    {
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        EstatusLibroDAO EstatusLibroMetodos = new EstatusLibroDAO();
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
                    cargarDatalist(ID);
                    LoadCategorias();
                }
                catch (Exception ex)
                {

                    Response.Redirect("../Login.aspx");
                }

            }
            Panel1.Visible = false;
        }
        private void cargarDatalist(int ID)
        {
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarMisLibrosToEdit(ID);
            dtlBooks.DataSource = dt;
            dtlBooks.DataBind();
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
                    actualizarDatos(e);
                    break;
                case "btnSeleccionar":
                    cargarDatos(e); //Carga datos de la fila del grid seleccionada.
                    break;
                default:
                    break;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false; //Oculta la celda de imagen cuando se hace bind al grid.

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Toca para seleccionar este libro.";    //Ayuda
            }
        }

        private void cargarDatos(GridViewCommandEventArgs e)
        {
            //Este método recupera el índice del grid y carga los datos de la fila en el formulario.
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            txtNombre.Value = Server.HtmlDecode(row.Cells[4].Text);
            txtSinopsis.Value = Server.HtmlDecode(row.Cells[5].Text);
            dpCategorias.Text = Server.HtmlDecode(row.Cells[6].Text);
            ImagenUsuario.Src = "../LibrosPortadas/" + Server.HtmlDecode(row.Cells[7].Text);
        }

        private void actualizarDatos(GridViewCommandEventArgs e)
        {
            int indexUpdate = Convert.ToInt32(e.CommandArgument);
            GridViewRow rowUpdate = GridView1.Rows[indexUpdate];
            //   SelectCategoria();
            OBLibros.ID_LIBRO = int.Parse(Server.HtmlDecode(rowUpdate.Cells[3].Text));
            OBLibros.Titulo = txtNombre.Value;
            OBLibros.Sinpsis = txtSinopsis.Value;
            OBLibros.Categoria = dpCategorias.SelectedValue;
            if (DAOLibrosToedit.UpdateLibroDelete(OBLibros) == 1)
            {
                cart1 = (String[])Session["ALL"];
                ID = int.Parse((cart1[5]).ToString());
                LoadGrid(ID);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Toca para seleccionar este libro.";
                }
            }
        }

        protected void dtlBooks_EditCommand(object source, DataListCommandEventArgs e)
        {
            dtlBooks.EditItemIndex = e.Item.ItemIndex;
            bind();
            
        }
        private void bind()
        {
            cart1 = (String[])Session["ALL"];
            ID = int.Parse(cart1[5]);
            cargarDatalist(ID);
        }
        protected void dtlBooks_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            int id = Convert.ToInt32(dtlBooks.DataKeys[e.Item.ItemIndex]);
            TextBox nombreLibro = (TextBox)e.Item.FindControl("txtTitulo");
            TextBox sinopsisLibro = (TextBox)e.Item.FindControl("txtSinopsis");
            TextBox categoriaLibro = (TextBox)e.Item.FindControl("txtCategoria");
            OBLibros.ID_LIBRO = id;
            OBLibros.Titulo = nombreLibro.Text;
            OBLibros.Sinpsis = sinopsisLibro.Text;
            OBLibros.Categoria = categoriaLibro.Text;
            //Falta Tener el combo de los estatus de los libros el metodo ya esta hecho, seria que anexes el control nada mas
            //ENVIAMOS LOS NUEVOS DATOS
            if (DAOLibrosToedit.UpdateLibroDelete(OBLibros) == 1)
            {
                cart1 = (String[])Session["ALL"];
                ID = int.Parse((cart1[5]).ToString());
                LoadGrid(ID);
            }

        }

        protected void dtlBooks_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dtlBooks.EditItemIndex = -1;
            bind();
        }

        protected void dtlBooks_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DropDownList ddl = e.Item.FindControl("ddlCat") as DropDownList;
                if (ddl != null)
                {
                    //populate the ddl now  
                    ddl.DataSource = DAOCategorias.ConsultarCategoriasLibrosVista();
                    ddl.DataTextField  = "NombreCategoria";
                    ddl.DataValueField = "NombreCategoria";
                    ddl.DataBind();
                }
                DropDownList ddlEsta = e.Item.FindControl("ddlEstatus") as DropDownList;
                if (ddlEsta != null)
                {
                    //populate the ddl now  
                    ddlEsta.DataSource = EstatusLibroMetodos.ConsultarStatusLibro();
                    ddlEsta.DataTextField = "Estado del Libro";
                    ddlEsta.DataValueField = "Identificador";
                    ddlEsta.DataBind();
                }
            }
        }
    }
}