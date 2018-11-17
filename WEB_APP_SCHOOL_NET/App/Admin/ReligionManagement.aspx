<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReligionManagement.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Admin.ReligionManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Religion Management
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Religion Management</li>
        </ol>
    </div>

    <div class="box box-primary">
        <div class="box-header with-border">
              <h3 class="box-title">Religion Management</h3>
            </div>
              <div class="box-body">
                  <div class="row">
                      <div class="col-md-6">
                          <div class="form-group">
                  <label>Religion Name</label>
                 <input type="text" class="form-control" id="txtReligionName" placeholder="Enter the Religion Name">
                </div>
                      </div>
                      <div class="col-md-6">
                              <asp:LinkButton ID="lkbSave" runat="server" class="btn btn-primary" ToolTip="Save"><i class="fa fa-save"></i>Save</asp:LinkButton>
                          </div>
                  </div>
                  
                  </div>
            
        
          </div>
</asp:Content>
