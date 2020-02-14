using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Librox2.DAO;
using Librox2.BO;
using System.Data;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using System.ServiceModel;

namespace Librox2.WebServices
{
    /// <summary>
    /// Descripción breve de ApiService
    /// </summary>
    [WebService(Namespace = "https://www.escribox.com/WebServices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ApiService : System.Web.Services.WebService
    {

        JavaScriptSerializer ser = new JavaScriptSerializer();

        //Metodos insert
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertUserApi(string Nombre, string User, string Email, string FechaNaci, string Pass, string DescriptionUser)
        {
            UsuarioBO ObUsuario = new UsuarioBO();
            UsuariosDAO Register = new UsuariosDAO();
            Security OBSecurity = new Security();
            string contraseña = "";
            contraseña = OBSecurity.encrypt(Pass);
            ObUsuario.Contraseña = contraseña;
            //ObUsuario.Cumpleaños = "";
            ObUsuario.Correo = Email;
            ObUsuario.Nombre = Nombre;
            ObUsuario.Usuario = User;
            int TU = 0;
            TU = ObUsuario.TipoUsuario;
            ObUsuario.DescriptionUser = DescriptionUser;
            ObUsuario.Cumpleaños = FechaNaci;
            //string Result =Register.SaveUserRegister(ObUsuario).ToString();
            JsonResult OBJson = new JsonResult
            { Result = Register.SaveUserRegister(ObUsuario) };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertComentarioLibro(string IDLibro, string User, string Comentario)
        {
            LibrosDAO OBLibros = new LibrosDAO();
            //string Result =Register.SaveUserRegister(ObUsuario).ToString();
            JsonResult OBJson = new JsonResult
            { Result = OBLibros.InsertarComentariosApp(User, IDLibro, Comentario) };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetAllBooks()
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarLibrosApp();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetBooksByName(string NameBook)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarLibrosByNameApp(NameBook);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }

        //Mis Ventas
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMysales(string IDUser)
        {
            UsuariosDAO DAOLibros = new UsuariosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.GetMysales(IDUser);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCommentByBook(string NameBook)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarComentariosByNameApp(NameBook);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDetailByIDBook(string IDBook)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarLibrosXIDApp(IDBook);
            string libroFisico = dt.Rows[0]["LibroFisico"].ToString();
            string Paginas = prepareMuestra(libroFisico);
            LibroDetalleBO OBJson = new LibroDetalleBO
            { IDLibro = dt.Rows[0]["IDLibro"].ToString(), FotoAutor = dt.Rows[0]["FotoAutor"].ToString(), Autor = dt.Rows[0]["Autor"].ToString(), PRECIO = int.Parse(dt.Rows[0]["PRECIO"].ToString()), Titulo = dt.Rows[0]["Titulo"].ToString(), Categoria = dt.Rows[0]["Categoria"].ToString(), LibroPortada = dt.Rows[0]["LibroPortada"].ToString(), NombreEstatus = dt.Rows[0]["NombreEstatus"].ToString(), Ranking = int.Parse(dt.Rows[0]["Ranking"].ToString()), Sinopsis = dt.Rows[0]["Sinopsis"].ToString(), TotalPaginas = Paginas };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void prepareMuestraApp(string IDLibro)
        {
            LibrosDAO a = new LibrosDAO();
            DataTable DT = new DataTable();
            DT = a.ConsultarLibroDescargaApp(IDLibro);
            string libroFisico = DT.Rows[0]["LibroFisico"].ToString();
            string book = Server.MapPath("~/LibrosPortadas/" + libroFisico + ".pdf");
            string muestraLimitada = Server.MapPath("~/LibrosPortadas/" + libroFisico + "_trial.pdf");
            string mensaje = extraerPaginas(book, muestraLimitada);
            if (mensaje != "El libro no tiene suficientes páginas para generar una muestra")
            {
                mensaje = "https://www.escribox.com/LibrosPortadas/" + libroFisico + "_trial.pdf";
            }
            RutaLibroBO OBJson = new RutaLibroBO
            { RutaLibro = mensaje };
            string outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMiBooksBuy(string IDUser)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarBiblotecaUsuario(IDUser);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ValorarLibro(string IDUser, string IDLibro, string IDPago, string Valor)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            string outputJSON;
            int value = 0;
            try
            {
                DAOLibros.UpdRantingLibros(int.Parse(IDPago), int.Parse(IDUser), int.Parse(IDLibro), int.Parse(Valor));
                //string test = serializer.Serialize(rows);
                value = 1;
            }
            catch (Exception)
            {
                value = 0;
            }
            JsonResult OBJson = new JsonResult
            { Result = value };
            outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }

        //Metodo para leer el libro descargado
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetLecturaLibro(string LibroFisico, string UserName, string NameBook)
        {
            UsuariosDAO User = new UsuariosDAO();
            UserName = User.GetUserName(UserName);
            string outputJSON;
            prepareBook(LibroFisico);  //Este método desencadena 2 métodos consecuentes (desencriptado y lectura de la primera página)
            var pathReading = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + UserName + "/Reading/"));
            if (!Directory.Exists(pathReading.ToString()))
            {
                Directory.CreateDirectory(pathReading.ToString());

            }
            string libro = "";
            libro = NameBook.Replace(" ", "_");
            if (!File.Exists(System.IO.Path.Combine(pathReading.ToString(), libro + ".txt")))
            {
                StreamWriter writer = new StreamWriter(System.IO.Path.Combine(pathReading.ToString(), libro + ".txt"));
                writer.WriteLine("1");
                writer.Close();
            }
            string ruta = System.IO.Path.Combine(pathReading.ToString(), libro);
            StreamReader reader = File.OpenText(ruta + ".txt");
            string page = reader.ReadLine();
            reader.Close();
            string Lectura;
            if (int.Parse(page) == 1)
            {
                LibroFisico = Server.MapPath("~/LibrosPortadas/" + LibroFisico + ".pdf");
                Lectura = getNextPage(LibroFisico, int.Parse(page), UserName, NameBook);
                determinePaginas(LibroFisico); //Pinta total de páginas en labelPaginas
            }
            else
            {
                //No es la página 1
                LibroFisico = Server.MapPath("~/LibrosPortadas/" + LibroFisico + ".pdf");
                Lectura = getNextPage(LibroFisico, int.Parse(page), UserName, NameBook);
                determinePaginas(LibroFisico); //Pinta total de páginas en labelPaginas
            }
            //getBookDetails();
            ReadBookClass OBJson = new ReadBookClass
            { TextoLibro = Lectura };
            outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }
        //Metodo para leer el libro descargado ya sea anterior o despues
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetLecturaLibroAfterBefore(string LibroFisico, string UserName, string NameBook, string Accion)
        {
            UsuariosDAO User = new UsuariosDAO();
            UserName = User.GetUserName(UserName);
            if (Accion == "1")
            {
                string LibroFisicoTest = Server.MapPath("~/LibrosPortadas/" + LibroFisico + ".pdf");
                string PaginasTotal = determinePaginasEntero(LibroFisicoTest);
                EscribeNextPaginaBook(UserName, NameBook, PaginasTotal);
            }
            else
            {

                EscribeAnteriorPaginaBook(UserName, NameBook);
            }
            string outputJSON;
            prepareBook(LibroFisico);  //Este método desencadena 2 métodos consecuentes (desencriptado y lectura de la primera página)
            var pathReading = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + UserName + "/Reading/"));
            if (!Directory.Exists(pathReading.ToString()))
            {
                Directory.CreateDirectory(pathReading.ToString());

            }
            string libro = "";
            libro = NameBook.Replace(" ", "_");
            if (!File.Exists(System.IO.Path.Combine(pathReading.ToString(), libro + ".txt")))
            {
                StreamWriter writer = new StreamWriter(System.IO.Path.Combine(pathReading.ToString(), libro + ".txt"));
                writer.WriteLine("1");
                writer.Close();
            }
            string ruta = System.IO.Path.Combine(pathReading.ToString(), libro);
            StreamReader reader = File.OpenText(ruta + ".txt");
            string page = reader.ReadLine();
            reader.Close();
            string Lectura;
            if (int.Parse(page) == 1)
            {
                LibroFisico = Server.MapPath("~/LibrosPortadas/" + LibroFisico + ".pdf");
                Lectura = getNextPage(LibroFisico, int.Parse(page), UserName, NameBook);
                determinePaginas(LibroFisico); //Pinta total de páginas en labelPaginas
            }
            else
            {
                //No es la página 1
                LibroFisico = Server.MapPath("~/LibrosPortadas/" + LibroFisico + ".pdf");
                Lectura = getNextPage(LibroFisico, int.Parse(page), UserName, NameBook);
                determinePaginas(LibroFisico); //Pinta total de páginas en labelPaginas
            }
            //getBookDetails();
            ReadBookClass OBJson = new ReadBookClass
            { TextoLibro = Lectura };
            outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }



        //********************Paypal Metodos ******************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ProcesarPagoPaypal(string IDUser, string Precio, string NombreLibro)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            string outputJSON;
            int value = 0;
            try
            {
                LibrosBO Olibros = new LibrosBO();
                Olibros.Titulo = NombreLibro;
                Olibros.Precio = Precio;
                //Codigo nuevo para enviar desde el detalle.
                string IDIns = DAOLibros.ProcesarLibroPaypal(Olibros, int.Parse(IDUser));
                //string test = serializer.Serialize(rows);
                value = int.Parse(IDIns);
            }
            catch (Exception)
            {
                value = 0;
            }
            JsonResult OBJson = new JsonResult
            { Result = value };
            outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdatePagoPaypal(string IDVenta, string OrderID)
        {
            LibrosDAO DAOLibros = new LibrosDAO();
            DataTable dt = new DataTable();
            string outputJSON;
            int value = 0;
            try
            {
                DAOLibros.UpdEstatusVentaPaypal(IDVenta, OrderID);
                value = 1;
            }
            catch (Exception)
            {
                value = 0;
            }
            JsonResult OBJson = new JsonResult
            { Result = value };
            outputJSON = ser.Serialize(OBJson);
            Context.Response.Write(ser.Serialize(OBJson));
        }
        //******************** END Paypal Metodos ******************************
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void RegistrarLibro(string PdfBase64,string ImagenBase64,string NombreLibro,string IDUsuario)
        //{
        //    LibrosDAO DAOLibros = new LibrosDAO();
        //    DataTable dt = new DataTable();
        //    string outputJSON;
        //    int value = 0;
        //    byte[] sPDFDecoded = Convert.FromBase64String(PdfBase64);
        //    UsuariosDAO User = new UsuariosDAO();
        //   string UserName = User.GetUserName(IDUsuario);
        //    var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + UserName + "/"));
        //    if (!Directory.Exists(originalDirectory.ToString()))
        //    {
        //        Directory.CreateDirectory(originalDirectory.ToString());
        //    }
        //    string pathString = originalDirectory.ToString();
        //    File.WriteAllBytes(@"c:\Users\u316383\Documents\pdf8.pdf", sPDFDecoded);
        //    JsonResult OBJson = new JsonResult
        //    { Result = value };
        //    outputJSON = ser.Serialize(OBJson);
        //    Context.Response.Write(ser.Serialize(OBJson));
        //}


        //Metodo insertar un libro desde la app
        //Metodos insert
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsBookApp(byte[] LibroPDF, byte[] ImagenLibro, string FileNamePic, string NombreLibro, string NombreUsuario, string sinopsis, string Categoria, int EstatusLibro)
        {
            LibrosBO Olibros = new LibrosBO();
            LibrosDAO DaoLibros = new LibrosDAO();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + NombreUsuario + "/"));
            //Verificamos si existe el directorio
            if (!Directory.Exists(originalDirectory.ToString()))
            {
                Directory.CreateDirectory(originalDirectory.ToString());
            }
            var fileName1 = NombreLibro;    //Cambié esta instrucción para obtener solo el nombre del archivo, sin la extensión.
            //Solo el pdf necesitamos encriptar
            string encryptedName = fileName1 + "_encrypted";    //Se asigna el nombre que tendrá el archivo ya encriptado
            string pathDestino = originalDirectory.ToString() + encryptedName;    //Se combinan las rutas para indicar en dónde se guardará el archivo encriptado
            EncryptFile(LibroPDF, pathDestino); //Llamada al método para encriptar archivo

