<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>New Student
            <small>Create Student</small></h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">New Student</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-primary">
            <div class="box-header ">
                <h4 class="box-title">
                    <asp:Label ID="formno" runat="server">Form No. :</asp:Label>
                    <asp:Label ID="lblform" runat="server" Text="FormNo."></asp:Label>
                </h4>
                <div class="box-tools pull-right">
                    <asp:LinkButton ID="lkbBack" Visible="false" CssClass="btn btn-danger pull-right" EnableTheming="false" OnClick="lkbBack_Click" runat="server">&nbsp;<i class="fa fa-backward"></i> Back</asp:LinkButton>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                            SESSION</label>
                            <asp:DropDownList style="width:100%" ID="ddlYear" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Class Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlClassName" AutoPostBack="true" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Gender</label>
                            <asp:DropDownList style="width:100%" ID="ddlGender" runat="server">
                                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Address</label>
                            <asp:TextBox ID="txtCorrespondenceAddress" Placeholder="Correspondence Address" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Pin Code</label><asp:TextBox ID="txtPincode" autocomplete="off" onkeypress="return onlyNos(event,this);" onpaste="return false;" Placeholder="Pin Code" MaxLength="6" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Email Id</label>
                            <asp:TextBox ID="txtEmailId" Placeholder="Email ID" ValidationGroup="vgCreateStudent" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rfvEmailid" runat="server" Display="Dynamic" ValidationGroup="vgCreateStudent" ErrorMessage="Please specify valid email id" CssClass="help-block" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>
                                Last School Name</label>
                            <asp:TextBox ID="txtlastschool" placeholder="Last School Name" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Residing Since</label>
                            <asp:TextBox ID="txtresiding" Placeholder="Residing Since" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                            Subject</label>
                            <asp:CheckBoxList ID="cblListSubject" CssClass="icheckbox_minimal-red" RepeatColumns="4" DataTextField="SubjectName" DataValueField="SubjectId" runat="server">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                                Serial Number</label>
                            <asp:TextBox ID="txtSerialNumber" MaxLength="4" CssClass="form-control" Placeholder="Serial No." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Section Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlSectionName" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Date of Birth</label>
                            <asp:TextBox ID="txtDob" ValidationGroup="sa" CssClass="form-control date-picker_invertdate" EnableTheming="false" placeholder="DOB" runat="server"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator EnableClientScript="true" ID="rfvtxtDob" ForeColor="Red" SetFocusOnError="true" ValidationGroup="sa" runat="server" Display="Dynamic" ControlToValidate="txtDob" CssClass="help-block" ErrorMessage="Please specify DOB."></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group">
                            <label>
                                Village / Town / Street</label><asp:TextBox ID="txtVillage" Placeholder="Village / Town / Street" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Caste Type</label>
                            <asp:DropDownList style="width:100%" ID="ddlCasteType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCasteType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Contact No.</label>
                            <asp:TextBox ID="txtContactNo" Placeholder="Contact No." onkeypress="return onlyNos(event,this);" onpaste="return false;" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Reffered By</label><asp:TextBox ID="txtReferred" Placeholder="Reffered By" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Whatsapp No.</label>
                            <asp:TextBox ID="txtWhatsapNo" Placeholder="Whatsapp No." runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                                Roll Number</label><asp:TextBox ID="txtRollNo" MaxLength="6" placeholder="Roll Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Student's Name</label><asp:TextBox ID="txtStudentname" ValidationGroup="sa" placeholder="Student's Name" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator EnableClientScript="true" ID="RequiredFieldValidator1" SetFocusOnError="true" ControlToValidate="txtStudentname" ValidationGroup="sa" runat="server" ForeColor="Red" Display="Dynamic" CssClass="help-block" ErrorMessage="Please specify Student's Name."></asp:RequiredFieldValidator>--%>
                            <%--<asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rfvStudentName" ValidationGroup="vgCreateStudent" runat="server" Display="Dynamic" ControlToValidate="txtStudentname" CssClass="help-block" ErrorMessage="Please specify Student's Name."></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group">
                            <label>
                                Father's Name</label><asp:TextBox ID="txtFathername" ValidationGroup="sa" placeholder="Father's Name" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator EnableClientScript="true" ForeColor="Red" SetFocusOnError="true" ID="rfvFatherName" ValidationGroup="sa" runat="server" Display="Dynamic" ControlToValidate="txtFathername" CssClass="help-block" ErrorMessage="Please specify Father's Name."></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group">
                            <label>
                                State Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlStateName" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Caste Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlCasteName" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Occupation</label>
                            <asp:DropDownList style="width:100%" ID="ddlOccupation" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Reffered Person Mo. No.</label><asp:TextBox ID="txtMobileNo" MaxLength="10" Placeholder="Reff. Person Mo. No." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Student's Photo</label>
                            <asp:UpdatePanel ID="udpimg" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lkbSave" />
                                    <%-- <asp:AsyncPostBackTrigger ControlID="lkbSave"/>--%>
                                </Triggers>
                                <ContentTemplate>
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file-upload" accept=".png,.jpg,.jpeg,.gif,.bmp"/>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                                <asp:Image ID="imgUserImage" Height="135px" Width="150px" CssClass="img-responsive img-upload" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>
                                Mother's Name</label><asp:TextBox ID="txtMothername" placeholder="Mother's Name" ValidationGroup="sa" runat="server"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator EnableClientScript="true" ID="rfvMotherName" ForeColor="Red" SetFocusOnError="true" ValidationGroup="sa" runat="server" Display="Dynamic" ControlToValidate="txtMothername" CssClass="help-block" ErrorMessage="Please specify Mother's Name."></asp:RequiredFieldValidator>
                            --%>
                        </div>
                        <div class="form-group">
                            <label>
                                City Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlCityName" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Religion Name</label>
                            <asp:DropDownList style="width:100%" ID="ddlReligionName" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Aadhar Number</label>
                            <asp:TextBox ID="txtAadharNo" MaxLength="12" placeholder="Aadhar Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Nationality</label><asp:TextBox ID="txtNationality" Placeholder="Nationality" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box-footer">
                <asp:Button ID="lkbSave" UseSubmitBehavior="false" runat="server" CssClass="btn btn-info btn-lg" OnClick="lkbSave_Click" ValidationGroup="sa" Text="Add New Student" />
                <input id="Reset1" type="reset" class="btn btn-danger btn-lg" value="reset" />
                <asp:PlaceHolder ID="litMessage" runat="server"></asp:PlaceHolder>
                <%--<asp:LinkButton ID="lkbSave" runat="server" CausesValidation="false" OnClick="lkbSave_Click" ValidationGroup="sa" class="btn btn-primary" ToolTip="Save"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>--%>
            </div>
        </div>
    </div>
       <script>
           function readURL(input) {
               try {
                   if (input.files && input.files[0]) {
                       var reader = new FileReader();

                       reader.onload = function (e) {
                           $('.img-upload').attr('src', e.target.result);
                       }

                       reader.readAsDataURL(input.files[0]);
                   }
               }
               catch (err) {
                   alert('Image is not in correct format');
               }
    }
        $('.file-upload').change(function(){
        readURL(this);
    });
    </script>
</asp:Content>