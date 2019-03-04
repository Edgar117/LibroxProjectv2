<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="Librox2.Forms.Read" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Start your development with a Design System for Bootstrap 4." />
    <meta name="author" content="Creative Tim" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Leyendo...</title>
    <!-- Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <!-- Icons -->
    <link href="../argon/assets/vendor/nucleo/css/nucleo.css" rel="stylesheet" />
    <link href="../argon/assets/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Argon CSS -->
    <link href="../argon/assets/css/argon.css?v=1.0.1" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <header class="header-global">
        </header>

        <main class="profile-page">
            <section class="section-profile-cover section-shaped my-0">
                <!-- Circles background -->
                <div class="shape shape-style-1 shape-primary alpha-4">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
                <!-- SVG separator -->
                <div class="separator separator-bottom separator-skew">
                    <svg x="0" y="0" viewBox="0 0 2560 100" preserveAspectRatio="none" version="1.1" xmlns="http://www.w3.org/2000/svg">
                        <polygon class="fill-white" points="2560 0 2560 100 0 100"></polygon>
                    </svg>
                </div>
            </section>
            <section class="section">
                <div class="container">
                    <div class="card card-profile shadow mt--300">
                        <div class="px-4">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <a href="#">
                                            <img id="imgPerfil" runat="server" src="../argon/assets/img/theme/team-4-800x800.jpg" class="rounded-circle" width="215" height="200" />
                                        </a>
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-3 text-lg-right align-self-lg-center">
                                    <div class="card-profile-actions py-4 mt-lg-0">
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbtnSalir_Click" CssClass="btn btn-sm btn-danger mr-4">Salir</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnBack1" runat="server" OnClick="LinkButton3_Click" CssClass="btn btn-sm btn-info float-center"><<</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnNext1" runat="server" OnClick="lbtnNext_Click" CssClass="btn btn-sm btn-info float-right">>></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-1">
                                    <div class="card-profile-stats d-flex justify-content-center">
                                    </div>
                                </div>
                            </div>
                            <div class="text-center mt-5">
                                <br />
                                <h3 id="titulo" runat="server"></h3>
                                <div class="h6 font-weight-300">
                                    <i class="ni location_pin mr-2"></i>
                                    <asp:Label ID="lblAutor" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="h6 mt-4">
                                    <i class="ni business_briefcase-24 mr-2"></i>
                                    <asp:Label ID="lblSinop" runat="server" Text=""></asp:Label>
                                </div>
                                <%--<div><i class="ni education_hat mr-2"></i>University of Computer Science</div>--%>
                            </div>
                            <div class="mt-5 py-5 border-top text-center">
                                <div class="row justify-content-around">
                                    <div class="col-lg-9">
                                        <%--Aquí va el texto--%>
                                        <p>
                                            <asp:Label oncopy="return false;" ID="lblTexto" runat="server" Text="Label"></asp:Label>
                                            <br />
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-3 text-lg-right align-self-lg-center">
                                    <div class="card-profile-actions py-4 mt-lg-0">
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-1">

                                    <div class="card-profile-stats d-flex justify-content-center">
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-3 text-lg-right align-self-lg-center">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:LinkButton ID="lbtnSalir" runat="server" OnClick="lbtnSalir_Click" CssClass="btn btn-sm btn-danger mr-4">Salir</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnBack2" runat="server" OnClick="LinkButton3_Click" CssClass="btn btn-sm btn-info float-center"><<</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnNext" runat="server" OnClick="lbtnNext_Click" CssClass="btn btn-sm btn-info float-right">>></asp:LinkButton>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-1">
                                    <div class="card-profile-stats d-flex justify-content-center">
                                        <div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <asp:Label Visible="false" ID="lblPaginas" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

            </section>
        </main>

        
        <!-- Core -->
        <script src="../argon/assets/vendor/jquery/jquery.min.js"></script>
        <script src="../argon/assets/vendor/popper/popper.min.js"></script>
        <script src="../argon/assets/vendor/bootstrap/bootstrap.min.js"></script>
        <script src="../argon/assets/vendor/headroom/headroom.min.js"></script>
        <!-- Argon JS -->
        <script src="../argon/assets/js/argon.js?v=1.0.1"></script>
        <!--Script pa no copiar -->
        
    </form>
</body>
</html>