            //Hasta aqui ya se guardo el archivo

            Olibros.Titulo = NombreLibro;
            Olibros.Sinpsis = sinopsis;
            Olibros.LibroFisico = NombreUsuario + "/" + fileName1;
            Olibros.ImagenPòrtada = NombreUsuario + "/" + NombreUsuario + "_" + FileNamePic;
            Olibros.Categoria = Categoria;
            Olibros.EstatusLibro = EstatusLibro;


            //Guardamos la imagen
            var path = string.Format("{0}\\{1}", originalDirectory.ToString(), NombreUsuario + "_" + FileNamePic);
            File.WriteAllBytes(path, ImagenLibro);
            UsuariosDAO DaoUser = new UsuariosDAO();
            Olibros.Autor_ID = DaoUser.GetUserIDByName(NombreUsuario);
            string outputJSON;
            try
            {

                if (DaoLibros.SaveBook(Olibros) == 1)
                {
                    JsonResult OBJson = new JsonResult
                    { Result = 1 };
                    outputJSON = ser.Serialize(OBJson);
                    Context.Response.Write(ser.Serialize(OBJson));
                }
            }
            catch (Exception)
            {
                JsonResult OBJson = new JsonResult
                { Result = 0 };
                outputJSON = ser.Serialize(OBJson);
                Context.Response.Write(ser.Serialize(OBJson));

            }

        }

        //Metodo imagen API
        //[OperationContract]
        //[WebMethod(methp = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertImagePost(string FileNameWithExtencion, string ImageBase64, string UserName)
        {
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + UserName + "/"));
            if (!Directory.Exists(originalDirectory.ToString()))
            {
                Directory.CreateDirectory(originalDirectory.ToString());
            }
            try
            {
                string saveImagePath = Server.MapPath("~/LibrosPortadas/" + UserName + "/") + FileNameWithExtencion;
                byte[] bytes = Convert.FromBase64String(ImageBase64);
                File.WriteAllBytes(saveImagePath, bytes);
                JsonResult OBJson = new JsonResult
                { Result = 1 };
                string outputJSON = ser.Serialize(OBJson);
                Context.Response.Write(ser.Serialize(OBJson));
            }
            catch (Exception)
            {

                JsonResult OBJson = new JsonResult
                { Result = 0 };
                string outputJSON = ser.Serialize(OBJson);
                Context.Response.Write(ser.Serialize(OBJson));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertPDFPost(string FileNameWithExtencion, Byte[] PDF, string UserName)
        {
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + UserName + "/"));
            if (!Directory.Exists(originalDirectory.ToString()))
            {
                Directory.CreateDirectory(originalDirectory.ToString());
            }
            try
            {
                string saveImagePath = Server.MapPath("~/LibrosPortadas/" + UserName + "/") + FileNameWithExtencion;
                File.WriteAllBytes(saveImagePath, PDF);
                JsonResult OBJson = new JsonResult
                { Result = 1 };
                string outputJSON = ser.Serialize(OBJson);
                Context.Response.Write(ser.Serialize(OBJson));
            }
            catch (Exception)
            {

                JsonResult OBJson = new JsonResult
                { Result = 0 };
                string outputJSON = ser.Serialize(OBJson);
                Context.Response.Write(ser.Serialize(OBJson));
            }

        }


        //Posible final

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsBookAppFinal(string LibroPDF, string ImagenLibro, string FileNamePic, string NombreLibro, string NombreUsuario, string sinopsis, string Categoria, int EstatusLibro)
        {
            LibrosBO Olibros = new LibrosBO();
            LibrosDAO DaoLibros = new LibrosDAO();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + NombreUsuario + "/"));
            //Verificamos si existe el directorio
            if (!Directory.Exists(originalDirectory.ToString()))
            {
                Directory.CreateDirectory(originalDirectory.ToString());
            }
            var fileName1 = NombreLibro.Replace(" ", "");    //Cambié esta instrucción para obtener solo el nombre del archivo, sin la extensión.
            //Solo el pdf necesitamos encriptar
            string encryptedName = fileName1 + "_encrypted";    //Se asigna el nombre que tendrá el archivo ya encriptado
                                                                //Convertimos a Byte el base 64
            byte[] bytesPDF = Convert.FromBase64String(LibroPDF);
            string pathDestino = originalDirectory.ToString() + encryptedName;    //Se combinan las rutas para indicar en dónde se guardará el archivo encriptado
            EncryptFile(bytesPDF, pathDestino); //Llamada al método para encriptar archivo

            //Hasta aqui ya se guardo el archivo

            Olibros.Titulo = NombreLibro;
            Olibros.Sinpsis = sinopsis;
            Olibros.LibroFisico = NombreUsuario + "/" + fileName1;
            Olibros.ImagenPòrtada = NombreUsuario + "/" + NombreUsuario + "_" + FileNamePic;
            Olibros.Categoria = Categoria;
            Olibros.EstatusLibro = EstatusLibro;


            //Guardamos la imagen
            var path = string.Format("{0}\\{1}", originalDirectory.ToString(), NombreUsuario + "_" + FileNamePic);
            File.WriteAllBytes(path, Convert.FromBase64String(ImagenLibro));
            UsuariosDAO DaoUser = new UsuariosDAO();
            Olibros.Autor_ID = DaoUser.GetUserIDByName(NombreUsuario);
            string outputJSON;
            try
            {

                if (DaoLibros.SaveBook(Olibros) == 1)
                {
                    JsonResult OBJson = new JsonResult
                    { Result = 1 };
                    outputJSON = ser.Serialize(OBJson);
                    Context.Response.Write(ser.Serialize(OBJson));
                }
            }
            catch (Exception)
            {
                JsonResult OBJson = new JsonResult
                { Result = 0 };
                outputJSON = ser.Serialize(OBJson);
                Context.Response.Write(ser.Serialize(OBJson));

            }

        }

        //posible final

        //END Metodo imagen API



        //Metodos generales combos app
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetGategorias()
        {
            CategoriaDAO DAOLibros = new CategoriaDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarCategoriasLibrosVista();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetEstatusLibros()
        {
            EstatusLibroDAO DAOLibros = new EstatusLibroDAO();
            DataTable dt = new DataTable();
            dt = DAOLibros.ConsultarStatusLibrosVista();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            //string test = serializer.Serialize(rows);
            Context.Response.Write(serializer.Serialize(rows));
        }
        //end metodos generales combo app

        //******************Metodos libro generales*************************************
        private string prepareMuestra(string libroFisico)
        {
            //Método que se ocupa para prepara el archivo de muestra con páginas limitadas
            //obtenerLibroFisico();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + libroFisico + "_encrypted"));
            string input = originalDirectory.ToString();
            string output = Server.MapPath("~/LibrosPortadas/" + libroFisico + ".pdf");

            decryptBook(input, output);
            string paginas = determinePaginas(output);
            return paginas;
        }
        protected string extraerPaginas(string archivoMuestra, string outputPdfPath)
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
                    return archivoMuestra;
                }
                //De lo contrario, no es posible generar una muestra, aparece el siguiente mensaje.
                else
                {
                    // lblMuestraNo.Text = 
                    return "El libro no tiene suficientes páginas para generar una muestra"; ;
                }
            }
            catch (Exception ex)
            {
                //lblMuestraNo.Text = "No es posible descargar una muestra de este libro";
            }
            return archivoMuestra;
        }
        private void EncryptFile(byte[] file, string outputfile)
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
                //while ((data = file.ins.ReadByte()) != -1)  //Escribe los bytes
                foreach (var item in file)
                {
                    cs.WriteByte((byte)item);   //Va construyendo de nuevo el archivo

                }

                //Se cierran las instancias abiertas
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
            }
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
        protected string determinePaginas(string archivoMuestra)
        {
            PdfReader pdfReader = new PdfReader(archivoMuestra);
            int numberOfPages = pdfReader.NumberOfPages;
            string Devuelve = "";
            Devuelve = "(" + numberOfPages.ToString() + " páginas)";
            return Devuelve;
        }
        protected string determinePaginasEntero(string archivoMuestra)
        {
            PdfReader pdfReader = new PdfReader(archivoMuestra);
            int numberOfPages = pdfReader.NumberOfPages;
            string Devuelve = "";
            Devuelve = numberOfPages.ToString();
            return Devuelve;
        }
        private void prepareBook(string encriptedPath)
        {

            //obtenerLibroFisico();
            var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/" + encriptedPath + "_encrypted"));
            string input = originalDirectory.ToString();
            string output = Server.MapPath("~/LibrosPortadas/" + encriptedPath + ".pdf");
            decryptBook(input, output);
        }
        protected string getNextPage(string book, int page, string UserName, string NameBook)
        {
            string texto = "";
            if (File.Exists(book))
            {

                string ExtractedData = string.Empty;
                PdfReader reader = new PdfReader(book);
                ITextExtractionStrategy strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                ExtractedData = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                string[] lineas = ExtractedData.Split('\n');
                StringBuilder db = new StringBuilder();
                foreach (string line in lineas)
                {
                    texto += line + Environment.NewLine;
                }
                StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + UserName + "/Reading/" + NameBook.Replace(" ", "_") + ".txt"));
                writer.WriteLine(page);
                writer.Close();
            }
            return texto;
        }
        private void EscribeNextPaginaBook(string User, string NameBook, string PaginasTotal)
        {
            NameBook = NameBook.Replace(' ', '_');
            StreamReader reader = File.OpenText(Server.MapPath("~/LibrosPortadas/" + User + "/Reading/" + NameBook + ".txt"));
            int pagina = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            if (pagina == int.Parse(PaginasTotal))
            {
                pagina = int.Parse(PaginasTotal);
            }
            else
            {
                pagina++;
            }
            StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + User + "/Reading/" + NameBook + ".txt"));
            writer.WriteLine(pagina);
            writer.Close();
        }
        private void EscribeAnteriorPaginaBook(string User, string NameBook)
        {
            NameBook = NameBook.Replace(' ', '_');
            StreamReader reader = File.OpenText(Server.MapPath("~/LibrosPortadas/" + User + "/Reading/" + NameBook + ".txt"));
            int pagina = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            if (pagina > 1)
            {
                pagina--;
            }
            else
            {
                pagina = 1;
            }
            StreamWriter writer = new StreamWriter(Server.MapPath("~/LibrosPortadas/" + User + "/Reading/" + NameBook + ".txt"));
            writer.WriteLine(pagina);
            writer.Close();
        }
    }
}
