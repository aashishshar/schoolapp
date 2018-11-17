<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_user_ResetPassword.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.Account.uc_user_ResetPassword" %>
<div class="box box-primary">
    <div class="box-header with-border">
      <h4 class="box-title">Reset Password</h4>
    </div>
    <div class="box-body">
        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                <asp:TextBox ID="txtUserId" placeholder="User Name" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-3">
                <div class="form-group">
               <asp:TextBox ID="txtPassword"  placeholder="Password" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="box-footer">
<asp:LinkButton ID="lkbResetPassword" OnClick="lkbResetPassword_Click" runat="server">Reset Password</asp:LinkButton>
    </div>

</div>



