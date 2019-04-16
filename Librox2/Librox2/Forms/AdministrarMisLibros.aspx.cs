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
using System.IO;
using System.Security.Cryptography;
using System.Text;

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

                    Response.Redirect("Login.aspx");
                }

            }
            Panel1.Visible = false;
        }
        private void cargarDatalist(int ID)
        {
            pnlMyBooks.Visible = false;
            pnlNoBooks.Visible = false;
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarMisLibrosToEdit(ID);
            if (dt.Rows.Count > 0)
            {
                pnlMyBooks.Visible = true;
                pnlNoBooks.Visible = false;
                dtlBooks.DataSource = dt;
                dtlBooks.DataBind();
            }
            else
            {
                pnlMyBooks.Visible = false;
                pnlNoBooks.Visible = true;
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
            if (DAOLibrosToedit.UpdLibro(OBLibros) == 1)
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
            DropDownList categoriaLibro = e.Item.FindControl("ddlCat") as DropDownList;
            DropDownList ddlEsta = e.Item.FindControl("ddlEstatus") as DropDownList;
            FileUpload fileU = e.Item.FindControl("fuImg") as FileUpload;
            FileUpload LoadNewPdf = e.Item.FindControl("LoadNewPdf") as FileUpload;
            if (fileU.HasFile)
            {
                var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"].ToString() + "/"));
                OBLibros.ImagenPòrtada = Session["Usuario"].ToString() + "/" + fileU.FileName;    //Actualiza la imagen
                string pathString = originalDirectory.ToString();
                var path = string.Format("{0}\\{1}", pathString, fileU.FileName);//Formamos la ruta donde se guardara la imagen
                fileU.SaveAs(path);  //Guarda el archivo físico original en servidor
            }
            else
            {
                OBLibros.ImagenPòrtada = null;
            }
            if (LoadNewPdf.HasFile)
            {
                string Variable = Session["Usuario"].ToString();
                var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + Variable + "/"));
               
                string pathString = originalDirectory.ToString();
                var FileNameVerify = Path.GetFileName(LoadNewPdf.FileName);//Lo estoy usando para verificar algo
                var fileName1 = Path.GetFileNameWithoutExtension(LoadNewPdf.FileName);
                //Solo el pdf necesitamos encriptar
                string encryptedName = fileName1 + "_encrypted";    //Se asigna el nombre que tendrá el archivo ya encriptado
                string pathDestino = pathString + encryptedName;    //Se combinan las rutas para indicar en dónde se guardará el archivo encriptado
                EncryptFile(LoadNewPdf.PostedFile, pathDestino); //Llamada al método para encriptar archivo
                Session["LibroFisico"] = Variable + "/" + fileName1;
                OBLibros.LibroFisico= Variable + "/" + fileName1;
            }
            else
            {
                OBLibros.LibroFisico = null;
            }
            OBLibros.EstatusLibro = Convert.ToInt32(ddlEsta.SelectedValue);
            OBLibros.ID_LIBRO = id;
            OBLibros.Titulo = nombreLibro.Text;
            OBLibros.Sinpsis = sinopsisLibro.Text;
            OBLibros.Categoria = categoriaLibro.Text;
            cart1 = (String[])Session["ALL"];
            try
            {
                DAOLibrosToedit.UpdLibro(OBLibros);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroGoodLibro();", true);
                bind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + "No se pudo actualizar el libro. Código de error: " + ex.ToString() + "');</script>");
                throw;
            }

        }
        private void EncryptFile(HttpPostedFile file, string outputfile)
        {
            //file y outpfile hacen referencia al archivo que se subió a encriptar y en dónde se guardará una vez encriptado respectivamente.
            try
            {
                //string InitVector = "qwertyui"; //16byte 1chr = 2byte(unicode)
                string password = "mikey2018";  //Se encripta con esta contraseña

                string cryptFile = outputfile;  //Se trata el parámetro ingresado como una variable nueva e independiente
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);    //Crea un FS en modo criptógrafo (no permite lectura de ningún tipo)

                RijndaelManaged RMcrypto = new RijndaelManaged();   //Se crea un objeto del algoritmo de criptografía
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes("Salt text"));    //Codifica el password en bytes ASCII como lo requiere el algoritmo

                //Se asigna la clave 'key' y el índice del vector 'IV' basados en 8 bytes como propiedades del objeto de encriptación, mismos que servirán para decodificar
                RMcrypto.Key = key.GetBytes(RMcrypto.KeySize / 8);
                RMcrypto.IV = key.GetBytes(RMcrypto.BlockSize / 8);

                CryptoStream cs = new CryptoStream(fsCrypt, RMcrypto.CreateEncryptor(), CryptoStreamMode.Write);    //Escribe los bytes a bytes encriptados

                int data;
                while ((data = file.InputStream.ReadByte()) != -1)  //Escribe los bytes
                    cs.WriteByte((byte)data);   //Va construyendo de nuevo el archivo

                //Se cierran las instancias abiertas
                file.InputStream.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
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
                    ddl.DataTextField = "NombreCategoria";
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

        protected void dtlBooks_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            //Se recupera el ID del libro a eliminar
            int id = Convert.ToInt32(dtlBooks.DataKeys[e.Item.ItemIndex]);
            //Script de confirmación, se requiere para poder eliminar el libro, de lo contrario se recarga la página.
            ClientScriptManager CSM = Page.ClientScript;
            if (!ReturnValue())
            {
                string strconfirm = "<script>if(!window.confirm('¿Estás seguro de eliminar tu libro?')){window.location.href='/mybooks'}</script>";
                CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
                try
                {
                    //Método para eliminar el libro
                    OBLibros.ID_LIBRO = id;
                    OBLibros.Action = true;
                    DAOLibrosToedit.UpdLibro(OBLibros);
                    bind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + "No se pudo eliminar el libro. Código de error: " + ex.ToString() + "');</script>");
                }
            }
            
        }
        bool ReturnValue()
        {
            return false;
        }
    }
}
