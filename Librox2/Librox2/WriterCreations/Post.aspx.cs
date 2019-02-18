using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Librox2.BO;
using Librox2.DAO;
using System.Security.Cryptography;


namespace Librox2.WriterCreations
{
    public partial class Post : System.Web.UI.Page
    {
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        EstatusLibroDAO DAOStatusLibros = new EstatusLibroDAO();
        LibrosDAO DAOLibros = new LibrosDAO();
        LibrosBO OBLibros = new LibrosBO();
        string file = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Post"] == null && Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadCategorias();
                    LoadStatusLibros();
                    System.Collections.Hashtable ht = new System.Collections.Hashtable();
                    ht = (System.Collections.Hashtable)Session["Post"];
                    //txtTitulo.Text = Convert.ToString(ht["Titulo"]);
                    file = Convert.ToString(ht["Titulo"]);
                }
                
            }

        }
        private void LoadCategorias()
        {
            // llenamos el dropdownlist de acuerdo a las categorias Disponibles (Visibles en el admin)
            this.ddlCategorias.DataSource = DAOCategorias.ConsultarCategoriasLibrosVista();//Metodo que consulta las categorias disponibles para el usuario
            this.ddlCategorias.DataValueField = "NombreCategoria";//Nombre que tiene el field en la base de datos
            this.ddlCategorias.DataTextField = "NombreCategoria";//Nombre que tendra en el Drop
            this.ddlCategorias.DataBind();//Se le pasa los datos para que se llene de nuevo
        }
        private void LoadStatusLibros()
        {
            // llenamos el dropdownlist de acuerdo a las categorias Disponibles (Visibles en el admin)
            this.ddlEstatus.DataSource = DAOStatusLibros.ConsultarStatusLibrosVista();//Metodo que consulta las categorias disponibles para el usuario
            this.ddlEstatus.DataValueField = "ID";//Nombre que tiene el field en la base de datos
            this.ddlEstatus.DataTextField = "NombreEstatus";//Nombre que tendra en el Drop
            this.ddlEstatus.DataBind();//Se le pasa los datos para que se llene de nuevo
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            copyBook(file);
            savePic();
            //ObtenerDatos();
            try
            {
                String[] cart1 = new String[0];
                cart1 = (String[])Session["ALL"];
                OBLibros.Autor_ID = (cart1[5]).ToString();
                ObtenerDatos();
                if (DAOLibros.SaveBook(OBLibros) == 1)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "LibroGuardado();", true);
                    Response.Redirect("~/WriterCreations/Creator.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroFailLibro();", true);
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroFailLibro();", true);
                throw ex;
            }
        }
        private void copyBook(string file)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht = (System.Collections.Hashtable)Session["Post"];
            if (String.IsNullOrEmpty(file))
            {
                file = Convert.ToString(ht["Titulo"]);
            }
            string variable = Session["Usuario"].ToString();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + variable + "/"));
            var fromDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + variable + "/Creations/"));
            //Se crea el directorio LibrosPortadas/Usuario/ por si es la primera vez
            if (!Directory.Exists(originalDirectory.ToString()))
            {
                Directory.CreateDirectory(originalDirectory.ToString());
            }
            string sourceFile = System.IO.Path.Combine(fromDirectory.ToString(), file);
            string destFile = System.IO.Path.Combine(originalDirectory.ToString(), file);
            Session["LibroFisico"] = variable + "/" + file.Substring(0, file.Length - 4);   //Quita el ".pdf"
            //System.IO.File.Copy(sourceFile, destFile, true);
            EncryptFile(sourceFile, destFile);
            ObtenerDatos();
        }
        private void savePic()
        {
            string variable = Session["Usuario"].ToString();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + variable + "/"));
            string pathString = originalDirectory.ToString();
            if (fuImg.HasFile) // Si el usuario tiene un archivo
            {
                //DeletePhoto();
                string filename2 = Path.GetFileName(fuImg.FileName);
                var path = string.Format("{0}\\{1}", pathString, fuImg.FileName);//Formamos la ruta donde se guardará la imagen
                fuImg.SaveAs(path);
            }
               

        }
        private void ObtenerDatos()
        {
            OBLibros.Titulo = txtTitulo.Text;
            OBLibros.Sinpsis = txtSinop.Text;
            OBLibros.LibroFisico = Session["LibroFisico"].ToString();
            OBLibros.ImagenPòrtada = Session["Usuario"].ToString() + "/" + fuImg.FileName;
            OBLibros.Categoria = ddlCategorias.Text;
            OBLibros.EstatusLibro = int.Parse(ddlEstatus.SelectedValue);
        }
        private void EncryptFile(string inputfile, string outputfile)
        {
            outputfile = outputfile.Substring(0, outputfile.Length - 4) + "_encrypted";
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

                FileStream fsIn = new FileStream(inputfile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)  //Escribe los bytes
                    cs.WriteByte((byte)data);   //Va construyendo de nuevo el archivo

                //Se cierran las instancias abiertas
                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
            }
        }
    }
}