using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Security.Principal;
//using System.Web.Providers.Entities;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

using Microsoft.AspNet.Identity.EntityFramework;
using WEB_APP_SCHOOL_NET.Models;

namespace WEB_APP_SCHOOL_NET.Account
{
    public partial class uc_ChangePassword : System.Web.UI.UserControl
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Web.UI.ScriptManager sm = new System.Web.UI.ScriptManager.GetCurrent(this.Page); 
        }
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private ApplicationUserManager _userManager;
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

        protected void  btnResetPwd_Click(object sender, EventArgs e)
        {
            var result = UserManager.ChangePassword(HttpContext.Current.User.Identity.GetUserId(), txtOldPwd.Text.Trim(), txtNewPwd.Text.Trim());
           // IdentityResult result = await UserManager.ChangePasswordAsync(HttpContext.Current.User.Identity.GetUserId(), txtOldPwd.Text.Trim(), txtNewPwd.Text.Trim());
            if (result.Succeeded)
            {
               uc_sucess.SuccessMessage = "Password successfully changed.";
               uc_sucess.Visible = !String.IsNullOrEmpty(SuccessMessage);
                //var user = await UserManager.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId());
                //await SignInAsync(user, isPersistent: false);
               // return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            else
            {
               uc_sucess.SuccessMessage = "Their is some error in your password.";
                uc_sucess.Visible = !String.IsNullOrEmpty(SuccessMessage);
            }
        }

        //private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        //}
        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.Current.GetOwinContext().Authentication;
        //    }
        //}
    }
}