<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Exam.Result" %>

<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_finyear" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>
<%@ Register Src="~/UC/uc_ResultFormat.ascx" TagPrefix="uc1" TagName="uc_ResultFormat" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Student Result
            <small>View/Download Student Result</small> </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Student Result</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Result" data-toggle="tab">Result</a></li>
                       <%-- <li>
                            <a href="#Promote" data-toggle="tab">Promote Student</a></li>--%>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="Result">
                            <div class="form-vertical">
                                <div class="row">
                                    <div class="col-sm-2 form-group">
                                        <label>Academic Year</label>
                                        <uc1:uc_finyear runat="server" ID="uc_finyear" />
                                    </div>
                                    <div class="col-sm-2 form-group"> <label>Result Format</label>
                                        <uc1:uc_ResultFormat runat="server" ID="uc_ResultFormat" />
                                    </div>
                                    <uc1:uc_Class runat="server" ID="uc_Class" />
                                    <br />
                                    <asp:Button runat="server" Visible="false" ID="btnGetStudent" OnClick="btnGetStudent_Click" CssClass="btn btn-primary" Text="Get Student"></asp:Button>
                                </div>
                            </div>
                              <div class="box-body no-padding">
                                  
                            <asp:ListView ID="lvStudent" runat="server" OnItemDataBound="lvStudent_ItemDataBound" >
                                <EmptyDataTemplate>
                                    <table class="table table-responsive">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkStudent" Checked="true" runat="server" />
                                            <%--<%# Container.DataItemIndex + 1%>.--%></td>
                                        <td><%#Eval("FormNumber") %></td>
                                        <td><%#Eval("StudentName") %></td>
                                    <%--    <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %></td>--%>
                                        <td><%#Eval("FatherName") %></td>

                                     <%--   <td><%#Eval("CasteType")!=null?((WEB_APP_SCHOOL_NET.Common.EnumConstants.Caste)Convert.ToInt32(Eval("CasteType"))).ToString():"-" %></td>
                                        <td><%#Eval("Gender").ToString()=="M"?"Male":"Female" %></td>
                                        <td><%#Eval("ContactNumber") %></td>--%>
                                        <td>
                                            <asp:LinkButton ID="lkbDownload" runat="server" CommandArgument='<%#Eval("StudentId") %>' CommandName='<%#Eval("FormNumber").ToString()+"_"+Eval("StudentId").ToString()+"_"+Eval("StudentName").ToString() %>' ToolTip="Download Result" OnClick="lkbDownload_Click"  CssClass="btn btn-success" data-trigger="hover" EnableTheming="false" Style="padding: 1px 5px;" data-placement="right"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                                         </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table class="table table-responsive dataTable" id="lvItems">
                                        <thead>
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Form No.</th>
                                                <th>Student</th>
                                              <%--  <th>Class</th>--%>
                                                <th>Father's Name</th>
                                                <%--<th>Cast</th>
                                                <th>Gender</th>
                                                <th>Contact No.</th>--%>
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
        </div>
    </div>
</asp:Content>
