<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageStudent.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.ManageStudent" %>

<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_finyear" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Manage Students
            <small>Student Movement/Promote Student</small> </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Student</a></li>
            <li class="active">Manage Student</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Move" data-toggle="tab">Student Move/Shift</a></li>

                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="Move">
                            <div class="form-vertical">
                                <div class="row">
                                    <div class="col-sm-2 form-group">
                                        <label>Academic Year</label>
                                        <uc1:uc_finyear runat="server" ID="uc_finyearFrom" />
                                    </div>

                                    <uc1:uc_Class runat="server" ID="uc_ClassFrom" />

                                    <div class="col-sm-2 form-group">
                                        <label>Academic Year</label>
                                        <uc1:uc_finyear runat="server" ID="uc_finyearTo" />
                                    </div>

                                    <uc1:uc_Class runat="server" ID="uc_ClassTo" />
                                </div>
                            </div>
                            <div class="box-body no-padding">
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div style="float: left; width: 400px; overflow-y: auto; height: 380px;">
                                            <asp:CheckBoxList ID="lbFromStudent" RepeatLayout="Table" runat="server" DataTextField="StudentName" DataValueField="StudentId"></asp:CheckBoxList>
                                        </div>
                                        <%-- <asp:ListBox ID="lbFromStudent"   runat="server"  Rows="50" SelectionMode="Multiple" EnableTheming="False"></asp:ListBox>--%>
                                    </div>
                                    <div class="col-sm-2" style="text-align: center; vertical-align: top;">
                                        <div class="row">
                                            <div class="col-sm-12" style="margin-bottom:5px;">
                                                <asp:Button runat="server" Width="100%" ID="btnMoveStudent" OnClick="btnMoveStudent_Click" CssClass="btn btn-primary" Text="Move Student >>"></asp:Button>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12" style="margin-bottom:5px;">
                                                <asp:Button runat="server" Width="100%" ID="btnPromoted" CommandName="Promoted" OnClick="btnStudentStatus_Click" CssClass="btn btn-warning" Text="Promoted/Failed Move"></asp:Button>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12" style="margin-bottom:5px;">
                                                <asp:Button runat="server" Width="100%" ID="btnPassed" CommandName="Passed" OnClick="btnStudentStatus_Click" CssClass="btn btn-success" Text="Passed"></asp:Button>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12" style="margin-bottom:5px;">
                                                <asp:Button runat="server" Width="100%" ID="btnDropOut" CommandName="DropOut" OnClick="btnStudentStatus_Click" CssClass="btn btn-danger" Text="Drop-Out"></asp:Button>

                                            </div>
                                        </div>
                                         <div class="row">
                                            <div class="col-sm-12" >
                                                <asp:Button runat="server" Width="100%" ID="btnFailed" CommandName="Failed" OnClick="btnStudentStatus_Click" CssClass="btn btn-danger" Text="Failed"></asp:Button>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-5" style="float: left; width: 400px; overflow-y: auto; height: 380px;">

                                        <asp:CheckBoxList ID="lbToStudent"  RepeatLayout="Table" runat="server" DataTextField="StudentName" DataValueField="StudentId"></asp:CheckBoxList>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
