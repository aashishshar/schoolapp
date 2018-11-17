<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_CreateGroup.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_CreateGroup" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


 <div class="box box-primary">
    <div class="box-header with-border">
     <h3 class="box-title">Group</h3>
    </div>
    <div class="box-body">
        <div class="row">
                <div class="col-md-4">
                     <div class="form-group">
                    <asp:TextBox ID="txtGroupName" placeholder="Group Name" MaxLength="20" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvGroupName" Display="Dynamic" runat="server" ControlToValidate="txtGroupName" ErrorMessage="Please enter group name" ValidationGroup="creategroup"></asp:RequiredFieldValidator>
                          </div>
                     </div>
                     <div class="col-md-4">
                     <div class="form-group">
                           <asp:TextBox ID="txtpath" placeholder="Path" MaxLength="20" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvpath" Display="Dynamic" runat="server" ControlToValidate="txtGroupName" ErrorMessage="Please enter path" ValidationGroup="creategroup"></asp:RequiredFieldValidator>
                         </div>
                         </div>
                    <div class="col-md-4">
                     <div class="form-group">
                           <asp:TextBox ID="txtmenu" placeholder="Menu" MaxLength="20" runat="server"></asp:TextBox>
                         </div>
                         </div>
                     
                   
             </div>
          <div class="row">
                <div class="col-md-4">
                     <div class="form-group">
                         <asp:CheckBox ID="chkread"   Text="Read"  runat="server" />
                          </div>

                     </div>
                     <div class="col-md-4">
                     <div class="form-group">
                         <asp:CheckBox ID="chkwrite"  CssClass="minimal" Text="Write" runat="server" />
                         </div>
                         </div>
                    <div class="col-md-4">
                     <div class="form-group">
                         <asp:CheckBox ID="chkexecute"  CssClass="minimal" Text="Execute" runat="server" />
                         </div>
                         </div>
                    </div>
            
                <div class="row">
                <div class="col-md-6">
                     <div class="form-group">
                    <asp:textbox ID="txtDescription" placeholder="Group Description" TextMode="MultiLine" Rows="2" MaxLength="50" runat="server"></asp:textbox>
                    <asp:RequiredFieldValidator ID="rfvGroupDes" Display="Dynamic" runat="server" CssClass="help-block" ControlToValidate="txtDescription" ErrorMessage="Please Enter group description" ValidationGroup="creategroup"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                    <div class="col-md-3">
         <asp:LinkButton ID="btnCreateGroup" runat="server" ValidationGroup="creategroup" OnClick="btnCreateGroup_Click"><i class="fa fa-users"></i>&nbsp;Create Group</asp:LinkButton>

                   
                         <uc1:uc_sucess runat="server" ID="uc_sucess" />
              
                  </div>
   
                    </div>
                 </div>
    
        <div class="box-body table-responsive no-padding">
            <asp:ListView ID="lvGroups" runat="server">
                <LayoutTemplate>
                    <table class="table">
                        <tr>
                            <th style="width: 10px">#</th>
                            <th style="width: 20px">Group Name</th>
                            <th style="width: 60px">Description</th>
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
                        <td><%#Eval("Description")%></td>
                        <td>
                            <asp:LinkButton ID="lkbRemoveButton" EnableTheming="false" runat="server" OnClick="RemoveGroup" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Are you sure you want delete');" CausesValidation="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                           
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
   </div>
