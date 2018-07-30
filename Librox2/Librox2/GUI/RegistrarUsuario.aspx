<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="Librox2.GUI.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inner-banner">
	
</div>
    <section class="contact py-5 my-lg-5">
	<div class="container">
		<h3 class="heading text-center text-capitalize mb-5">Registro de Usuario</h3>
		<div class="row contact_information">
			<div class="col-md-12 mt-md-0 mt-4">
				<div class="contact_right p-lg-5 p-4">
						<div class="w3_agileits_contact_left">
							<h3 class="mb-3">Formulario de Registro</h3>
							<input type="text" runat="server" name="Name" id="txtnombre" placeholder="Tu Nombre" required=""/>
                          
                            <input type="text" runat="server" name="Name" id="txtusuario" placeholder="Tu Usuario" required=""/>
							<input type="email"  runat="server" name="Email" id="txtemail" placeholder="Tu Email" required=""/>
							<input type="password"  runat="server" class="form-control" name="Phone" id="txtContraseña" placeholder="Contraseña" required=""/>
                              <input type="text"  runat="server" name="Name" id="txtcumpleaños" placeholder="17/12/1996" required=""/>
						</div>
						<div class="w3_agileits_contact_right"><br />
                            <asp:Button ID="btnSave" CssClass="btn btn-info" runat="server" Text="Registrarse" OnClick="btnSave_Click" />
						</div>
						<div class="clearfix"> </div>
				</div>
			</div>
		</div>
	</div>
</section>
</asp:Content>
