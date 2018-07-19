<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Librox2.GUI.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- inner page banner-->
<div class="inner-banner">
	
</div>
<!-- //inner page banner-->

<!-- Welcome -->
<section class="welcome py-5 my-lg-5">
	<div class="container">
		<div class="row welcome_grids">
			<div class="col-lg-7 mb-lg-0 mb-5">
				<h3 class="mb-3 text-capitalize">Bienvenido a Librox</h3>
				<p class="my-2 initial font-italic">¿Quienes somos?</p>
				<p class="mb-5 mt-4">Somos una plataforma,  cuya finalidad es impulsar el talento de las personas dedicadas a escribir y que les gustaria aprovecharlo de tal manera que puedan darse a conocer a traves de la comunidad  lectora y poder compartir sus pensamientos, ideologias y cultura, a traves de sus obras, poemas etc. 
</p>
			</div>
			<div class="col-lg-5 welcome_right">
				<img src="../images/slide1.jpg" alt="" class="img-fluid"/>
			</div>
		</div>
	</div>
</section>
<!-- //Welcome -->
<!-- welcome bottom -->
<section class="welcome_bottom">
	<div class="layer py-5">
		<div class="container py-lg-5">
			<div class="row bottom_grids">
				<div class="col-lg-6 col-md-8">
					<h4>Objetivos</h4>
					<p class="my-4">•Mantenernos actualizados en las diversas categorías.</p>
                    <p class="my-4">•Abarcar diferentes géneros de lectura para la diversidad de gustos.</p>
					<h4 class="head text-uppercase"><i class="fas mb-4 fa-eye"></i>Valores </h4>
					<p class="mb-4">Respecto,Honestidad,Tolerancia,Pasión,Creatidad</p>
				</div>
				<div class="col-lg-6 col-md-4 video text-center">
					<a href="#" class="text-uppercase" data-toggle="modal" data-target="#exampleModal"><span class="fas fa-play-circle"></span></a>
				</div>
			</div>
		</div>
	</div>
</section>
<!-- //welcome bottom -->

<!-- services -->
<section class="services py-5 my-lg-5">
	<div class="container">
		<h3 class="heading text-center text-capitalize mb-5">En donde nos puedes encontrar</h3>
		<div class="row service_grids">
			<div class="col-lg-4 col-md-6 mb-md-0 mb-3 text-center">
				<div class="serv_grid1">
					<i class="fas mb-4 fa-globe"></i>
					<h4 class="text-uppercase">Pagína Web</h4>
					<p class="mt-4 mb-5">Pagína web para subir archivos y leer libros de manera intuitiva y divertida.</p>
					<a href="#"> Leer mas</a>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 mb-md-0 mb-3 text-center">
				<div class="serv_grid1 service_grid_active">
					<i class="fas mb-4 fa-mobile-alt"></i>
					<h4 class="text-uppercase">App Movil</h4>
					<p class="mt-4 mb-5">App Movil con la misma funcionalidad de la pagina web, pero al alcance de tu smartphone.</p>
					<a href="#">Leer Mas </a>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 text-center">
				<div class="serv_grid1">
					<i class="fas mb-4 fa-desktop"></i>
					<h4 class="text-uppercase">Desing</h4>
					<p class="mt-4 mb-5">Phasellus id venenatis odio. Curabitur eleifend mattis ipsum non euismod. Suspendisse non euismod dolor.</p>
					<a href="#"> Learn more </a>
				</div>
			</div>
		</div>
	</div>
</section>
<!-- //services -->

</asp:Content>
