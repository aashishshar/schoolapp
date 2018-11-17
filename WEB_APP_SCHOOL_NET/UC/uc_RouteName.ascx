<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_RouteName.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_RouteName" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<div class="row">
    <div class="col-md-3">
        <div class="form-group">
             <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtRouteName" placeholder="Route Name" runat="server"></asp:TextBox>
        </div>
    </div>
   

    <div class="col-md-1">
        <div class="form-group">
            <asp:LinkButton ID="lkbSave" runat="server" OnClick="lkbSave_Click" ToolTip="Save"><i class="fa fa-save"></i>&nbsp; Save</asp:LinkButton>
        </div>
    </div>
     <div class="col-md-8">
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
                <td><%#Eval("RouteName") %></td>
                       
                <td>
                    <asp:LinkButton ID="lkbDeleteClass" OnClick="lkbDeleteClass_Click" CommandName="Delete" CommandArgument='<%#Eval("RouteId")%>' OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table table-responsive dataTable">
                <thead>
                    <tr>
                        <th >#</th>
                        <th>Route Name</th>
                       
                      
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