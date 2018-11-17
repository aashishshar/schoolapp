<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ChangePassword.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.Account.uc_ChangePassword" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>



<%--<asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
    <p class="message-success"><%: SuccessMessage %></p>
</asp:PlaceHolder>--%>

            
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:TextBox ID="txtOldPwd" CssClass="form-control" TextMode="Password" ValidationGroup="grpValidationChangePwd" placeholder="Old Password"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtOldPwd" CssClass="help-block" ValidationGroup="grpValidationChangePwd" ErrorMessage="The password field is required." />
                        <asp:RegularExpressionValidator ID="revOldpwd" runat="server" Display="Dynamic" ErrorMessage="Please specify valid password" CssClass="help-block" ControlToValidate="txtOldPwd" ValidationGroup="grpValidationChangePwd" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                    </div>                
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:TextBox ID="txtNewPwd" CssClass="form-control" TextMode="Password" ValidationGroup="grpValidationChangePwd" placeholder="New Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ValidationGroup="grpValidationChangePwd" ControlToValidate="txtNewPwd" CssClass="help-block" ErrorMessage="The password field is required." />
                    <asp:RegularExpressionValidator ID="revNewpwd" runat="server" Display="Dynamic" ErrorMessage="Please specify valid password" CssClass="help-block" ControlToValidate="txtNewPwd" ValidationGroup="grpValidationChangePwd" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" ValidationGroup="grpValidationChangePwd" placeholder="Confirm New Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtConfirmPassword" CssClass="help-block" ValidationGroup="grpValidationChangePwd" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" Display="Dynamic" ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmPassword" CssClass="help-block" ValidationGroup="grpValidationChangePwd" ErrorMessage="The password and confirmation password do not match." />
                    <asp:RegularExpressionValidator ID="revConfirm" runat="server" Display="Dynamic" ErrorMessage="Please specify valid password" CssClass="help-block" ControlToValidate="txtConfirmPassword" ValidationGroup="grpValidationChangePwd" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                </div>
            </div>       
        <!-- /.box-body -->
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <uc1:uc_sucess runat="server" ID="uc_sucess" />
                <asp:Button ID="btnResetPwd" runat="server" class="btn btn-primary" OnClick="btnResetPwd_Click" ValidationGroup="grpValidationChangePwd" Width="200px" Text="Change Password" />
            </div>
            </div>

  


