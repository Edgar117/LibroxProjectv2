<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="LibrosDetails.aspx.cs" Inherits="Librox2.Forms.LibrosDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="page-header page-header-small">
            <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/bg6.jpg');">
            </div>
            <div class="content-center">
                <div class="container">
                    <h1 class="title">Escribox.</h1>
                    <div class="text-center">
                        <a href="#pablo" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-facebook-square"></i>
                        </a>
                        <a href="#pablo" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-twitter"></i>
                        </a>
                        <a href="#pablo" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-google-plus"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="section section-contact-us text-center">
        <div class="container">
            <div class="row">
                <div class="col-sm-4 card">
                    <asp:Image ID="imgPortada" runat="server" CssClass="img-responsive" />
                </div>
                <div class="col-sm-4 card text-center">
                    <div class="card-header">
                        <h3 class="card-header">
                            <asp:Label ID="lblTitulo" runat="server" Text='' CssClass="card-title"></asp:Label>
                        </h3>
                    </div>
                    <hr />
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblSinop" runat="server" Text='' CssClass="title"></asp:Label></h5>
                        <asp:Label ID="lblCat" runat="server" Text='' CssClass="title"></asp:Label>
                    </div>
                    <hr />
                    <h5>Escrito por:
                        <asp:Label ID="lblAutor" runat="server" Text='' CssClass="title"></asp:Label>
                    </h5>
                    <h4>
                        <asp:Label ID="lblEstatus" runat="server" Text='' CssClass="title"></asp:Label></h4>
                    <%--<p>$<asp:Label ID="lblPrecio" runat="server" Text=''></asp:Label></p>--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-round" Enabled="true" CommandName="pay"></asp:LinkButton>
                    <br />
                </div>
                <div class="col-sm-4">
                    <h4>Libros que pueden gustarte...</h4>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="media">
                                <%--<img class="mr-3" alt="Bootstrap Media Preview" src="https://www.layoutit.com/img/sports-q-c-64-64-8.jpg" />--%>
                                <asp:Image ID="imgPortada" runat="server" CssClass="img-thumbnail" ImageUrl='<%# string.Format("~/LibrosPortadas/{0}",Eval("ImagenPortada"))%>' alt="Card image cap" Width="70" Height="84" />
                                <div class="media-body">
                                    <h5 class="mt-0">
                                        <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>' CssClass="title"></asp:Label>
                                    </h5>
                                    <asp:Label ID="lblSinop" runat="server" Text='<%# Eval("Sinopsis") %>' CssClass="text-center text"></asp:Label>
                                </div>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="card-link" Enabled="true" PostBackUrl="/libros">Ver más libros...</asp:LinkButton>
                </div>
            </div>
            <h3 class="title">Comentarios y reseñas</h3>
            <div class="row card">
                <div class="col-md-12">
                </div>
            </div>
            <%--Empieza sección para publicar un comentario--%>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8 card">
                    <br />
                    <asp:Panel ID="pnlComments2" runat="server">
                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="750" Height="150" CssClass="form-control" placeholder="Escribe un comentario..."></asp:TextBox>
                        <p class="text-right">
                            <asp:Button ID="btnComment" runat="server" Text="Comentar" CssClass="btn btn-round btn-warning" OnClick="btnComment_Click" />
                        </p>
                    </asp:Panel>
                    <asp:Panel ID="pnlLogin" runat="server">
                        <a href="/Login.aspx" class="btn btn-round btn-warning">Inicia sesión para comentar</a>
                    </asp:Panel>
                    <asp:DataList ID="dtlComments" runat="server" RepeatDirection="Vertical" Width="720px">
                        <ItemTemplate>
                            <h5><b>
                                <asp:Label ID="lblUser" runat="server" Text='<%# Eval ("Usuario") %>'></asp:Label></b></h5>
                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval ("Hora") %>'></asp:Label>
                            <p>
                                <b>
                                    <asp:Label ID="lblComment" runat="server" Text='<%# Eval ("Comentario") %>'></asp:Label>
                                </b>
                            </p>
                            <hr />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="col-md-2"></div>
            </div>

        </div>
    </div>
</asp:Content>
