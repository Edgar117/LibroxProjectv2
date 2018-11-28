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

        //Metodo que llena los datos del paypal
        private void SetOrderingValue(string itemName, string itemNumber, string amount, string noShipping, string quantity)
        {
            entity.Business = "Escribox@gmail.com";
            entity.ItemName = itemName;
            entity.ItemNumber = itemNumber;
            entity.Amount = amount;
            entity.NoShipping = noShipping;
            entity.Quantity = quantity;
            Session["myOrderingEntity"] = entity;
        }

        //Metodo que david hara para pasar los datos
        //protected void btnPaypal4_Click(object sender, ImageClickEventArgs e)
        //{
        //    SetOrderingValue("Championship Tennis", "PN4", "13.98", "1", "3");
        //    Response.Redirect("~/PaypalProcess.aspx");
        //}
    }
}