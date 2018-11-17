<%@ Page Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentAttendance.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.StudentAttendance" %>

<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ MasterType VirtualPath="~/App/AdminMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Student Attendance
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Student Attendance</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Student Attendance</h3>
            </div>
            <div class="box-body">
                <div class="row">

                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Class Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlClassName" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Section Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlSectionName" class="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Attandence Date</label>
                            <asp:TextBox ID="txtAttandenceDate" CssClass="form-control date-picker_attendance" EnableTheming="false" placeholder="Attandence Date" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>&nbsp;</label><br />
                            <asp:LinkButton ID="lkbGetAttendance" OnClick="lkbGetAttendance_Click" runat="server">View Attandence</asp:LinkButton>
                        </div>
                    </div>

                </div>




                <div class="table no-padding">

                    <div class="col-md-12">
                        <asp:ListView ID="lvStudentAttendance" DataKeyNames="StudentId,StudentAttendId" runat="server">
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
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNumber")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName")%>' />
                                    </td>
                                    <%--  <td><%# DataBinder.Eval(Container.DataItem,"MST_SECTION.MST_CLASS.ClassName") %></td>--%>
                                    <td>
                                        <%--<asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn" data-trigger="hover" style="padding:3px 6px;" data-placement="right"><i class="fa fa-eye text-white"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lkbEdit" runat="server" CommandArgument='<%# Eval("StudentId") %>' style="padding:3px 6px;" OnClick="lkbEdit_Click" CssClass="btn" data-trigger="hover" data-placement="right"><i class="fa fa-edit text-white"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn" data-trigger="hover" style="padding:3px 6px;" data-placement="right"><i class="fa fa-trash text-white"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn" data-trigger="hover" data-placement="right"><i class="fa fa-credit-card text-primary"></i></asp:LinkButton>
                                        --%>
                                        <asp:CheckBox ID="selectone" CssClass="selectone" Checked='<%#Eval("Presentbool")%>' runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table class="table table-responsive " id="lvItems">
                                    <thead>
                                        <tr>
                                            <th style="width: 10px">#</th>
                                            <th>Roll Number</th>
                                            <th>Student Name</th>
                                            <%--<th>class Name</th>--%>
                                            <th>
                                                <%--<asp:CheckBox ID="selectall" CssClass="selectall" ClientIDMode="Static" runat="server"></asp:CheckBox>--%></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>




                    </div>




                </div>


            </div>
            <div class="box-footer">
                <asp:LinkButton ID="lkbSave" runat="server" OnClick="lkbSave_Click" EnableTheming="false" class="btn btn-primary pull-right" ToolTip="Save Attandence"><i class="fa fa-save"></i>&nbsp;Save Attandence</asp:LinkButton>
                <uc1:uc_sucess runat="server" ID="uc_sucess" />
            </div>
        </div>
    </div>
</asp:Content>
