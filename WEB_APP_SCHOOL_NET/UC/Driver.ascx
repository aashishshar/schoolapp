<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Driver.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.Driver" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<div class="row">
    <div class="col-md-3">
        <div class="form-group">
             <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtDriverName" placeholder="Driver Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDriverName" Display="Dynamic" ValidationGroup="dvs" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%--  <label>Class Name</label>--%>
            <asp:TextBox ID="txtMoNo" placeholder="Mo.No." runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="col-md-1">
        <div class="form-group">
            <asp:LinkButton ID="lkbSave" runat="server" OnClick="lkbSave_Click" ValidationGroup="dvs" ToolTip="Save"><i class="fa fa-save"></i>&nbsp; Save</asp:LinkButton>
        </div>
    </div>
     <div class="col-md-5">
        <div class="form-group">
             <asp:PlaceHolder ID="litMessage" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</div>

<div class="table no-padding">
    <asp:ListView ID="lvItems" runat="server">
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
                <td><%#Eval("DriverName") %></td>
                <td><%#Eval("MoNo") %></td>                
                <td>
                    <asp:LinkButton ID="lkbDeleteClass" OnClick="lkbDeleteClass_Click" CommandName="Delete" CommandArgument='<%#Eval("DriverId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table table-responsive dataTable">
                <thead>
                    <tr>
                        <th style="width: 10px">#</th>
                        <th>Driver Name</th>
                        <th>Mo. No.</th>
                      
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
