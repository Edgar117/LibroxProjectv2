using System;
using System.Web.UI;
using Librox2.BO;
namespace Librox2.Forms
{
    public partial class ProcesarPago : System.Web.UI.Page
    {
        Paypal pe = new Paypal();

        protected string BusinessValue { get; set; }
        protected string ItemNameValue { get; set; }
        protected string ItemNumberValue { get; set; }
        protected string AmountValue { get; set; }
        protected string NoShippingValue { get; set; }
        protected string QuantityValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pe = (Paypal)Session["myOrderingEntity"];

                this.BusinessValue = pe.Business;
                this.ItemNameValue = pe.ItemName;
                this.ItemNumberValue = pe.ItemNumber;
                this.AmountValue = pe.Amount;
                this.NoShippingValue = pe.NoShipping;
                this.QuantityValue = pe.Quantity;
            }

        }
    }
}