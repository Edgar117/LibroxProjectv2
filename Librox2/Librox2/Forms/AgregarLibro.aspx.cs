using System;
using System.IO;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Librox2.BO;
using Librox2.DAO;
using System.Web.UI;

namespace Librox2.GUI
{
    public partial class AgregarLibro : System.Web.UI.Page
    {
        CategoriaDAO DAOCategorias = new CategoriaDAO();
        EstatusLibroDAO DAOStatusLibros = new EstatusLibroDAO();
        LibrosDAO DAOLibros = new LibrosDAO();
        LibrosBO OBLibros = new LibrosBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    SaveUploadedFile(Request.Files);
                    LoadCategorias();
                    LoadStatusLibros();
                }
                catch (Exception)
                {
                    Response.Redirect("../Login.aspx");
                }
                 
               
            }
        }

        private void LoadCategorias()
        {
            // llenamos el dropdownlist de acuerdo a las categorias Disponibles (Visibles en el admin)
            this.dpCategorias.DataSource = DAOCategorias.ConsultarCategoriasLibrosVista();//Metodo que consulta las categorias disponibles para el usuario
            this.dpCategorias.DataValueField = "NombreCategoria";//Nombre que tiene el field en la base de datos
            this.dpCategorias.DataTextField = "NombreCategoria";//Nombre que tendra en el Drop
            this.dpCategorias.DataBind();//Se le pasa los datos para que se llene de nuevo
        }
        private void LoadStatusLibros()
        {
            // llenamos el dropdownlist de acuerdo a las categorias Disponibles (Visibles en el admin)
            this.dpStatusLibro.DataSource = DAOStatusLibros.ConsultarStatusLibrosVista();//Metodo que consulta las categorias disponibles para el usuario
            this.dpStatusLibro.DataValueField = "ID";//Nombre que tiene el field en la base de datos
            this.dpStatusLibro.DataTextField = "NombreEstatus";//Nombre que tendra en el Drop
            this.dpStatusLibro.DataBind();//Se le pasa los datos para que se llene de nuevo
        }
        public void SaveUploadedFile(HttpFileCollection httpFileCollection)
        {
            int i = 0;
            string Variable = Session["Usuario"].ToString();
            //  bool isSavedSuccessfully = true;
            string fName = "";
            foreach (string fileName in httpFileCollection)
            {
                //while (i <= 2)
                //{
                    HttpPostedFile file = httpFileCollection.Get(fileName);
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/"+Variable+"/"));
                        if (!Directory.Exists(originalDirectory.ToString()))
                        {
                            Directory.CreateDirectory(originalDirectory.ToString());
                        }
                        string pathString = originalDirectory.ToString();
                        var FileNameVerify = Path.GetFileName(file.FileName);//Lo estoy usando para verificar algo
                        var fileName1 = Path.GetFileNameWithoutExtension(file.FileName);    //Cambié esta instrucción para obtener solo el nombre del archivo, sin la extensión.
                        if (FileNameVerify.Contains(".pdf") || FileNameVerify.Contains(".PDF"))
                        {
                            //Solo el pdf necesitamos encriptar
                            string encryptedName = fileName1 + "_encrypted";    //Se asigna el nombre que tendrá el archivo ya encriptado
                            string pathDestino = pathString + encryptedName;    //Se combinan las rutas para indicar en dónde se guardará el archivo encriptado
                            EncryptFile(file, pathDestino); //Llamada al método para encriptar archivo
                            Session["LibroFisico"] = Variable + "/"+ fileName1;
                    }
                        else
                        {
                            Session["ImagenPortada"] = Variable + "/"+ FileNameVerify.ToString() ;
                            var path = string.Format("{0}\\{1}", pathString, file.FileName);
                            file.SaveAs(path);  //Guarda el archivo físico original en servidor
                        }                  
                          //Después de encriptar... sería óptimo borrar el archivo original? O sería mucho uso de memoria? Por el hecho de leer y escribir en servidor.
                    }
                    i++;
                //}
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
        private void DecryptFile()
        {
            //Próximamente la rutina para desencriptar el archivo... Espero ya este lista >:v
        }
        private void ObtenerDatos()
        {
            OBLibros.Titulo = txtNombre.Value;
            OBLibros.Sinpsis = txtSinopsis.Value;
            OBLibros.LibroFisico = Session["LibroFisico"].ToString();
            OBLibros.ImagenPòrtada = Session["ImagenPortada"].ToString();
            OBLibros.Categoria = dpCategorias.Text;
            OBLibros.EstatusLibro = int.Parse(dpStatusLibro.SelectedValue);
        }
        protected void btnRegistrarLibro_Click(object sender, EventArgs e)
        {
            try
            {
            String[] cart1 = new String[0];
            cart1 = (String[])Session["ALL"];
            OBLibros.Autor_ID = (cart1[5]).ToString();
            ObtenerDatos();
            if (DAOLibros.SaveBook(OBLibros)==1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "LibroGuardado();", true);
                    limpiarFormulario();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroFailLibro();", true);
            }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "RegistroFailLibro();", true);
            }

        }
        private void limpiarFormulario()
        {
            txtNombre.Value = "";
            txtSinopsis.Value = "";    
        }
    }
}