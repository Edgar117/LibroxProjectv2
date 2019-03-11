using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2
{
    public partial class RevoveryPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            //Verificamos si el correo existe
            if (txtcorreo.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Vacio();", true);
            }
            else
            {
                UsuariosDAO US = new UsuariosDAO();
                String[] substrings = US.ValidarCorreoToReset(txtcorreo.Text).Split('|');
                if (substrings[0].ToString()== "Usuario de Facebook")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "FB();", true);
                }
                else
                {
                    if (substrings[0].ToString()=="")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Noforma();", true);
                    }
                    else
                    {
                        Security SC = new Security();
                        string Nombre = substrings[0].ToString();
                        string Contraseña = SC.desencrypt(substrings[1].ToString());
                        EnviarCorreo(txtcorreo.Text, "Estimado(a): " + Nombre + Environment.NewLine + "Tu contraseña es :" + Environment.NewLine + Contraseña);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MensajeEnviado();", true);
                    }
                   
                }
            }
        }
        protected void EnviarCorreo(string destinatario, string cuerpoCorreo)
        {
            //Mensaje de correo
            //Autor: David May

            /*A continuación se realiza rutina de envío de correo, este método es llamado al hacer click en el botón "Enviar"
            Debido a restricciones del componente 'updatePanel', no se visualiza un 'PostBack' al hacer click al botón, es necesario esperar unos segundos
            después de hacer click para saber si el correo se envió con éxito o no.*/

            //create the mail message 
            MailMessage mail = new MailMessage();

            //set the addresses 
            mail.From = new MailAddress("administrador@escribox.com"); //IMPORTANT: This must be same as your smtp authentication address.
            mail.To.Add(destinatario);

            //set the content 
            mail.Subject = "ESCRIBOX | Solicitud de recuperación de contraseña";
            mail.Body = cuerpoCorreo;
            //send the message 
            SmtpClient smtp = new SmtpClient("mail.escribox.com");

            //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
            NetworkCredential Credentials = new NetworkCredential("administrador@escribox.com", "Admin_Escribox");
            smtp.Credentials = Credentials;
            smtp.Send(mail);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}