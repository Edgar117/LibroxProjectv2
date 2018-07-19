<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Librox2.GUI.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--/banner-->
<div class="banner">
	<div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
		<ol class="carousel-indicators">
			<li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
			<li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
			<li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
			<li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
		</ol>
		<div class="carousel-inner" role="listbox">
			<div class="carousel-item active">
				<div class="carousel-caption">
					<h3>Libros <span>Espectaculares</span></h3>
					<p class="text-capitalize mt-3 mb-sm-5 mb-4">Que esperas para leer o escribir.</p>
					<a href="#">Encuentranos <span class="fas fa-long-arrow-alt-down"></span></a>
				</div>
			</div>
			<div class="carousel-item item2">
				<div class="carousel-caption">
					<h3>Leer  <span>te lleva a nuevos mundos</span></h3>
					<p class="text-capitalize mt-3 mb-sm-5 mb-4">¿Quieres conocer nuevos mundos?</p>
					<a href="#">Find Out More <span class="fas fa-long-arrow-alt-down"></span></a>
				</div>
			</div>
			<div class="carousel-item item3">
				<div class="carousel-caption">
					<h3>Terro,Suspenso <span>y otros generos a tu alcance</span></h3>
					<p class="text-capitalize mt-3 mb-sm-5 mb-4">Ingresar el facíl</p>
					<a href="#">Find Out More <span class="fas fa-long-arrow-alt-down"></span></a>
					</div>
			</div>
		</div>
		<a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
			<span class="carousel-control-prev-icon" aria-hidden="true"></span>
			<span class="sr-only">Previous</span>
		</a>
		<a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
			<span class="carousel-control-next-icon" aria-hidden="true"></span>
			<span class="sr-only">Next</span>
		</a>
	</div>
</div>
<!--//banner-->

<!-- Welcome -->
<section class="welcome py-5 my-lg-5">
	<div class="container">
		<div class="row welcome_grids">
			<div class="col-lg-7 mb-lg-0 mb-5">
				<h3 class="mb-3 text-capitalize">Bienvenido a Librox.</h3>
				<p class="my-2 initial font-italic">Donde cada cabeza es un mundo diferente.</p>
				<p class="mb-5 mt-4"> Información o agradecimientos...</p>
			</div>
			<div class="col-lg-5 welcome_right">
				<img src="../images/slide1.jpg" alt="" class="img-fluid">
			</div>
		</div>
	</div>
</section>
<!-- //Welcome -->

<!-- Testimonials -->
<section class="testimonials py-5">
	<div class="container py-lg-5">
		<div class="row">
			<!-- Clients -->
			<div class=" col-lg-6 clients">
				<div class="slider p-sm-5 p-4">
					<div class="flexslider">
						<ul class="slides">
							<li>
								<div class="client row">
									<div class="col-sm-4">
										<img src="images/t1.jpg" alt="" />
									</div>
									<div class="col-sm-8">
										<h5 class="my-2">Brian Fantana</h5>
										<h6>lorem ipsum dolor</h6>
										<ul class="rating mt-2">
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star-half"></span></li>
										</ul>
									</div>
								</div>
								<p class="my-4">Lorem ipsum dolor sit amet, consectetur elit adipiscing elit, sed do eiusmod tempor labore incididunt ut et dolore magna aliqua.</p>
									
							</li>
							<li>
								<div class="client row">
									<div class="col-sm-4">
										<img src="images/t2.jpg" alt="" />
									</div>
									<div class="col-sm-8">
										<h5 class="my-2">Brick Tamland</h5>
										<h6>lorem ipsum dolor</h6>
										<ul class="rating mt-2">
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star-half"></span></li>
										</ul>
									</div>
								</div>
								<p class="my-4">Lorem ipsum dolor sit amet, consectetur elit adipiscing elit, sed do eiusmod tempor labore incididunt ut et dolore magna aliqua.</p>
									
							</li>
							<li>
								<div class="client row">
									<div class="col-sm-4">
										<img src="images/t1.jpg" alt="" />
									</div>
									<div class="col-sm-8">
										<h5 class="my-2">Ron Burgundy</h5>
										<h6>lorem ipsum dolor</h6>
										<ul class="rating mt-2">
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star-half"></span></li>
										</ul>
									</div>
								</div>
								<p class="my-4">Lorem ipsum dolor sit amet, consectetur elit adipiscing elit, sed do eiusmod tempor labore incididunt ut et dolore magna aliqua.</p>
									
							</li>
							<li>
								<div class="client row">
									<div class="col-sm-4">
										<img src="images/t1.jpg" alt="" />
									</div>
									<div class="col-sm-8">
										<h5 class="my-2">Arturo Mendez</h5>
										<h6>lorem ipsum dolor</h6>
										<ul class="rating mt-2">
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star"></span></li>
											<li class="mx-1"><span class="fas fa-star-half"></span></li>
										</ul>
									</div>
								</div>
								<p class="my-4">Lorem ipsum dolor sit amet, consectetur elit adipiscing elit, sed do eiusmod tempor labore incididunt ut et dolore magna aliqua.</p>
									
							</li>
						</ul>
					</div>
				</div>
			</div>
			<!-- //Clients -->
			<div class="col-lg-6 collections mt-lg-0 mt-5 px-sm-5 px-4">
				<h3>Comentarios de clientes</h3>
				<p class="my-4">Lorem ipsum dolor sit amet, consectetur elit adipiscing elit, sed do eiusmod tempor labore incididunt ut et dolore magna aliqua. consectetur elit adipiscing elit, sed do eiusmod tempor labore incididunt ut et dolore. consectetur elit adipiscing elit, sed do eiusmod tempor Etiam vel ante ac elit scelerisque bibendum. Fusce suscipit nibh ami.</p>
				<a href="#" class="text-capitalize" data-toggle="modal" data-target="#exampleModalCenter" role="button">Read more <i class="fas fa-angle-right"></i></a>
			</div>
		</div>
	</div>
