<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevoveryPass.aspx.cs" Inherits="Librox2.RevoveryPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recuperar contraseña escribox_</title>
     
</head>
<body>
    <link href="bootstrap.min.css" rel="stylesheet" />
   
      <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <script type="text/javascript">
        function MensajeEnviado() {
            swal({
                title: "Mensaje Enviado",
                text: "Tu contraseña a sido enviado a su correo!",
                icon: "success",
            });
        }
    </script>
        <script type="text/javascript">
        function Vacio() {
            swal({
                title: "ERROR",
                text: "Ingresa un correo por favor.",
                icon: "error",
            });
        }
    </script>
            <script type="text/javascript">
        function Noforma() {
            swal({
                title: "Información",
                text: "Este correo no forma parte de excribox_",
                icon: "info",
            });
        }
    </script>
        <script type="text/javascript">
        function FB() {
            swal({
                title: "Información",
                text: "No se recuperan contraseñas para usuarios de Facebook",
                icon: "info",
            });
        }
    </script>
    <form id="form1" runat="server">
        <div>
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />
            <div class="form-gap"></div>
            <div class="container">
                <div class="row">
                    <br /><br /><br /><br />
                    <div class="col-md-4 col-md-offset-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="text-center">
                                    <h3><i class="fa fa-lock fa-4x"></i></h3>
                                    <h2 class="text-center">¿Olvidaste tu contraseña?</h2>
                                    <p>Recuperalo aquí.</p>
                                    <div class="panel-body">


                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                                <%--<input id="email" name="email"   type="email">--%>
                                                <asp:TextBox  placeholder="Correo electronico" ID="txtcorreo" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button ID="btnRecuperar" OnClick="btnRecuperar_Click" class="btn btn-lg btn-primary btn-block" runat="server" Text="Recuperar contraseña" />
                                             <asp:Button ID="btnRegresar" OnClick="btnRegresar_Click" class="btn btn-lg btn-primary btn-block" runat="server" Text="Regresar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
