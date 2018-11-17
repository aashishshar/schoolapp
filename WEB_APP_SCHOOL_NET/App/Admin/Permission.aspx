<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Admin.Permission" %>

<%@ Register Src="~/UC/uc_CreateGroup.ascx" TagPrefix="uc1" TagName="uc_CreateGroup" %>
<%@ Register Src="~/UC/uc_RoleManager.ascx" TagPrefix="uc1" TagName="uc_RoleManager" %>
<%@ Register Src="~/UC/uc_CreateUser.ascx" TagPrefix="uc1" TagName="uc_CreateUser" %>
<%@ Register Src="~/Account/uc_UserAddToRole.ascx" TagPrefix="uc1" TagName="uc_UserAddToRole" %>
<%@ Register Src="~/Account/uc_user_ResetPassword.ascx" TagPrefix="uc1" TagName="uc_user_ResetPassword" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Autherization
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <%--<li><a href="#">Create Users</a></li>--%>
            <li class="active">Autherization</li>
        </ol>
    </div>
    <div class="content">
        <uc1:uc_CreateUser runat="server" ID="uc_CreateUser" />
        <uc1:uc_user_ResetPassword runat="server" ID="uc_user_ResetPassword" />
        <uc1:uc_CreateGroup runat="server" ID="uc_CreateGroup" />
        <uc1:uc_RoleManager runat="server" ID="uc_RoleManager" />
        <uc1:uc_UserAddToRole runat="server" ID="uc_UserAddToRole" />

    </div>

</asp:Content>
