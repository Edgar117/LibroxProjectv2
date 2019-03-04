using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text;
using System.IO;
using System.Net;
using System.Text;
using iTextSharp.text.pdf.parser;

namespace Librox2.WriterCreations
{
    public partial class Creator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]==null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                pnlWritter.Visible = false;
                try
                {
                    String[] cart1 = (String[])Session["ALL"];
                    getBooks();
                    pnlGeneral.Visible = true;
                    if (Session["FaceLogin"] != null)
                    {
                        ImagenUsuario.Src = Session["FaceLogin"].ToString();
                        //Imagen.Src = Session["FaceLogin"].ToString();
                    }
                    else
                    {
                        ImagenUsuario.Src = "/images/Users/" + cart1[2].ToString();
                        //Imagen.Src = "/images/Users/" + cart1[2].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                    throw;
                }
            }
            
        }
        private void getBooks()
        {
            var pathCreations = Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Creations/");
            if (!Directory.Exists(pathCreations.ToString()))
            {
                Directory.CreateDirectory(pathCreations.ToString());
            }
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Creations/"), "*.pdf");
            List<System.Web.UI.WebControls.ListItem> files = new List<System.Web.UI.WebControls.ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new System.Web.UI.WebControls.ListItem(Path.GetFileName(filePath), filePath));
            }
            Repeater1.DataSource = files;
            Repeater1.DataBind();
            string[] user = Session["Usuario"].ToString().Split(' ');
            if (files.Count > 0)
            {
                lblUser.Text = "Hola, " + user[0] + ". Estas son tus creaciones";
            }
            else {
                lblUser.Text = "Hola, " + user[0] + ". Parece que no tienes creaciones por ahora, empieza a escribir!";
            }
            lblUserP.Text = user[0];
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                lblWar.Text = "Escribe un título para guardar";
                pnlGeneral.Visible = false;
                pnlWritter.Visible = true;
                LinkButton1.Visible = true;
            }
            else
            {
                writeBook();
                LinkButton1.Visible = false;
                lbtnNew.Visible = true;
            }
        }
        private void writeBook()
        {
            try
            {
                Document doc = new Document(PageSize.LETTER);
                // Indicamos donde vamos a guardar el documento
                string pathDest = Server.MapPath("~/LibrosPortadas/" + Session["Usuario"] + "/Creations/" + txtTitulo.Text.Trim()) + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(pathDest, FileMode.Create));

                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle("Mi primer PDF");
                doc.AddCreator("Roberto Torres");

                // Abrimos el archivo
                doc.Open();

                // Escribimos el encabezamiento en el documento
                doc.Add(new Paragraph(txtContent.Text));
                doc.Add(Chunk.NEWLINE);

                doc.Close();
                writer.Close();
                LinkButton1.Visible = false;
                if (File.Exists(lblHelp.Text) && lblHelp.Text != pathDest)
                {
                    File.Delete(lblHelp.Text);
                }
                Response.Redirect(Request.Url.AbsoluteUri);

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                //throw;
            }
        }
        public string ReadPdfFile(string fileName)
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(fileName))
            {
                Label1.Text = "Continúa desde donde lo dejaste...";
                PdfReader pdfReader = new PdfReader(fileName);

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }
                pdfReader.Close();
            }
            return text.ToString();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                string filePath = ((Label)item.FindControl("lblValue")).Text;
                pnlGeneral.Visible = false;
                pnlWritter.Visible = true;
                string titulo = ((LinkButton)item.FindControl("lbtnTitulo")).Text;
                titulo = titulo.Substring(0, titulo.Length - 4);
                txtTitulo.Text = titulo;
                txtContent.Text = ReadPdfFile(filePath);
                LinkButton1.Visible = true;
                lbtnNew.Visible = false;
                lblHelp.Text = filePath;
            }
            if (e.CommandName == "delete")
            {
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                //Script de confirmación, se requiere para poder eliminar el libro, de lo contrario se recarga la página.
                ClientScriptManager CSM = Page.ClientScript;
                if (!ReturnValue())
                {
                    string strconfirm2 = "<script>if(!window.confirm('¿Estás seguro de eliminar tu libro?')){window.location.href='~/WriterCreations/Creator.aspx'}</script>";
                    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm2, false);
                    try
                    {
                        string filePath = ((Label)item.FindControl("lblValue")).Text;
                        File.Delete(filePath);
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + "No se pudo eliminar el libro. Código de error: " + ex.ToString() + "');</script>");
                    }
                }
            }
            if (e.CommandName == "post")
            {
                RepeaterItem item = (RepeaterItem)(((LinkButton)(e.CommandSource)).NamingContainer);
                string filePath = ((Label)item.FindControl("lblValue")).Text;   //Ruta física del PDF en edición
                string titulo = ((LinkButton)item.FindControl("lbtnTitulo")).Text;
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                ht.Add("Path", filePath);
                ht.Add("Titulo", titulo);
                Session["Post"] = ht;
                Response.Redirect("~/WriterCreations/Post.aspx");
            }
        }
        bool ReturnValue()
        {
            return false;
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            pnlGeneral.Visible = false;
            pnlWritter.Visible = true;
            txtTitulo.Text = "";
            txtContent.Text = "";
            lblHelp.Text = "";
            LinkButton1.Visible = true;
            lbtnNew.Visible = false;
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("../Login.aspx");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            //{
            //    if (((LinkButton)e.Item.FindControl("lbtnTitulo")).Text.Contains(".pdf"))
            //    {
            //        string titulo = ((LinkButton)e.Item.FindControl("lbtnTitulo")).Text;
            //        titulo = titulo.Replace(".pdf", " ");
            //        ((LinkButton)e.Item.FindControl("lbtnTitulo")).Text = titulo;
            //    }
            //}
        }
    }
}