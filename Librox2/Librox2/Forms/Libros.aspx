﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="Librox2.GUI.Libros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <div class="section section-contact-us text-center">
            <div class="container">
                <h2 class="title">Libros que pueden ser tuyos.</h2>
                <p class="description">Descubrir nuevos mundos esta a tu alcance.</p>
                <asp:DropDownList CssClass="form-control" ID="dpCategorias" AutoPostBack="true" runat="server" Height="30px" Width="250px" OnSelectedIndexChanged="dpCategorias_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <div class="row">
                    <asp:Label ID="Label1" Visible="false" runat="server" Text="Label"></asp:Label>

                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <div class="col-sm-4">
                                <div class="card" style="width: 19rem;">
                                    <h5 class="card-header"></h5>
                                    <%--<img class="card-img-top" src="../LibrosPortadas/<%# Eval("ImagenPortada") %>" alt="Card image cap" width="237" height="260">--%>
                                    <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top" ImageUrl=<%# string.Format("~/LibrosPortadas/{0}",Eval("ImagenPortada"))%> alt="Card image cap" width="237" height="260"/>
                                    <div class="card-body">
                                        <%--<h5 class="title"><%# Eval("Categoria") %></h5>--%>
                                        <h5>Categoría:
                                    <br />
                                            <asp:Label ID="lblCat" runat="server" Text='<%# Eval("Categoria") %>' CssClass="title"></asp:Label></h5>
                                        <%--<h5 class="card-title"><%# Eval("Titulo") %></h5>--%>
                                        <h5>Título:
                                    <br />
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="details"><asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>' CssClass="card-title"></asp:Label></asp:LinkButton></h5>
                                        <%--<p class="text"><%# Eval("Sinopsis") %></p>--%>
                                        <p>
                                            Sinopsis:
                                    <br />
                                            <asp:Label ID="lblSinop" runat="server" Text='<%# Eval("Sinopsis") %>' CssClass="text"></asp:Label>
                                        </p>
                                        <p>Precio :$<asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("PRECIO") %>'></asp:Label></p>
                                        <h5>Estado Actual del Libro:
                                    <br />
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("NombreEstatus") %>' CssClass="title"></asp:Label></h5>
                                        <h5>Autor:
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Autor") %>' CssClass="title"></asp:Label></h5>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-round" Enabled="true" CommandName="pay">Comprar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <footer class="footer footer-default">
            <div class="container">
                <nav>
                    <ul>
                        <li>
                            <a href="Politicas.aspx">Aviso de Privacidad.
                            </a>
                        </li>
                        <li>
                            <a href="AcercaDe.aspx">Acerca de nosotros
                            </a>
                        </li>
                        <li>
                            <%-- <a href="http://blog.creative-tim.com">
                Blog--%>
                            <%-- </a>--%>
                        </li>
                    </ul>
                </nav>
                <div class="copyright" id="copyright">
                    &copy;
          <script>
              document.getElementById('copyright').appendChild(document.createTextNode(new Date().getFullYear()))
          </script>
                    , Diseñado por
          <a href="https://www.facebook.com/Developers-Corp-2308672249427418" target="_blank">Developers Corp</a>. Desarrollado por
          <a href="https://www.facebook.com/Developers-Corp-2308672249427418" target="_blank">Developers Corp</a>.
                </div>
            </div>
        </footer>
    </div>
</asp:Content>
