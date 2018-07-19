<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Acerca.aspx.cs" Inherits="Librox2.GUI.Acerca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- For about Slider-->	
	<link rel="stylesheet" href="../css/owl.carousel.css" type="text/css" media="all"/> <!-- Owl-Carousel-CSS -->
    <!-- inner page banner-->
<div class="inner-banner">
	
</div>
<!-- //inner page banner-->
    <!-- About us -->
<section class="about py-5 my-lg-5">
	<div class="container">
		<h3 class="heading text-center text-capitalize mb-5">¿Por que somos diferentes?</h3>
	</div>
</section>
<!-- //About us -->
<!-- help -->
<section class="help">
	<div class="layer py-5">
		<div class="container py-lg-5">
		<h3 class="heading text-center text-capitalize mb-5">Estamos para ayudarte </h3>
			<div class="row help_grids">
				<div class="col-sm-4">
					<div class="row">
						<div class="col-lg-3 mb-lg-0 mb-4 icon">
							<i class="fas fa-briefcase"></i>
						</div>
						<div class="col-lg-9">
							<h4 class="text-uppercase mb-3">Negocio</h4>
							<p class="mb-3">Si te gusta escribir en tus tiempos libres, por que no hacer dinero con eso que tanto te gusta.</p>
							<a href="#">Read More <i class="fas fa-angle-right"></i></a>
						</div>
					</div>
				</div>
				<div class="col-sm-4 mt-sm-0 mt-4">
					<div class="row">
						<div class="col-lg-3 mb-lg-0 mb-4 icon">
							<i class="fas fa-signal"></i>
						</div>
						<div class="col-lg-9">
							<h4 class="text-uppercase mb-3">Estrategia</h4>
							<p class="mb-3">Nosotros ofrecemos el 50% de la venta de tu libro.</p>
							<a href="#">Read More <i class="fas fa-angle-right"></i></a>
						</div>
					</div>
				</div>
				<div class="col-sm-4 mt-sm-0 mt-4">
					<div class="row">
						<div class="col-lg-3 mb-lg-0 mb-4 icon">
							<i class="fab fa-connectdevelop"></i>
						</div>
						<div class="col-lg-9">
							<h4 class="text-uppercase mb-3">Tecnología</h4>
							<p class="mb-3">Contamos con la mas alta tecnologia, para realizar los pagos y subir tus libros.</p>
							<a href="#">Read More <i class="fas fa-angle-right"></i></a>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</section>
<!-- //help -->

    <!-- about top -->
<section class="about-top py-5 my-lg-5">
	<div class="container">
		<h3 class="heading text-center text-capitalize mb-5">Visión</h3>
		<div class="row top-grids">
			<div class="col-lg-4">
               <h3 class="heading text-center text-capitalize mb-5">Misión</h3>
				<P>Librox es una herramienta, para aquellos que buscan publicar un libro, poemas, pensamientos y más, con la finalidad de que la gente los reconozca y puedan ver las diversas opiniones acerca de su propia obra. Con esto, librox busca implementar la cultura de la lectura y de la escritura a todo el país y reforzar dichos talentos.</P>
			</div>
			<div class="col-lg-5 my-lg-0 my-5">
				<p>Ser una empresa que apoye a todos los escritores independientes a expresar sus pensamientos, ideas y filosofía y así,  sean reconocidos por su talento y sus diversas obras, con el objetivo de darse a conocer y valorar su esfuerzo a través de la comunidad lectora del país..</p>
			</div>
			<div class="col-lg-3 col-sm-6">
				<img src="../images/slide1.jpg" alt="" class="img-fluid">
			</div>
		</div>
	</div>
</section>
    <!-- project -->
<section class="project py-5 text-center">
	<div class="container">
		<h3 class="text-capitalize mb-5">Quieres empezar un nuevo proyecto ?</h3>
		<a href="contact.html" class="text-uppercase"><i class="fas fa-envelope-open"></i>Contactanos </a>
	</div>
</section>
<!-- //project -->
<!-- //about top -->
</asp:Content>
