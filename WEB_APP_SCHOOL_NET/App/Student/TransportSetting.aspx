<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TransportSetting.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.TransportSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/UC/Driver.ascx" TagPrefix="uc1" TagName="Driver" %>
<%@ Register Src="~/UC/uc_RouteName.ascx" TagPrefix="uc1" TagName="uc_RouteName" %>
<%@ Register Src="~/UC/uc_Vehicle.ascx" TagPrefix="uc1" TagName="uc_Vehicle" %>
<%@ Register Src="~/UC/uc_Stop_Name.ascx" TagPrefix="uc1" TagName="uc_Stop_Name" %>
<%@ Register Src="~/UC/uc_Route_Setting.ascx" TagPrefix="uc1" TagName="uc_Route_Setting" %>
<%@ Register Src="~/App/Student/uc_Student_Route_Setting.ascx" TagPrefix="uc1" TagName="uc_Student_Route_Setting" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Transport Management
            <small>Settings</small> </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Transport Management</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Driver" data-toggle="tab">Driver</a></li>
                        <li>
                            <a href="#Vehicle" data-toggle="tab">Vehicle</a></li>

                        <li>
                            <a href="#RouteName" data-toggle="tab">Route Name</a></li>
                        <li>
                            <a href="#StoppageName" data-toggle="tab">Stoppage Name</a></li>

                        <li>
                            <a href="#RouteSetting" data-toggle="tab">Route Management</a></li>
                        <li>
                            <a href="#StudentRouteSetting" data-toggle="tab">Student Route Setting</a></li>
                    </ul>

                    <div class="tab-content">
                        <div class="tab-pane active" id="Driver">
                            <uc1:Driver runat="server" ID="Driver1" />
                        </div>
                        <div class="tab-pane" id="Vehicle">
                            <uc1:uc_Vehicle runat="server" ID="uc_Vehicle" />
                        </div>
                        <div class="tab-pane" id="RouteName">
                            <uc1:uc_RouteName runat="server" ID="uc_RouteName" />
                        </div>
                        <div class="tab-pane" id="StoppageName">
                            <uc1:uc_Stop_Name runat="server" ID="uc_Stop_Name" />
                        </div>

                        <div class="tab-pane" id="RouteSetting">
                            <uc1:uc_Route_Setting runat="server" ID="uc_Route_Setting" />
                        </div>
                        <div class="tab-pane" id="StudentRouteSetting">
                            <uc1:uc_Student_Route_Setting runat="server" id="uc_Student_Route_Setting" />

                        </div>
                    </div>


                </div>
            </div>
        </div>
 <%--<div class="row"> <div class="col-md-12">
     <ajaxToolkit:TabContainer CssClass="nav nav-tabs" ID="TabContainer1" runat="server">
          <ajaxToolkit:TabPanel CssClass="nav nav-tabs" runat="server" HeaderText="Login Form" ID="TabPanel1">  
            </ajaxToolkit:TabPanel>  
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Registration Form">  
            </ajaxToolkit:TabPanel>  

     </ajaxToolkit:TabContainer></div>
     </div>--%>




    </div>
</asp:Content>
