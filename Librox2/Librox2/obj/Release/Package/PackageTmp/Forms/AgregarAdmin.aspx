<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterBack.Master" AutoEventWireup="true" CodeBehind="AgregarAdmin.aspx.cs" Inherits="Librox2.Forms.AgregarAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
      Registro de Estatus
        </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li><a href="#">Registrar Usuario Admin</a></li>
      </ol>
    </section>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <!-- Main content -->
    <section class="content">
       <div class="row">
        <div class="col-md-12">
          <div class="box box-info">
            <div class="box-header">
              <h3 class="box-title">Registro de Usuario Administrador</h3>
            </div>
            <div class="box-body">
                <div class="col-md-3">
                 <div class="form-group">
                 <label>Usuario:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-folder"></i>
                  </div>
                   <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
                </div>
                 <div class="col-md-3">
                 <div class="form-group">
                 <label>Correo:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-folder"></i>
                  </div>
                   <asp:TextBox ID="txtcorreo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
                </div>
          <div class="col-md-3">
                 <div class="form-group">
                <label>Contraseña:</label>
               <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-folder"></i>
                  </div>
                   <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
                </div>
                      <div class="col-md-3">
                 <div class="form-group">
                <label>Guardar:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa  fa-save"></i>
                  </div>               
                    <asp:Button ID="btnRegisterAdminUser" CssClass="form-control" OnClick="btnRegisterAdminUser_Click"  runat="server" Text="Registrar" />
                </div>
              </div>
                </div>
                      <div class="col-md-12">
                          <asp:GridView ID="GVUsersAdmin" CssClass="table table-bordered table-hover" runat="server" OnSelectedIndexChanged="GVUsersAdmin_SelectedIndexChanged" OnRowCommand="GVUsersAdmin_RowCommand" >
                               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                               <Columns>
                                    <asp:ButtonField CommandName="btneliminar" ControlStyle-CssClass="btn btn-danger"  Text="Eliminar"/>                                
                       </Columns>
                          </asp:GridView>   
                      </div>
              </div>
                </div>
            </div>
        </section>
          </div>
            </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
