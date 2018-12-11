using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;
using Librox2.BO;
namespace Librox2.GUI
{
    public partial class Libros : System.Web.UI.Page
    {
        //Declaramos la instancia de paypal
        Paypal entity = new Paypal();

        LibrosDAO DAOLibros = new LibrosDAO();
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["myOrderingEntity"] = null;
                LoadLibros();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                Repeater1.Visible = true;
                //dtlBooks.Visible = false;
                //dtlBooks.DataSource = dt;
                //dtlBooks.DataBind();
                PaginarPorCategorias();
            }
        }
        private void LoadAll()
        {
            if (dt.Rows.Count > 0)
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
                Label1.Text = "No hay libros con esa categoría para mostrar";
            }

        }
        private void LoadLibros()
        {
            dt = DAOLibros.ConsultarLibros();
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

        //Método que llena los datos del paypal
        private void SetOrderingValue(string itemName, string itemNumber, string amount, string noShipping, string quantity)
        {
            entity.Business = "huesos_blin182-facilitator@hotmail.com";
            entity.ItemName = itemName;
            entity.ItemNumber = itemNumber;
            entity.Amount = amount;
            entity.NoShipping = noShipping;
            entity.Quantity = quantity;
            Session["myOrderingEntity"] = entity;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "pay")
            {
                //Busca una referencia al 'linkbutton' dentro del repeater
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                //Obtiene valores del item seleccionado (título y precio)
                string titulo = ((Label)item.FindControl("lblTitulo")).Text;
                string precio = ((Label)item.FindControl("lblPrecio")).Text;
                //Método para activar la sesión para enviar al proceso de pago
                SetOrderingValue(titulo, "BB01", precio, "1", "1");
                //Redirige al proceso de pago con los datos del libro elegido ya en la sesión.
                Response.Redirect("~/Forms/ProcesarPago.aspx");
            }
            if (e.CommandName == "details")
            {
                //Busca una referencia al 'linkbutton' dentro del repeater
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                //Obtiene valores del item seleccionado (título y precio)
                string titulo = ((Label)item.FindControl("lblTitulo")).Text;
                string precio = ((Label)item.FindControl("lblPrecio")).Text;
                string categoria = ((Label)item.FindControl("lblCat")).Text;
                string sinopsis = ((Label)item.FindControl("lblSinop")).Text;
                string autor = ((Label)item.FindControl("Label2")).Text;
                string estatus = ((Label)item.FindControl("Label3")).Text;
                Image imgPortada = (Image)item.FindControl("imgPortada");
                string imgRuta = imgPortada.ImageUrl;
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                ht.Add("Titulo", titulo);
                ht.Add("Precio", precio);
                ht.Add("Categoria", categoria);
                ht.Add("Sinopsis", sinopsis);
                ht.Add("Autor", autor);
                ht.Add("Estatus", estatus);
                ht.Add("ImagenPortada", imgRuta);
                Session["LibroDetalle"] = ht;
                Server.Transfer("~/Forms/LibrosDetails.aspx");
            }
        }
    }
}