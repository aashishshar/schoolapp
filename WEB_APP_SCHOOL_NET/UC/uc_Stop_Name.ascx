<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Stop_Name.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_Stop_Name" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<div class="row">
    <div class="col-md-2">
        <div class="form-group">
            <label>Route Name</label>
            <asp:DropDownList style="width:100%" runat="server" ID="ddlRouteName"></asp:DropDownList>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <label>Stop Name</label>
            <asp:TextBox ID="txtStopName" placeholder="Stop Name" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-2 bootstrap-timepicker">
        <div class="form-group">
            <label>PickUp Time</label>
            <div class="input-group">
                <asp:TextBox ID="txtPickUpTime" CssClass="form-control timepicker" EnableTheming="false" placeholder="PickUp Time" runat="server"></asp:TextBox>
                <div class="input-group-addon">
                    <i class="fa fa-clock-o"></i>
                </div>
            </div>

        </div>
    </div>
    <div class="col-md-2 bootstrap-timepicker">
        <div class="form-group">
            <label>Drop Time</label>
            <div class="input-group">
                <asp:TextBox ID="txtDropTime" CssClass="form-control timepicker" EnableTheming="false" placeholder="Drop Time" runat="server"></asp:TextBox>
                <div class="input-group-addon">
                    <i class="fa fa-clock-o"></i>
                </div>
            </div>

        </div>
    </div>
    <br />
    <div class="col-md-1">
        <div class="form-group">
            <asp:LinkButton ID="lkbSave" runat="server" OnClick="lkbSave_Click" ToolTip="Save"><i class="fa fa-save"></i>&nbsp; Save</asp:LinkButton>
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
                    <asp:LinkButton ID="lkbDeleteClass" CommandName="Delete" OnClick="lkbDeleteClass_Click" CommandArgument='<%#Eval("StopId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
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
