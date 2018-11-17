<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_StudentDetail.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_StudentDetail" %>

<%--<asp:Repeater ID="Repeater1" runat="server">
     <ItemTemplate>--%>
<div class="box-body">

    <div class="row">
        <div class="col-md-9">
             <div class="row">
              
            <div class="col-md-4">
                <div class="form-group">
                    <label>Class Name</label><br />
                    <asp:Literal ID="litClassName" runat="server" />
                </div>
            </div>
            <%--<div class="col-md-4">
                <div class="form-group">
                    <label>Section Name</label><br />
                    <asp:Literal ID="litSectionName" runat="server" />
                </div>
            </div>--%>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Serial Number</label><br />
                    <asp:Literal ID="litSerialNumber" runat="server" />
                </div>
            </div>
                 <div class="col-md-4">
            <div class="form-group">
                <label>Roll No.</label><br />
                <asp:Literal ID="litRollNo" runat="server" />
            </div>
        </div>
                 
                 </div>
                
            <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label>Student's Name</label><br />
                <asp:Literal ID="litStudentName" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>Father's Name</label><br />
                <asp:Literal ID="litFatherName" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>Mother's Name</label><br />
                <asp:Literal ID="litMotherName" runat="server" />
            </div>
        </div>
        
    </div>

        </div>

        <div class="col-md-3">
            <asp:Image ID="imgUserImage" Height="100px" Width="120px" CssClass="img-responsive" runat="server" />
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>DOB</label><br />
                <asp:Literal ID="litDoB" runat="server" />
            </div>
        </div>
        
        <div class="col-md-3">
            <div class="form-group">
                <label>Contact No.</label><br />
                <asp:Literal ID="litContactNo" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Subject</label><br />
                <asp:Literal ID="litSubject" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Nationality</label><br />
                <asp:Literal ID="litNationality" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Email Id</label><br />
                <asp:Literal ID="litEmailId" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>City Name</label><br />
                <asp:Literal ID="litCityName" runat="server" />
            </div>
        </div>
        
        
        <div class="col-md-3">
            <div class="form-group">
                <label>Pin Code</label><br />
                <asp:Literal ID="litPinCode" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>State Name</label><br />
                <asp:Literal ID="litStateName" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Gender</label><br />
                <asp:Literal ID="litGender" Text='<%#Eval("Gender").ToString()=="True" ? "Male" : "Female" %>' runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Correspondence Address</label><br />
                <asp:Literal ID="litCorrespondenceAdd" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Aadhar Number</label><br />
                <asp:Literal ID="litAadharNo" runat="server" />
            </div>
        </div>
        
        
        <div class="col-md-3">
            <div class="form-group">
                <label>Reffered By</label><br />
                <asp:Literal ID="litRefer" runat="server" />
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Reffered Person Mo. No.</label><br />
                <asp:Literal ID="litMobNo" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Whatsap No.</label><br />
                <asp:Literal ID="litWhatsap" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Religion Name</label><br />
                <asp:Literal ID="litReligionName" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Caste Name</label><br />
                <asp:Literal ID="litCastName" runat="server" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>Caste Type</label><br />
                <asp:Literal ID="litCasteType" runat="server" />
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <label>Occupation</label><br />
                <asp:Literal ID="litOccupation" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Last School Name</label><br />
                <asp:Literal ID="litSchoolName" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Village / Town / Street</label><br />
                <asp:Literal ID="litVillage" runat="server" />
            </div>
        </div>



    </div>
    <div class="row">
        
    </div>
</div>


<%-- </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>--%>












