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
        String[] cart1 = new String[0];
        LibrosDAO books = new LibrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                string idPago = ((Label)item.FindControl("lblIDPago")).Text;
                string rutaFisico = ((Label)item.FindControl("lblFisico")).Text;
                books.UpdCampoDescargado(idPago, "");
                prepareBook(rutaFisico);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        private void prepareBook(string encriptedPath)
        {
            //Método que se ocupa para prepara el archivo de muestra con páginas limitadas
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
            dwdBook(output);
        }

        protected void dwdBook(string book)
        {
            //Abre archivo de muestra en el explorador
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(book);
            if (FileBuffer != null)
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", Path.GetFileName(book)));
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("Content-Disposition",
                //    "attachment; filename=\"" + Path.GetFileName(book) + "\"");
                Response.TransmitFile(book);
                Response.End();
            }
        }

        protected void rptCompras_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView dbr = (DataRowView)e.Item.DataItem;
                if (Convert.ToString(DataBinder.Eval(dbr, "Descargado")) == "True")
                {
                    ((LinkButton)e.Item.FindControl("lbtnDescargar")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lbtnValorar")).Visible = true;
                }
                else
                {
                    ((LinkButton)e.Item.FindControl("lbtnDescargar")).Visible = true;
                    ((LinkButton)e.Item.FindControl("lbtnValorar")).Visible = false;
                }
            }
        }
    }
}