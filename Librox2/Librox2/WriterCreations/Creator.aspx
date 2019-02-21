<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Creator.aspx.cs" Inherits="Librox2.WriterCreations.Creator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Creador</title>
    <!-- Bootstrap css-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <!--Google Icon Font-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <!-- Propeller css -->
    <link href="resources_material/assets/css/propeller.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">

        <!-- Basic nav menu which will remain fixed at the top -->
        <nav class="navbar navbar-default navbar-fixed-top pmd-navbar pmd-z-depth">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a href="javascript:void(0);" class="navbar-brand navbar-brand-custome">Escribox</a>
                </div>
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div id="bs-example-navbar-collapse-1" class="collapse navbar-collapse">
                    <ul class="nav navbar-nav">
                        <li><a class="pmd-ripple-effect" href="/home">Inicio <span class="sr-only">(current)</span></a></li>
                        <li><a class="pmd-ripple-effect" href="/libros">Libros</a></li>
                        <li><a class="pmd-ripple-effect" href="/mybooks">Mis publicaciones</a></li>
                        <li><a class="pmd-ripple-effect" href="/libros"></a></li>
                    </ul>
                    <div class="dropdown pmd-dropdown pmd-user-info pull-right">
                        <a href="javascript:void(0);" class="btn-user dropdown-toggle media" data-toggle="dropdown" aria-expanded="false">
                            <div class="media-left">
                                <img runat="server" id="ImagenUsuario" class="img-circle" src="" width="40" height="40" alt="avatar" />
                            </div>
                            <div class="media-body media-middle">
                                <asp:Label ID="lblUserP" runat="server" Text="David" Visible="true"></asp:Label>
                            </div>
                            <div class="media-right media-middle">
                                <i class="material-icons md-dark pmd-sm">more_vert</i>
                            </div>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-right" role="menu">
                            <li><a href="../Forms/Perfil.aspx">Perfil</a></li>
                            <li><%--<a href="javascript:void(0);">Salir</a>--%>
                                <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click">Salir</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
            <div class="pmd-sidebar-overlay"></div>
        </nav>
        <!-- getting started constructor start -->
        <div class="pmd-content pmd-content-custom getting-start-page" id="content">
            <div class="componant-title-bg">
                <!--Getting started start -->
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <!-- Card body -->
                            <asp:Panel ID="pnlWritter" runat="server">
                                <div class="pmd-card pmd-card-default pmd-z-depth pmd-card-custom-form">
                                    <div class="pmd-card-body">
                                        <asp:Label ID="lblWar" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Documento sin título"></asp:TextBox>
                                        <div class="form-group pmd-textfield pmd-textfield-floating-label">
                                            <label class="control-label">Toca aquí para escribir...</label>
                                            <asp:Label ID="lblHelp" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Height="700px" Columns="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlGeneral" runat="server">
                                <h1 class="text-center">
                                    <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label></h1>
                                <br />
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-3">
                                            <div class="pmd-card pmd-card-media-inline pmd-card-default pmd-z-depth">
                                                <!-- Card media-->
                                                <div class="pmd-card-media">
                                                    <!-- Card media heading -->
                                                    <div class="media-body">
                                                        <h2 class="pmd-card-title-text">
                                                            <asp:LinkButton ID="lbtnTitulo" runat="server" CommandName="edit" Text='<%# Eval("Text") %>'></asp:LinkButton></h2>
                                                        <span class="pmd-card-subtitle-text">Elige la acción que desees, edita o elimina este libro. Ten en cuenta que al seleccionar 'Eliminar' no se te solicitará confirmación.
                                                        <asp:Label ID="lblValue" runat="server" Text='<%# Eval("Value") %>' Visible="false"></asp:Label></span>
                                                    </div>
                                                    <!-- Card media image -->
                                                    <div class="media-right media-middle">
                                                        <a href="javascript:void(0);">
                                                            <img width="80" height="80" src="https://animagehub.com/wp-content/uploads/2016/03/book-vector-13.png">
                                                        </a>
                                                    </div>
                                                </div>
                                                <!-- Card action -->
                                                <div class="pmd-card-actions">
                                                    <asp:LinkButton ID="lbtnPost" CssClass="btn pmd-btn-flat pmd-ripple-effect btn-primary" runat="server" CommandName="post"><i class="material-icons pmd-sm">cloud_upload</i></asp:LinkButton>
                                                    <asp:LinkButton ID="lbtnEdit" CssClass="btn pmd-btn-flat pmd-ripple-effect btn-primary" runat="server" CommandName="edit"><i class="material-icons pmd-sm">edit</i></asp:LinkButton>
                                                    <asp:LinkButton ID="lbtnDelete" CssClass="btn pmd-btn-flat pmd-ripple-effect btn-danger" runat="server" CommandName="delete"><i class="material-icons pmd-sm">delete</i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </asp:Panel>

                            <!-- Floating Action Button like Google Material -->
                            <div class="menu pmd-floating-action" role="navigation">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="pmd-floating-action-btn btn btn-sm pmd-btn-fab pmd-btn-raised pmd-ripple-effect btn-default" data-title="Guardar y salir" Visible="false" OnClick="LinkButton1_Click">
                                    <span class="pmd-floating-hidden">Guardar</span>
                                    <i class="material-icons">save</i>
                                </asp:LinkButton>
                                <%--<a href="javascript:void(0);" class="pmd-floating-action-btn btn btn-sm pmd-btn-fab pmd-btn-raised pmd-ripple-effect btn-default" data-title="Guardar">
                                    <span class="pmd-floating-hidden">Guardar</span>
                                    <i class="material-icons">save</i>
                                </a>--%>
                                <asp:LinkButton ID="lbtnNew" runat="server" CssClass="pmd-floating-action-btn btn pmd-btn-fab pmd-btn-raised pmd-ripple-effect btn-primary" data-title="Nuevo" OnClick="lbtnNew_Click">
                                    <span class="pmd-floating-hidden">Primary</span>
                                    <i class="material-icons pmd-sm">add</i>
                                </asp:LinkButton>
                                <%--<a class="pmd-floating-action-btn btn pmd-btn-fab pmd-btn-raised pmd-ripple-effect btn-primary" data-title="Add" href="javascript:void(0);">
                                    <span class="pmd-floating-hidden">Primary</span>
                                    <i class="material-icons pmd-sm">add</i>
                                </a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- jQuery before Propeller.js -->
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <script src="resources_material/assets/js/propeller.min.js"></script>
        <!-- Propeller Global js -->
        <script src="http://propeller.in/components/global/js/global.js"></script>

        <!-- Propeller ripple effect js -->
        <script type="text/javascript" src="http://propeller.in/components/button/js/ripple-effect.js"></script>
    </form>
</body>
</html>
