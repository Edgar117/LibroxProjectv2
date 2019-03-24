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
    <script src="https://www.paypal.com/sdk/js?client-id=AXe6wK9rBS57kSinpoNmrDrC9-jNWvQP_tZFAxuKOpKyvQVXtDRVxUVHTBRcTxydUKEvLtxP4ke4s1Dy&currency=MXN"></script>
<%--       <script src="https://www.paypal.com/sdk/js?client-id=AbCPnvXObi8MHbjfcBp9U8XuQsaJXuIW2JyGxW9KYeaka_L8W7jWdfCjD43Jmqn--z9MOxLVbDDkfN_g&currency=MXN"></script>--%>
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
            var Base64 = {

                // private property
                _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

                // public method for encoding
                encode: function (input) {
                    var output = "";
                    var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
                    var i = 0;

                    input = Base64._utf8_encode(input);

                    while (i < input.length) {

                        chr1 = input.charCodeAt(i++);
                        chr2 = input.charCodeAt(i++);
                        chr3 = input.charCodeAt(i++);

                        enc1 = chr1 >> 2;
                        enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                        enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                        enc4 = chr3 & 63;

                        if (isNaN(chr2)) {
                            enc3 = enc4 = 64;
                        } else if (isNaN(chr3)) {
                            enc4 = 64;
                        }

                        output = output +
                        this._keyStr.charAt(enc1) + this._keyStr.charAt(enc2) +
                        this._keyStr.charAt(enc3) + this._keyStr.charAt(enc4);

                    }

                    return output;
                },

                // public method for decoding
                decode: function (input) {
                    var output = "";
                    var chr1, chr2, chr3;
                    var enc1, enc2, enc3, enc4;
                    var i = 0;

                    input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

                    while (i < input.length) {

                        enc1 = this._keyStr.indexOf(input.charAt(i++));
                        enc2 = this._keyStr.indexOf(input.charAt(i++));
                        enc3 = this._keyStr.indexOf(input.charAt(i++));
                        enc4 = this._keyStr.indexOf(input.charAt(i++));

                        chr1 = (enc1 << 2) | (enc2 >> 4);
                        chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                        chr3 = ((enc3 & 3) << 6) | enc4;

                        output = output + String.fromCharCode(chr1);

                        if (enc3 != 64) {
                            output = output + String.fromCharCode(chr2);
                        }
                        if (enc4 != 64) {
                            output = output + String.fromCharCode(chr3);
                        }

                    }

                    output = Base64._utf8_decode(output);

                    return output;

                },

                // private method for UTF-8 encoding
                _utf8_encode: function (string) {
                    string = string.replace(/\r\n/g, "\n");
                    var utftext = "";

                    for (var n = 0; n < string.length; n++) {

                        var c = string.charCodeAt(n);

                        if (c < 128) {
                            utftext += String.fromCharCode(c);
                        }
                        else if ((c > 127) && (c < 2048)) {
                            utftext += String.fromCharCode((c >> 6) | 192);
                            utftext += String.fromCharCode((c & 63) | 128);
                        }
                        else {
                            utftext += String.fromCharCode((c >> 12) | 224);
                            utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                            utftext += String.fromCharCode((c & 63) | 128);
                        }

                    }

                    return utftext;
                },

                // private method for UTF-8 decoding
                _utf8_decode: function (utftext) {
                    var string = "";
                    var i = 0;
                    var c = c1 = c2 = 0;

                    while (i < utftext.length) {

                        c = utftext.charCodeAt(i);

                        if (c < 128) {
                            string += String.fromCharCode(c);
                            i++;
                        }
                        else if ((c > 191) && (c < 224)) {
                            c2 = utftext.charCodeAt(i + 1);
                            string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                            i += 2;
                        }
                        else {
                            c2 = utftext.charCodeAt(i + 1);
                            c3 = utftext.charCodeAt(i + 2);
                            string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                            i += 3;
                        }

                    }

                    return string;
                }

            }
        </script>
        <script>
            paypal.Buttons({
                createOrder: function (data, actions) {
                    // Set up the transaction
                    var precio = document.getElementById('<%= PrecioLibro.ClientID %>').textContent;
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: precio
                            },
                            description: 'Estás comprando a Escribox $' + precio
                        }]
                    });
                },
                onApprove: function (data, actions) {
                    // Capture the funds from the transaction
                    return actions.order.capture().then(function (details) {
                        // Show a success message to your buyer
                        //alert('Transaction completed by ' + details.payer.name.given_name);
                        console.log(details);
                        var myJSON = { "status": Base64.encode(details.status), "id": Base64.encode(details.id) };
                        var myString = JSON.stringify(myJSON);
                        window.location = "Verificador.aspx?details=" + myString
                    });
                }
            }).render('#paypal-button-container');
        </script>
    </form>
</body>
</html>
