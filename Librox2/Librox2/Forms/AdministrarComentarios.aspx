<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterBack.Master" AutoEventWireup="true" CodeBehind="AdministrarComentarios.aspx.cs" Inherits="Librox2.Forms.AdministrarComentarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
     Administrar Comentarios
        </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li><a href="#">Administrar Comentarios</a></li>
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
              <h3 class="box-title">Comentarios</h3>
            </div>
            <div class="box-body">
                      <div class="col-md-12">
                          <asp:GridView ID="GVComentarios" CssClass="table table-bordered table-hover" runat="server" OnRowCommand="GVComentarios_RowCommand"  >
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
