<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterBack.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Librox2.GUI.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
      Registro de Categorias
        </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li><a href="#">Registrar Categorias</a></li>
      </ol>
    </section>
    <!-- Main content -->
    <section class="content">
       <div class="row">
        <div class="col-md-12">
          <div class="box box-info">
            <div class="box-header">
              <h3 class="box-title">Registro de Categorias para libros</h3>
            </div>
            <div class="box-body">
                <div class="col-md-4">
                 <div class="form-group">
                 <label>Nombre de la Categoria:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-folder"></i>
                  </div>
                   <asp:TextBox ID="txtCategorias" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
                </div><asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <div class="col-md-4">
                 <div class="form-group">
                <label>Categoria Visible:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                         <i class="fa fa-question"></i>
                  </div>
                         <asp:DropDownList ID="DPGeneraSc" AutoPostBack="true" CssClass="form-control" runat="server" >
                         <asp:ListItem>Escoja una opción</asp:ListItem>
                         <asp:ListItem>SI</asp:ListItem>
                         <asp:ListItem>NO</asp:ListItem>
                         <asp:ListItem>Proximamente</asp:ListItem>
                    </asp:DropDownList>

                </div>
              </div>
                </div>
                      <div class="col-md-4">
                 <div class="form-group">
                <label>Mattermost Message:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-mail-forward"></i>
                  </div>               
                    <asp:Button ID="Button1" CssClass="form-control" OnClick="Button1_Click" runat="server" Text="Registrar" />
                </div>
              </div>
                </div>
                      
                 
            

                      <div class="col-md-12">
                          <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server"></asp:GridView>   
                      </div>
                 </ContentTemplate>
    </asp:UpdatePanel>
              </div>
            
                </div>
            </div>
        </section>
          </div>
</asp:Content>
