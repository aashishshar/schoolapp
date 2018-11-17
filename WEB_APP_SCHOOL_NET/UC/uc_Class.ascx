<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Class.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_Class" %>
<div class="col-md-2">
    <div class="form-group">
        <label>Class Name</label>
        <asp:DropDownList style="width:100%" ID="ddlClassName" AutoPostBack="true" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="col-md-2">
    <div class="form-group">
        <label>Section Name</label>

        <asp:DropDownList style="width:100%" ID="ddlSectionName"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSectionName_SelectedIndexChanged"></asp:DropDownList>
    </div>
</div>
