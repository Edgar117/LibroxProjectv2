<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPro.Master" AutoEventWireup="true" CodeBehind="AdministrarMisLibros.aspx.cs" Inherits="Librox2.Forms.AdministrarMisLibros" EnableEventValidation="false" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="wrapper">
        <div class="page-header page-header-small">
            <div class="page-header-image" data-parallax="true" style="background-image: url('../Maybe/assets/img/bg6.jpg');">
            </div>
            <div class="content-center">
                <div class="container">
                    <h2 class="title">Menú administrativo</h2>
                    <div class="text-center">
                        <%--<a href="#" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-facebook-square"></i>
                        </a>
                        <a href="#" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-twitter"></i>
                        </a>
                        <a href="#" class="btn btn-primary btn-icon btn-round">
                            <i class="fab fa-google-plus"></i>
                        </a>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="section section-contact-us text-center">
            <div class="container">
                <h2 class="title">Edita la información de tus libros
                </h2>
                <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server">
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
                                <div class="input-group input-lg">
                                    <div class=" col-md-12">
                                        <div class="col-md-6">
                                            <asp:Label ID="Label1" runat="server" Text="Cambiar Foto (Foto Actual)"></asp:Label>
                                            <img width="250" height="250" runat="server" id="ImagenUsuario" src="" />
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lblcambiarfoto" runat="server" Text="Cambiar Foto (Nueva Foto)"></asp:Label>
                                            
                                        </div>
                                    </div>

                                </div>
                                <div class="send-button">
                                </div>
                            </div>
                            <div class="col-lg-12 text-center col-md-8 ml-auto mr-auto">
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <FooterStyle BackColor="#1DE9B6 " Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1DE9B6 " Font-Bold="True" ForeColor="White" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <Columns>
                                        <asp:ButtonField CommandName="btnSeleccionar" ControlStyle-CssClass="btn btn-sm btn-success" Text="Seleccionar" HeaderText="Seleccionar">
                                            <ControlStyle CssClass="btn btn-sm btn-success" />
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="btnActualizar" ControlStyle-CssClass="btn btn-sm btn-info" Text="Actualizar" HeaderText="Actualizar">
                                            <ControlStyle CssClass="btn btn-sm btn-info" />
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="btnEliminar" ControlStyle-CssClass="btn btn-sm btn-danger" Text="Eliminar" HeaderText="Eliminar">
                                            <ControlStyle CssClass="btn btn-sm btn-danger" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                                <div class="send-button">
                                </div>
                            </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="pnlMyBooks" runat="server">
                        <h3>Libros a editar</h3>
                        <br />
                        <asp:DataList ID="dtlBooks" runat="server" RepeatDirection="Horizontal" Width="883px" HorizontalAlign="Center" RepeatColumns="3" CellPadding="10" DataKeyField="IDLibro" OnEditCommand="dtlBooks_EditCommand" OnUpdateCommand="dtlBooks_UpdateCommand" OnCancelCommand="dtlBooks_CancelCommand" OnItemDataBound="dtlBooks_ItemDataBound" OnDeleteCommand="dtlBooks_DeleteCommand">
                            <ItemTemplate>
                                <div class="card" style="width: 19rem;">
                                    <h5 class="card-header">Editar</h5>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("IDLibro") %>'></asp:Label>
                                    <img class="card-img-top" src="../LibrosPortadas/<%# Eval("ImagenPortada") %>" alt="Card image cap" width="237" height="260">
                                    <div class="card-body">
                                        <h5 class="title"><%# Eval("Categoria") %></h5>
                                        <h5 class="card-title"><%# Eval("Titulo") %></h5>
                                        <p class="text"><%# Eval("Sinopsis") %></p>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="card-link" CommandName="edit">Editar</asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="card" style="width: 19rem;">
                                    <h5 class="card-header">
                                        Editando...
                                        <asp:Label ID="lblIdLibro" runat="server" Text='<%# Eval("IDLibro") %>'></asp:Label></h5>
                                    <img class="card-img-top" src="../LibrosPortadas/<%# Eval("ImagenPortada") %>" alt="Card image cap" width="237" height="260">
                                    <img id="imagend2" class="img-raised" alt="" width="237" height="260" src="" />
                                    <div class="card-body">
                                        <%--<asp:TextBox ID="txtCategoria" runat="server" Text='<%# Eval("Categoria") %>' CssClass="form-control" Height="30" Width="250"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlCat" runat="server" CssClass="form-control" Height="30" Width="250"></asp:DropDownList>
                                        <br />
                                        <asp:TextBox ID="txtTitulo" runat="server" Text='<%# Eval("Titulo") %>' CssClass="form-control" Height="30" Width="250"></asp:TextBox>
                                        <br />
                                        <asp:TextBox ID="txtSinopsis" runat="server" Text='<%# Eval("Sinopsis") %>' CssClass="form-control" Height="30" Width="250"></asp:TextBox>
                                        <br />
                                        <asp:DropDownList CssClass="form-control" ID="ddlEstatus" runat="server" Height="30" Width="250"></asp:DropDownList>
                                        <br />
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="update" CssClass="btn bnt-sm btn-round btn-warning">Guardar</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbtnCancel" runat="server" CommandName="cancel">Cancelar</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbtnDelete" runat="server" CommandName="delete" CssClass="btn bnt-sm btn-round btn-danger">Eliminar</asp:LinkButton>
                                        <asp:FileUpload ID="fuImg" runat="server" accept=" image/jpeg, image/png" onchange="showimagepreview(this)" />
                                       <br />
                                         <label>Cargar nuevo pdf</label> 
                                         <asp:FileUpload ID="LoadNewPdf" runat="server" />
                                    </div>
                                </div>
                            </EditItemTemplate>
                        </asp:DataList>
                        </asp:Panel>
                        <asp:Panel ID="pnlNoBooks" runat="server">
                            <h3 class="title">No tienes libros actualmente, no te quedes atrás</h3>
                            <a href="\newbook" class="btn btn-outline-warning btn-warning">Registra un libro!</a>
                        </asp:Panel>
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
                            <a href="AcercaDe.aspx">Acerca de nosotros
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
    </div>
</asp:Content>
