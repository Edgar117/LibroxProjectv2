﻿using System;
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

namespace Librox2.Forms
{
    public partial class LibrosDetails : System.Web.UI.Page
    {
        LibrosDAO DAOLibros = new LibrosDAO();
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        ComentariosBO comentarios = new ComentariosBO();
        DataTable dt = new DataTable();
        string titulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"]==null)
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
                    //prepareMuestra();
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
            comentarios.Comentarios = txtComment.Text;
            comentarios.Libro = lblTitulo.Text;
            comentarios.Usuario = Session["Usuario"].ToString();
            DAOLibros.InsertarComentarios(comentarios);
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            //bindComments();
        }
        private void prepareMuestra() {
            //Método que se ocupa para prepara el archivo de muestra con páginas limitadas
            DataTable dtBooks = new DataTable();
            dtBooks = DAOLibros.ConsultarLibrosXTexto(lblTitulo.Text);
            string libroFisico = dtBooks.Rows[0]["LibroFisico"].ToString();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + libroFisico + "_encrypted"));
            string input = originalDirectory.ToString();
            string output = Server.MapPath("~/LibrosPortadas/" + libroFisico + ".pdf");
            decryptBook(input, output);
            determinePaginas(output);
        }

        protected void lbtnPrueba_Click(object sender, EventArgs e)
        {
            prepareMuestra();
        }
        protected void decryptBook(string input, string output) {
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
            lblPages.Text = numberOfPages.ToString() + " páginas";
        }
    }
}