using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            try
            {
                EnviarCorreo(txtCorreo.Text.Trim(), txtAvisoMensaje.Text.Trim());
            }
            catch (Exception ex)
            {
                lblExcep.Text = ex.ToString();
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
            mail.From = new MailAddress("Soporte@escribox.com"); //IMPORTANT: This must be same as your smtp authentication address.
            mail.To.Add(destinatario);

            //set the content 
            mail.Subject = "ESCRIBOX | AVISO";
            mail.Body = cuerpoCorreo;
            //send the message 
            SmtpClient smtp = new SmtpClient("mail.escribox.com");

            //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
            NetworkCredential Credentials = new NetworkCredential("Soporte@escribox.com", "SoporteAdmin<");
            smtp.Credentials = Credentials;
            smtp.Send(mail);
            lblSuccess.Text = "Mensaje enviado";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadUsuarios();
        }
    }
}
