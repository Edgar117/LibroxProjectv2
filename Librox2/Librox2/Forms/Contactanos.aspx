<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="Librox2.GUI.Contactanos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
  <div class="wrapper">
    <div class="page-header page-header-small">
        <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/contacto.jpg');">
      </div>
      <div class="content-center">
        <div class="container">
          <h2 class="title">Tienes alguna duda?.</h2>
          <div class="text-center">
          </div>
        </div>
      </div>
    </div>
    <div class="section section-contact-us text-center">
      <div class="container">
        <h2 class="title">Estamos para escucharte</h2>
        <p class="description">Tu opinión es importante para nosotros.</p>
        <div class="row">
          <div class="col-lg-6 text-center col-md-8 ml-auto mr-auto">
                <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons ui-2_chat-round"></i>
                </span>
              </div>
              <input type="text" id="txtAsunto" runat="server" class="form-control" placeholder="Asunto/Tema">
            </div>
            <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons users_circle-08"></i>
                </span>
              </div>
              <input type="text" id="txtNombre" runat="server" class="form-control" placeholder="Nombre...">
            </div>
            <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons ui-1_email-85"></i>
                </span>
              </div>
              <input type="text" id="txtCorreo" runat="server" class="form-control" placeholder="Correo...">
            </div>
                 <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons media-1_album"></i>
                </span>
              </div>
              <img id="imagend2" class="img-thumbnail" alt="" src="http://pngimages.net/sites/default/files/add-a-button-png-image-68709.png" width="150" height="150"/>
                                    <asp:FileUpload ID="fuImg" runat="server" accept=" image/jpeg, image/png" onchange="showimagepreview(this)" />
            </div>

              
            <div class="textarea-container">
              <textarea class="form-control" id="txtMensaje" runat="server" name="name" rows="4" cols="80" placeholder="Escribe tu mensaje..."></textarea>
            </div>
            <div class="send-button">
                <asp:Button ID="btnEnviarMensaje" runat="server" CssClass="btn btn-primary btn-round btn-block btn-lg" OnClick="btnEnviarMensaje_Click" Text="Enviar Mensaje" />
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
