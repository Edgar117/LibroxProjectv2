<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="AcercaDe.aspx.cs" Inherits="Librox2.GUI.AcercaDe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="wrapper">
    <div class="page-header page-header-small">
        <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/bg6.jpg');">
      </div>
      <div class="content-center">
        <div class="container">
          <h1 class="title">Queremos ser lo mejor para ti.</h1>
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
    <div class="section section-about-us">
      <div class="container">
        <div class="row">
          <div class="col-md-8 ml-auto mr-auto text-center">
            <h2 class="title">¿Quienes somos?</h2>
            <h5 class="description">Somos una plataforma, cuya finalidad es impulsar el talento de las personas dedicadas a escribir y que les gustaria aprovecharlo de tal manera que puedan
darse a conocer a traves de la comunidad lectora y poder compartir sus
pensamientos, ideologias y cultura, a traves de sus obras, poemas etc.
</h5>
          </div>
        </div>
        <div class="separator separator-primary"></div>
        <div class="section-story-overview">
          <div class="row">
            <div class="col-md-6">
              <div class="image-container image-left" style="background-image: url('../Maybe/assets/img/login.jpg')">
                <!-- First image on the left side -->
                <p class="blockquote blockquote-primary">"Un libro abierto es un  cerebro que habla; cerrado un amigo que espera; olvidado, un alma que perdona; destruido, un corazón que llora"
                  <br>
                  <br>
                  <small>Proverbio hindú</small>
                </p>
              </div>
              <!-- Second image on the left side of the article -->
              <div class="image-container" style="background-image: url('../Maybe/assets/img/bg3.jpg')"></div>
            </div>
            <div class="col-md-5">
              <!-- First image on the right side, above the article -->
              <div class="image-container image-right" style="background-image: url('../Maybe/assets/img/bg4.jpg')"></div>
              <h3>Misión</h3>
              <p><b>Librox</b> es una herramienta, para aquellos que buscan publicar un libro, poemas,
pensamientos y más, con la finalidad de que la gente los reconozca y puedan ver las
diversas opiniones acerca de su propia obra. con esto, librox busca implementar la
cultura de la lectura y de la escritura a todo el país y reforzar dichos talentos.
              </p>
             <h3>Visión</h3>
              <p>Ser una empresa que apoye a todos los escritores independientes a expresar sus
pensamientos, ideas y filosofía y así, sean reconocidos por su talento y sus diversas
obras, con el objetivo de darse a conocer y valorar su esfuerzo a través de la
comunidad lectora del país.
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="section section-team text-center">
      <div class="container">
        <h2 class="title">Nuestro equipo de trabajo</h2>
        <div class="team">
          <div class="row">
            <div class="col-md-6">
              <div class="team-player">
                <img src="../Maybe/assets/img/avatar.jpg" alt="Thumbnail Image" class="rounded-circle img-fluid img-raised">
                <h4 class="title">Manuel Ancona</h4>
                <p class="category text-primary">CEO</p>
                <p class="description">Si lo puedes pensar lo puedes escribir.</p>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-twitter"></i></a>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-instagram"></i></a>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-facebook-square"></i></a>
              </div>
            </div>
            <div class="col-md-6">
              <div class="team-player">
                <img src="../Maybe/assets/img/ryan.jpg" alt="Thumbnail Image" class="rounded-circle img-fluid img-raised">
                <h4 class="title">Fausto</h4>
                <p class="category text-primary">Director</p>
                <p class="description">En librox queremos que no solo escribas, si no que alguien mas se pueda llevar una sonrisa al leer tu libro.</p>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-twitter"></i></a>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-linkedin"></i></a>
              </div>
            </div>
    <%--        <div class="col-md-4">
              <div class="team-player">
                <img src="../assets/img/eva.jpg" alt="Thumbnail Image" class="rounded-circle img-fluid img-raised">
                <h4 class="title">Eva Jenner</h4>
                <p class="category text-primary">Fashion</p>
                <p class="description">You can write here details about one of your team members. You can give more details about what they do. Feel free to add some
                  <a href="#">links</a> for people to be able to follow them outside the site.</p>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-google-plus"></i></a>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-youtube"></i></a>
                <a href="#pablo" class="btn btn-primary btn-icon btn-round"><i class="fab fa-twitter"></i></a>
              </div>
            </div>--%>
          </div>
        </div>
      </div>
    </div>
<%--    <div class="section section-contact-us text-center">
      <div class="container">
        <h2 class="title">Want to work with us?</h2>
        <p class="description">Your project is very important to us.</p>
        <div class="row">
          <div class="col-lg-6 text-center col-md-8 ml-auto mr-auto">
            <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons users_circle-08"></i>
                </span>
              </div>
              <input type="text" class="form-control" placeholder="First Name...">
            </div>
            <div class="input-group input-lg">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="now-ui-icons ui-1_email-85"></i>
                </span>
              </div>
              <input type="text" class="form-control" placeholder="Email...">
            </div>
            <div class="textarea-container">
              <textarea class="form-control" name="name" rows="4" cols="80" placeholder="Type a message..."></textarea>
            </div>
            <div class="send-button">
              <a href="#pablo" class="btn btn-primary btn-round btn-block btn-lg">Send Message</a>
            </div>
          </div>
        </div>
      </div>
    </div>--%>
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
