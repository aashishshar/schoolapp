using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WEB_APP_SCHOOL_NET.Models;
using System.Configuration;
using WEB_APP_SCHOOL_NET.Common;
using System.Linq;

namespace WEB_APP_SCHOOL_NET.Account
{
    public partial class Login : Page
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _db = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}   



        }
        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //protected void Login_Click1(object sender, EventArgs e)
        //{
        // RegisterAsyncTask
        //}

        protected void Login_Click(object sender, EventArgs e)
        {

            //ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            var result = SignInManager.PasswordSignIn(UserName.Text.Trim(), Password.Text.Trim(), RememberMe.Checked, shouldLockout: false);
            var hashPassword = Crypto.HashPassword(Password.Text.Trim());
            //PasswordVerificationResult.Success
            //if (Crypto.VerifyHashedPassword("hashedPassword", "password") != PasswordVerificationResult.Failed)
            //{
            //    // password is correct 
            //}
            switch (result)
            {
                case SignInStatus.Success:
                    IdentityHelper.RedirectToReturnUrl("/App/Dashboard.aspx", Response);
                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    break;
                case SignInStatus.LockedOut:
                    Response.Redirect("/Account/Lockout");
                    break;
                case SignInStatus.RequiresVerification:
                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                    Request.QueryString["ReturnUrl"],
                                                    RememberMe.Checked),
                                      true);
                    break;
                case SignInStatus.Failure:
                default:
                    FailureText.Text = "Invalid login attempt";
                    //ErrorMessage.Visible = true;
                    break;
            }
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        //RedirectLogin(UserName.Text.Trim());
            //        //var user = UserManager.Find(UserName.Text.Trim(), Password.Text.Trim());
            //        //SignInManager.SignIn(user, RememberMe.Checked, true);
            //        //var singIn = SignInManager.CreateUserIdentity(user);

            //        //var userIdentity = (ClaimsIdentity)User.Identity;
            //        //var claims = userIdentity.Claims;
            //        //var roleClaimType = userIdentity.RoleClaimType;

            //        //var roles = claims.Where(c => c.Type == roleClaimType).ToList();
            //        var user = UserManager.FindByName(UserName.Text.Trim());
            //        var roles = UserManager.GetRoles(user.Id); FailureText.Text = "sucess.";
            //        if (roles.Count > 0)
            //        {
            //            //FailureText.Text = "sucess11.";
            //            System.Web.HttpContext.Current.Response.Redirect("~/Admin/Dashboard");
            //            //if (roles.FirstOrDefault().Contains(EnumConstants.RoleName.Admin.ToString()))
            //            //{
            //            //    System.Web.HttpContext.Current.Response.Redirect("~/Admin/Dashboard");
            //            //}
            //            //else if (roles.FirstOrDefault().Contains(EnumConstants.RoleName.TaxConsultant.ToString()) || roles.FirstOrDefault().Contains(EnumConstants.RoleName.User.ToString()))
            //            //{
            //            //    System.Web.HttpContext.Current.Response.Redirect("~/User/Dashboard");
            //            //}

            //        }
            //        else
            //        {


            //            //var userIdentityRefresh = (ClaimsIdentity)User.Identity;
            //            //var claimsRefresh = userIdentityRefresh.Claims;
            //            //var roleClaimTypeRefresh = userIdentityRefresh.RoleClaimType;
            //            //var rolesRefresh = claimsRefresh.Where(c => c.Type == roleClaimType).ToList();
            //            //if (roles.Count > 0)
            //            //{
            //            //    if (roles.FirstOrDefault().Value.Contains(EnumConstants.RoleName.Admin.ToString()))
            //            //    {
            //            //        System.Web.HttpContext.Current.Response.Redirect("~/Admin/Dashboard");
            //            //    }
            //            //    else if (roles.FirstOrDefault().Value.Contains(EnumConstants.RoleName.TaxConsultant.ToString()) || roles.FirstOrDefault().Value.Contains(EnumConstants.RoleName.User.ToString()))
            //            //    {
            //            //        System.Web.HttpContext.Current.Response.Redirect("~/User/Dashboard");
            //            //    }

            //            //}
            //            //else
            //            //{
            //            FailureText.Text = "Invalid login attempt.";
            //            // }
            //        }
            //        //	roles.FirstOrDefault().Value	"User"	string

            //        // System.Web.HttpContext.Current.Response.Redirect("~/Security.ashx");
            //        return;
            //    //case SignInStatus.LockedOut:
            //    //    return View("Lockout");
            //    //case SignInStatus.RequiresVerification:
            //    //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
            //    case SignInStatus.Failure:
            //        FailureText.Text = "Invalid login attempt.";
            //        return;
            //    default:
            //        FailureText.Text = "Invalid login attempt.";
            //        return;
            //}
        }

        private void RedirectLogin(string username)
        {
            LoginRedirectByRoleSection roleRedirectSection = (LoginRedirectByRoleSection)ConfigurationManager.GetSection("loginRedirectByRole");
            var user = UserManager.FindByName(username);
            var rolesForUser = UserManager.GetRoles(user.Id);
            foreach (RoleRedirect roleRedirect in roleRedirectSection.RoleRedirects)
            {
                if (rolesForUser.Contains(roleRedirect.Role))
                {
                    // Response.Redirect(roleRedirect.Url);
                }
            }
        }

        //private async Task<bool> IsValidUserName(string userName, string password)
        //{
        //    bool isValid = false;
        //    UserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    ApplicationUser user = await UserManager.FindAsync(userName.Trim(), password.Trim());
        //    if (user != null)
        //    {
        //        await SignInAsync(user, false);
        //        isValid = true;
        //    }
        //    else
        //    {
        //         StatusText.Text = "Invalid username or password.";
        //         LoginStatus.Visible = true;
        //    }
        //    return isValid;
        //}
        //private void SignIn(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent },user.GenerateUserIdentity();
        //}
        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.Current.GetOwinContext().Authentication;
        //    }
        //}
    }

    public class LoginRedirectByRoleSection : ConfigurationSection
    {
        [ConfigurationProperty("roleRedirects")]
        public RoleRedirectCollection RoleRedirects
        {
            get
            {
                return (RoleRedirectCollection)this["roleRedirects"];
            }
            set
            {
                this["roleRedirects"] = value;
            }
        }
    }

    public class RoleRedirectCollection : ConfigurationElementCollection
    {
        public RoleRedirect this[int index]
        {
            get
            {
                return (RoleRedirect)BaseGet(index);
            }
        }

        public RoleRedirect this[object key]
        {
            get
            {
                return (RoleRedirect)BaseGet(key);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RoleRedirect();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RoleRedirect)element).Role;
        }
    }

    public class RoleRedirect : ConfigurationElement
    {
        [ConfigurationProperty("role", IsRequired = true)]
        public string Role
        {
            get
            {
                return (string)this["role"];
            }
            set
            {
                this["role"] = value;
            }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }
    }
    //public partial class Login : Page
    //{
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        //RegisterHyperLink.NavigateUrl = "Register";
    //        //// Enable this once you have account confirmation enabled for password reset functionality
    //        ////ForgotPasswordHyperLink.NavigateUrl = "Forgot";
    //        //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
    //        //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    //        //if (!String.IsNullOrEmpty(returnUrl))
    //        //{
    //        //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
    //        //}
    //    }

    //    protected void LogIn(object sender, EventArgs e)
    //    {
    //        if (IsValid)
    //        {
    //            // Validate the user password
    //            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

    //            // This doen't count login failures towards account lockout
    //            // To enable password failures to trigger lockout, change to shouldLockout: true
    //            var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

    //            switch (result)
    //            {
    //                case SignInStatus.Success:
    //                    IdentityHelper.RedirectToReturnUrl("/App/Dashboard.aspx", Response);
    //                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
    //                    break;
    //                case SignInStatus.LockedOut:
    //                    Response.Redirect("/Account/Lockout");
    //                    break;
    //                case SignInStatus.RequiresVerification:
    //                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
    //                                                    Request.QueryString["ReturnUrl"],
    //                                                    RememberMe.Checked),
    //                                      true);
    //                    break;
    //                case SignInStatus.Failure:
    //                default:
    //                    FailureText.Text = "Invalid login attempt";
    //                    ErrorMessage.Visible = true;
    //                    break;
    //            }
    //        }
    //    }
    //}
}