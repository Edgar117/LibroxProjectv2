<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterBack.Master" AutoEventWireup="true" CodeBehind="PreciosLibros.aspx.cs" Inherits="Librox2.GUI.PreciosLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
      Registro de Precios de libros
        </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li><a href="#">Registrar Precios</a></li>
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
              <h3 class="box-title">Registro de Precios para libros de acuerdo a sus ranking</h3>
            </div>
            <div class="box-body">
                          <div class="col-md-4">
                 <div class="form-group">
                <label>Ranking:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                         <i class="fa fa-star"></i>
                  </div>
                         <asp:DropDownList ID="DPGeneraSc" AutoPostBack="true" CssClass="form-control" runat="server" >
                         <asp:ListItem>Escoja una opción</asp:ListItem>
                         <asp:ListItem>0-2</asp:ListItem>
                         <asp:ListItem>3-4</asp:ListItem>
                         <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>

                </div>
              </div>
                </div>
                <div class="col-md-4">
                 <div class="form-group">
                 <label>Precio :</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-dollar"></i>
                  </div>
                   <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </div>
              </div>
                </div>

                      <div class="col-md-4">
                 <div class="form-group">
                <label>Guardar:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa  fa-save"></i>
                  </div>               
                    <asp:Button ID="btnRegisterPrecio" CssClass="form-control" OnClick="btnRegisterPrecio_Click"  runat="server" Text="Registrar" />
                </div>
              </div>
                </div>
                      
                 
            

                      <div class="col-md-12">
                          <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" OnRowCommand="GridView1_RowCommand">
                               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                               <Columns>
                                    <asp:ButtonField CommandName="btnseleccionar" ControlStyle-CssClass="btn btn-success"  Text="Seleccionar"/>
                                    <asp:ButtonField CommandName="btneliminar" ControlStyle-CssClass="btn btn-danger"  Text="Eliminar"/>
                                    <asp:ButtonField CommandName="btnactualizar" ControlStyle-CssClass="btn btn-info"  Text="Actualizar"/>                                  
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
