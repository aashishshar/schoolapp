<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Masters.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Admin.Masters" %>

<%@ MasterType VirtualPath="~/App/AdminMaster.Master" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Masters
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Masters</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-sm-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h4 class="box-title">State</h4>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove">
                                <i class="fa fa-remove"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="txtStateName" Placeholder="State Name" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                <uc1:uc_sucess runat="server" ID="uc_sucess" />
                            </div>
                        </div>
                        <div class="table-responsive no-padding">
                            <asp:ListView ID="lvstate" runat="server">
                                <EmptyDataTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.DataItemIndex + 1%>.</td>
                                        <td>
                                            <asp:Label ID="lblStateName" runat="server" Text='<%# Eval("StateName") %>' />
                                        </td>
                                        <%--<td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CreatedDate") %>' />
                                </td>--%>
                                        <td>
                                            <%--<asp:LinkButton ID="lkbState_action" runat="server" CommandArgument='<%# Eval("StateID") %>' OnClick="lkbState_action_Click" ToolTip="Edit"><i class="fa fa-edit text-green"></i></asp:LinkButton>--%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table class="table table-responsive dataTable" id="lvItems">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>State Name</th>
                                                <%-- <th style="width: 10%">Created Date</th>--%>
                                                <th>#</th>
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
            <div class="col-sm-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h4 class="box-title">City Management</h4>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove">
                                <i class="fa fa-remove"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:DropDownList style="width:100%" ID="ddlState" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="txtCityName" Placeholder="City Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:LinkButton ID="btnSaveCity" runat="server" OnClick="btnSaveCity_Click"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                </div>
                            </div>
                        </div>
                        <div class="table-responsive no-padding">
                            <asp:ListView ID="lvCity" runat="server">
                                <EmptyDataTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.DataItemIndex + 1%>.</td>

                                        <td><%#DataBinder.Eval(Container.DataItem,"MST_STATE.StateName")%></td>

                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CityName") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                     <table class="table table-responsive dataTable" id="lvItems">
                                         <thead>
                                       <tr>
                                                <th>#</th>
                                                <th>State Name</th>
                                                <th>City Name</th>
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
        <!-- Start -- For State Master -->
        <div class="row">
            <div class="col-sm-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h4 class="box-title">Religion</h4>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove">
                                <i class="fa fa-remove"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="txtReligion" runat="server" placeholder="Religion Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvReligion" runat="server" Display="Dynamic" CssClass="field-validation-error" ControlToValidate="txtReligion" ErrorMessage="Please enter religion name." ValidationGroup="religionmaster"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:LinkButton ID="btnReligion" runat="server" Text="Save" OnClick="btnReligion_Click" ValidationGroup="religionmaster" />
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive no-padding">
                            <asp:ListView ID="lvReligion" runat="server">
                                <EmptyDataTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.DataItemIndex + 1%>.</td>

                                        <td><%#DataBinder.Eval(Container.DataItem,"ReligionName")%></td>

                                        <%--   <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("CreatedDate") %>' />
                        </td>--%>
                                        <td>
                                            <asp:LinkButton ID="lkbReligionDelete" EnableTheming="false" runat="server" OnClick="lkbReligionDelete_Click" CommandArgument='<%#Eval("ReligionId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" ToolTip="Delete" CausesValidation="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table class="table table-responsive dataTable" id="lvItems">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Religion Name</th>
                                                <%-- <th style="width: 10%">Created Date</th>--%>
                                                <th>#</th>

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
            <div class="col-sm-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Caste</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove">
                                <i class="fa fa-remove"></i>
                            </button>
                        </div>
                    </div>

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="txtCasteName" runat="server" placeholder="Caste Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCaste" runat="server" Display="Dynamic" CssClass="field-validation-error" ControlToValidate="txtCasteName" ErrorMessage="Please enter caste name." ValidationGroup="castemaster"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:DropDownList style="width:100%" ID="ddlCasteType" AutoPostBack="true" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:DropDownList style="width:100%" ID="ddlReligion" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:LinkButton ID="btnSaveCaste" runat="server" Text="Save" OnClick="btnSaveCaste_Click" ValidationGroup="castemaster" />
                                </div>
                            </div>
                        </div>
                    </div>
                       <div class="table table-responsive no-padding">
                    <asp:ListView ID="lvCaste" runat="server">
                        <EmptyDataTemplate>
                            <table class="table">
                                <tr>
                                    <td>No data was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.DataItemIndex + 1%>.</td>

                                <td><%#DataBinder.Eval(Container.DataItem,"CasteName")%></td>

                                <td>
                                    <%#(WEB_APP_SCHOOL_NET.Common.EnumConstants.Caste)Convert.ToInt32(Eval("CasteType").ToString()) %>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MST_RELIGION.ReligionName") %>' />
                                </td>
                                
                                <td>
                                    <asp:LinkButton ID="lkbCasteDelete" EnableTheming="false" runat="server" OnClick="lkbCasteDelete_Click" CommandArgument='<%#Eval("CasteId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" ToolTip="Delete" CausesValidation="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table class="table table-responsive dataTable" id="lvItems">
                                         <thead>
                                        <tr>
                                             <th style="width: 3%">#</th>
                                    <th style="width: 26%">Caste Name</th>
                                    <th style="width: 26%">Caste Type</th>
                                    <th style="width: 26%">Religion Name</th>
                                    <th style="width: 3%">#</th>
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

            <div class="col-sm-6">
                <!--Start-- For Occupation Master   -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Occupation</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove">
                                <i class="fa fa-remove"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="txtOccupation" runat="server" placeholder="Occupation Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvOccupation" runat="server" Display="Dynamic" CssClass="field-validation-error" ControlToValidate="txtOccupation" ErrorMessage="Please enter occupation name." ValidationGroup="Occupationmaster"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:LinkButton ID="btnSaveOcc" runat="server" Text="Save" OnClick="btnSaveOcc_Click" ValidationGroup="Occupationmaster" />
                                </div>
                            </div>
                        </div>
                        <div class="table table-responsive no-padding">
                            <asp:ListView ID="lvOccupation" runat="server">
                                <EmptyDataTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.DataItemIndex + 1%>.</td>

                                        <td><%#DataBinder.Eval(Container.DataItem,"OccupationName")%></td>

                                        <td>
                                            <%#(WEB_APP_SCHOOL_NET.Common.EnumConstants.Status)Convert.ToInt32(Eval("Status").ToString()) %>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lkbOccupationDelete" EnableTheming="false" runat="server" OnClick="lkbOccupationDelete_Click" CommandArgument='<%#Eval("Occupation_ID")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" ToolTip="Delete" CausesValidation="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table class="table table-responsive dataTable" id="lvItems">
                                         <thead>
                                        <tr>
                                             <th>#</th>
                                                <th>Occupation Name</th>
                                                <th>Status</th>
                                                <th>#</th>
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
                <!--End -->
            </div>
        </div>

    </div>

    <!--End -->
</asp:Content>
