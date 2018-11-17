using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_APP_SCHOOL_NET.Account
{
    public partial class uc_user_ResetPassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lkbResetPassword_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(txtUserId.Text.Trim());

            var result = Common.cls_Common.UserManager.RemovePassword(user.Id);// txtUserId.Text.Trim());

            var status = Common.cls_Common.UserManager.AddPassword(user.Id, txtPassword.Text.Trim());
        }
    }
}