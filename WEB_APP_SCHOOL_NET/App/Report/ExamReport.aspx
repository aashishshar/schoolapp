<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ExamReport.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Report.ExamReport" %>

<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_FinYear" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>
<%@ Register Src="~/App/Report/uc_ReportViewer.ascx" TagPrefix="uc1" TagName="uc_ReportViewer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Exam Report
            <small></small></h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Hall Ticket</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-primary">
            <div class="box-body">

                <div class="col-md-2">
                    <label>Academic Year</label>
                    <uc1:uc_FinYear runat="server" ID="uc_FinYear" />
                </div>
                <uc1:uc_Class runat="server" ID="uc_Class" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Ticket" data-toggle="tab">Hall Ticket</a></li>

                    </ul>
                    <div class="tab-content">

                        <div class="tab-pane active" id="Ticket">
                            <div class="row">
                            <div class="col-md-3" >
                            <asp:DropDownList style="width:100%" ID="ddlExamType"  runat="server">
                                <asp:ListItem Text="Half Yearly Examination"></asp:ListItem>
                              <asp:ListItem Text="Annual Examination"></asp:ListItem>
                              <asp:ListItem Text="Quaterly Examination"></asp:ListItem>
                             <asp:ListItem Text="Monthly Assement Examination"></asp:ListItem>
                            </asp:DropDownList> 
                            </div>
                            <div class="col-md-2">
                            <asp:LinkButton ID="lkbTicket" CommandName="HallTicket" OnClick="lkbGetFeeDetail_Click" runat="server">Generate Hall Ticket</asp:LinkButton>
                         </div>
                        </div>
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
