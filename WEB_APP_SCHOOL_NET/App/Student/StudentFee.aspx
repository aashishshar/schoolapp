<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentFee.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Student.StudentFee" %>

<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_FeeReceipt.ascx" TagPrefix="uc1" TagName="uc_FeeReceipt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Student Fees
            <small></small></h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Student Fees</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#StudentFee" data-toggle="tab">Student Fees</a></li>
                        <li><a href="#FeeDetails" data-toggle="tab">Fee Details</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="StudentFee">
                            <div class="box-body">
                                <uc1:uc_FeeReceipt runat="server" ID="uc_FeeReceipt" />

                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Fin Year</label>
                                            <asp:DropDownList Style="width: 100%" ID="ddlFinYear" AutoPostBack="true" OnSelectedIndexChanged="ddlFinYear_SelectedIndexChanged"  runat="server">
                                            </asp:DropDownList> 
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Class Name</label>
                                            <asp:DropDownList Style="width: 100%" ID="ddlClassName" AutoPostBack="true" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Section Name</label>
                                            <asp:DropDownList Style="width: 100%" ID="ddlSectionName" AutoPostBack="true" OnSelectedIndexChanged="ddlSectionName_SelectedIndexChanged" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%-- <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Month Name</label>
                                            <asp:DropDownList style="width:100%" ID="ddlMonth" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Student Name</label>
                                            <asp:DropDownList Style="width: 100%" ID="ddlStudentList" Width="100%" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:LinkButton ID="lkbGetFeeDetail" OnClick="lkbGetFeeDetail_Click" runat="server">Get Fee Detail</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <asp:LinkButton ID="lkbViewReceipt" OnClick="lkbViewReceipt_Click" CssClass="btn-success" runat="server">Show Fee Receipt</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="DivPaymentType" visible="false">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Receipt Number</label>
                                            <asp:TextBox runat="server" ID="txtPaymentReceiptNumber"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Payment Type</label>
                                            <asp:DropDownList Style="width: 100%" ID="ddlPaymentType" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:Label AssociatedControlID="txtTransactionNumber" runat="server" ID="lblTransaction"></asp:Label>
                                            <asp:TextBox ID="txtTransactionNumber" Visible="false" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="box-body table-responsive">
                                <div class="table no-padding">
                                    <asp:ListView ID="lvStudentFee"  DataKeyNames="FEETERMID,STUDENTFEEID,FEEAMOUNT_NEW" runat="server" OnItemDataBound="lvStudentFee_ItemDataBound">
                                        <EmptyDataTemplate>
                                            <table class="table table-responsive">
                                                <tr>
                                                    <td>No data was returned.</td>
                                                </tr>
                                            </table>
                                            <%btnSave.Visible = false; %>
                                        </EmptyDataTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.DataItemIndex + 1%></td>
                                                <td><%#Eval("FEENAME") %><%# FeeTermName(Convert.ToByte(Eval("FEETERM") as byte? == null ? 0 : Eval("FEETERM")),Convert.ToByte(Eval("FEEDURATION"))) %></td>
                                                <%-- <td><%#Eval("FEEDURATION") %></td>--%>
                                                <td style="text-align: right;"><%#Eval("FEEAMOUNT_NEW") %></td>
                                                <td style="text-align: right;">
                                                    <div style="float: right;">
                                                        <asp:TextBox ID="txtDepositFeeNew" Style="text-align: right;" onkeyup="CalculateDeposit(this)" onkeypress="return onlyDecNos(event,this);" MaxLength="9" EnableTheming="false" CssClass="form-control input-sm" Width="80px" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItem(Eval("STUDENT_FEEAMOUNT_NEW"))%>' onfocus="OnFocusDecNos(this)" onblur="OnBlurDecNos(this)" runat="server"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td style="text-align: right; display: none;"><%#Eval("FEEAMOUNT_OLD") %></td>
                                                <td style="text-align: right; display: none;">
                                                    <div style="float: right;">
                                                        <asp:TextBox ID="txtDepositFeeOld" Style="text-align: right;" onkeypress="return onlyDecNos(event,this);" MaxLength="9" EnableTheming="false" CssClass="form-control input-sm" Width="80px" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItem(Eval("STUDENT_FEEAMOUNT_OLD"))%>' runat="server"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td style="text-align: right;">
                                                    <div style="float: right;">
                                                        <asp:TextBox ID="txtCONCESSIONFEEAMT" Style="text-align: right;" onkeyup="calculateConcession(this)" onkeypress="return onlyDecNos(event,this);" MaxLength="9" EnableTheming="false" CssClass="form-control input-sm" Width="80px" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItem(Eval("CONCESSIONFEEAMT"))%>' onfocus="OnFocusDecNos(this)" onblur="OnBlurDecNos(this)" runat="server"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td runat="server" visible="false" style="text-align: right;">
                                                    <div style="float: right;">
                                                        <asp:TextBox ID="txtDUEFEE" Style="text-align: right;" onkeypress="return onlyDecNos(event,this);" MaxLength="9" EnableTheming="false" CssClass="form-control input-sm" Width="80px" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItem(Eval("DUEFEE")) %>' runat="server"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <table class="table table-bordered table-responsive">
                                                <thead>
                                                    <tr>
                                                        <th rowspan="2" style="width: 10px">#</th>
                                                        <th rowspan="2" style="width: 50%;">Fees</th>
                                                        <%-- <th rowspan="2">Duration</th>--%>
                                                        <th style="text-align: center;" colspan="2">Fees </th>
                                                        <%--                                                        <th style="text-align: center; display: none;" colspan="2">Fees Old </th>--%>
                                                        <th rowspan="2" style="text-align: center;">CONCESSION AMT.<br />
                                                            (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <%--<th runat="server" visible="false" rowspan="2" style="text-align: right;">Due<br />
                                                            (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>--%>
                                                    </tr>
                                                    <tr>
                                                        <th style="text-align: right;">Amt<br />
                                                            (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: right;">Deposit<br />
                                                            (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <%-- <th style="text-align: right;">Amt<br />
                                                            (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: right;">Deposit<br />
                                                            (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                                 <%--<tfoot>
                                                     <tr>
                    <asp:Label ID="lblSum" runat="server" Text="Label"></asp:Label></tr>
                </tfoot>--%>
                                            </table>
                                        </LayoutTemplate>
                                        
                                    </asp:ListView>
                                    <%--   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="PROC_STUDENT_FEEDETAIL" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    --%>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="PROC_STUDENT_FEEDETAIL" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="" Name="CLASS_ID" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="STUDENT_ID" Type="String" />
                                            <asp:Parameter DefaultValue="" Name="FIN_ID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" runat="server" ValidationGroup="Compare" Visible="false"><i class="fa fa-save"></i>&nbsp;Save Student Fee</asp:LinkButton>
                                <div class="pull-right"><strong>
                                    <asp:Label runat="server" ID="lblTotalDueFee"></asp:Label></strong></div>
                                <uc1:uc_sucess runat="server" ID="uc_sucess" />
                            </div>
                        </div>
                        <div class="tab-pane" id="FeeDetails">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Fin Year</label>
                                            <asp:DropDownList Style="width: 100%" ID="FeeDetailFinYear" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Class Name</label>
                                            <asp:DropDownList Style="width: 100%" ID="FeeDetailClass" AutoPostBack="true" OnSelectedIndexChanged="FeeDetailClass_SelectedIndexChanged" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Section Name</label>
                                            <asp:DropDownList Style="width: 100%" ID="FeeDetailSection" AutoPostBack="true" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <br>
                                            <asp:LinkButton ID="lkbGetFeeDetail2" OnClick="lkbGetFeeDetail2_Click" runat="server">Get Fee Detail</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box-body table-responsive">
                                <div class="table no-padding">
                                    <asp:ListView ID="lvFeeDetail" DataKeyNames="STUDENTID" runat="server" OnItemDataBound="lvFeeDetail_ItemDataBound">
                                        <EmptyDataTemplate>
                                            <table class="table table-responsive">
                                                <tr>
                                                    <td>No data was returned.</td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td width="3%"><%# Container.DataItemIndex + 1%></td>
                                                <td><%#Eval("STUDENTNAME") %></td>
                                                <%-- <td><%#Eval("FEEDURATION") %></td>--%>
                                                <td style="text-align: center;"><%#Eval("TOTALFEE") %></td>
                                                <td style="text-align: center;"><%#Eval("AMOUNTPAY") %></td>
                                                <td style="text-align: center;"><%#Eval("CONCESSIONAMOUNT") %></td>
                                                <td style="text-align: center;" id="DueFee" runat="server"><%#Eval("DUEFEE") %></td>
                                                <%-- <td style="text-align: center;"><%#Eval("TOTALOLDFEE") %></td>
                                                <td style="text-align: center;"><%#Eval("OLDAMOUNT") %></td>
                                                <td style="text-align: center;" id="DueOldFee" runat="server"><%#Eval("DUEOLDFEE") %></td>
                                                <td style="text-align: center;"><a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-eye text-orange"></i></a></td>--%>
                                            </tr>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <table class="table table-bordered table-responsive dataTable">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 10px">#</th>
                                                        <th>Student Name</th>
                                                        <%--<th rowspan="2">Duration</th>--%>
                                                        <th style="text-align: center;">Total Fee(<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: center;">Amount Pay(<i style="font-size: 10px;" class="fa fa-rupee"></i>) </th>
                                                        <th style="text-align: center;">Concession Fee (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: center;">Due Fee (<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <%--<th style="text-align: center;">Total Old Fee(<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: center;">Old Amount(<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: center;">Due Old Fee(<i style="font-size: 10px;" class="fa fa-rupee"></i>)</th>
                                                        <th style="text-align: center;">Actions</th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                    </asp:ListView>
                                    <div id="myModal" class="modal fade" role="dialog">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title">Modal Header</h4>
                                                </div>
                                                <div class="modal-body">
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="PROC_STUDENT_FEE_STATUS" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="" Name="CLASS_ID" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="SECTION_ID" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="FINYEAR_ID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function CalculateDeposit(e) {
            if ($(e).val().trim() == "") {
                $(e).val(0.0);
                return;
            }
            var deposit = parseFloat($(e).val());
            var Amt = parseFloat($(e).parent('div').parent('td').prev('td').text());
            var Concession = parseFloat($(e).parent('div').parent('td').next('td').next('td').next('td').children().children('input').val());
            Amt = Amt - Concession;
            if (deposit > Amt) {
                $(e).val(Amt.toFixed(2));
            }
        }

        function calculateConcession(e) {
            if ($(e).val().trim() == "") {
                $(e).val(0.0);
                return;
            }
            var Amt = parseFloat($(e).parent('div').parent('td').prev('td').prev('td').prev('td').prev('td').text());
            var Concession = parseFloat($(e).val());
            var deposit = parseFloat($(e).parent('div').parent('td').prev('td').prev('td').prev('td').children().children('input').val());
            if (Amt < Concession) {
                $(e).val(Amt);
            }
            Amt = Amt - Concession;
            if (deposit > Amt) {
                if (Amt < 0)
                    Amt = 0;
                $(e).parent('div').parent('td').prev('td').prev('td').prev('td').children().children('input').val(Amt.toFixed(2));
            }
        }
    </script>
</asp:Content>
