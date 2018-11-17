<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Student_Route_Setting.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.uc_Student_Route_Setting" %>
<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_FinYear" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>




<div class="row">
    <div class="col-md-2">
        <div class="form-group">
            <label>Route Name</label>
            <uc1:uc_FinYear runat="server" ID="uc_FinYear" />
        </div>
    </div>
    <uc1:uc_Class runat="server" ID="uc_Class" />
   <br />

    <div class="col-md-1">
        <div class="form-group">
            <asp:LinkButton ID="lkbSave" runat="server"  ToolTip="Save"><i class="fa fa-save"></i>&nbsp; Save</asp:LinkButton>
        </div>
    </div>
    <div class="col-md-2">
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
                <td><%#DataBinder.Eval(Container.DataItem,"MST_ROUTE_NAME.RouteName") %></td>
                <td><%#Eval("StopName") %></td>
                <td><%#Eval("PickUpTiming") %></td>
                <td><%#Eval("DropTiming") %></td>
                <td>
                    <asp:LinkButton ID="lkbDeleteClass" CommandName="Delete"  CommandArgument='<%#Eval("StopId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table table-responsive dataTable">
                <thead>
                    <tr>
                        <th style="width: 10px">#</th>
                        <td>Route Name</td>
                        <th>Stop Name</th>
                        <th>Pick up Time</th>
                        <th>Drop Time</th>
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
