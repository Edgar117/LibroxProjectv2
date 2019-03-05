using System;
using Librox2.BO;
using Librox2.DAO;
using System.Web.UI;
using System.IO;

namespace Librox2.GUI
{
    public partial class Contactanos : System.Web.UI.Page
    {
        Mensajes OBMensajes = new Mensajes();
        MensajesDAO OBMensajesDao = new MensajesDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetValues()
        {
            OBMensajes.Correo = txtCorreo.Value;
            OBMensajes.Mensaje = txtMensaje.Value;
            OBMensajes.Nombre = txtNombre.Value;
            OBMensajes.Asunto= txtAsunto.Value;
            if (fuImg.HasFile) // Si el usuario tiene un archivo
            {
                var originalDirectory = new DirectoryInfo(Server.MapPath("~/Mensajes/"));
                string pathString = originalDirectory.ToString();
                //DeletePhoto();
                string filename2 = Path.GetFileName(fuImg.FileName);
                var path = string.Format("{0}\\{1}", pathString, fuImg.FileName);//Formamos la ruta donde se guardará la imagen
                fuImg.SaveAs(path);
                OBMensajes.Imagen = "../Mensajes/"+fuImg.FileName;
            }
            else
            {
                OBMensajes.Imagen = "";
            }
           
        }

        protected void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            GetValues();
            if (ValidControls()==1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MensajeFail();", true);
            }
            else
            {
                if (OBMensajesDao.SaveMensaje(OBMensajes) == 1)
                {
                    //Mensaje Enviado
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MensajeEnviado();", true);
                }
            }
           
        }
        private int ValidControls()
        {
            int Numero = 0;
            if (txtAsunto.Value=="" || txtCorreo.Value==""|| txtMensaje.Value=="" || txtNombre.Value=="")
            {
                Numero = 1;
            }
            return Numero;
        }
    }
}