<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterBack.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Librox2.GUI.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
       TEST SCRIPTS WITH FTP 
        </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">DataBases Test</a></li>
          <li><a href="#">Test Scripts with FTP</a></li>
      </ol>
    </section>
    <!-- Main content -->
    <section class="content">
       <div class="row">
        <div class="col-md-12">
          <div class="box box-info">
            <div class="box-header">
              <h3 class="box-title">site to configure the database tests with scripts</h3>
            </div>
            <div class="box-body">
                <div class="col-md-4">
                 <div class="form-group">
                 <label>SVN Url or Folder Name:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-folder"></i>
                  </div>
                   <asp:TextBox ID="txtSVNRep" CssClass="form-control" runat="server"></asp:TextBox>
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
                
  <asp:TextBox ID="txtMatterMessage" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
                </div>
                      <div class="col-md-4">
                 <div class="form-group">
                <label>Generate Scripts:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                         <i class="fa fa-question"></i>
                  </div>
                         <asp:DropDownList ID="DPGeneraSc" CssClass="form-control" runat="server" >
                         <asp:ListItem>Choose a option</asp:ListItem>
                         <asp:ListItem>TRUE</asp:ListItem>
                     <asp:ListItem>FALSE</asp:ListItem>
                    </asp:DropDownList>

                </div>
              </div>
                </div>
                        <div class="col-md-5">
                 <div class="form-group">
                 <label>path to download files ftp:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-download"></i>
                  </div>
               <asp:TextBox ID="txtftp" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
                </div>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

                      <div class="col-md-3">
                 <div class="form-group">
                 <label>MergeSystemFiles:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-list"></i>
                  </div>
                 <asp:ListBox ID="ltsMergeSystem" CssClass="form-control" runat="server" SelectionMode="Multiple" AutoPostBack="True"></asp:ListBox>
                </div>
              </div>
                </div>
                          <div class="col-md-1">
                 <div class="form-group">
                <div class="input-group">
                 <br />
                        <%--<asp:Button ID="Button4" CssClass="form-control" runat="server" Text="Load Files" OnClick="Button4_Click" />
                         <asp:Button ID="Button2" CssClass="form-control" runat="server" Text=">>" OnClick="Button2_Click" />
                         <asp:Button ID="Button3" CssClass="form-control" runat="server" Text="<<" OnClick="Button3_Click" />--%>
                </div>
              </div>
                </div>
                            <div class="col-md-3">
                 <div class="form-group">
                 <label>MergeDataFiles:</label>
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-list"></i>
                  </div>
                  <asp:ListBox ID="ltsMergeData" CssClass="form-control" runat="server" SelectionMode="Multiple" AutoPostBack="True"></asp:ListBox>
                </div>
              </div>
                </div>
            
     </ContentTemplate>
    </asp:UpdatePanel>
                      <div class="col-md-12">
                 <div class="form-group">
                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-file-archive-o"></i>
                  </div>
                  <div  class="dropzone" id="dropzoneForm"> 
                    <span class="issue-drop-zone__text">
                               Drop files here to attach them
                           </span>
                              <br />
        <div class="fallback">
            <input name="file" type="file" multiple />
            <input type="submit" value="Upload" />
        </div>
                </div>
              </div>
                </div>
                     <div class="col-md-12">
            <%-- <asp:Button ID="btnSave" CssClass="btn btn-info" runat="server" Text="Save TEST" OnClick="btnSave_Click" />--%>
        </div>
                </div>
              </div>
            
                </div>
            </div>
        </section>
          </div>
</asp:Content>
