<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Header.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_Header" %>
<a class="logo"><span class="logo-mini">DB</span>
    <span class="logo-lg">DASHBOARD</span>
</a>

<!-- Header Navbar: style can be found in header.less -->
<nav class="navbar navbar-static-top">
    <!-- Sidebar toggle button-->
    <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
        <span class="sr-only">Toggle navigation</span>
    </a>
    <!-- Navbar Right Menu -->
    <div class="container-fluid">
        <div class="navbar-custom-menu">

            <ul class="nav navbar-nav input-group input-group-lg">
               <%-- <li class="dropdown" runat="server">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="true">
                        <i class="fa fa-globe"></i>
                        <span class="">Masters<b class="caret"></b></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li id="li1" runat="server">
                            <asp:HyperLink ID="masters" NavigateUrl="~/App/Admin/Masters.aspx" runat="server"><i class="fa fa-file"></i>Masters Management</asp:HyperLink></li>
                    </ul>
                </li>--%>

              


                <!-- User Account: style can be found in dropdown.less -->
                <li class="dropdown user user-menu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <%--<asp:Image ID="imgUser" ImageUrl="~/dist/img/balaji.jpg" alt="User Image" class="user-image" runat="server" />--%>
                        <asp:LoginView runat="server" ViewStateMode="Disabled">
                            <LoggedInTemplate>
                                Hello! 
                                <span class="hidden-xs">
                                    <asp:LoginName runat="server" CssClass="username" />
                                </span>

                                <%--   <asp:LoginStatus runat="server" OnLoggingOut="Unnamed_LoggingOut" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />
                                --%>
                            </LoggedInTemplate>
                        </asp:LoginView>

                        <%-- <span class="hidden-xs">Alexander Pierce</span>--%>
                    </a>
                    <ul class="dropdown-menu">
                        <!-- User image -->
                        <li class="user-header">
                            <%--  <asp:Image ID="Image1" ImageUrl="~/dist/img/balaji.jpg" alt="User Image" runat="server" />--%>

                            <p>
                                <asp:LoginName runat="server" CssClass="username" />
                                <small><%=DateTime.Now %></small>
                            </p>
                        </li>


                        <!-- Menu Body -->
                        <%-- <li class="user-body">
                        <div class="row">
                            <div class="col-xs-4 text-center">
                                <a href="#">Chan</a>
                            </div>
                            <div class="col-xs-4 text-center">
                                <a href="#">Sales</a>
                            </div>
                            <div class="col-xs-4 text-center">
                                <a href="#">Friends</a>
                            </div>
                        </div>
                        <!-- /.row -->
                    </li>--%>
                        <!-- Menu Footer-->
                        <li class="user-footer">
                            <div class="pull-left">
                                <asp:HyperLink ID="hlLinkProfile" NavigateUrl="~/Account/Profile.aspx" CssClass="btn btn-default btn-flat" runat="server">Profile</asp:HyperLink>

                            </div>
                            <div class="pull-right">

                                <asp:LoginStatus CssClass="btn btn-default btn-flat" runat="server" OnLoggingOut="Unnamed_LoggingOut" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />

                            </div>
                        </li>
                    </ul>
                </li>
                <!-- Control Sidebar Toggle Button -->
                <%--  <li>
                <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
            </li>--%>
            </ul>
        </div>
    </div>
</nav>
