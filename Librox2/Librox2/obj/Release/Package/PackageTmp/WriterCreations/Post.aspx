<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="Librox2.WriterCreations.Post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>Material Bootstrap Wizard by Creative Tim</title>

    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <meta name="viewport" content="width=device-width" />

    <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" />

    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />

    <!-- CSS Files -->
    <link href="wizard_res/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="wizard_res/assets/css/material-bootstrap-wizard.css" rel="stylesheet" />
    <link href="wizard_res/assets/css/demo.css" rel="stylesheet" />

</head>
<body>

    <form id="form1" runat="server">
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

        <div class="image-container set-full-height" style="background-image: url('https://www.solofondos.com/wp-content/uploads/2015/11/21omxpw.jpg')">
            <!--   Creative Tim Branding   -->
            <a href="/home">
                <div class="logo-container">
                    <div class="logo">
                        <img src="https://i.ytimg.com/vi/ZPGHuuk2bKw/hqdefault.jpg" />
                    </div>
                    <div class="brand">
                        Escribox
	           
                    </div>
                </div>
            </a>

            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <!--      Wizard container        -->
                        <div class="wizard-container">
                            <h1>¿Estás listo para publicar?</h1>
                            <asp:Label ID="lblPath" runat="server" Text=""></asp:Label>
                            <div class="card wizard-card" data-color="purple" id="wizard">
                                <div class="col-md-4">
                                    <img id="imagend2" class="img-thumbnail" alt="" src="http://pngimages.net/sites/default/files/add-a-button-png-image-68709.png" width="250" height="250"/>
                                    <label>Elige una portada genial!</label>
                                    <asp:FileUpload ID="fuImg" runat="server" accept=" image/jpeg, image/png" onchange="showimagepreview(this)" />
                                </div>
                          <%--      Agrego el update panel para evitar el post y que se vea mas mamalon--%>
<%--                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Elige un buen título"></asp:TextBox>
                                    <asp:TextBox ID="txtSinop" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Atrae a los lectores con una pequeña sinópsis"></asp:TextBox>
                                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="form-control"></asp:DropDownList>
<%--                                                                   </ContentTemplate>
                                </asp:UpdatePanel>--%>
                                     <div class="pull-right">
                                    <asp:Button ID="Button1" runat="server" Text="Publicar!" CssClass="btn btn-warning" OnClick="Button1_Click" />
                                         <asp:Label ID="lblWar" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <!-- wizard container -->
                    </div>
                </div>
                <!-- row -->
            </div>
        </div>

        <script src="wizard_res/assets/js/jquery-2.2.4.min.js"></script>
        <script src="wizard_res/assets/js/bootstrap.min.js"></script>
        <script src="wizard_res/assets/js/jquery.bootstrap.js"></script>
        <script src="wizard_res/assets/js/material-bootstrap-wizard.js"></script>
        <script src="wizard_res/assets/js/jquery.validate.min.js"></script>
    </form>
</body>
</html>
