<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="LibrosDetails.aspx.cs" Inherits="Librox2.Forms.LibrosDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-sm-4">
        <div class="card" style="width: 19rem;">
            <h5 class="card-header"></h5>
            <%--<img class="card-img-top" src="../LibrosPortadas/<%# Eval("ImagenPortada") %>" alt="Card image cap" width="237" height="260">--%>
            <div class="card-body">
                <%--<h5 class="title"><%# Eval("Categoria") %></h5>--%>
                <h5>Categoria:
                                    <br />
                    <asp:Label ID="lblCat" runat="server" Text='' CssClass="title"></asp:Label></h5>
                <%--<h5 class="card-title"><%# Eval("Titulo") %></h5>--%>
                <h5>Título:
                                    <br />
                    <asp:Label ID="lblTitulo" runat="server" Text='' CssClass="card-title"></asp:Label></h5>
                <%--<p class="text"><%# Eval("Sinopsis") %></p>--%>
                <p>
                    Sinopsis:
                                    <br />
                    <asp:Label ID="lblSinop" runat="server" Text='' CssClass="text"></asp:Label>
                </p>
                <p>Precio :$<asp:Label ID="lblPrecio" runat="server" Text=''></asp:Label></p>
                <h5>Estado Actual del Libro:
                                    <br />
                    <asp:Label ID="Label3" runat="server" Text='' CssClass="title"></asp:Label></h5>
                <h5>Autor:
                                    <asp:Label ID="Label2" runat="server" Text='' CssClass="title"></asp:Label></h5>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-round" Enabled="true" CommandName="pay">Comprar</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
