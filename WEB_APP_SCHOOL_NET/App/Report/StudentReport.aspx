<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentReport.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Report.StudentReport" %>

<%@ Register Src="~/App/Report/uc_ReportViewer.ascx" TagPrefix="uc1" TagName="uc_ReportViewer" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>
<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_FinYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Reports
            <small></small></h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Reports</li>
        </ol>
    </div>
    <div class="content">
        <div id="divMain" runat="server">
            <div class="box">
                <div class="box-body">
                    <div class="col-md-2">
                        <label>Academic Year</label>
                        <uc1:uc_FinYear runat="server" ID="uc_FinYear" />
                    </div>
                    <uc1:uc_Class runat="server" ID="uc_Class" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Student" data-toggle="tab">Student Report</a></li>
                        <li>
                            <a href="#Attandence" data-toggle="tab">Attandence</a></li>

                        <li style="display: none;">
                            <a href="#Ticket" data-toggle="tab">Hall Ticket</a></li>

                    </ul>


                    <div class="tab-content">
                        <div class="tab-pane active" id="Student">
                            <div class="form-inline">
                                <div class="form-group">
                                    <label>Gender</label>
                                    <asp:DropDownList style="width:100%" ID="ddlGender" runat="server">
                                        <asp:ListItem Text="[ ALL ]" Value="A"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Cast</label>
                                    <asp:DropDownList style="width:100%" ID="ddlCasteType" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="lkbGetFeeDetail" CommandName="StudentReport" OnClick="lkbGetFeeDetail_Click" runat="server">Get Student Report</asp:LinkButton>
                                <asp:LinkButton ID="lkbGeneralInfo" CommandName="GeneralInfo" OnClick="lkbGetFeeDetail_Click" runat="server">Student General Info</asp:LinkButton>
                                <asp:LinkButton ID="lkbCrossList" CommandName="CrossList" OnClick="lkbGetFeeDetail_Click" runat="server">Student Cross List</asp:LinkButton>
                                <asp:LinkButton ID="lkbRefferedBy" CommandName="ReferredBy" OnClick="lkbGetFeeDetail_Click" runat="server">Referred-By Student List</asp:LinkButton>
                                <asp:LinkButton ID="lkbSummaryReport" CommandName="SummaryReport" OnClick="lkbGetFeeDetail_Click" runat="server">Student Summary Report</asp:LinkButton>
                            </div>
                        </div>
                        <div class="tab-pane " id="Attandence">
                            <asp:LinkButton ID="lkbAttandence" CommandName="Attandence" OnClick="lkbGetFeeDetail_Click" runat="server">Get Student Attandence</asp:LinkButton>
                           
                        </div>
                        <div class="tab-pane " id="Ticket">

                            <asp:LinkButton ID="lkbTicket" CommandName="HallTicket" OnClick="lkbGetFeeDetail_Click" runat="server">Generate Hall Ticket</asp:LinkButton>

                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="box">
            <uc1:uc_ReportViewer runat="server" ID="uc_ReportViewer" />
        </div>
    </div>


</asp:Content>