</section>
<!-- Testimonials -->

<!-- Process -->
<section class="process py-5 my-lg-5">
	<div class="container">
		<div class="row process-grids">
			<div class="col-lg-4 col-md-6 grid1">
				<span class="fab fa-digital-ocean"></span>
				<h3 class="text-uppercase mt-3">Metas</h3>
				<ul class="mt-4">
					<li class="mt-2"><span class="fas fa-angle-right"></span>Impulsar a autores independientes a expresar sus obras</li>
					<li class="mt-2"><span class="fas fa-angle-right"></span>Motivar a la comunidad lectora a reconocer el  talento de cada autor</li>
					<li class="mt-2"><span class="fas fa-angle-right"></span>•	Mantener satisfechos a nuestros usuarios</li>
				</ul>
			</div>
			<div class="col-lg-4 col-md-6 grid1 mt-md-0 mt-5">
				<span class="fab fa-digital-ocean"></span>
				<h3 class="text-uppercase mt-3">Proceso</h3>
				<ul class="mt-4">
					<li class="mt-2"><span class="fas fa-angle-right"></span>Eficiente.</li>
					<li class="mt-2"><span class="fas fa-angle-right"></span>Rapido</li>
					<li class="mt-2"><span class="fas fa-angle-right"></span>Sin problemas</li>
				</ul>
			</div>
			<div class="col-lg-4 col-md-12 grid1 mt-lg-0 mt-5">
				<span class="fab fa-digital-ocean"></span>
				<h3 class="text-uppercase mt-3">Resultados</h3>
				<ul class="mt-4">
					<li class="mt-2"><span class="fas fa-angle-right"></span>Positivos.</li>
					<li class="mt-2"><span class="fas fa-angle-right"></span>Geniales</li>
					<li class="mt-2"><span class="fas fa-angle-right"></span>Lucrativos</li>
				</ul>
			</div>
		</div>
	</div>
</section>
<!-- //Process -->

<!-- odometer stats-->
<section class="odometer1">
	<div class="layer py-5">
		<div class="container py-lg-5">
			<h3 class="heading mb-5 text-capitalize text-center">Status de la compania </h3>
			<div class="row w3layouts_statistics_grid_right">
				<div class="col-sm-3 col-6 text-center w3_stats_grid">
					<h3 id="w3l_stats1" class="odometer">0</h3>
					<p class="mt-2">Versiones</p>
				</div>
				<div class="col-sm-3 col-6 text-center w3_stats_grid">
					<h3 id="w3l_stats2" class="odometer">0</h3>
					<p class="mt-2">Comentarios</p>
				</div>
				<div class="col-sm-3 col-6 mt-sm-0 mt-4 text-center w3_stats_grid">
					<h3 id="w3l_stats3" class="odometer">0</h3>
					<p class="mt-2">Equipo de trabajo</p>
				</div>
				<div class="col-sm-3 col-6 mt-sm-0 mt-4 text-center w3_stats_grid">
					<h3 id="w3l_stats4" class="odometer">0</h3>
					<p class="mt-2">Libros</p>
				</div>
			</div>
		</div>
	</div>
