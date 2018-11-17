<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_sucess.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_sucess" %>


<div class="alert alert-danger" runat="server" visible="false" id="MsgError" >
    <asp:PlaceHolder runat="server" ID="errorMessage" Visible="<%# VisibleError %>" ViewStateMode="Disabled">
        <%: ErrorMessage %>
    </asp:PlaceHolder>
</div>
<div class="alert alert-success" runat="server" id="MsgSuccess" visible="false" >
    <asp:PlaceHolder runat="server" ID="successMessage" Visible="<%# Visible %>" ViewStateMode="Disabled">
        <%: SuccessMessage %>
    </asp:PlaceHolder>
</div>


    
        
         
   
