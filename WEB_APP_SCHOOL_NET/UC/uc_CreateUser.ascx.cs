using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.Models;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_CreateUser : System.Web.UI.UserControl
    {
        CommonBindControl commonBindControl = new CommonBindControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonBindControl.BindMasterData(ddlOrganization, EnumConstants.Masters.Organization);
                commonBindControl.BindMasterData(ddlRoleName, EnumConstants.Masters.Role);
                BindUsers();
            }
        }

        private void BindUsers()
        {
            lvUsers.DataSource = GetUsers();
            lvUsers.DataBind();
        }
        public List<ApplicationUser> GetUsers()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            //if (UserManager.IsInRole(userId, EnumConstants.RoleName.User.ToString()))
            //{
            //    return null;
            //}
            var accounts = cls_Common.UserManager.Users.ToList();
           // ddlUserList.DataSource = accounts;
           // ddlUserList.DataTextField = "OrganizationName";
           // ddlUserList.DataValueField = "ID";
          //  ddlUserList.DataBind();
           // ddlUserList.Items.Insert(0, new ListItem(" [ Select ] ", "0"));
            return accounts;
        }
        protected void lbSave_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser()
            {
                UserName = txtUserName.Text,
                Email = txtEmailID.Text,
                PhoneNumber = txtPhoneNo.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ORG_ID = Convert.ToInt16(ddlOrganization.SelectedValue.ToString())
            };
            IdentityResult result = manager.Create(user, txtPassword.Text);
            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, ddlRoleName.SelectedItem.Text);
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                // IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                uc_sucess.SuccessMessage = "User created.";

            }
            else
            {
                uc_sucess.ErrorMessage = result.Errors.FirstOrDefault();
            }
            uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
        }
    }
}