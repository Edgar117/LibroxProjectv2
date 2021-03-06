﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Librox2.GUI.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">  

        function showimagepreview(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imagend2').attr('src', e.target.result);
                    document.getElementsById("imagend2")[0].setAttribute("src", e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
    <!-- End Navbar -->
    <div class="wrapper">
        <div class="page-header clear-filter" filter-color="orange">
            <div class="page-header-image" data-parallax="true" id="Fondo" runat="server" style="background-image: url('../Maybe/assets/img/bg5.jpg');">
            </div>
            <div class="container">
                <div class="photo-container">
                    <img runat="server" id="ImagenUsuario" src="" />
                </div>
                <h3 runat="server" id="NameUser" class="title">...</h3>
                <p runat="server" id="Categoria" class="category">...</p>
                <div class="content">
                    <div class="social-description">
                        <h2 id="lblSeguidres" runat="server">0 </h2>
                        <p>Seguidores</p>
                    </div>
                   
                    <div class="social-description">
                        <h2 id="Libros" runat="server">...</h2>
                        <p>Libros</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="section">
            <div class="container">
                <div class="button-container">
                    <%--<a href="#button" class="btn btn-primary btn-round btn-lg">Sigueme</a>--%>
                </div>
                <h3 class="title">Acerca de mí</h3>
                <h5 id="about" runat="server" class="description"></h5>
                <div class="row">
                    <div class="col-md-6 ml-auto mr-auto">
                        <h4 class="title text-center">Mis Libros</h4>
                        <div class="nav-align-center">
                            <ul class="nav nav-pills nav-pills-primary nav-pills-just-icons" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#profile" role="tablist">
                                        <i class="now-ui-icons design_image"></i>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#home" role="tablist">
                                        <i class="now-ui-icons location_world"></i>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#messages" role="tablist">
                                        <i class="now-ui-icons sport_user-run"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!-- Tab panes -->
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="tab-content gallery">
                        <div class="tab-pane active" id="home" role="tabpanel">
                            <div class="col-md-10 ml-auto mr-auto">
                                <div class="row collections">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <div class="col-md-4">
                                                <img alt="" src="../LibrosPortadas/<%# Eval("ImagenPortada") %>" width="500" height="250" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="profile" role="tabpanel">
                            <div class="col-md-10 ml-auto mr-auto">
                                <div class="row collections">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblcambiarfoto" runat="server" Text="Cambiar Foto (Actual)"></asp:Label>
                                        <img runat="server" id="Imagen" width="250" height="250" src="" alt="" class="img-raised">
                                        <asp:FileUpload ID="FileUpload1" runat="server" accept=" image/jpeg, image/png" onchange="showimagepreview(this)" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label1" runat="server" Text="Cambiar Foto (Nueva)"></asp:Label><br />
                                        <img id="imagend2" class="img-raised" alt="" width="250" height="250" src="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="messages" role="tabpanel">
                            <div class="col-md-10 ml-auto mr-auto">
                                <asp:Label ID="Label2" runat="server" Text="Actualiza tus Datos"></asp:Label>
                                <img src="../Maybe/assets/img/bg7.jpg" width="1000" height="250" alt="" class="img-raised">
                                <div class="row collections">
                                    <div class="col-md-6">

                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="Escoje Un Rol"></asp:Label>
                                        <asp:DropDownList ID="dpCategoria" CssClass="form-control" runat="server">
                                            <asp:ListItem>Escritor</asp:ListItem>
                                            <asp:ListItem>Lector</asp:ListItem>
                                            <asp:ListItem>Lector/Escritor</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <br />
                                        <br />
                                        <textarea id="txtdescription" runat="server" class="form-control" name="name" rows="4" cols="80"></textarea>
                                    </div>
                                    <div class="col-md-6">
                                        <br />
                                        <p class="text-center">
                                        <asp:Button class="btn btn-primary btn-round" ID="btnRegistro" OnClick="btnRegistro_Click" runat="server" Text="Guardar Cambios" />
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
        <footer class="footer footer-default">
            <div class="container">
                <nav>
                    <ul>
                        <li>
                            <a href="#">Aviso de Privacidad.
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
