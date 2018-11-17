<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClassExamReport.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Exam.ClassExamReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Src="~/App/Report/uc_ReportViewer.ascx" TagPrefix="uc1" TagName="uc_ReportViewer" %>
<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_finyear" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>
<%@ Register Src="~/UC/uc_ResultFormat.ascx" TagPrefix="uc1" TagName="uc_ResultFormat" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Class Exam Report
            <small>Exam Masters</small> </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Class Exam Report</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label>Academic Year</label>
                        <uc1:uc_finyear runat="server" ID="uc_finyear1" />
                    </div>
                    <uc1:uc_Class runat="server" ID="uc_Class" />
                    <div class="col-md-3 form-group">
                        <label>Student Name</label>
                        <asp:DropDownList Style="width: 100%" runat="server" AutoPostBack="true" ID="ddlStudent"></asp:DropDownList>
                    </div>
                   <div class="col-md-2 form-group">
                         <label>Result Format</label>
                       <uc1:uc_ResultFormat runat="server" id="uc_ResultFormat" />
                   </div>
                   
                      </div>
                 <div class="row"> <div class="col-md-2 form-group">
                     <asp:Button runat="server" ID="btnGenerateResult" OnClick="btnGenerateResult_Click"  CssClass="btn btn-primary" Text="Show Result"></asp:Button>
            </div>
                  </div>
            </div>
            <div class="box">
                <uc1:uc_ReportViewer runat="server" ID="uc_ReportViewer" />
            </div>
        </div>
    </div>

</asp:Content>
