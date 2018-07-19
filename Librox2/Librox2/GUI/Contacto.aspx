<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Librox2.GUI.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inner-banner">
	
</div>
    <section class="contact py-5 my-lg-5">
	<div class="container">
		<h3 class="heading text-center text-capitalize mb-5">Contactanos</h3>
		<div class="row contact_information">
			<div class="col-md-6 contact_left p-lg-5 p-4">
				<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6350041.310790406!2d30.68773492426509!3d39.0014851732576!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14b0155c964f2671%3A0x40d9dbd42a625f2a!2sTurkey!5e0!3m2!1sen!2sin!4v1522753415269"></iframe>
			</div>
			<div class="col-md-6 mt-md-0 mt-4">
				<div class="contact_right p-lg-5 p-4">
						<div class="w3_agileits_contact_left">
							<h3 class="mb-3">Formulario de contacto</h3>
							<input type="text" name="Name" id="txtnombre" placeholder="Tu nombre" required=""/>
							<input type="email" name="Email" id="txtemail" placeholder="Tu Email" required=""/>
							<input type="text" name="Phone" id="txttelefono" placeholder="Telefono" required=""/>
							<textarea id="mensaje" placeholder="Tu mensaje aqui..." required=""></textarea>
						</div>
						<div class="w3_agileits_contact_right">
							<input type="submit" value="Enviar"/>
						</div>
						<div class="clearfix"> </div>
				</div>
			</div>
			<div class="col-md-6">
				<div class="mt-5 information">
					<div class="row">
						<div class="col-sm-2 mb-sm-0 mb-3">
							<i class="fas fa-comments"></i>
						</div>
						<div class="col-sm-10">
							<h4 class="text-uppercase mb-4">Comunicación General</h4>
							<p class="mb-3 text-capitalize">Tienes alguna duda y aun no te respondemos, escribemos a este correo: <a href="mailto:soportelibrox@gmail.com">soportelibrox@gmail.com</a></p>
						</div>
					</div>
			</div>
				</div>
				<div class="col-md-6 mt-md-5 mt-2 information">
					<div class="row">
						<div class="col-sm-2 mb-sm-0 mb-3">
							<i class="fas fa-life-ring"></i>
						</div>
						<div class="col-sm-10">
							<h4 class="text-uppercase mb-4">Soporte tecníco</h4>
							<p class="mb-3 text-capitalize">Es urgente tu duda, llamanos a este numero sin ningún compromiso<span>+12 388 455 6789</span>.</p>
						</div>
					</div>
				</div>
		</div>
	</div>
</section>
</asp:Content>
