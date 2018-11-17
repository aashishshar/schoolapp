<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_RoleManager.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_RoleManager" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>

<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">Role Create</h3>
    </div>
    <div class="box-body">
        <div class="row">
            <div class="form-group">
                <div class="col-md-3 col-xs-6">
                    <asp:TextBox ID="txtRoleCreate" CssClass="form-control" placeholder="Role Name" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRolecreate" runat="server" Display="Dynamic" CssClass="field-validation-error" ControlToValidate="txtRoleCreate" ErrorMessage="Please specify role name." ValidationGroup="rolemanager"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-1">
                      <asp:LinkButton ID="btnCreate" runat="server" ValidationGroup="rolemanager"  OnClick="btnCreate_Click"><i class="fa fa-tasks"></i>&nbsp;Create Role</asp:LinkButton>
                   
                </div>
                <div class="col-md-8"></div>
            </div>
        </div>       
        
            <uc1:uc_sucess runat="server" ID="uc_sucess" />
        </div>

        <div class="box-body no-padding">
            <asp:ListView runat="server"  ID="lvRoles" >
                <LayoutTemplate>

                    <table class="table">

                        <tr>
                            <th style="width: 10px">#</th>
                            <th style="width: 80px">Role Name</th>
                            <th style="width: 10px">Action</th>
                        </tr>

                        <tbody>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex + 1%>.</td>
                        <td><%#Eval("Name")%></td>
                        <td>
                            <asp:LinkButton ID="lkbRemoveButton" EnableTheming="false" runat="server" OnClick="RemoveRoles" CommandArgument='<%#Eval("Name")%>' OnClientClick="return confirm('Are you sure you want delete');" ToolTip="Delete" CausesValidation="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                        </td>

                    </tr>
                </ItemTemplate>

            </asp:ListView>
        </div>
        <!-- /.box-body -->


  
</div>
