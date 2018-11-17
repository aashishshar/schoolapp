<%@ Page Title="" Language="C#" MasterPageFile="~/App/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ExamManagement.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.App.Exam.ExamManagement" %>

<%@ Register Src="~/UC/uc_FinYear.ascx" TagPrefix="uc1" TagName="uc_finyear" %>
<%@ Register Src="~/UC/uc_sucess.ascx" TagPrefix="uc1" TagName="uc_sucess" %>
<%@ Register Src="~/UC/uc_Class.ascx" TagPrefix="uc1" TagName="uc_Class" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <h1>Exam Management
            <small>Exam Masters</small> </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Masters</a></li>
            <li class="active">Exam Management</li>
        </ol>
    </div>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="myTab" class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#Exam" data-toggle="tab">Exam</a></li>
                        <li>
                            <a href="#StudentExamResult" data-toggle="tab">Student Exam Result</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="Exam">
                            <div class="form-vertical">
                                <div class="row">
                                    <div class="col-sm-3 form-group">
                                        <label>Academic Year</label>
                                        <uc1:uc_finyear runat="server" ID="uc_finyear" />
                                    </div>
                                    <div class="col-sm-3 form-group">
                                        <label>Class Name</label>
                                        <asp:DropDownList style="width:100%" runat="server" ID="ddlClassName" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3 form-group">
                                        <label>Exam Type</label>
                                        <asp:DropDownList style="width:100%" runat="server" ID="ddlExamType" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <br />
                                    <asp:Button runat="server" ID="btnGetExam" OnClick="btnGetExam_Click" CssClass="btn btn-primary" Text="Get Exam Data"></asp:Button>
                                </div>
                            </div>
                            <div class="box-body no-padding">
                                <asp:ListView ID="lvExam" runat="server" DataKeyNames="SUBJECTID,SUBSUBJECTID,EXAMID,EXAMTYPEID,FIN_ID">
                                    <ItemTemplate>
                                        <tr>
                                            <td></td>
                                            <td><%#Eval("SUBJECTNAME") %></td>
                                            <td><%#Eval("SUBSUBJECTNAME") %></td>
                                            <td colspan="4" style="text-align: right;">
                                                <div style="float: right">
                                                    <asp:TextBox ID="txtMaximumMarks" Style="text-align: right;" onkeypress="return onlyNos(event,this);" MaxLength="3" runat="server" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItemInt(Eval("MAXIMUMMARKS"))%>'></asp:TextBox>
                                                </div>
                                            </td>
                                            <td colspan="4" style="text-align: right;">
                                                <div style="float: right">
                                                    <asp:TextBox ID="txtPassingMarks" Style="text-align: right;" onkeyup="calculatePassing(this);" onkeypress="return onlyNos(event,this);" MaxLength="3" runat="server" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItemInt(Eval("PASSINGMARKS"))%>'></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        No data available
                                <% btnSave.Visible = false; %>
                                    </EmptyDataTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive">
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Subject Name</th>
                                                <th>Sub Subject Name</th>
                                                <th style="text-align: right;" colspan="4">Maximum Marks</th>
                                                <th style="text-align: right;" colspan="4">Passing Marks</th>
                                                <%-- <th></th>--%>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="PROC_EXAM_DETAIL" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Name="CLASSID" Type="Int32" />
                                        <asp:Parameter Name="EXAMTYPEID" Type="Int16" />
                                        <asp:Parameter Name="FIN_ID" Type="Int16" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div class="box-footer">
                                <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" runat="server" OnClientClick="return confirm('Make Sure you have Created all Sub-Subjects!')" ValidationGroup="Compare" Visible="false"><i class="fa fa-save"></i>&nbsp;Save Exam Details</asp:LinkButton>
                                <uc1:uc_sucess runat="server" ID="uc_sucess" />
                            </div>
                            <div class="box box-primary">
                                <div class="box-header">
                                    <h3>Exam Records</h3>
                                </div>
                                <div class="box-body">
                                <asp:ListView ID="lvClassExam" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td></td>
                                            <td><%#Eval("CLASSNAME") %></td>
                                            <td><%#EvaluateExamId( Eval("EXAMTYPEID")) %></td>
                                            <td><%#EvaluateFinId(Eval("FIN_ID")) %></td>
                                            <td>
                                                <asp:LinkButton ID="lkbDelete" OnClick="lkbDelete_Click" CommandArgument='<%#Eval("FIN_ID")+","+Eval("CLASSID")+","+Eval("EXAMTYPEID") %>' OnClientClick="return confirm('Are you Sure ? \nDeleting exams can cause loss in whole class result!');" runat="server" CssClass="btn" data-trigger="hover" EnableTheming="false"><i class="fa fa-trash-o text-red"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        No data available
                                    </EmptyDataTemplate>
                                    <LayoutTemplate>
                                        <table class="table table-responsive">
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>CLASS NAME</th>
                                                <th>EXAM TYPE</th>
                                                <th>ACADEMIC YEAR</th>
                                                <th>ACTIONS</th>
                                                <%-- <th></th>--%>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server">
                                                    </tr>
                                                </tbody>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                               <uc1:uc_sucess runat="server" ID="uc_sucess2" />
                               <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="PROC_GETALLEXAMDATA" SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                    <asp:Parameter Name="ORG_ID" Type="Int32" />
                               </SelectParameters>
                               </asp:SqlDataSource>
                            </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="StudentExamResult">
                            <div class="form-vertical">
                                <div class="row">
                                    <div class="col-md-2 form-group">
                                        <label>Academic Year</label>
                                        <uc1:uc_finyear runat="server" ID="uc_finyear1" />
                                    </div>
                                    <uc1:uc_Class runat="server" ID="uc_Class" />
                                    <div class="col-md-2 form-group">
                                        <label>Student Name</label>
                                        <asp:DropDownList style="width:100%" runat="server" AutoPostBack="true" ID="ddlStudent"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>Exam Type</label>
                                        <asp:DropDownList style="width:100%" runat="server" ID="ddlExamType_Report" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <br />
                                    <asp:Button runat="server" ID="btnGetStudentExams" OnClick="btnGetStudentExams_Click" CssClass="btn btn-primary" Text="Get Exam Data"></asp:Button>
                                </div>
                                <div class="box-body no-padding">
                                    <asp:ListView ID="lvExamStudent" runat="server" DataKeyNames="ID,EXAMID">
                                        <ItemTemplate>
                                            <tr>
                                                <td></td>
                                                <td><%#Eval("SUBJECTNAME") %></td>
                                                <td><%#Eval("SUBSUBJECTNAME") %></td>
                                                <td><%#Eval("MAXIMUMMARKS") %></td>
                                                <td colspan="4" style="text-align: right;">
                                                    <div style="float: right">
                                                        <asp:TextBox ID="txtObtainedMarks" onkeyup="CalculateObtained(this)" Style="text-align: right;" onkeypress="return onlyNos(event,this);" MaxLength="3" runat="server" Text='<%#WEB_APP_SCHOOL_NET.Common.cls_Common.ProcessMyDataItemInt(Eval("OBTAINEDMARKS"))%>'></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                         Either the Student has no subjects OR the data for Exam has not been entered.
                                            <% lkbSaveExamReport.Visible = false; %>
                                        </EmptyDataTemplate>
                                        <LayoutTemplate>
                                            <table class="table table-responsive">
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Subject Name</th>
                                                    <th>Sub Subject Name</th>
                                                    <th>Maximum Marks</th>
                                                    <th style="text-align: right;" colspan="4">Obtained Marks</th>
                                                    <%-- <th></th>--%>
                                                    <tbody>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </tbody>
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                    </asp:ListView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="PROC_EXAM_STUDENT_DETAIL" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Name="CLASSID" Type="Int32" />
                                            <asp:Parameter Name="STUDENTID" Type="Int32" />
                                            <asp:Parameter Name="FIN_ID" Type="Int16" />
                                            <asp:Parameter Name="EXAMTYPEID" Type="Int16" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="box-footer">
                                    <asp:LinkButton ID="lkbSaveExamReport" OnClick="lkbSaveExamReport_Click" runat="server" ValidationGroup="Compare" Visible="false"><i class="fa fa-save"></i>&nbsp;Save Exam Report</asp:LinkButton>
                                    <uc1:uc_sucess runat="server" ID="uc_sucess1" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <script>
            function calculatePassing(e)
            {
                var MMarks = parseInt($(e).parent('div').parent('td').prev('td').find('input').val());
                var PassingMarks = parseInt($(e).val());
                if (PassingMarks >= MMarks){
                    if (MMarks > 0) {
                        $(e).val(MMarks - 1);
                    }
                    else { $(e).val(0); }
                }
            }
            function CalculateObtained(e)
            {
                var MMarks = parseInt($(e).parent('div').parent('td').prev('td').text());
                var ObtainedMarks = parseInt($(e).val());
                if (ObtainedMarks >= MMarks) {
                    if (MMarks > 0) {
                        $(e).val(MMarks - 1);
                    }
                    else { $(e).val(0);}
                }
            }
        </script>
</asp:Content>
