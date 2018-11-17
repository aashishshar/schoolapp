<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentManagement.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="WEB_APP_SCHOOL_NET.App.Student.StudentManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_StudentDetail.ascx" TagPrefix="uc1" TagName="uc_StudentDetail" %>
<%@ Register Src="~/UC/uc_Student.ascx" TagPrefix="uc1" TagName="uc_Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Student Management
            <small></small></h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Student Management</li>
        </ol>
    </div>
    <div class="content">
        <div id="divMain" runat="server" visible="true">
            <div class="box box-primary">
                <%--<div class="box-header with-border">
                    <h3 class="box-title">Student Management</h3>
                </div>--%>
                <div class="box-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="lkbCreateNew" Visible="false" runat="server" CssClass="btn btn-success pull-right" EnableTheming="false" OnClick="lkbCreateNew_Click" ToolTip="Add Student"><i class="fa fa-plus-circle"></i>&nbsp;Add Student</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:ListView ID="lvStudent" runat="server">
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
                                        <td><%#Eval("FormNumber") %></td>
                                        <td><%#Eval("StudentName") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem,"ClassName") %></td>
                                        <td><%#Eval("FatherName") %></td>

                                        <td><%#Eval("CasteType")!=null?((WEB_APP_SCHOOL_NET.Common.EnumConstants.Caste)Convert.ToInt32(Eval("CasteType"))).ToString():"-" %></td>
                                        <td><%#Eval("Gender").ToString()=="M"?"Male":"Female" %></td>
                                        <td><%#Eval("ContactNumber") %></td>
                                        <td>
                                            <asp:LinkButton ID="lkbView" runat="server" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalSTUDENTDETAILS"%>' CssClass="btn btn-success" data-trigger="hover" EnableTheming="false" Style="padding: 1px 5px;" data-placement="right"><i class="fa fa-eye text-white"></i></asp:LinkButton>
                                            <div class="modal" id='<%# Container.DataItemIndex +"_myModalSTUDENTDETAILS"%>' role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                                &times;
                                                            </button>
                                                            <h4 class="modal-title">
                                                                <b><i class="fa fa-user"></i>
                                                                    <asp:Label ID="lblModalTitle" runat="server" Text="Student Details"></asp:Label></b>
                                                            </h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <uc1:uc_StudentDetail runat="server" StudentId='<%#Convert.ToInt32(Eval("StudentId")) %>' ID="uc_StudentDetail" />
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button class="btn btn-info pull-right" data-dismiss="modal" aria-hidden="true">Close</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:LinkButton ID="lkbEdit" runat="server" CommandArgument='<%# Eval("StudentId") %>' Style="padding: 1px 5px;" OnClick="lkbEdit_Click" CssClass="btn" data-trigger="hover" data-placement="right"><i class="fa fa-edit text-white"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lkbDelete" runat="server" CommandArgument='<%# Eval("StudentId") %>' OnClientClick="return confirm('Are you sure, you want to delete!');" OnClick="lkbDelete_Click" CssClass="btn btn-danger" EnableTheming="false" data-trigger="hover" Style="padding: 1px 5px;" data-placement="right"><i class="fa fa-trash text-white"></i></asp:LinkButton>
                                            <%--  <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn" data-trigger="hover" data-placement="right"><i class="fa fa-credit-card text-primary"></i></asp:LinkButton>
                                            --%></td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table class="table table-responsive dataTable" id="lvItems">
                                        <thead>
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Form No.</th>
                                                <th>Student</th>
                                                <th>Class</th>
                                                <th>Father's Name</th>
                                                <th>Cast</th>
                                                <th>Gender</th>
                                                <th>Contact No.</th>
                                                <th>Action</th>
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
            </div>
        </div>
        <div id="divSecondary" runat="server" visible="false">
            <uc1:uc_Student runat="server" ID="uc_Student" />
        </div>
    </div>
    <script>
        function readURL(input) {
            try {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('.img-upload').attr('src', e.target.result);
                    }

                    reader.readAsDataURL(input.files[0]);
                }
            }
            catch (err) {
                alert('Image is not in correct format');
            }
        }

        $('.file-upload').change(function () {
            readURL(this);
        });
    </script>
    <%--<script type="text/javascript">
        $(function(){
            $('#MainContent_lkbCreateNew').addClass('pull-right');
      });
    </script>--%>
</asp:Content>
