﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
using System.Data;

namespace Librox2.Forms
{
    public partial class Read : System.Web.UI.Page
    {
        string book = "";
        string desencrypetdBook = "";
        string tit = "";
        int page = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                book = Request.QueryString["read"];
                tit = Request.QueryString["tit"];
                tit = tit.Replace(" ", "_");
                page = Convert.ToInt32(Request.QueryString["track"]);
                if (page == 1)
                {
                    lbtnBack1.Enabled = false;
                    lbtnBack2.Enabled = false;
                    lbtnNext.Enabled = true;
                    lbtnNext1.Enabled = true;
                    prepareBook(book);  //Este método desencadena 2 métodos consecuentes (desencriptado y lectura de la primera página)
                    if (isRead(page))
                    {
                        lbtnNext.Enabled = false;
                        lbtnNext1.Enabled = false;
                        lbtnBack1.Enabled = false;
                        lbtnBack2.Enabled = false;
                    }
                }
                else
                {
                    //No es la página 1
                    book = Server.MapPath("~/LibrosPortadas/" + book + ".pdf");
                    getNextPage(book, page);
                    //Puede retroceder
                    lbtnBack1.Enabled = true;
                    lbtnBack2.Enabled = true;
                    //Verifica si puede avanzar
                    determinePaginas(book); //Pinta total de páginas en labelPaginas
                    if (page < int.Parse(lblPaginas.Text))
                    {
                        lbtnNext.Enabled = true;
                        lbtnNext1.Enabled = true;
                    }
                    if (page == int.Parse(lblPaginas.Text))
                    {
                        //No puede avanzar
                        lbtnNext.Enabled = false;
                        lbtnNext1.Enabled = false;
                        lbtnBack1.Enabled = true;
                        lbtnBack2.Enabled = true;
                    }
                }
                getBookDetails();
            }
            else
            {
                book = Request.QueryString["read"];
                tit = Request.QueryString["tit"];
                tit = tit.Replace(" ", "_");
            }
        }
        private void getContenido(string book)
        {
            page = Convert.ToInt32(Request.QueryString["track"]);
            if (File.Exists(book))
            {
                string texto = "";
                lblTexto.Text = "";
                string ExtractedData = string.Empty;

                PdfReader reader = new PdfReader(book);

                ITextExtractionStrategy strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();

                ExtractedData = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                try
                {
                    string[] lineas = ExtractedData.Split('\n');
                    //StringBuilder db = new StringBuilder();
                    if (lineas.Length > 0)
                    {
                        foreach (string line in lineas)
                        {
                            texto += line + "\n";
                        }
                        lblTexto.Text = texto.Replace("\n", "<br/>");
                    }
                    else
                    {
                        lblTexto.Text = ExtractedData;
                    }
                }
                catch (Exception)
                {
                    lblTexto.Text = ExtractedData;
                }
                StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
                writer.WriteLine(page);
                writer.Close();
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
            desencrypetdBook = output;
            getContenido(output);
            determinePaginas(output);
            //Response.Redirect("~/Forms/Read.aspx?read=" + output);
            //dwdBook(output);
        }
        protected void determinePaginas(string archivoMuestra)
        {
            PdfReader pdfReader = new PdfReader(archivoMuestra);
            lblPaginas.Text = pdfReader.NumberOfPages.ToString();
        }

        protected void lbtnSalir_Click(object sender, EventArgs e)
        {
            StreamReader reader = File.OpenText(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
            int pagina = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
            writer.WriteLine(pagina);
            writer.Close();
            Response.Redirect("~/Forms/MisCompras.aspx");
        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            StreamReader reader = File.OpenText(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
            int pagina = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            pagina++;
            StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
            writer.WriteLine(pagina);
            writer.Close();
            //book = Server.MapPath("~/LibrosPortadas/"+book+".pdf");
            //getNextPage(book, pagina);
            Response.Redirect("~/Forms/Read.aspx?read=" + book + "&tit=" + tit + "&track=" + pagina);
        }
        protected void getNextPage(string book, int page)
        {

            if (File.Exists(book))
            {
                string texto = "";
                lblTexto.Text = "";
                string ExtractedData = string.Empty;
                PdfReader reader = new PdfReader(book);
                ITextExtractionStrategy strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                ExtractedData = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                string[] lineas = ExtractedData.Split('\n');
                StringBuilder db = new StringBuilder();
                foreach (string line in lineas)
                {
                    texto += line + "\n";
                }
                lblTexto.Text = texto.Replace("\n", "<br/>");
                StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
                writer.WriteLine(page);
                writer.Close();
            }
        }
        private bool isRead(int page)
        {
            if (page == Convert.ToInt32(lblPaginas.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void getBookDetails()
        {
            string libro = Request.QueryString["tit"];
            libro = libro.Replace("_", " ");
            LibrosDAO book = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = book.ConsultarLibrosXNombreLibro(libro);
            titulo.InnerText = dt.Rows[0][0].ToString();
            lblAutor.Text = dt.Rows[0][2].ToString();
            lblSinop.Text = dt.Rows[0][1].ToString();
            imgPerfil.Src = "https://www.escribox.com/LibrosPortadas/" + dt.Rows[0][3].ToString();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            StreamReader reader = File.OpenText(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
            int pagina = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            pagina--;
            StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Reading/" + tit + ".txt"));
            writer.WriteLine(pagina);
            writer.Close();
            //book = Server.MapPath("~/LibrosPortadas/"+book+".pdf");
            //getNextPage(book, pagina);
            Response.Redirect("~/Forms/Read.aspx?read=" + book + "&tit=" + tit + "&track=" + pagina);
        }

    }
}