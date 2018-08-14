<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Librox2.GUI.RegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
    <div class="page-header page-header-small">
      <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/bg6.jpg');">
      </div>
      <div class="content-center">
        <div class="container">
          <h1 class="title">This is our great company.</h1>
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
        <h2 class="title">Registro de usuario</h2>
        <p class="description">Descubrir nuevos mundos esta a tu alcance.</p>
        <div class="row">
          <div class="col-lg-6 text-center col-md-8 ml-auto mr-auto">
              <%--Nombre--%>
            <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons users_single-02"></i>
                </span>
              </div>
              <input id="txtNombre" runat="server" type="text" class="form-control" placeholder="Nombre">
            </div>
              <%--Usuario--%>
                  <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons users_circle-08"></i>
                </span>
              </div>
              <input id="txtusuario" runat="server" type="text" class="form-control" placeholder="Usuario">
            </div>
              <%--Email--%>
                  <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons ui-1_email-85"></i>
                </span>
              </div>
              <input id="txtemail" runat="server" type="text" class="form-control" placeholder="Email">
            </div>
              <%--Contraseña--%>
            <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons objects_key-25"></i>
                </span>
              </div>
              <input id="txtcontraseña" runat="server" type="password" class="form-control" placeholder="*****">
            </div>
              <%--Breve descripcion--%>
            <div class="textarea-container">
              <textarea id="txtdescription" runat="server" class="form-control" name="name" rows="4" cols="80" placeholder="Breve descripción(Opcional)"></textarea>
            </div>
            <div class="send-button">
                <asp:Button  class="btn btn-primary btn-round btn-block btn-lg" ID="btnRegistro" OnClick="btnRegistro_Click" runat="server" Text="Registrar Usuario" />
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
              <a href="https://www.creative-tim.com">
                Creative Tim
              </a>
            </li>
            <li>
              <a href="http://presentation.creative-tim.com">
                About Us
              </a>
            </li>
            <li>
              <a href="http://blog.creative-tim.com">
                Blog
              </a>
            </li>
          </ul>
        </nav>
        <div class="copyright" id="copyright">
          &copy;
          <script>
            document.getElementById('copyright').appendChild(document.createTextNode(new Date().getFullYear()))
          </script>, Designed by
          <a href="https://www.invisionapp.com" target="_blank">Invision</a>. Coded by
          <a href="https://www.creative-tim.com" target="_blank">Creative Tim</a>.
        </div>
      </div>
    </footer>
  </div>
</asp:Content>
