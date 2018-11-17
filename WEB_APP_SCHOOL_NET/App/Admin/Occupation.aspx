<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Occupation.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Admin.Occupation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1> Occupation
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Occupation</li>
        </ol>
    </div>
    <div class="box box-primary">
        <div class="box-header with-border">
              <h3 class="box-title">Occupation</h3>
            </div>
              <div class="box-body">
                  <div class="row">
                      <div class="col-md-6">
                          <div class="form-group">
                  <label>Occupation</label>
                 <input type="text" class="form-control" id="txtOccupation" placeholder="Please Enter the Occupation">
                </div>
                      </div>
                      <div class="col-md-6">
                              <asp:LinkButton ID="lkbSave" runat="server" class="btn btn-primary" ToolTip="Save"><i class="fa fa-save"></i>Save</asp:LinkButton>
                          </div>
                  </div>
                  <div class="table-responsive no-padding">
            <asp:ListView ID="lvOccupation" runat="server">
                        <EmptyDataTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <td>No data was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.DataItemIndex + 1%>.</td>
                                <td>
                                    <%#Eval("") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lkbView" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalClass"%>' runat="server" CssClass="btn" data-trigger="hover" data-placement="right"><i class="fa fa-eye text-orange"></i></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <th style="width: 10px">#</th>
                                    <th>Occupation</th>
                                    <th>Actions</th>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </tbody>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                    </div>
                  </div>
            
        
          </div>
</asp:Content>
