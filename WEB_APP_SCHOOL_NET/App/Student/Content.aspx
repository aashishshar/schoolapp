<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Content
            <small>website content</small></h1>
    </div>
    <div class="content">
        <div id="divMain" runat="server">
            <div class="box box-primary">
                <%--<div class="box-header with-border">
                    <h3 class="box-title">Student Management</h3>
                </div>--%>
                <div class="box-body">
                    <asp:DropDownList style="width:100%" ID="ddlContentType" runat="server"></asp:DropDownList>
                    
                </div>
             


            </div>
        </div>
    </div>

</asp:Content>
