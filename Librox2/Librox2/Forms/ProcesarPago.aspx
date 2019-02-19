<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcesarPago.aspx.cs" Inherits="Librox2.Forms.ProcesarPago" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Procesando Pago</title>
    <!-- Bootstrap Core CSS -->
    <link href="../PagoPaypal/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css" />
    <link href="../PagoPaypal/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../PagoPaypal/css/stylish-portfolio.css" rel="stylesheet" />
    <script src="https://www.paypal.com/sdk/js?client-id=sb"></script>
    <%--    <script src="../PaypalScri/scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            setTimeout(function () {
                //alert('this form is about to be submitted...');
                $('#frmPaypal').submit();
            }, 1000);
        });
    </script>--%>

    <%--<style type="text/css">
        .auto-style1
        {
            width: 100%;
        }

        .ajaxloader_style
        {
            text-align: center;
        }

        .auto-style2
        {
            width: 486px;
        }
    </style>--%>
</head>
<body id="page-top">
    <%--    <form id="frmPaypal" method="post" action="https://www.paypal.com/cgi-bin/webscr" runat="server">
        <input type="hidden" name="cmd" value="_xclick" />
        <input type="hidden" name="business" value="<%= this.BusinessValue %>" />
        <input type="hidden" name="item_name" value="<%= this.ItemNameValue %>" />
        <input type="hidden" name="item_number" value="<%= this.ItemNumberValue %>" />
        <input type="hidden" name="amount" value="<%= this.AmountValue %>" />
        <input type="hidden" name="no_shipping" value="<%= this.NoShippingValue %>" />
        <input type="hidden" name="quantity" value="<%= this.QuantityValue %>" />
        <input type="hidden" name="currency_code" value="MXN"/>
    </form>--%>
    <form id="form1" runat="server">

        <header class="masthead d-flex">
            <div class="container text-center my-auto">
                <div class="row">
                    <div class="col-md-12">
                        <h2 id="H1" runat="server" class="mb-1">Estás a punto de pagar por el libro:</h2>
                        <h2 id="NombreLibro" runat="server" class="mb-1">Stylish Portfolio</h2>
                        <h3 id="PrecioLibro" runat="server" class="mb-5">
                            <em>A Free Bootstrap Theme by Start Bootstrap</em>
                        </h3>
                        <div id="paypal-button-container"></div>
                        <%--<script>paypal.Buttons().render('#paypal-button-container');</script>--%>
                        <%--      <a class="btn btn-primary btn-xl js-scroll-trigger" href="#about">Find Out More</a>--%>
                        <%--<img src="https://www.paypalobjects.com/webstatic/es_MX/mktg/logos-buttons/redesign/btn_10.png" alt="PayPal" />--%>

                        <h4 id="H2" runat="server" class="mb-5">
                            <br />
                            <em>Podrás descargar el libro una vez que tu pago se haya verificado.</em>
                            <br />
                            <em>Dudas o aclaraciones: escribox.com.mx</em>
                        </h4>
                    </div>
                </div>

            </div>
            <div class="overlay"></div>
        </header>
        <script>
            paypal.Buttons({
                createOrder: function (data, actions) {
                    // Set up the transaction
                    var precio = document.getElementById('<%= PrecioLibro.ClientID %>').textContent;
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: precio
                            }
                        }]
                    });
                }
            }).render('#paypal-button-container');
        </script>
    </form>
</body>
</html>
