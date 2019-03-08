<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="MisVentas.aspx.cs" Inherits="Librox2.Forms.MisVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="page-header page-header-small">
            <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/bg6.jpg');">
            </div>
            <div class="content-center">
                <div class="container">
                     <h1 class="title" style="font-family:veteran; font-size:90px;">escribox_</h1>
                </div>
            </div>
        </div>
        <div class="section section-contact-us text-center">
            <div class="container">
                <h2 class="title">Mis ventas</h2>
                <h4>*El porcentaje ganado hace referencia al 65% del precio original. La comisión de Escribox es un 35% del precio total</h4>
                 
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="dtgVentas" runat="server" CssClass="table table-bordered">
                        </asp:GridView>
                         <h4 id="MensajeCorreo" runat="server" visible="false">Correo de paypal donde se hara el pago</h4>
                        <asp:TextBox ID="TXTCorreoPaypal" Visible="false" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                    <h3 class="text-right">Total de ventas:</h3>
                    <h2 class="text-right">$ 
                        <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="*Los pagos se realizan cada día 30. Dudas o aclaraciones comunicarse a escribox" forecolor="Orange"></asp:Label><br />
                         <asp:Label ID="Label2" runat="server" Text="*Los pagos son unicamente a cuentas paypal" forecolor="Orange"></asp:Label>
                    </h2>
                        <div class="pull-right">
                    <asp:Button ID="btnSolicitar" runat="server" Text="Solicitar fondos" OnClick="btnSolicitar_Click" Visible="false" CssClass="btn btn-warning btn-round" />
                     <asp:Button ID="btnSolicitarConCorreo" runat="server" Text="Solicitar fondos" OnClick="btnSolicitarConCorreo_Click" CssClass="btn btn-warning btn-round" />
                            </div>
                </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
