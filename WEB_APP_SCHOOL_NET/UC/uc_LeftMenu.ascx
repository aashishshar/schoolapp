<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_LeftMenu.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_LeftMenu" %>
<div class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->

    <div class="sidebar">
        <!-- Sidebar user panel -->
        <%-- <div class="user-panel">
            <div class="pull-left image">
                <asp:Image ID="uc_Header_Image1" ImageUrl="~/dist/img/balaji.jpg" runat="server" />
            </div>
            <div class="pull-left info">
                <asp:LoginView runat="server" ViewStateMode="Disabled">
                    <LoggedInTemplate>
                       
                        <span>
                            <asp:LoginName runat="server" CssClass="username" />
                        </span>
                        <a href="#">
                    </LoggedInTemplate>
                </asp:LoginView>
                <div style="font-size: 11px; margin-top: 10px;"><a href="#"><i class="fa fa-circle text-green"></i>&nbsp;&nbsp;Online</a></div>
            </div>
        </div>--%>
        <!-- search form -->
        <%--<div class="sidebar-form">
            <div class="input-group">
                <input type="text" name="q" class="form-control" placeholder="Search...">
                <span class="input-group-btn">
                    <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                        <i class="fa fa-search"></i>
                    </button>
                </span>
            </div>
        </div>--%>
        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class="sidebar-menu">

            <li class="header">
                <i class="fa fa-home"></i><span>MAIN NAVIGATION</span>
            </li>


            <li id="liMaster" runat="server" visible="false" class="treeview active">
                <asp:HyperLink ID="hl" NavigateUrl="#" runat="server">
               
                    <i class="fa fa-users"></i><span>MASTERS</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </asp:HyperLink>

                <ul class=" active treeview-menu">
                    <%--<li>
                        <asp:HyperLink NavigateUrl="~/Account/Register.aspx" ID="HyperLink1" runat="server"><i class="fa fa-circle-o text-aqua"></i>Create Users</asp:HyperLink></li>--%>

                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Admin/Organization.aspx" ID="hlB2BInvoice" runat="server"><i class="fa fa-circle-o text-aqua"></i>Organization</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Admin/Permission.aspx" runat="server"><i class="fa fa-circle-o text-aqua"></i>Permission/Users</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Admin/Masters.aspx" runat="server"><i class="fa fa-circle-o text-aqua"></i>Masters</asp:HyperLink></li>
                    <%-- <li>
                        <asp:HyperLink NavigateUrl="~/App/Admin/Occupation.aspx" runat="server"><i class="fa fa-circle-o text-aqua"></i>Occupation</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Admin/CasteManagement.aspx" runat="server"><i class="fa fa-circle-o text-aqua"></i>Caste Management</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Admin/ReligionManagement.aspx" runat="server"><i class="fa fa-circle-o text-aqua"></i>Religion Management</asp:HyperLink></li>

                    --%>
                </ul>

            </li>
            <li class="treeview active">
                <asp:HyperLink NavigateUrl="#" runat="server">
                    <i class="fa fa-user"></i><span>STUDENT</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </asp:HyperLink>

                <ul class=" active treeview-menu">
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/ClassManagement.aspx" ID="HyperLink2" runat="server"><i class="fa fa-circle-o text-green"></i>CLASS MASTERS</asp:HyperLink></li>


                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/Student.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>ADD STUDENT</asp:HyperLink></li>



                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/StudentManagement.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>STUDENT DETAILS</asp:HyperLink></li>
                     <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/ManageStudent.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>MANAGE STUDENT</asp:HyperLink></li>
                   
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/StudentAttendance.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>ATTANDENCE</asp:HyperLink></li>


                </ul>
            </li>
            <li class="treeview active">
                <asp:HyperLink NavigateUrl="#" runat="server">
                    <i class="fa fa-credit-card"></i><span>FEES MANAGEMENT</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </asp:HyperLink>

                <ul class=" active treeview-menu">
                    <li>
                        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/App/Student/FeesDetail.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>MANAGE FEE</asp:HyperLink></li>
                    <%-- <li>
                        <asp:HyperLink ID="HyperLink4" runat="server"><i class="fa fa-circle-o text-green"></i>Fee Structure</asp:HyperLink></li>--%>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/StudentFee.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>STUDENT FEE</asp:HyperLink></li>

                    <%--  <li>
                        <asp:HyperLink ID="HyperLink6" runat="server"><i class="fa fa-circle-o text-green"></i>Fee Collection</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink7" runat="server"><i class="fa fa-circle-o text-green"></i>Fee Dues</asp:HyperLink></li>--%>
                </ul>
            </li>
              <li class="treeview active">
                <asp:HyperLink NavigateUrl="#" runat="server">
                    <i class="fa fa-bus"></i><span>TRANSPORTATION</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </asp:HyperLink>

                <ul class=" active treeview-menu">
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/TransportSetting.aspx" ID="HyperLink5" runat="server"><i class="fa fa-circle-o text-green"></i>TRANSPORT SETTING</asp:HyperLink></li>


                   
                </ul>
            </li>
            <li class="treeview active">
                <asp:HyperLink NavigateUrl="#" runat="server">
                    <i class="fa fa-file-text"></i><span>EXAM</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </asp:HyperLink>

                <ul class=" active treeview-menu">
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Exam/ExamManagement.aspx" ID="HyperLink4" runat="server"><i class="fa fa-circle-o text-green"></i>EXAM MANAGEMENT</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Exam/ClassExamReport.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>CLASS EXAM REPORT</asp:HyperLink></li>
                <li>
                        <asp:HyperLink NavigateUrl="~/App/Exam/Result.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>RESULT DOWNLOAD</asp:HyperLink></li>
               
                </ul>
            </li>

            <li class="treeview active">
                <asp:HyperLink NavigateUrl="#" runat="server">
                    <i class="fa fa-file-text"></i><span>REPORT</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </asp:HyperLink>

                <ul class=" active treeview-menu">
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Report/StudentReport.aspx" ID="HyperLink1" runat="server"><i class="fa fa-circle-o text-green"></i>STUDENT REPORT</asp:HyperLink></li>


                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Report/ExamReport.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>EXAM REPORT</asp:HyperLink></li>
                    <%--
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/StudentFee.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>STUDENT FEE</asp:HyperLink></li>


                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/StudentManagement.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>NEW STUDENT</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/App/Student/StudentAttendance.aspx" runat="server"><i class="fa fa-circle-o text-green"></i>ATTANDENCE</asp:HyperLink></li>
                    --%>
                </ul>
            </li>
    </div>
    <!-- /.sidebar -->
</div>
