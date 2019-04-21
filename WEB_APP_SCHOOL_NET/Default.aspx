<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_APP_SCHOOL_NET._Default" %>

<%@ Register Src="~/UC/sms.ascx" TagPrefix="uc1" TagName="sms" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:sms runat="server" id="sms" />


    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
