using System;
using Librox2.BO;
using Librox2.DAO;
using System.Web.UI;

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
        }

        protected void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            GetValues();
            if (OBMensajesDao.SaveMensaje(OBMensajes)==1)
            {
                //Mensaje Enviado
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MensajeEnviado();", true);
            }
        }
    }
}