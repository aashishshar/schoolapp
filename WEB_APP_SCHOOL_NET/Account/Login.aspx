<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB_APP_SCHOOL_NET.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GST Login | Log in</title>
    <meta charset="utf-8" />

    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE"/>
    <meta http-equiv="PRAGMA" content="NO-CACHE"/>
    <meta name="GOOGLEBOT" content="NOARCHIVE"/>
    <meta name="ROBOTS" content="INDEX,NOFOLLOW"/>


    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="<%= ResolveUrl("~/Content/bootstrap/css/bootstrap.min.css") %>" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->

    <link rel="stylesheet" href="<%= ResolveUrl("~/Content/dist/css/AdminLTE.min.css") %>" />
    <!-- iCheck -->

    <link rel="stylesheet" href="<%= ResolveUrl("~/Content/plugins/iCheck/square/blue.css") %>" />

    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE">

    <meta http-equiv="PRAGMA" content="NO-CACHE"/>
    <meta name="GOOGLEBOT" content="NOARCHIVE"/>
    <meta name="ROBOTS" content="INDEX,NOFOLLOW"/>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <a><b>SCHOOL </b>c-Panel</a>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Sign in to start your session</p>


                <p class="text-red">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <div class="form-group has-feedback">
                    <%-- <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>--%>
                    <asp:TextBox class="form-control" runat="server" placeholder="User name" ID="UserName" />
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="help-block" Display="Dynamic" ErrorMessage="The user name field is required." />
                </div>
                <div class="form-group has-feedback">
                    <%--<asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>--%>
                    <asp:TextBox class="form-control" runat="server" placeholder="Password" ID="Password" TextMode="Password" />
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    <%--CssClass="field-validation-error"--%>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="help-block" ErrorMessage="The password field is required." Display="Dynamic" />
                </div>
                <div class="row">
                    <%--<div class="col-xs-8">
                       <div class="checkbox icheck">
                           <label class="">
                               <div class="icheckbox_square-blue" aria-checked="false" aria-disabled="false" style="position: relative;">
                                    <asp:CheckBox runat="server" ID="" /> Remember Me
                                   <ins class="iCheck-helper" style="position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;"></ins>
                              </div>
                               </label>
                                <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                            
                      </div>
                    </div>--%>
                    <!-- /.col -->
                    <div class="col-xs-8">
                        <asp:CheckBox ID="RememberMe" runat="server" />
                        <strong>Remember Me</strong>
                    </div>

                    <div class="col-xs-4">
                        <asp:Button class="btn btn-primary btn-block btn-flat" runat="server" CommandName="Login" Text="Log in" OnClick="Login_Click" />
                    </div>

                    <!-- /.col -->
                </div>

                <%-- <div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have an account.
                </p>
            </div>
            <a href="#">I forgot my password</a><br>
            <a href="register.html" class="text-center">Register a new membership</a>--%>
            </div>
        </div>
    </form>
    <!-- jQuery 2.2.3 -->
    <script src="../Content/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="../Content/bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="../Content/plugins/iCheck/icheck.min.js"></script>
    <script>
        //$(function () {
        //    $('input').iCheck({
        //        checkboxClass: 'icheckbox_square-blue',
        //        radioClass: 'iradio_square-blue',
        //        increaseArea: '20%' // optional
        //    });
        //});

        function extendedValidatorUpdateDisplay(obj) {
            // Appelle la méthode originale
            if (typeof originalValidatorUpdateDisplay === "function") {
                originalValidatorUpdateDisplay(obj);
            }
            // Récupère l'état du control (valide ou invalide) 
            // et ajoute ou enlève la classe has-error
            var control = document.getElementById(obj.controltovalidate);
            if (control) {
                var isValid = true;
                for (var i = 0; i < control.Validators.length; i += 1) {
                    if (!control.Validators[i].isvalid) {
                        isValid = false;
                        break;
                    }
                }
                if (isValid) {
                    $(control).closest(".form-group").removeClass("has-error");
                } else {
                    $(control).closest(".form-group").addClass("has-error");
                }
            }
        }
        // Remplace la méthode ValidatorUpdateDisplay
        var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
        window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;
    </script>
</body>
</html>
<%--<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                          
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                    
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>--%>
