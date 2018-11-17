<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Route_Setting.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_Route_Setting" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<div class="row">
    <div class="col-md-2">
        <div class="form-group">
            <label>Vehicle Name</label>
            <asp:DropDownList style="width:100%" runat="server" ID="ddlVehicleName"></asp:DropDownList>
        </div>
    </div>
    <div class="col-md-2">
        <div class="form-group">
            <label>Driver Name</label>
            <asp:DropDownList style="width:100%" runat="server" ID="ddlDriverName"></asp:DropDownList>

        </div>
    </div>
    <div class="col-md-2">
        <div class="form-group">
            <label>Route Name</label>
            <asp:DropDownList style="width:100%" runat="server" ID="ddlRouteName" AutoPostBack="true" OnSelectedIndexChanged="ddlRouteName_SelectedIndexChanged"></asp:DropDownList>

        </div>
    </div>
    <div class="col-md-2">
        <div class="form-group">
            <label>Stoppage Name</label>
            <asp:DropDownList style="width:100%" runat="server" ID="ddlStoppageName"></asp:DropDownList>

        </div>
    </div>
    <div class="col-md-2">
        <div class="form-group">
            <label>Route Amount(Rs.)</label>
            <asp:TextBox runat="server" ID="txtRoutePrice"></asp:TextBox>

        </div>
    </div>
    <br />
    <div class="col-md-2">
        <div class="form-group">
            <asp:LinkButton ID="lkbSave" runat="server" OnClick="lkbSave_Click" ToolTip="Save"><i class="fa fa-save"></i>&nbsp; Save</asp:LinkButton>
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
                <td><%#DataBinder.Eval(Container.DataItem,"MST_VEHICLE.RegnNo") %></td>
                <td><%#DataBinder.Eval(Container.DataItem,"MST_DRIVER.DriverName") %></td>
                <td><i class="fa fa-inr"></i><%#DataBinder.Eval(Container.DataItem,"RoutePriceAmt") %></td>
                <td>
                    <asp:LinkButton ID="lkbDeleteClass" CommandName="Delete" CommandArgument='<%#Eval("StudentRouteId")%>' OnClick="lkbDeleteClass_Click" OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn btn-danger btn-xs" data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-white"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table table-responsive dataTable">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Route Name</th>
                        <th>Regn. No.</th>
                        <th>Driver Name</th>
                        <th>Route Amt.</th>
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
