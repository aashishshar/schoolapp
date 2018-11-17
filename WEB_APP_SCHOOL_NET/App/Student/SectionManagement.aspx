<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SectionManagement.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.SectionManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Section Management
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Section Management</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Section Management</h3>
            </div>
            <div class="box-body">
                <div class="form-group">
                    <label>Class Name</label>
                    <asp:DropDownList style="width:100%" ID="ddlClassName" class="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Section Name</label>
                    <input type="text" class="form-control" id="txtSectionName" placeholder="Enter the Section Name">
                </div>

                <div class="form-group">
                    <asp:LinkButton ID="lkbSave" runat="server" class="btn btn-primary" ToolTip="Save"><i class="fa fa-save"></i>Save</asp:LinkButton>
                </div>


                <asp:LinkButton ID="lkbCreateNew" runat="server" class="btn btn-primary" ToolTip="Create New"><i class="fa fa-plus-circle"></i>Create New</asp:LinkButton>
                <div class="table-responsive no-padding">
                    <asp:ListView ID="lvSection" runat="server">
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
                                    <asp:LinkButton ID="lkbView" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalClass"%>' runat="server" CssClass="btn" data-trigger="hover" data-placement="right" ToolTip="Add Signatory"><i class="fa fa-eye text-orange"></i></asp:LinkButton>

                                    <div class="modal" id='<%# Container.DataItemIndex +"_myModalClass"%>' role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" style="width: 60%;">
                                            <asp:UpdatePanel ID="upviewPurchaseRegigsterModel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                                &times;
                                                            </button>
                                                            <h4 class="modal-title">
                                                                <b><i class="fa fa-user"></i>
                                                                    <asp:Label ID="lblModalTitle" runat="server" Text="Signatory Person"></asp:Label></b>
                                                            </h4>
                                                        </div>
                                                        <div class="modal-body">
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button class="btn btn-info pull-right" data-dismiss="modal" aria-hidden="true">Close</button>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalSIGN"%>' runat="server" CssClass="btn" data-trigger="hover" data-placement="right" ToolTip="Add Signatory"><i class="fa fa-edit text-green"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalSIGN"%>' runat="server" CssClass="btn" data-trigger="hover" data-placement="right" ToolTip="Add Signatory"><i class="fa fa-delete text-red"></i></asp:LinkButton>
                                </td>

                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <th style="width: 10px">#</th>
                                    <th>Class Name</th>
                                    <th>Section Name</th>
                                    <th>Actions</th>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </tbody>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>

                    <div class="box-footer">
                        <%--<div class="dataTables_paginate paging_simple_numbers pull-right">
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvUsers" PageSize="10" class="btn-group-sm pager-buttons">
                        <Fields>
                            <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn btn-primary" RenderNonBreakingSpacesBetweenControls="false" />
                            <asp:NumericPagerField ButtonType="Button" RenderNonBreakingSpacesBetweenControls="false" NumericButtonCssClass="btn btn-primary" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                            <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn btn-primary" RenderNonBreakingSpacesBetweenControls="false" />
                        </Fields>
                    </asp:DataPager>
                </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
