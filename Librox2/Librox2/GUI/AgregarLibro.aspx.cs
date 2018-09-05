using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text;

namespace Librox2.GUI
{
    public partial class AgregarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveUploadedFile(Request.Files);
            }
        }
        public void SaveUploadedFile(HttpFileCollection httpFileCollection)
        {
            //  bool isSavedSuccessfully = true;
            string fName = "";
            foreach (string fileName in httpFileCollection)
            {
                HttpPostedFile file = httpFileCollection.Get(fileName);
                //Save file content goes here
                fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/"));
                    string pathString = originalDirectory.ToString();
                    var fileName1 = Path.GetFileNameWithoutExtension(file.FileName);    //Cambié esta instrucción para obtener solo el nombre del archivo, sin la extensión.
                    bool isExists = System.IO.Directory.Exists(pathString);
                    if (!isExists)
                        System.IO.Directory.CreateDirectory(pathString);
                    var path = string.Format("{0}\\{1}", pathString, file.FileName);
                    file.SaveAs(path);  //Guarda el archivo físico original en servidor

                    string encryptedName = fileName1 + "_encrypted";    //Se asigna el nombre que tendrá el archivo ya encriptado
                    string pathDestino = pathString + encryptedName;    //Se combinan las rutas para indicar en dónde se guardará el archivo encriptado
                    EncryptFile(file, pathDestino); //Llamada al método para encriptar archivo

                    //Después de encriptar... sería óptimo borrar el archivo original? O sería mucho uso de memoria? Por el hecho de leer y escribir en servidor.
                }
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
                Label1.Text = ex.ToString();
            }
        }
        private void DecryptFile()
        {
            //Próximamente la rutina para desencriptar el archivo...
        }
    }
}