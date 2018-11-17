<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_CreateUser.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_CreateUser" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title">User Create</h3>
    </div>
    <div class="box-body">
        <div class="row">
             <div class="col-md-3">
            <div class="form-group">
                     <asp:TextBox ID="txtUserName" placeholder="User Name" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="col-md-3">
             <div class="form-group">
                   <asp:TextBox ID="txtEmailID" placeholder="Email-ID" runat="server"></asp:TextBox>
                </div>
                 </div>
            <div class="col-md-3">
             <div class="form-group">
                      <asp:TextBox ID="txtPassword" placeholder="Password" runat="server"></asp:TextBox>
                 </div>
                </div>
            <div class="col-md-3">
             <div class="form-group">
                  <asp:TextBox ID="txtFirstName" placeholder="First Name" runat="server"></asp:TextBox>
                 </div>
                </div>
        </div>
    <div class="row">
         <div class="col-md-3">
            <div class="form-group">
                <asp:TextBox ID="txtLastName" placeholder="Last Name" runat="server"></asp:TextBox>
                </div>
             </div>
          <div class="col-md-3">
            <div class="form-group">
                  <asp:TextBox ID="txtPhoneNo" placeholder="Phone No." runat="server"></asp:TextBox>
                </div>
             </div>
          <div class="col-md-3">
            <div class="form-group">
                 <asp:DropDownList style="width:100%" ID="ddlOrganization" DataTextField="Name" DataValueField="Org_Id" runat="server"></asp:DropDownList>
                </div>
             </div>
          <div class="col-md-3">
            <div class="form-group">
                 <asp:DropDownList style="width:100%" ID="ddlRoleName" DataTextField="Name" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
             </div>
    </div>
    </div>
    <div class="box-footer">
         <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click"><i class="fa fa-user"></i>&nbsp;Create Users</asp:LinkButton>
        <uc1:uc_sucess runat="server" ID="uc_sucess" />
    </div>
    <div class="table-responsive no-padding">
            <asp:ListView ID="lvUsers" runat="server">
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
                                <td> <%#Eval("UserName") %></td>
                                <td><%#Eval("Email") %></td> 
                               <td><%#Eval("FirstName") %></td> 
                                <td><%#Eval("LastName") %></td> 
                               <%-- <td><%#Eval("") %></td> 
                                <td><%#Eval("") %></td> --%>
                                <td><%#Eval("ORG_ID") %></td> 
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <th style="width: 10px">#</th>
                                    <th>User Name</th>
                                    <th>Email Id</th>
                              <%--     <th>Phone No.</th>--%>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Organization</th>
                                   <%-- <th>Role</th>--%>
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
