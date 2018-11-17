<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ClassManagement.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.ClassManagement" %>

<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Class Management
            <small>Class Masters</small> </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Class Management</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Class" data-toggle="tab">Class</a></li>
                        <li>
                            <a href="#Section" data-toggle="tab">Section</a></li>
                        <li>
                            <a href="#Promoted" data-toggle="tab">Promoted Settings</a></li>
                        <li>
                            <a href="#Subject" data-toggle="tab">Subject</a></li>
                        <li>
                            <a href="#SUBSubject" data-toggle="tab">SUB-Subject</a></li>
                    </ul>

                    <div class="tab-content">
                        <div class="tab-pane active" id="Class">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <%--  <label>Class Name</label>--%>
                                        <asp:TextBox ID="txtClassName" placeholder="Class Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:LinkButton ID="lkbSave" runat="server" OnClick="lkbSave_Click" ToolTip="Save"><i class="fa fa-save"></i>&nbsp; Save</asp:LinkButton>
                                        <uc1:uc_sucess runat="server" ID="uc_sucess1" />
                                    </div>
                                </div>
                            </div>

                            <div class="table no-padding">
                                <asp:ListView ID="lvClass" DataKeyNames="ClassId" OnItemCanceling="lvClass_ItemCanceling" OnItemEditing="lvClass_ItemEditing" OnItemUpdating="lvClass_ItemUpdating" runat="server">
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
                                            <td><%#Eval("ClassName") %></td>
                                            <td>
                                                <asp:LinkButton ID="lkbSection" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalSection"%>' runat="server" CssClass="btn" data-trigger="hover" data-placement="right" EnableTheming="false" ToolTip="View Section"><i class="fa fa-eye text-red"></i></asp:LinkButton>
                                                <div class="modal" id='<%# Container.DataItemIndex +"_myModalSection"%>' role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                                            &times;
                                                                        </button>
                                                                        <h4 class="modal-title"><b><i class="fa fa-user"></i>
                                                                            <asp:Label ID="Label1" runat="server" Text="Section"></asp:Label>
                                                                        </b></h4>
                                                                    </div>
                                                                    <div class="modal-body">
                                                                        <asp:ListView ID="lvSectionView" DataSource='<%#Eval("MST_SECTION") %>' runat="server">
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
                                                                                    <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %></td>
                                                                                    <td><%#Eval("SectionName") %></td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <LayoutTemplate>
                                                                                <table class="table table-responsive">
                                                                                    <thead>
                                                                                        <tr>
                                                                                            <th style="width: 10px">#</th>
                                                                                            <th>Class Name</th>
                                                                                            <th>Section Name</th>
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
                                                                    <div class="modal-footer">
                                                                        <button class="btn btn-info pull-right" data-dismiss="modal" aria-hidden="true">
                                                                            Close
                                                                        </button>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lkbSubject" data-toggle="modal" data-target='<%#"#"+ Container.DataItemIndex +"_myModalSubject"%>' runat="server" CssClass="btn" data-trigger="hover" data-placement="right" EnableTheming="false" ToolTip="View Subject"><i class="fa fa-eye text-red"></i></asp:LinkButton>
                                                <div class="modal" id='<%# Container.DataItemIndex +"_myModalSubject"%>' role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog">
                                                        <asp:UpdatePanel ID="upviewPurchaseRegigsterModel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                                            &times;
                                                                        </button>
                                                                        <h4 class="modal-title"><b><i class="fa fa-user"></i>
                                                                            <asp:Label ID="lblModalTitle" runat="server" Text="Subject"></asp:Label>
                                                                        </b></h4>
                                                                    </div>
                                                                    <div class="modal-body">
                                                                        <asp:ListView ID="lvSubjectView" DataSource='<%#Eval("MST_Subject") %>' runat="server">
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
                                                                                    <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %></td>
                                                                                    <td><%#Eval("SubjectName") %></td>
                                                                                    <%-- <td>
                                                                                    <asp:LinkButton ID="lkbDelete" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                                                                </td>--%>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <LayoutTemplate>
                                                                                <table class="table table-responsive">
                                                                                    <tr>
                                                                                        <th style="width: 10px">#</th>
                                                                                        <th>Class Name</th>
                                                                                        <th>Subject Name</th>
                                                                                        <%-- <th></th>--%>
                                                                                        <tbody>
                                                                                            <tr id="itemPlaceholder" runat="server">
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </tr>
                                                                                </table>
                                                                            </LayoutTemplate>
                                                                        </asp:ListView>
                                                                    </div>
                                                                    <div class="modal-footer">
                                                                        <button class="btn btn-info pull-right" data-dismiss="modal" aria-hidden="true">
                                                                            Close
                                                                        </button>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lkbDeleteClass" OnClick="lkbDeleteClass_Click" CommandArgument='<%#Eval("ClassId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server"    data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                         &nbsp;  <asp:LinkButton ID="btnedit" EnableTheming="false" runat="server" CommandName="Edit" ToolTip="Edit this record."><i class="fa fa-pencil-square-o text-red" aria-hidden="true"></i></asp:LinkButton>
                                                 </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <tr style="background-color: #ADD8E6">
                                            <td><%# Container.DataItemIndex + 1%>.</td>
                                            <td >
                                          
                                                <asp:TextBox ID="txtClassName" runat="server" Width="200px"
                                                    Text='<%#Bind("ClassName") %>' MaxLength="50" /><br />
                                               
                                            </td>
                                            <td></td>
                                             <td></td>
                                            <td >
                                                <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                                <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </EditItemTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive dataTable">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Class Name</th>
                                                    <th>Section</th>
                                                    <th>Subject</th>
                                                    <th></th>

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
                        <div class="tab-pane" id="Section">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>
                                            Class Name</label>
                                        <asp:DropDownList Style="width: 100%" ID="ddlClassName" class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>
                                            Section Name</label>
                                        <asp:TextBox ID="txtSectionName" runat="server" placeholder="Enter the Section Name"></asp:TextBox>
                                    </div>
                                </div>



                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lkbSaveSection" OnClick="lkbSaveSection_Click" runat="server" class="btn btn-primary" ToolTip="Save"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                <uc1:uc_sucess runat="server" ID="uc_sucess" />
                            </div>
                            <div class="table no-padding">
                                <asp:ListView ID="lvSection" DataKeyNames="SectionId" OnItemCanceling="lvSection_ItemCanceling" OnItemEditing="lvSection_ItemEditing" OnItemUpdating="lvSection_ItemUpdating" runat="server">
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
                                            <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %></td>
                                            <td><%#Eval("SectionName") %></td>
                                            <td>

                                                <asp:LinkButton ID="lkbDeleteSection" OnClick="lkbDeleteSection_Click" CommandArgument='<%#Eval("SectionId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                             &nbsp;  <asp:LinkButton ID="btnedit" EnableTheming="false" runat="server" CommandName="Edit" ToolTip="Edit this record."><i class="fa fa-pencil-square-o text-red" aria-hidden="true"></i></asp:LinkButton>
                                         
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <tr style="background-color: #ADD8E6">
                                            <td><%# Container.DataItemIndex + 1%>.</td>
                                            <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %></td>
                                            <td >
                                          
                                                <asp:TextBox ID="txtSectionName" runat="server" Width="200px"
                                                    Text='<%#Bind("SectionName") %>' MaxLength="50" /><br />
                                               
                                            </td>
                                           
                                            <td >
                                                <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                                <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </EditItemTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive dataTable">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Class Name</th>
                                                    <th>Section Name</th>
                                                    <th></th>
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
                        <div class="tab-pane" id="Promoted">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>
                                            Promoted From</label>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>
                                            Promoted To</label>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Class Name</label>
                                                        <asp:DropDownList Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged" ID="ddlPramodClassFrom" class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Section Name</label>
                                                        <asp:DropDownList Style="width: 100%" ID="ddlPramodSectionFrom" class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Class Name</label>
                                                        <asp:DropDownList Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged" ID="ddlPromotedClassTo" class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Section Name</label>
                                                        <asp:DropDownList Style="width: 100%" ID="ddlPromotedSectionTo" class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <asp:LinkButton ID="lkbSavePromotedData" runat="server" OnClick="lkbSavePromotedData_Click" CssClass="btn btn-primary" ToolTip="Save"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                            <uc1:uc_sucess runat="server" ID="uc_sucessPromoted" />
                            <div class="table-responsive no-padding">
                                <asp:ListView ID="lvPromoted" runat="server">
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
                                            <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %>(<%# DataBinder.Eval(Container.DataItem,"MST_SECTION.SectionName") %>)</td>
                                            <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS1.ClassName") %>(<%# DataBinder.Eval(Container.DataItem,"MST_SECTION1.SectionName") %>)</td>
                                            <td>
                                                <asp:LinkButton ID="lkbPSDelete" OnClick="lkbPSDelete_Click" CommandArgument='<%#Eval("PromotedId") %>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive">
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>From Class</th>
                                                <th>To Class</th>
                                                <th></th>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>

                        <div class="tab-pane" id="Subject">

                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Class Name</label>
                                        <asp:DropDownList Style="width: 100%" ID="ddlSubClass" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Subject Name</label>
                                        <asp:TextBox ID="txtSubjectName" placeholder="Subject Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:LinkButton ID="lkbSubject" OnClick="lkbSubject_Click" runat="server"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                        <uc1:uc_sucess runat="server" ID="uc_sucess2" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive no-padding">
                                <asp:ListView ID="lvSubject" runat="server">
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
                                            <td><%# DataBinder.Eval(Container.DataItem,"MST_CLASS.ClassName") %></td>
                                            <td><%#Eval("SubjectName") %></td>
                                            <td>
                                                <asp:LinkButton ID="lkbSubjectDelete" OnClick="lkbSubjectDelete_Click" CommandArgument='<%#Eval("SubjectId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive">
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Class Name</th>
                                                <th>Subject Name</th>
                                                <th></th>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>

                        </div>
                        <div class="tab-pane" id="SUBSubject">

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Class Name</label>
                                        <asp:DropDownList Style="width: 100%" ID="ddlCClassName" AutoPostBack="true" OnSelectedIndexChanged="ddlCClassName_SelectedIndexChanged" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Subject Name</label>
                                        <asp:DropDownList Style="width: 100%" ID="ddlSubjectName" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Sub Subject Name</label>
                                        <asp:TextBox ID="txtSubSubjectName" placeholder="Sub-Subject Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:LinkButton ID="lkbSubjectSave" OnClick="lkbSubjectSave_Click" runat="server"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">&nbsp;</div>
                                <div class="col-md-8">
                                    <uc1:uc_sucess runat="server" ID="uc_sucess3" />
                                </div>
                                <div class="col-md-2">&nbsp;</div>
                            </div>
                            <div class="table-responsive no-padding">
                                <asp:ListView ID="lvSubSubject" runat="server">
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
                                            <td><%#Eval("MST_SUBJECT.MST_CLASS.ClassName") %></td>
                                            <td><%# Eval("MST_SUBJECT.SubjectName") %></td>
                                            <td><%#Eval("SubSubjectName") %></td>
                                            <td>
                                                <asp:LinkButton ID="lkbSubSubjectDelete" OnClick="lkbSubSubjectDelete_Click" CommandArgument='<%#Eval("SubSubjectId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive">
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Class Name</th>
                                                <th>Subject Name</th>
                                                <th>Sub-Subject Name</th>
                                                <th></th>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                            </tr>
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
