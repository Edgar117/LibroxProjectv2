<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="Librox2.Forms.MisCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoading(e) {
        // var divBg = document.createElement('div');
        var divBg = document.getElementById('blockScreen');
        var divLoad = document.createElement('div');
        var img = document.createElement('img');

        img.src = '../images/loader.gif';
        divLoad.setAttribute("class", "blockScreenLoader");
        divLoad.appendChild(img);

        divBg.appendChild(divLoad);

        document.getElementById('blockScreen').style.display = 'block';

        // These 2 lines cancel form submission, so only use if needed.
        //window.event.cancelBubble= true;
        //e.stopPropagation();
    }

    function HideLoading() {
        //alert('hideloading');
        document.getElementById("form1").onsubmit = null;
        document.getElementById('blockScreen').style.display = 'none';
        //alert('done');
    }
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
                <div id="blockScreen" class="blockScreen" style="display:none">&nbsp;</div>
                <div class="row">
                    <asp:Repeater runat="server" ID="rptCompras" OnItemCommand="rptCompras_ItemCommand" OnItemDataBound="rptCompras_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-sm-4">
                                <div class="card" style="width: 19rem;">
                                    <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top" ImageUrl='<%# string.Format("https://www.escribox.com/LibrosPortadas/{0}",Eval("ImagenPortada"))%>' alt="Card image cap" Width="237" Height="260" />
                                    <div class="card-body">
                                        <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>' CssClass="card-title"></asp:Label>
                                        <asp:Label ID="lblFisico" runat="server" Text='<%# Eval("LibroFisico") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDescargado" runat="server" Text='<%# Eval("Descargado") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIDPago" runat="server" Text='<%# Eval("IDPago") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIDLibro" runat="server" Text='<%# Eval("IDLibro") %>' CssClass="card-title" Visible="false"></asp:Label>
                                        <br />
                                        <label>Continúa leyendo en la página:</label>
                                        <asp:Label ID="lblPage" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <div class="progress-container progress-warning">
                                            <span class="progress-badge"></span>
                                            <div class="progress" style="height: 18px;">
                                                <asp:Panel ID="pnlProgress" runat="server" CssClass="progress-bar progress-bar-warning"></asp:Panel>
                                                <%--<div id="progreso" runat="server" class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 45%;">
                                                </div>--%>
                                            </div>
                                        </div>
                                        <asp:LinkButton ID="lbtnDescargar" runat="server" CssClass="btn btn-warning btn-round" CommandName="dwd" OnClientClick="javascript:setFormSubmitToFalse()">Leer</asp:LinkButton>
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
