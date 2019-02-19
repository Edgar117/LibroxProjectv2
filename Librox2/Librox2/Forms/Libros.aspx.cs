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
        LibrosBO DatosLibro = new LibrosBO();
        LibrosDAO DAOLibros = new LibrosDAO();
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        UsuariosDAO DAOUsers = new UsuariosDAO();
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
                //this.txtSearch.Attributes.Add("onkeypress", "button_click(this,'" + this.txtSearch.ClientID + "')");
            }
        }
        private void LoadAll(string text)
        {
            //Si el data table devolvió, algo entonces se llena el repeater.
            if (dt.Rows.Count > 0)
            {
                Label1.Visible = false;
                lblTit2.Visible = false;
                lblSearchResults.Text = "Resultados para: " + "'" + text + "'";
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            //De lo contrario, se limpia la tabla y se muestra el mensaje de que no se encontraron libros con ese dato.
            else
            {
                dt.Clear();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                Label1.Visible = true;
                Label1.Text = "Nada para mostrar por ahora";
                lblSearchResults.Text = "No se encontraron libros para: " + "'" + text + "'";
            }

        }
        //Método que devuelve todos los libros que hay en el sistema.
        private void LoadLibros()
        {
            dt = DAOLibros.ConsultarLibros();
        }
        //Este Método realiza la búsqueda de libros por un texto que el usuario escriba en el control que vas a crear saludos.
        private void BuscarLibrosPorTexto(string Text)
        {
            //Se llena el data table con la consulta que nos devuelve el metodo.
            dt = DAOLibros.ConsultarLibrosXTexto(Text);
            //Se llama al metodo LoadAll() para cargar los datos que se hayan devuelto.
            LoadAll(Text);

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
            LoadAll(dpCategorias.Text);
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
                ////Insertamos los datos del usuario a la tabla para la comparación de datos posteriormente
                //DatosLibro.Titulo = titulo;
                //DatosLibro.Precio = precio;
                ////Datos para obtener el id
                //String[] cart1 = new String[0];
                //cart1 = (String[])Session["ALL"];
                ////Obtenemos su Id del usuario.
                //int ID = int.Parse(cart1[5]);
                ////Obtenemos los datos del usuario.
                //DAOLibros.ProcesarLibroPaypal(DatosLibro, ID);
                ////Redirige al proceso de pago con los datos del libro elegido ya en la sesión.
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
                Response.Redirect("/details");
            }
            if (e.CommandName == "profile")
            {
                if (Session["Usuario"]!=null)
                {
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                lblUser.Text = ((Label)item.FindControl("Label2")).Text;
                DataTable dtuser = new DataTable();
                dtuser = DAOUsers.ConsultaDatosUsuario(lblUser.Text);
                lblUserMail.Text = dtuser.Rows[0]["Correo"].ToString();
                ImagenUsuario.ImageUrl = "/images/Users/" + dtuser.Rows[0]["Imagen"].ToString();
                dtuser = null;
                dtuser = DAOUsers.ConsultaDatosLibrosXUsuario(lblUser.Text);
                TotalLibros.Text = "Libros: " + dtuser.Rows[0]["Libros"].ToString();
                if (isFollow(lblUser.Text)) //Si ya lo sigue, entonces no debe poder seguirlo
                {
                    lbtnFollow.Visible = false;
                    lblFollower.Visible = true;
                    string[] userr = lblUser.Text.Split(' ');
                    lblFollower.Text = "Ya sigues a " + userr[0].ToString() + ". Genial!";
                }
                else
                {
                    lblFollower.Visible = false;
                    //Si no, pues puede seguirlo
                    lbtnFollow.Visible = true;
                    lbtnFollow.Text = "Seguir";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Session();", true);
                }
          }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarLibrosPorTexto(txtSearch.Text);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Cookies["check"].Value = "Yes";
            Response.Redirect("/libros");
        }

        protected void btnDeclinar_Click(object sender, EventArgs e)
        {
            Response.Cookies["check"].Value = "No";
        }

        protected void lbtnFollow_Click(object sender, EventArgs e)
        {
            //Recuperamos al usuario logeado y tomamos su ID
            String[] cart1 = new String[0];
            cart1 = (String[])Session["ALL"];
            //Obtenemos su Id del usuario.
            int ID = int.Parse(cart1[5]);
            //Obtenemos los datos del usuario.
            DataTable dtuser = new DataTable();
            dtuser = DAOUsers.ConsultaDatosUsuario(lblUser.Text);
            DAOUsers.InsertaSeguidores(ID, Convert.ToInt32(dtuser.Rows[0]["Identificador"].ToString()));

        }
        private bool isFollow(string user)
        {
            bool isFollow = false;
            //Recuperamos al usuario logeado y tomamos su ID
            String[] cart1 = new String[0];
            cart1 = (String[])Session["ALL"];
            //Obtenemos su Id del usuario.
            int ID = int.Parse(cart1[5]);
            //Obtenemos los datos del usuario.
            DataTable dtuser = new DataTable();
            dtuser = DAOUsers.ConsultaDatosUsuario(user);
            //Hacemos un split a los seguidores para ver si el usuario logeado no forma parte ya de los seguidores.           
            string Seguidores = dtuser.Rows[0]["Seguidores"].ToString();
            string[] substrings = Seguidores.Split(',');
            foreach (var substring in substrings)
            {
                if (ID.ToString() == substring)
                {
                    isFollow = true;
                }
            }
            return isFollow;
        }
    }
}