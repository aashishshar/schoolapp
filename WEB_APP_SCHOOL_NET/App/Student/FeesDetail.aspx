<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FeesDetail.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.FeesManagement" %>

<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Fees Master
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Fees Details</li>
        </ol>
    </div>
    <div class="content">

        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Fee" data-toggle="tab">Fees</a></li>
                        <li>
                            <a href="#FeeDetails" data-toggle="tab">Fee Details</a></li> 

                        <li>
                            <a href="#FeeStructure" data-toggle="tab">Fee Structure</a></li>

                    </ul>


                    <div class="tab-content">
                        <div class="tab-pane active" id="Fee">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-md-2">
                                        <label>Fee Name</label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtFeeText" placeholder="Fee Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-2">
                                        <label>Fee Collection</label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList style="width:100%" ID="ddlFeeDuration" OnSelectedIndexChanged="ddlFeeDuration_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="form-group">

                                            <asp:CheckBoxList ID="cbTerm" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" CellPadding="2" CellSpacing="2" RepeatLayout="Table"></asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-4">
                                        <asp:LinkButton ID="lkbFeeSave" OnClick="lkbFeeSave_Click" runat="server"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                        <uc1:uc_sucess runat="server" ID="uc_sucess3" />
                                    </div>
                                </div>
                            </div>

                            <div class="box-body no-padding">
                                <div class="table-responsive no-padding">
                                    <asp:ListView ID="lvFee" runat="server">
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
                                                <td><%# DataBinder.Eval(Container.DataItem,"FeeName") %></td>
                                                <td><%# GetDuration(Eval("FeeDuration")) %></td>
                                                <td>
                                                    <asp:LinkButton ID="lkbFeeDelete" OnClick="lkbFeeDelete_Click" CommandArgument='<%#Eval("FeeId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <table class="table table-responsive">
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Name</th>
                                                    <th>Payment Type</th>
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

                        <div class="tab-pane" id="FeeDetails">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="box-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>Acadmic Year</label>
                                                        <asp:DropDownList style="width:100%" ID="ddlFinYear" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>Class</label>
                                                        <asp:DropDownList style="width:100%" ID="ddlClass" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                 <div class="col-md-3">
                                                <asp:Button ID="btnGetData" runat="server" CssClass="btn btn-primary" Text="Get Data" OnClick="btnGetData_Click" />
                                                </div>
                                            </div>
                                            <div class="table no-padding">
                                                <asp:ListView ID="lvFees" DataKeyNames="FeeId,FeeDetailId" runat="server">
                                                    <EmptyDataTemplate>
                                                        <table class="table table-responsive">
                                                            <tr>
                                                                <td>No data was returned.</td>
                                                            </tr>
                                                        </table>
                                                        <% btnSave.Visible = false; %>
                                                    </EmptyDataTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.DataItemIndex + 1%>.</td>
                                                            <td><%#Eval("FeeName") %></td>
                                                            <td><%#GetDuration(Eval("FeeDuration")) %></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAmtNew" onkeypress="return onlyDecNos(event,this);" MaxLength="10" CssClass="form-control input-sm" EnableTheming="false" onkeyup="calculateFeesDetailAmount(this)" Text='<%# WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItem(Eval("FeeAmount_New")) %>' onfocus="OnFocusDecNos(this)" onblur="OnBlurDecNos(this)" runat="server"></asp:TextBox></td>
                                                            <td style="display:none;">
                                                                <asp:TextBox ID="txtAmtOld" onkeypress="return onlyDecNos(event,this);" MaxLength="10" CssClass="form-control input-sm" EnableTheming="false" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItem(Eval("FeeAmount_Old")) %>' runat="server"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemark" Text='<%#Eval("Remark") %>' MaxLength="60" CssClass="form-control input-sm" EnableTheming="false" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <LayoutTemplate>
                                                        <table class="table table-responsive dataTable" id="lvItems">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 10px">#</th>
                                                                    <th>Fee Name</th>
                                                                    <th>Payment</th>
                                                                    <th><%--New--%> Amount</th>
                                                                    <th style="display:none;">Old Amount</th>
                                                                    <th>Remarks</th>
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
                                        <div class="box-footer">
                                            <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" runat="server" Visible="false"><i class="fa fa-save"></i>&nbsp;Save Fee Details</asp:LinkButton>
                                            <uc1:uc_sucess runat="server" ID="uc_sucess" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="FeeStructure">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Acadmic Year</label>
                                            <asp:DropDownList style="width:100%" ID="ddlAcaYearFeeStrucure" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Class</label>
                                            <asp:DropDownList style="width:100%" ID="ddlClassFeeStru" OnSelectedIndexChanged="ddlClassFee_SelectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="table no-padding">

                                    <asp:ListView ID="lvFeeStructure" DataKeyNames="" runat="server">
                                        <EmptyDataTemplate>
                                            <table class="table table-responsive">
                                                <tr>
                                                    <td>No data was returned.</td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <ItemTemplate>
                                            <tr>

                                                <td><%# DataBinder.Eval(Container.DataItem,"MST_FINYEAR.Finyear_Format") %></td>
                                                <td><%# DataBinder.Eval(Container.DataItem,"MST_FEE.FeeName") %></td>
                                                <td><%# GetDuration(Eval("FeeDuration")) %></td>
                                                <td>
                                                    <%#Eval("Fee_New_Amt") %></td>
                                                <td><%#Eval("Total_New_Amt") %></td>
                                               <%-- <td>
                                                    <%#Eval("Fee_Old_Amt") %></td>

                                                <td>
                                                    <%#Eval("Total_Old_Amt") %></td>--%>
                                            </tr>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <table class="table table-responsive dataTable" id="lvItems">
                                                <thead>
                                                    <tr>

                                                        <th>Aca. Year</th>
                                                        <th>Fee Name</th>
                                                        <th>Payment Type</th>
                                                        <th>Fee <%--New--%>Amt</th>
                                                        <th>Total <%--New--%> Amt</th>
                                                        <%--<th>Fee Old Amt</th>
                                                        <th>Total Old Amt</th>--%>
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

    </div>
    <script>
        function calculateFeesDetailAmount(e)
        {
            if ($(e).val().trim() == "")
                $(e).val("0.0");
        }
    </script>
</asp:Content>
