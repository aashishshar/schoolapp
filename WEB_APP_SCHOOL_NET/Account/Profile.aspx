<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.Account.Profile" %>
<%@ Register Src="~/Account/uc_ChangePassword.ascx" TagPrefix="uc1" TagName="uc_ChangePassword" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="content-header">
    <h1>User Profile
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <%--<li><a href="#">Create Users</a></li>--%>
        <li class="active">User profile</li>
    </ol>
</div>
<div class="content">
    <div class="row">
     
        
        <!-- /.col -->
        <div class="col-md-12">
            <div id="myTab" class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#UserProfile" data-toggle="tab">User Profile</a></li>
                    <li>
                        <a href="#Changepassword" data-toggle="tab">Change Password</a></li>
                </ul>


                <div class="tab-content">
                    <div class="tab-pane active" id="UserProfile">
                      <div class="box-body">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="lblName" class="control-label">Name</label>
                                    <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                     </div>
                                <div class="form-group">
                                    <label for="lblAddress" class="control-label">Address</label>
                                        <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox> 
                                </div>
                                <div class="form-group">
                                    <label for="lblPrincipalName" class="control-label">Principal Name</label>
                                    <asp:TextBox ID="txtPrincipalName" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                    <label for="lblPanNo" class="control-label">PAN No.</label>
                                    <asp:TextBox ID="txtPANNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtPhoneno" class="control-label">Phone No.</label>
                                    <asp:TextBox ID="txtPhoneno" class="form-control" runat="server" onkeypress="return onlyNos(event,this);" onpaste="return false;" MaxLength="12"></asp:TextBox>
                                 <%--   <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtPhoneno" ErrorMessage="Please specify the Phone No." ValidationGroup="profileupdate"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group">
                                    <label for="lblFaxNo" class="control-label">Fax No.</label>
                                    <asp:TextBox ID="txtFaxNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                
                              <div class="form-group">
                                  <div class="form-group">
                                      <label for="lblDirectorName" class="control-label">Director Name</label>
                                      <asp:TextBox ID="txtDirectorName" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>
                              </div>
                                <div class="form-group">
                                  <label for="lblImagePath" class="control-label">Image Path</label>
                                  <asp:TextBox ID="txtimgPath" CssClass="form-control" runat="server"></asp:TextBox>
                              </div>
                                
                            </div>

                          <div class="col-md-4">
                              <div class="form-group">
                              <label for="lblRegNo" class="control-label">Registration No.</label>
                              <asp:TextBox ID="txtRegNo" CssClass="form-control" runat="server"></asp:TextBox>
                                  </div>
                              <div class="form-group">
                                  <label for="lblAffilated" class="control-label">Affilated From</label>
                                  <asp:TextBox ID="txtAffilated" CssClass="form-control" runat="server"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                 <label for="lblManagerName" class="control-label">Manager Name</label>
                                 <asp:TextBox ID="txtManagerName" CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                              
                              <div class="form-group">
                            <label>Image</label>

                            <asp:UpdatePanel ID="updimage" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lkbSave" />
                                    <%-- <asp:AsyncPostBackTrigger ControlID="lkbSave"/>--%>
                                </Triggers>
                                <ContentTemplate>

                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                          </div>
                        </div>
                        <div class="box-footer">
                          <div class="row">
                              <div class="col-md-2">
                            <asp:Button ID="lkbSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="lkbSave_Click" />
                              </div>
                              </div>
                            <br />
                            <div class="row">
                            <div class="col-md-6">
                            <asp:PlaceHolder ID="litMessage" runat="server"></asp:PlaceHolder>
                                </div>
                       
                        </div>
                              
                        </div>
                        </div>
                   
                    <div class="tab-pane" id="Changepassword">
                        <div class="form-horizontal">
                            <uc1:uc_ChangePassword runat="server" ID="uc_ChangePassword" />
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hfTab" runat="server" />
            </div>
            <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->
    </div>
</div>
</asp:Content>