</section>
<!-- //odometer stats -->

<!-- team -->
<div class="banner-bottom py-5 my-lg-5">
	<div class="container">
	<h3 class="heading mb-5 text-capitalize text-center">Equipo de trabajo </h3>
		<div class="row w3_testimonials_grids">
			<div class="col-md-3 col-sm-6 text-center w3layouts_team_grid">
				<div class="agileits_grid w3_team_grid1">
					<figure class="effect-layla">
						<img src="../images/team1.jpg" alt=" " class="img-responsive" />
						<figcaption>
							<ul class="agileits_social_list">
								<li><a href="#" class="w3_agile_facebook"><i class="fab fa-facebook-f" aria-hidden="true"></i></a></li>
								<li><a href="#" class="agile_twitter"><i class="fab fa-twitter" aria-hidden="true"></i></a></li>
								<li><a href="#" class="w3_agile_dribble"><i class="fab fa-dribbble" aria-hidden="true"></i></a></li>
							</ul>
						</figcaption>			
					</figure>
				</div>
				<h4 class="mb-2">Fausto</h4>
				<p>General Manager</p>
			</div>
			<div class="col-md-3 col-sm-6 mt-sm-0 mt-5 text-center w3layouts_team_grid">
				<div class="agileits_grid w3_team_grid1">
					<figure class="effect-layla">
						<img src="../images/team2.jpg" alt=" " class="img-responsive" />
						<figcaption>
							<ul class="agileits_social_list">
								<li><a href="#" class="w3_agile_facebook"><i class="fab fa-facebook-f" aria-hidden="true"></i></a></li>
								<li><a href="#" class="agile_twitter"><i class="fab fa-twitter" aria-hidden="true"></i></a></li>
								<li><a href="#" class="w3_agile_dribble"><i class="fab fa-dribbble" aria-hidden="true"></i></a></li>
							</ul>
						</figcaption>			
					</figure>
				</div>
				<h4 class="mb-2">Manuel</h4>
				<p>Founder & CEO</p>
			</div>
			<div class="col-md-3 col-sm-6 mt-md-0 mt-5 text-center w3layouts_team_grid">
				<div class="agileits_grid w3_team_grid1">
					<figure class="effect-layla">
						<img src="../images/team3.jpg" alt=" " class="img-responsive" />
						<figcaption>
							<ul class="agileits_social_list">
								<li><a href="#" class="w3_agile_facebook"><i class="fab fa-facebook-f" aria-hidden="true"></i></a></li>
								<li><a href="#" class="agile_twitter"><i class="fab fa-twitter" aria-hidden="true"></i></a></li>
								<li><a href="#" class="w3_agile_dribble"><i class="fab fa-dribbble" aria-hidden="true"></i></a></li>
							</ul>
						</figcaption>			
					</figure>
				</div>
				<h4 class="mb-2">...</h4>
				<p>Asst. Manager</p>
			</div>
			<div class="col-md-3 col-sm-6 mt-md-0 mt-5 text-center w3layouts_team_grid">
				<div class="agileits_grid w3_team_grid1">
					<figure class="effect-layla">
						<img src="../images/team4.jpg" alt=" " class="img-responsive" />
						<figcaption>
							<ul class="agileits_social_list">
								<li><a href="#" class="w3_agile_facebook"><i class="fab fa-facebook-f" aria-hidden="true"></i></a></li>
								<li><a href="#" class="agile_twitter"><i class="fab fa-twitter" aria-hidden="true"></i></a></li>
								<li><a href="#" class="w3_agile_dribble"><i class="fab fa-dribbble" aria-hidden="true"></i></a></li>
							</ul>
						</figcaption>			
					</figure>
				</div>
				<h4 class="mb-2">...</h4>
				<p>Asst. Manager</p>
			</div>
		</div>
	</div>
</div>
<!-- //team -->

<!-- project -->
<section class="project py-5 text-center">
	<div class="container">
		<h3 class="text-capitalize mb-5">Tienes algun comentario?</h3>
		<a href="#" class="text-uppercase"><i class="fas fa-envelope-open"></i> Contactanos </a>
	</div>
</section>
<!-- //project -->

</asp:Content>
