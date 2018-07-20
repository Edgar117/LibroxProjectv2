<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Librox2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido a Librox</title>
</head>
 
<body>
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="Login/images/icons/favicon.ico"/>
<!--===============================================================================================-->
    <link href="Login/bootstrap.min.css" rel="stylesheet" />
<!--===============================================================================================-->
    <link href="Login/font-awesome.min.css" rel="stylesheet" />
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
				<div class="login100-form validate-form flex-sb flex-w">
					<span class="login100-form-title p-b-53">
						Entrar con
					</span>                     
                         <div id="fb-root"></div>
					<a href="#" onclick="loginByFacebook();" class="btn-face m-b-20">
						<i class="fa fa-facebook"></i>
						Facebook
					</a>
					<a href="#" class="btn-google m-b-20">
						<img src="Login/images/icons/icon-google.png" alt="GOOGLE">
						Google
					</a>
					
					<div class="p-t-31 p-b-9">
						<span class="txt1">
							Username
						</span>
					</div>
					<div class="wrap-input100 validate-input" data-validate = "Username is required">
                        <asp:TextBox class="input100" ID="txtusuario" runat="server"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
					
					<div class="p-t-13 p-b-9">
						<span class="txt1">
							Password
						</span>

						<a href="#" class="txt2 bo1 m-l-5">
							Forgot?
						</a>
					</div>
					<div class="wrap-input100 validate-input" data-validate = "Password is required">
					 <asp:TextBox class="input100" ID="txtpassword" runat="server"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

					<div class="container-login100-form-btn m-t-17">
                        <asp:Button class="login100-form-btn" ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
					</div>

					<div class="w-full text-center p-t-55">
						<span class="txt2">
							No eres un miembro?
						</span>

						<a href="#" class="txt2 bo1">
							Sign up now
						</a>
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
            var loc = '/GUI/Callback.aspx';
            if (loc.indexOf('?') > -1)
                window.location = loc + '&authprv=facebook&access_token=' + response.authResponse.accessToken;
            else
                window.location = loc + '?authprv=facebook&access_token=' + response.authResponse.accessToken;
        }
    </script>
    </form>
</body>
</html>
