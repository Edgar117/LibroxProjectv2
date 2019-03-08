<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="Librox2.Forms.MisCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script type="text/javascript">
        function showModal() {
            $("#myModal").modal('show');
        }

        $(function () {
            $("#btnShow").click(function () {
                showModal();
            });
        });

    </script>
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
                     <h1 class="title" style="font-family:veteran; font-size:90px;">escribox_</h1>
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
                                        <%--<label>Continúa leyendo en la página:</label>--%>
                                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblPage" runat="server" Text=""></asp:Label>
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
                                        <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-warning btn-round" CommandName="val">Valorar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
                     <div class="modal fade modal-primary"  id="myModal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header justify-content-center">
                                <div class="modal-profile">
                                     <asp:Image CssClass="rounded-circle"  ID="ImagenLibro" runat="server" Width="140" Height="140" />
                                </div>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="TituloLirbo" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="IDPago" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="IdLibro" runat="server" Text="" Visible="false"></asp:Label>
                                <div class="container">
                                          <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row">
                                            <div class="col-sm-1"></div>
                                            <div class="col-sm-2">
                                             <asp:LinkButton ID="btn1" OnClick="btn1_Click" runat="server" CssClass="btn btn-round btn-warning">1</asp:LinkButton>
                                        </div>
                                               <div class="col-sm-2">
                                             <asp:LinkButton ID="btn2" OnClick="btn2_Click" runat="server" CssClass="btn btn-round btn-warning">2</asp:LinkButton>
                                        </div>
                                               <div class="col-sm-2">
                                             <asp:LinkButton ID="btn3" OnClick="btn3_Click" runat="server" CssClass="btn btn-round btn-warning">3</asp:LinkButton>
                                        </div>
                                               <div class="col-sm-2">
                                             <asp:LinkButton ID="btn4" OnClick="btn4_Click" runat="server" CssClass="btn btn-round btn-warning">4</asp:LinkButton>
                                        </div>
                                         <div class="col-sm-2">
                                             <asp:LinkButton ID="btn5" OnClick="btn5_Click" runat="server" CssClass="btn btn-round btn-warning">5</asp:LinkButton>
                                        </div>
                                             <div class="col-sm-1"></div>
                                        </div>
                                        
                                    </div>
                                </div>
                                </div>
                          
                                
                                <b><asp:Label ID="lblFollower" runat="server" Text="" CssClass="text_bold"></asp:Label></b>
                            </div>

                            <div class="modal-footer">
                                <b><button type="button" class="btn btn-simple" data-dismiss="modal">X</button></b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
