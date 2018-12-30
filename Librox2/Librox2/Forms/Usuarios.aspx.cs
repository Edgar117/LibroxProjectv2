using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class Usuarios : System.Web.UI.Page
    {
        string correoDestinatario = "";
        string cuerpoCorreo = "";
        UsuariosDAO ob = new UsuariosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsuarios();
                pnAviso.Visible = false;    //El panel se inicia de manera invisible, solamente es visible al invocarlo
                lblExcep.Visible = false;   //El label dedicado a una excepción no se ve al inicio
            }
        }
        private void LoadUsuarios()
        {
            GridView1.DataSource = ob.ConsultarUsuarios();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string action = Convert.ToString(e.CommandName);
            switch (action) {
                case "btnAviso":
                    pnAviso.Visible = true; //Aparece panel al seleccionar un usuario del Grid
                    int index = Convert.ToInt32(e.CommandArgument); //Operación conversión de argumento válido del Grid
                    GridViewRow row = GridView1.Rows[index]; //Se asigna una fila del grid (pendiente try-catch)
                    txtCorreo.Text = Server.HtmlDecode(row.Cells[7].Text);  //Se recupera correo del usuario seleccionado y se ajusta a un TextBox del mismo nombre
                    //correoDestinatario = txtCorreo.Text.Trim();
                    //cuerpoCorreo = txtAvisoMensaje.Text.Trim();
                    
                    break;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //Llamada al método EnviarCorreo
            EnviarCorreo(txtCorreo.Text.Trim(), txtAvisoMensaje.Text.Trim());
        }

        protected void EnviarCorreo(string destinatario, string cuerpoCorreo) {
            //Mensaje de correo
            //Autor: David May

            /*A continuación se realiza rutina de envío de correo, este método es llamado al hacer click en el botón "Enviar"
            Debido a restricciones del componente 'updatePanel', no se visualiza un 'PostBack' al hacer click al botón, es necesario esperar unos segundos
            después de hacer click para saber si el correo se envió con éxito o no.*/


            /*Para poder realizar una prueba del método cambiar en la línea 89 y en la línea 98, en dichas líneas se describe lo que se requiere,
            particularmente, son las credenciales del correo del que se va enviar el aviso.*/

            //Se crea un nuevo obeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            //Dirección de correo electrónico a la que queremos enviar el mensaje
            mmsg.To.Add(destinatario);    //El destinatario se recupera del grid de usuarios

            //NOTA: Uso la propiedad 'to' como una colección que permite enviar el correo a más de un destinatario

            //Asunto
            mmsg.Subject = "Aviso por uso inadecuado de la plataforma Librox";  //Asunto estático
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Dirección de correo electrónico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("david_may4@hotmail.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = cuerpoCorreo; //Se recupera igual del textbox 'txtAviso'
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electrónico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("david_may4@hotmail.com");


            /*-------------------------DEFINIENDO CLIENTE DE CORREO----------------------*/

            //Se crea un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("david_may4@hotmail.com", "davisaac19");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */

            cliente.Host = "smtp.live.com"; //Para Gmail "smtp.gmail.com";
            cliente.EnableSsl = false;


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg); //Envía el correo
                //Se ejecuta rutina que avisa que se envió el correo correctamente, enseguida se deberá ocultar el panel (pendiente lo del panel)
                lblExcep.Visible = true;
                lblExcep.ForeColor = System.Drawing.Color.Green;
                lblExcep.Text = "Se envió el correo";
                //pnAviso.Visible = false;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                lblExcep.Visible = true;
                lblExcep.Text = ex.ToString();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadUsuarios();
        }
    }
}
