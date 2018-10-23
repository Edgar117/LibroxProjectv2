<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="AdministrarMisLibros.aspx.cs" Inherits="Librox2.Forms.AdministrarMisLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <div class="page-header page-header-small">
            <div class="page-header-image" data-parallax="true" style="background-image:  url('../Maybe/assets/img/bg6.jpg');">
            </div>
            <div class="content-center">
                <div class="container">
                    <h2 class="title">Menú Administrativo</h2>
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
                <h2 class="title">Cuidado con lo que estas a punto de realizar.</h2>
                <p class="description">!CUIDADO¡</p>
                <div class="row">
                    <div class="col-lg-12 text-center col-md-8 ml-auto mr-auto">
                      <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server"  OnRowCommand="GridView1_RowCommand">
                                            <FooterStyle BackColor="#1DE9B6 " Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1DE9B6 " Font-Bold="True" ForeColor="White" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <Columns>
                                                <asp:ButtonField CommandName="btnSeleccionar" ControlStyle-CssClass="btn btn-success" Text="Seleccionar" />
                                                <asp:ButtonField CommandName="btnEliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />
                                                <asp:ButtonField CommandName="btnActualizar" ControlStyle-CssClass="btn btn-info" Text="Actualizar" />
                                            </Columns>
                                        </asp:GridView>
                        <div class="send-button">
                   
                            
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
              <a href="#">
                Aviso de Privacidad.
              </a>
            </li>
            <li>
              <a href="AcercaDe.aspx">
               Acerca de nosotros
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
          </script>, Diseñado por
          <a href="https://www.facebook.com/Developers-Corp-2308672249427418" target="_blank">Developers Corp</a>. Desarrollado por
          <a href="https://www.facebook.com/Developers-Corp-2308672249427418" target="_blank">Developers Corp</a>.
        </div>
      </div>
    </footer>
    </div>
</asp:Content>
