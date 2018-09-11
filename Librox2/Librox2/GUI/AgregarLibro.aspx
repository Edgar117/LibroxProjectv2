﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="AgregarLibro.aspx.cs" Inherits="Librox2.GUI.AgregarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/dropzone.min.js"></script>
    <link href="../css/dropzone.css" rel="stylesheet" />
    <%--Drag and Drop--%>
    <script type="text/javascript">
        //File Upload response from the server
        Dropzone.options.dropzoneForm = {
            maxFiles: 10,
            url: "AgregarLibro.aspx",
            init: function () {
                this.on("maxfilesexceeded", function (data) {
                    var res = eval('(' + data.xhr.responseText + ')');
                });
                this.on("addedfile", function (file) {
                    // Create the remove button
                    var removeButton = Dropzone.createElement("<button>Remove file</button>");
                    // Capture the Dropzone instance as closure.
                    var _this = this;
                    // Listen to the click event
                    removeButton.addEventListener("click", function (e) {
                        // Make sure the button click doesn't submit the form:
                        e.preventDefault();
                        e.stopPropagation();
                        // Remove the file preview.
                        _this.removeFile(file);
                        // If you want to the delete the file on the server as well,
                        // you can do the AJAX request here.
                    });
                    // Add the button to the file preview element.
                    file.previewElement.appendChild(removeButton);
                });
            }
        };

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="wrapper">
        <div class="page-header page-header-small">
            <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/contacto.jpg');">
            </div>
            <div class="content-center">
                <div class="container">
                    <h2 class="title">Registro de libros</h2>
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
                <h2 class="title">Algo sorprende esta a punto de ocurrir.</h2>
                <p class="description">No lo dudes</p>
                <div class="row">
                    <div class="col-lg-6 text-center col-md-8 ml-auto mr-auto">
                        <div class="input-group input-lg">
                            <div class="input-group-prepend">
                                <span class="input-group-text">
                                    <i class="now-ui-icons education_agenda-bookmark"></i>
                                </span>
                            </div>
                            <input type="text" id="txtNombre" runat="server" class="form-control" placeholder="Titulo del libro">
                        </div>
                        <div class="textarea-container">
                            <textarea class="form-control" id="txtSinopsis" runat="server" name="name" rows="4" cols="80" placeholder="Sinopsis del libro..."></textarea>
                        </div>
                        <br />
                        <div class="input-group input-lg">
                            <div class="input-group-prepend">
                                <span class="input-group-text"></span>
                            </div>
                            <asp:DropDownList CssClass="form-control" ID="dpCategorias" runat="server" Height="45px" Width="408px"></asp:DropDownList>
                        </div>
                        <div class="send-button">
                            <div class="dropzone" id="dropzoneForm">
                                <span class="issue-drop-zone__text">Arrastra tu libro y Fotografia del libro "AQUI"
                                </span>
                                <br />
                                <div class="fallback">
                                    <input name="file" type="file" multiple />
                                    <input type="submit" value="Upload" />
                                </div>
                            </div>
                             <asp:Button ID="btnRegistrarLibro" runat="server" CssClass="btn btn-primary btn-round btn-block btn-lg" OnClick="btnRegistrarLibro_Click" Text="Registrar Mi libro" />
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
                            <a href="https://www.creative-tim.com">Creative Tim
                            </a>
                        </li>
                        <li>
                            <a href="http://presentation.creative-tim.com">About Us
                            </a>
                        </li>
                        <li>
                            <a href="http://blog.creative-tim.com">Blog
                            </a>
                        </li>
                    </ul>
                </nav>
                <div class="copyright" id="copyright">
                    &copy;
          <script>
              document.getElementById('copyright').appendChild(document.createTextNode(new Date().getFullYear()))
          </script>
                    , Designed by
          <a href="https://www.invisionapp.com" target="_blank">Invision</a>. Coded by
          <a href="https://www.creative-tim.com" target="_blank">Creative Tim</a>.
                </div>
            </div>
        </footer>
    </div>
</asp:Content>
