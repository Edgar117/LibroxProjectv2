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
using System.Text;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text;
using System.Data.Common;
using System.Net;

namespace Librox2.Forms
{
    public partial class MisCompras : System.Web.UI.Page
    {
        int ID = 0;
        int porcentajeLeído = 0;
        int numberOfPages = 0;
        string page = "";
        String[] cart1 = new String[0];
        LibrosDAO books = new LibrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "submit", "ShowLoading()");
            if (!IsPostBack)
            {
                try
                {
                    cart1 = (String[])Session["ALL"];
                    ID = int.Parse(cart1[5]);
                    getBooks(ID);
                }
                catch (Exception ex)
                {

                    Response.Redirect("Login.aspx");
                }

            }
        }
        private void getBooks(int id)
        {
            DataTable dt = books.ConsultarMisLibrosComprados(id);
            rptCompras.DataSource = dt;
            rptCompras.DataBind();
        }
        protected void rptCompras_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "dwd")
            {
                //Busca una referencia al 'linkbutton' dentro del repeater
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                //Obtenemos los datos del item seleccionado
                string tit = ((Label)item.FindControl("lblTitulo")).Text;
                string rutaFisico = ((Label)item.FindControl("lblFisico")).Text;
                string page = ((Label)item.FindControl("lblPage")).Text;
                if (page == "F")
                {
                    Response.Redirect("~/Forms/Read.aspx?read=" + rutaFisico + "&tit=" + tit + "&track=1");
                }
                else
                {
                    Response.Redirect("~/Forms/Read.aspx?read=" + rutaFisico + "&tit=" + tit + "&track=" + page);
                }
                //books.UpdCampoDescargado(idPago, "");
                //prepareBook(rutaFisico);
            }
        }
        private void prepareBook(string encriptedPath)
        {

            //obtenerLibroFisico();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + encriptedPath + "_encrypted"));
            string input = originalDirectory.ToString();
            string output = Server.MapPath("~/LibrosPortadas/" + encriptedPath + ".pdf");
            decryptBook(input, output);
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
            //Response.Redirect("~/Forms/Read.aspx?read=" + output);
            determinePaginas(output);
        }

        protected void determinePaginas(string archivoMuestra)
        {
            PdfReader pdfReader = new PdfReader(archivoMuestra);
            numberOfPages = pdfReader.NumberOfPages;
        }

        protected void dwdBook(string book)
        {
            //Abre archivo de muestra en el explorador
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(book);
            if (FileBuffer != null)
            {
                Label1.Text = book;
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Path.GetFileName(book)));
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("Content-Disposition",
                //    "attachment; filename=\"" + Path.GetFileName(book) + "\"");
                Response.TransmitFile(book);
                //Response.End();
                //Response.Redirect("~/Forms/Home.aspx");
            }
        }

        protected void rptCompras_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView dbr = (DataRowView)e.Item.DataItem;
                //if (Convert.ToString(DataBinder.Eval(dbr, "Descargado")) == "True")
                //{
                //    ((LinkButton)e.Item.FindControl("lbtnDescargar")).Visible = false;
                //    ((LinkButton)e.Item.FindControl("lbtnValorar")).Visible = true;
                //}
                //else
                //{
                //    ((LinkButton)e.Item.FindControl("lbtnDescargar")).Visible = true;
                //    ((LinkButton)e.Item.FindControl("lbtnValorar")).Visible = false;
                //}
                string libro = Convert.ToString(DataBinder.Eval(dbr, "Titulo"));
                string libroFisico = Convert.ToString(DataBinder.Eval(dbr, "LibroFisico"));
                prepareBook(libroFisico);
                libro = libro.Replace(" ", "_");
                var pathReading = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/"));
                if (!Directory.Exists(pathReading.ToString()))
                {
                    Directory.CreateDirectory(pathReading.ToString());

                }
                if (!File.Exists(System.IO.Path.Combine(pathReading.ToString(), libro + ".txt")))
                {
                    StreamWriter writer = new StreamWriter(System.IO.Path.Combine(pathReading.ToString(), libro + ".txt"));
                    writer.WriteLine("1");
                    writer.Close();
                }
                string ruta = System.IO.Path.Combine(pathReading.ToString(), libro);
                StreamReader reader = File.OpenText(ruta + ".txt");
                page = reader.ReadLine();
                reader.Close();

                if (page == "1")
                {
                    porcentajeLeído = 0;
                    ((Label)e.Item.FindControl("lblPage")).Text = page;
                    pintarProgress(e, porcentajeLeído);
                }
                else
                {
                    porcentajeLeído = Convert.ToInt32(page) * 100 / numberOfPages;
                    if (porcentajeLeído == 100) //Si ya terminó de leer el libro entonces
                    {
                        ((Label)e.Item.FindControl("lblInfo")).Text = "Terminaste de leer!";
                        ((Label)e.Item.FindControl("lblPage")).Visible = false;
                        ((Label)e.Item.FindControl("lblPage")).Text = "F";
                        pintarProgress(e, porcentajeLeído);
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("lblInfo")).Visible = false;
                        ((Label)e.Item.FindControl("lblPage")).Text = page;
                        pintarProgress(e, porcentajeLeído);
                    }

                }

            }
        }
        private void pintarProgress(RepeaterItemEventArgs e, int porcentajeLeido)
        {
            ((Panel)e.Item.FindControl("pnlProgress")).Attributes["aria-valuemin"] = "0";
            ((Panel)e.Item.FindControl("pnlProgress")).Attributes["aria-valuemax"] = "100";
            ((Panel)e.Item.FindControl("pnlProgress")).Attributes["aria-valuenow"] = porcentajeLeído.ToString();
            ((Panel)e.Item.FindControl("pnlProgress")).Style["width"] = String.Format("{0}%;", porcentajeLeído);
            ((Panel)e.Item.FindControl("pnlProgress")).Controls.Add(new LiteralControl(String.Format("{0}% leído", porcentajeLeído)));
        }
    }
}