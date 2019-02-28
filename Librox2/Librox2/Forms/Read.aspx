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
                                            <img src="../argon/assets/img/theme/team-4-800x800.jpg" class="rounded-circle" />
                                        </a>
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-3 text-lg-right align-self-lg-center">
                                    <div class="card-profile-actions py-4 mt-lg-0">
                                        <a href="#" class="btn btn-sm btn-info mr-4"></a>
                                        <a href="#" class="btn btn-sm btn-default float-right"></a>
                                    </div>
                                </div>
                                <div class="col-lg-4 order-lg-1">
                                    <div class="card-profile-stats d-flex justify-content-center">
                                        <div>
                                            <span class="heading">22</span>
                                            <span class="description"></span>
                                        </div>
                                        <div>
                                            <span class="heading">10</span>
                                            <span class="description"></span>
                                        </div>
                                        <div>
                                            <span class="heading">89</span>
                                            <span class="description"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center mt-5">
                                <h3>Jessica Jones
               
                                    <span class="font-weight-light">, 27</span>
                                </h3>
                                <div class="h6 font-weight-300"><i class="ni location_pin mr-2"></i>Bucharest, Romania</div>
                                <div class="h6 mt-4"><i class="ni business_briefcase-24 mr-2"></i>Solution Manager - Creative Tim Officer</div>
                                <div><i class="ni education_hat mr-2"></i>University of Computer Science</div>
                            </div>
                            <div class="mt-5 py-5 border-top text-center">
                                <div class="row justify-content-center">
                                    <div class="col-lg-9">
                                        <%--Aquí va el texto--%>
                                        <p>
                                            <asp:Label ID="lblTexto" runat="server" Text="Label"></asp:Label>
                                            <br />
                                        </p>
                                        <asp:LinkButton ID="lbtnNext" runat="server" OnClick="lbtnNext_Click">Siguiente</asp:LinkButton>
                                        <br />
                                        <asp:LinkButton ID="lbtnSalir" runat="server" OnClick="lbtnSalir_Click">Salir</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
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
    </form>
</body>
</html>
