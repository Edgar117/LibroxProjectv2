using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.DAO;

namespace Librox2.Forms
{
    public partial class MisVentas : System.Web.UI.Page
    {
        int id = 0;
        String[] cart1 = new String[0];
        LibrosDAO books = new LibrosDAO();
        UsuariosDAO UserDao = new UsuariosDAO();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            cart1 = (String[])Session["ALL"];
            id = int.Parse(cart1[5]);
            //Bind datagrid
            try
            {
                dt = books.ConsultarMiPago(id); //Devuelve solo ventas que no se haya solicitado fondos
                dtgVentas.DataSource = dt;
                dtgVentas.DataBind();
                getTotal();
            }
            catch (Exception ex)
            {
                lblTotal.Text = ex.Message;
            }

        }

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            Decimal subTotal = Convert.ToDecimal(lblTotal.Text);
            if (subTotal >= 100 && !string.IsNullOrEmpty(TXTCorreoPaypal.Text))
            {
                foreach (DataRow row in dt.Rows)
                {
                    int idPago = Convert.ToInt32(row["IDPago"]);
                    string var = row["Libro"].ToString();
                    string precioAPagar = row["Precio Original"].ToString();
                    decimal ganado = Convert.ToDecimal(row["% Obtenido"]);
                    string escribox = row["Comisión Escribox"].ToString();
                    //Rutina para actualizar el pago en tabla ventas
                    books.ActualizarPagoUsuario(idPago);
                }
                UserDao.UpdateCuentaDepositoPaypal(TXTCorreoPaypal.Text, id);//Actualiza el correo al cual se le hara el deposito
                //Inserta el  pago en tabla pagos
                books.InsertarPagoUsuario(id, 0, subTotal, TXTCorreoPaypal.Text);
            }
            Response.Redirect("~/Forms/MisVentas.aspx");
        }
        protected void getTotal()
        {
            Decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal monto = Convert.ToDecimal(row["% Obtenido"]);
                total = Convert.ToDecimal(total + monto);
            }
            lblTotal.Text = total.ToString();
        }

        protected void btnSolicitarConCorreo_Click(object sender, EventArgs e)
        {
            Decimal subTotal = Convert.ToDecimal(lblTotal.Text);
            if (subTotal >= 100)
            {
                string Correo = UserDao.ObtenerTargetaPaypal(id);
                if (!string.IsNullOrEmpty(Correo))
                {
                    TXTCorreoPaypal.Text = Correo;
                }
                TXTCorreoPaypal.Visible = true;
                btnSolicitar.Visible = true;
                MensajeCorreo.Visible = true;
                btnSolicitarConCorreo.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "InfoPagos();", true);
            }
        }
    }
}