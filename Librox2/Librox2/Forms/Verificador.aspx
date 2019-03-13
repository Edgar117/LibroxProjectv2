<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verificador.aspx.cs" Inherits="Librox2.Forms.Verificador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <script type="text/javascript">
        function NoProcess() {
            swal({
                title: "No se realizo el pago correctamente",
                text: "Intenta mas tarde",
                icon: "error",
            });
        }
    </script>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button Visible="false" ID="btnRegresar" OnClick="btnRegresar_Click" class="btn btn-lg btn-primary btn-block" runat="server" Text="Regresar" />

        </div>
    </form>
</body>
</html>
