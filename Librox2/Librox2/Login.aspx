﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Librox2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido a Escribox</title>
</head>

<body>
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="Login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link href="Login/bootstrap.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <!--===============================================================================================-->
    <link href="Login/icon-font.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Login/animate.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Login/css/main.css" rel="stylesheet" />
    <link href="Login/css/util.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <%--test--%>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <form id="form1" runat="server">
        <div>
            <div class="limiter">
                <div class="container-login100" style="background-image: url('Login/images/bg-01.jpg');">

                    <div class="wrap-login100 p-l-110 p-r-110 p-t-62 p-b-33">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12">
                                    <div align="center">
                                        <div id="fb-root"></div>
                                        <a style="width:280px;height:70px;background-color:#4267B2" href="#" onclick="loginByFacebook();" class="btn btn-face">
                                            <i class="fa fa-facebook-official"></i>
                                           Iniciar sesión con Facebook
                                        </a>
                                        <br />
                                        <span class="txt1">*No publicaremos en tu Facebook.</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="login100-form validate-form flex-sb flex-w">
                            <span class="login100-form-title p-b-53"></span>

                            <br />
                            <div class="p-t-31 p-b-9">
                                <span class="txt1">Usuario
                                </span>
                            </div>
                            <div class="wrap-input100 validate-input" data-validate="Username is required">
                                <asp:TextBox class="input100" ID="txtusuario" runat="server"></asp:TextBox>
                                <span class="focus-input100"></span>
                            </div>

                            <div class="p-t-13 p-b-9">
                                <span class="txt1">Contraseña
                                </span>

                                <a href="RevoveryPass.aspx" class="txt2 bo1 m-l-5">¿Olvidaste tu contraseña?
                                </a>
                            </div>
                            <div class="wrap-input100 validate-input" data-validate="Password is required">
                                <asp:TextBox class="input100" ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                                <span class="focus-input100"></span>
                            </div>

                            <div class="container-login100-form-btn m-t-17">
                                <div class="col-md-6">
                                    <asp:Button class="login100-form-btn" ID="btnEntrar" runat="server" Text="Ingresar" OnClick="btnEntrar_Click" />

                                </div>
                                <div class="col-md-6">
                                    <a href="/register" class="login100-form-btn">Registrarse
                                    </a>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <%-- now this is some required facebook's JS, two things to pay attention to
    1. setting the ApplicationID, To make this project work you have to edit "callback.aspx.cs" and put your facebook-app-key there
    2. Adjust the permissions you want to get from user, set that in scope options below. --%>
        <script type="text/javascript">
            window.fbAsyncInit = function () {
                FB.init({
                    appId: '616292575407620',
                    status: true, // check login status
                    cookie: true, // enable cookies to allow the server to access the session
                    xfbml: true, // parse XFBML
                    oauth: true // enable OAuth 2.0
                });
            };
            (function () {
                var e = document.createElement('script'); e.async = true;
                e.src = document.location.protocol +
                    '//connect.facebook.net/en_US/all.js';
                document.getElementById('fb-root').appendChild(e);
            }());
            function loginByFacebook() {
                FB.login(function (response) {
                    if (response.authResponse) {
                        FacebookLoggedIn(response);
                    } else {
                        console.log('User cancelled login or did not fully authorize.');
                    }
                }, { scope: 'user_birthday,user_hometown,user_location,email' });
            }
            function FacebookLoggedIn(response) {
                var loc = '/Forms/Callback.aspx';
                if (loc.indexOf('?') > -1)
                    window.location = loc + '&authprv=facebook&access_token=' + response.authResponse.accessToken;
                else
                    window.location = loc + '?authprv=facebook&access_token=' + response.authResponse.accessToken;
            }
        </script>
    </form>
</body>
</html>
