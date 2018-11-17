<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Vehicle.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_Vehicle" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>


<div class="row">
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtRegistrationNo" placeholder="Registration No." runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtRegnOwnerName" placeholder="Owner Name" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">

            <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>
                <asp:TextBox ID="txtMFGDate" placeholder="MFG Date" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>

            </div>


        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtChassisNo" placeholder="Chassis No" runat="server"></asp:TextBox>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtRegnAuthority" placeholder="Registration Authority" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">

            <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>
                <asp:TextBox ID="txtRegnDate" placeholder="Registration Date" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>

            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>

                <asp:TextBox ID="txtRegnValidUpTo" placeholder="Regn Valid UpTo" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>
            </div>

        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:DropDownList style="width:100%" ID="ddlFuelUsed" ToolTip="Vehicle Fuel" runat="server"></asp:DropDownList>

        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtEngineNo" placeholder="Engine No." runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtColor" placeholder="Vehicle Color" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtMakersClass" placeholder="Makers Class" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtSeatingCapacity" onkeypress="return onlyNos(event,this);" MaxLength="2" placeholder="Seating Capacity" runat="server"></asp:TextBox>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtCompanyName" placeholder="Company Name" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
          
            <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>

                <asp:TextBox ID="txtFitnessValidity" placeholder="Fitness Validity" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>
            </div>
          
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:DropDownList style="width:100%" ID="ddlVehicleType" ToolTip="Vehicle Type" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtInsuranceNo" placeholder="Insurance No." runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtInsuranceBy" placeholder="Company Name" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>

                <asp:TextBox ID="txtInsuranceStartDate" placeholder="Insurance Start Date" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>
            </div>
         
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
             <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>

                <asp:TextBox ID="txtInsuranceValidUpToDate" placeholder="Insurance Valid UpTo Date" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>
            </div>
          
        </div>
    </div>

</div>
<div class="row">
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtPolutionNo" placeholder="Polution No." runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
            <%-- <label>Class Name</label>--%>
            <asp:TextBox ID="txtPollutionBy" placeholder="Pollution By" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
        <div class="form-group">
           <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>

                <asp:TextBox ID="txtPollutionStartDate" placeholder="Pollution Start Date" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>
            </div>
       
        </div>
    </div>

    <div class="col-md-3">
        <div class="form-group">
          <div class="input-group input-group-unstyled-right">
                <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                </div>

                <asp:TextBox ID="txtPollutionEndDate" placeholder="Pollution EndDate" CssClass="form-control date-picker_invertdate" EnableTheming="false" runat="server"></asp:TextBox>
            </div>
       
        </div>
    </div>
</div>
<div class="row">
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
                <td><%#Eval("RegnNo") %></td>
                <td><%#Eval("RegnOwnerName") %></td>
                 <td><%#Eval("SeatingCapacity") %></td>
                 <td><%#Eval("MakersClass") %></td>
                 <td><%#Eval("CompanyName") %></td>
                
                <td>
                    <asp:LinkButton ID="lkbDelete" CommandName="Delete" CommandArgument='<%#Eval("VehicleId")%>' OnClick="lkbDelete_Click" OnClientClick="return confirm('Are you sure, you want to delete!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false" data-placement="right" ToolTip="Delete"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table table-responsive dataTable">
                <thead>
                    <tr>
                        <th style="width: 10px">#</th>
                        <th>Regn. No</th>
                        <th>OwnerName</th>
                         <th>Seating Capacity</th>
                           <th>Makers Class</th>
                           <th>Company Name</th>
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
