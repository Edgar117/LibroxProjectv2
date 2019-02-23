<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="Librox2.Forms.MisCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        setTimeout(function () { _spFormOnSubmitCalled = false; }, 3000);
    return true;
</script>

    <div class="wrapper">
        <div class="page-header page-header-small">
            <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/bg6.jpg');">
            </div>
            <div class="content-center">
                <div class="container">
                    <h1 class="title">Escribox.</h1>
                </div>
            </div>
        </div>
        <div class="section section-contact-us text-center">
            <div class="container">
                <h2 class="title">Mis compras</h2>
                <div class="row">
                    <asp:Repeater runat="server" ID="rptCompras" OnItemCommand="rptCompras_ItemCommand" OnItemDataBound="rptCompras_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-sm-4">
                                <div class="card" style="width: 19rem;">
                                    <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top" ImageUrl='<%# string.Format("~/LibrosPortadas/{0}",Eval("ImagenPortada"))%>' alt="Card image cap" Width="237" Height="260" />
                                    <div class="card-body">
                                        <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>' CssClass="card-title"></asp:Label>
                                        <asp:Label ID="lblFisico" runat="server" Text='<%# Eval("LibroFisico") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDescargado" runat="server" Text='<%# Eval("Descargado") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIDPago" runat="server" Text='<%# Eval("IDPago") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIDLibro" runat="server" Text='<%# Eval("IDLibro") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbtnDescargar" runat="server" CssClass="btn btn-warning btn-round" CommandName="dwd" OnClientClick="javascript:setFormSubmitToFalse()">Descargar</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnValorar" runat="server" CssClass="btn btn-warning btn-round" CommandName="val">Valorar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
