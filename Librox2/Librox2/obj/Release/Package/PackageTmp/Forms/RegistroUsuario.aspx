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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="section section-contact-us text-center">
            <div class="container">
                <h2 class="title">Registro de usuario</h2>
                <p class="description">Descubrir nuevos mundos está a tu alcance.</p>

            </div>
            <div class="row">
                <div class="col-lg-6 text-center col-md-8 ml-auto mr-auto">
                    <%--Nombre--%>
                    <asp:RequiredFieldValidator ID="validarNombre" runat="server" ErrorMessage="Escribe un nombre" ControlToValidate="txtNombre" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <div class="input-group input-lg">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="now-ui-icons users_single-02"></i>
                            </span>
                        </div>
                        <input id="txtNombre" runat="server" type="text" class="form-control" placeholder="Nombre">
                    </div>
                    <%--Usuario--%>
                    <asp:RequiredFieldValidator ID="validarUsuario" runat="server" ErrorMessage="Escribe un nombre de usuario" ControlToValidate="txtUsuario" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <div class="input-group input-lg">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="now-ui-icons users_circle-08"></i>
                            </span>
                        </div>
                        <input id="txtusuario" runat="server" type="text" class="form-control" placeholder="Usuario">
                    </div>
                    <%--Email--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Se requiere un email" ControlToValidate="txtemail" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <div class="input-group input-lg">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="now-ui-icons ui-1_email-85"></i>
                            </span>
                        </div>
                        <input id="txtemail" runat="server" type="text" class="form-control" placeholder="Email">
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingresa un email válido" ControlToValidate="txtemail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true"></asp:RegularExpressionValidator>
                    <br />
                    <%--Fecha de nacimiento--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingresa tu fecha de nacimiento" ControlToValidate="txtFechaNaci" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <div class="input-group input-lg">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="now-ui-icons ui-1_calendar-60"></i>
                            </span>
                        </div>
                        <input id="txtFechaNaci" runat="server" type="text" class="form-control" placeholder="17/12/1996">
                    </div>
                    <%--Contraseña--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingresa una contraseña" ControlToValidate="txtcontraseña" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <div class="input-group input-lg">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="now-ui-icons objects_key-25"></i>
                            </span>
                        </div>
                        <input id="txtcontraseña" runat="server" type="password" class="form-control" placeholder="*****">
                    </div>
                    <%--Confirmar contraseña--%>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToValidate="txtRepasswd" ControlToCompare="txtcontraseña" ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>
                    <div class="input-group input-lg">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="now-ui-icons objects_key-25"></i>
                            </span>
                        </div>
                        <input id="txtRepasswd" runat="server" type="password" class="form-control" placeholder="*****">
                    </div>
                    <%--Breve descripcion--%>
                    <div class="textarea-container">
                        <textarea id="txtdescription" runat="server" class="form-control" name="name" rows="4" cols="80" placeholder="Breve descripción(Opcional)"></textarea>
                   <br />
                        <asp:CheckBox ID="ChkTerminos" Text="  Acepto los " runat="server" /><a href="/privacy" target="_blank"> Términos y condiciones</a>
                      </div>
                    <div class="send-button">
                        <asp:Button class="btn btn-primary btn-round btn-block btn-lg" ID="btnRegistro" OnClick="btnRegistro_Click" runat="server" Text="Registrar Usuario" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Algo salió mal. Intenta de nuevo" ForeColor="Red" />
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
                            <a href="/about">Acerca de nosotros
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
</asp:Content>
