using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;
using Librox2.BO;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text;
using System.Net;

namespace Librox2.Forms
{
    public partial class LibrosDetails : System.Web.UI.Page
    {
        LibrosDAO DAOLibros = new LibrosDAO();
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        ComentariosBO comentarios = new ComentariosBO();
        DataTable dt = new DataTable();
        string titulo;
        string libroFisico;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    pnlComments2.Visible = false;
                    pnlLogin.Visible = true;
                }
                else
                {
                    pnlComments2.Visible = true;
                    pnlLogin.Visible = false;
                }
                if (Session["LibroDetalle"] != null)
                {
                    System.Collections.Hashtable ht = new System.Collections.Hashtable();
                    ht = (System.Collections.Hashtable)Session["LibroDetalle"];
                    titulo = Convert.ToString(ht["Titulo"]);
                    string categoria = Convert.ToString(ht["Categoria"]);
                    string precio = Convert.ToString(ht["Precio"]);
                    string autor = Convert.ToString(ht["Autor"]);
                    string sinopsis = Convert.ToString(ht["Sinopsis"]);
                    string estatus = Convert.ToString(ht["Estatus"]);
                    string imgPath = Convert.ToString(ht["ImagenPortada"]);

                    //string strDesignation = ht.ContainsKey("Precio") ? Convert.ToString(ht["Precio"]) : "";

                    //Cargando sección de comentarios
                    bindComments();

                    lblTitulo.Text = titulo;
                    lblAutor.Text = autor;
                    lblCat.Text = categoria;
                    lblEstatus.Text = estatus;
                    lblSinop.Text = sinopsis;
                    imgPortada.ImageUrl = imgPath;

                    LinkButton1.Text = "$" + precio + ".00";

                    //Cuando se abre la página de detalles del libro, se desencripta dicho libro y se queda guardado en servidor.
                    obtenerLibroFisico();
                    prepareMuestra();

                    //Recomendaciones basadas en la categoría del libro seleccionado
                    dt = DAOLibros.ConsultarLibrosPorCategorias(categoria);
                    //Generando recomendaciones
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dt.Rows[i];
                        if (dr["Titulo"].ToString() == titulo)
                            dt.Rows.Remove(dr);
                    }
                    //Removiendo título seleccionado, evita que se indexe en las recomendaciones
                    dt.AcceptChanges();
                    if (dt.Rows.Count == 0) //Si no hay recomendaciones, se oculta el repeater
                    {
                        Repeater1.Visible = false;
                    }
                    else
                    {   //De otra forma, si hay recomendaciones se toman solamente las primeras 3 para no cargar el repeater
                        dt.Rows.Cast<System.Data.DataRow>().Take(3);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("libros");
                }
            }
        }

        private void bindComments()
        {
            DataTable dtComments = new DataTable();
            dtComments = DAOLibros.ConsultaComentariosLibros(titulo);
            Repeater2.DataSource = dtComments;
            Repeater2.DataBind();
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            if (txtComment.Text != "")
            {
                comentarios.Comentarios = txtComment.Text;
                comentarios.Libro = lblTitulo.Text;
                comentarios.Usuario = Session["Usuario"].ToString();
                DAOLibros.InsertarComentarios(comentarios);
                Response.Redirect("/details");
            }
            else
            {
                return;
            }

            //bindComments();
        }
        private void prepareMuestra()
        {
            //Método que se ocupa para prepara el archivo de muestra con páginas limitadas
            //obtenerLibroFisico();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + libroFisico + "_encrypted"));
            string input = originalDirectory.ToString();
            string output = Server.MapPath("~/LibrosPortadas/" + libroFisico + ".pdf");

            decryptBook(input, output);
            determinePaginas(output);
        }

        private void obtenerLibroFisico()
        {
            DataTable dtBooks = new DataTable();
            dtBooks = DAOLibros.ConsultarLibrosXTexto(lblTitulo.Text);
            libroFisico = dtBooks.Rows[0]["LibroFisico"].ToString();
        }

        protected void lbtnPrueba_Click(object sender, EventArgs e)
        {
            obtenerLibroFisico();
            string book = Server.MapPath("~/LibrosPortadas/" + libroFisico + ".pdf");
            string muestraLimitada = Server.MapPath("~/LibrosPortadas/" + libroFisico + "_trial.pdf");
            extraerPaginas(book, muestraLimitada);
        }
        protected void decryptBook(string input, string output)
        {
            string password = "mikey2018";  //Se encripta con esta contraseña

            UnicodeEncoding UE = new UnicodeEncoding();

            FileStream fsCrypt = new FileStream(input, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();   //Se crea un objeto del algoritmo de criptografía
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes("Salt text"));    //Codifica el password en bytes ASCII como lo requiere el algoritmo

            //Se asigna la clave 'key' y el índice del vector 'IV' basados en 8 bytes como propiedades del objeto de encriptación, mismos que servirán para decodificar
            RMCrypto.Key = key.GetBytes(RMCrypto.KeySize / 8);
            RMCrypto.IV = key.GetBytes(RMCrypto.BlockSize / 8);

            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(output, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
        }
        protected void determinePaginas(string archivoMuestra)
        {
            PdfReader pdfReader = new PdfReader(archivoMuestra);
            int numberOfPages = pdfReader.NumberOfPages;
            lblPages.Text = "(" + numberOfPages.ToString() + " páginas)";
        }
        protected void extraerPaginas(string archivoMuestra, string outputPdfPath)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;
            int rangoPaginas = 5;

            try
            {
                //Inicializa un lector de PDF en la ruta del archivo desencriptado
                reader = new PdfReader(archivoMuestra);
                if (reader.NumberOfPages > rangoPaginas)   //Si tiene más de un rango de páginas predeterminado se puede descargar una muestra.
                {
                    //Por simplicidad, se asume que todas las páginas del PDF comparten el mismo tamaño de página
                    //y la misma rotación que la primera página.
                    sourceDocument = new Document();

                    // Inicializa una instancia de PdfCopy con la fuente y la salida del archivo PDF 
                    pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                    sourceDocument.Open();
                    //Recorre el rango de páginas especificadas y las copia a un nuevo archivo PDF:
                    for (int i = 1; i <= rangoPaginas; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    //Cerrando streams abiertos
                    sourceDocument.Close();
                    reader.Close();

                    //Abre archivo de muestra en el explorador
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(outputPdfPath);
                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
                //De lo contrario, no es posible generar una muestra, aparece el siguiente mensaje.
                else
                {
                    lblMuestraNo.Text = "No es posible descargar una muestra de este libro";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMuestraNo.Text = "No es posible descargar una muestra de este libro";
            }
        }
    }
}