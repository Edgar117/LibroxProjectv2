﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="LibrosDetails.aspx.cs" Inherits="Librox2.Forms.LibrosDetails" %>

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
                    <%--<div class="text-center">
                        <a href="#pablo" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-facebook-square"></i>
                        </a>
                        <a href="#pablo" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-twitter"></i>
                        </a>
                        <a href="#pablo" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-google-plus"></i>
                        </a>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="section section-contact-us text-center">
        <div class="container">
            <div class="row">
                <div class="col-md-8 card">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lblCat" runat="server" Text='' CssClass="title"></asp:Label>
                            <br />
                            <asp:Image ID="imgPortada" runat="server" CssClass="img-thumbnail" Width="240" Height="340" />
                        </div>
                        <div class="col-md-8">
                            <h3 class="text-left"><asp:Label ID="lblTitulo" runat="server" Text=''></asp:Label></h3>
                            <asp:Label ID="lblAuxTit" runat="server" Text='' Visible="false"></asp:Label>
                            <img id="fotoA" runat="server" src="../images/ImagenDefualt.png" width="45" height="45" align="left" class="rounded-circle" /> <p class="text-left"><b><asp:Label ID="lblAutor" runat="server" Text='' ForeColor="Orange"></asp:Label></b></p>
                            <asp:Label ID="lblPages" runat="server" Text="" CssClass="text-center"></asp:Label>
                            <br />
                            <p class="text-left"><asp:Label ID="lblSinop" runat="server" Text='' CssClass="title"></asp:Label></p>
                            <br />
                            <asp:Label ID="lblEstatus" runat="server" Text='' CssClass="title" Visible="false"></asp:Label>
                            <br />
                            <hr />
                    <%--<p>$<asp:Label ID="lblPrecio" runat="server" Text=''></asp:Label></p>--%>
                            <asp:LinkButton ID="lbtnPrueba" runat="server" CssClass="btn btn-warning btn-round" OnClick="lbtnPrueba_Click">Muestra gratis</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-warning btn-round" Enabled="true" CommandName="pay"></asp:LinkButton>
                            <br />
                            <asp:Label ID="lblMuestraNo" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <hr />
                    <h4 class="text-left">Opiniones</h4>
                    <asp:Panel ID="pnlComments2" runat="server">
                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="750" Height="150" CssClass="form-control" placeholder="Escribe un comentario..."></asp:TextBox>
                        <p class="text-right">
                            <asp:Button ID="btnComment" runat="server" Text="Comentar" CssClass="btn btn-round btn-warning" OnClick="btnComment_Click" />
                        </p>
                    </asp:Panel>
                    <asp:Panel ID="pnlLogin" runat="server">
                        <a href="/Login.aspx" class="btn btn-round btn-warning">Inicia sesión para comentar</a>
                    </asp:Panel>
                     <br />
                    <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-2 text-right">
                                    <%--<img src="../images/ImagenDefualt.png" class="align-self-center mr-3" alt="UserCommentPic" width="64" height="64">--%>
                                    <asp:Image ID="picCommentUser" runat="server" ImageUrl='<%# "~/images/Users/" + Eval ("ImagenUsuario") %>'  CssClass="align-self-center mr-3" alt="UserCommentPic" width="64" height="64"/>
                                </div>
                                <div class="col-sm-10 text-left">
                                    <h5>
                                        <asp:Label ID="lblUser" runat="server" Text='<%# Eval ("Usuario") %>'></asp:Label> 
                                    </h5>
                                    <h6>
                                         <asp:Label ID="lblComment" runat="server" Text='<%# Eval ("Comentario") %>'></asp:Label>
                                        </h6>
                                    <i>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval ("Hora", "{0:dd/MM/yyyy HH:mm:ss}") %>'></asp:Label>
                                    </i>
                                </div>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-4">
                    <h4>Libros que pueden gustarte...</h4>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="media">
                                <%--<img class="mr-3" alt="Bootstrap Media Preview" src="https://www.layoutit.com/img/sports-q-c-64-64-8.jpg" />--%>
                                <asp:Image ID="imgPortada" runat="server" CssClass="img-thumbnail" ImageUrl='<%# string.Format("~/LibrosPortadas/{0}",Eval("ImagenPortada"))%>' alt="Card image cap" Width="70" Height="84" />
                                <div class="media-body">
                                    <h5 class="mt-0">
                                        <asp:Label ID="lblTituloC" runat="server" Text='<%# Eval("Titulo") %>' CssClass="title"></asp:Label>
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
        </div>
    </div>
</asp:Content>
