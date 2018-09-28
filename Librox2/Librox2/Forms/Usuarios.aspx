<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterBack.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Librox2.GUI.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Datos de Usuarios
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li><a href="#">Usuarios</a></li>
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
                                    <h3 class="box-title">Lista de usuarios "Mucho cuidado con lo que se realice"</h3>
                                    <br />
                                    <asp:Panel ID="pnAviso" runat="server"> <%--Panel que aparece al seleccionar un usuario para enviar aviso, desaparecerá al enviar el correo automáticamente(pendiente)--%>
                                        <div class="row">
                                        <div class="col-md-12">
                                            <h4>Para:</h4>
                                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-12">
                                            <h4>Mensaje:</h4>
                                            <asp:TextBox ID="txtAvisoMensaje" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            <br />
                                            <div align="center">
                                               <asp:Label ID="lblExcep" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-success" OnClick="btnEnviar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    </asp:Panel>    <%--Termina panel--%>
                                </div>
                                <div class="box-body">
                                    <div class="col-md-12">
                                        <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <Columns>
                                                <asp:ButtonField CommandName="btnSeleccionar" ControlStyle-CssClass="btn btn-success" Text="Seleccionar" />
                                                <asp:ButtonField CommandName="btnEliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />
                                                <asp:ButtonField CommandName="btnActualizar" ControlStyle-CssClass="btn btn-info" Text="Actualizar" />
                                                <asp:ButtonField CommandName="btnAviso" ControlStyle-CssClass="btn btn-warning" Text="Aviso" />
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
