using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;

namespace Librox2.GUI
{
    public partial class Libros : System.Web.UI.Page
    {
        LibrosDAO DAOLibros = new LibrosDAO();
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLibros();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                PaginarPorCategorias();
            }
        }
        private void LoadAll()
        {
            if (dt.Rows.Count>0)
            {
                Label1.Visible = false;
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                dt.Clear();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                Label1.Visible = true;
                Label1.Text = "No hay Libros con esa Categoria Para Mostrar";
            }
            
        }
        private void LoadLibros()
        {
            dt=DAOLibros.ConsultarLibros();
        }
        private void PaginarPorCategorias()
        {
            // llenamos el dropdownlist de acuerdo a las categorias Disponibles (Visibles en el admin)
            this.dpCategorias.DataSource = DAOCategorias.ConsultarCategoriasLibrosVista();//Metodo que consulta las categorias disponibles para el usuario
            this.dpCategorias.DataValueField = "NombreCategoria";//Nombre que tiene el field en la base de datos
            this.dpCategorias.DataTextField = "NombreCategoria";//Nombre que tendra en el Drop
            this.dpCategorias.DataBind();//Se le pasa los datos para que se llene de nuevo
        }

        protected void dpCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = DAOLibros.ConsultarLibrosPorCategorias(dpCategorias.Text);
            LoadAll();
        }
    }
}