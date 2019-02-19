using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace Librox2.Forms
{
    public partial class paypal_ipn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void boton()
        {
            string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            //string strLive = "https://www.paypal.com/cgi-bin/webscr"; //Para usar en modo LIVE

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);

            //Ajustar valores para lo que devuelve el request
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] Param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(Param);
            strRequest = strRequest + "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //Enviar el request a PayPal y obtener la respuesta
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse == "VERIFIED")
            {
                //'check the payment_status is Completed
                //'check that txn_id has not been previously processed
                //'check that receiver_email is your Primary PayPal email
                //'check that payment_amount/payment_currency are correct
                //'process payment
                Label1.Text = strResponse;
            }
            else if (strResponse == "INVALID")
            {
                //Inválido
                Label1.Text = strResponse;
            }
            else
            {
                //La respuesta no fue ni verificada ni inválida, checar manual
                Label1.Text = strResponse;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            boton();
        }
    }
}