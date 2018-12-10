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
                        <h5 class="card-header">
                            <asp:Label ID="lblCat" runat="server" Text='' CssClass="title"></asp:Label>
                        </h5>
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblTitulo" runat="server" Text='' CssClass="card-title"></asp:Label></h5>
                        <p class="card-text">
                            <asp:Label ID="lblSinop" runat="server" Text='' CssClass="text"></asp:Label>
                        </p>
                        <p>Precio :$<asp:Label ID="lblPrecio" runat="server" Text=''></asp:Label></p>
                    </div>
                    <asp:Label ID="lblAutor" runat="server" Text='' CssClass="title"></asp:Label>
                    <h5>Autor:
                    </h5>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-round" Enabled="true" CommandName="pay">Comprar</asp:LinkButton>
                </div>
                <div class="col-sm-4">
                    <div class="media card text-white bg-warning mb-3">
                        <img class="mr-3" alt="Bootstrap Media Preview" src="https://www.layoutit.com/img/sports-q-c-64-64-8.jpg" />
                        <div class="media-body">
                            <h5 class="mt-0">Nested media heading
                            </h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
                        </div>
                    </div>
                    <br />
                    <div class="media">
                        <img class="mr-3" alt="Bootstrap Media Preview" src="https://www.layoutit.com/img/sports-q-c-64-64-8.jpg" />
                        <div class="media-body">
                            <h5 class="mt-0">Nested media heading
                            </h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
                        </div>
                    </div>
                    <br />
                    <div class="media">
                        <img class="mr-3" alt="Bootstrap Media Preview" src="https://www.layoutit.com/img/sports-q-c-64-64-8.jpg" />
                        <div class="media-body">
                            <h5 class="mt-0">Nested media heading
                            </h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
