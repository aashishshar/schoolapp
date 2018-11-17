using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.Models;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_CreateGroup : System.Web.UI.UserControl
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Groups();
            }
        }

        public void Groups()
        {
            var groupAll = this.GroupManager.Groups.OrderBy(o => o.Name);
            lvGroups.DataSource = groupAll.ToList();
            lvGroups.DataBind();          
        }

        private ApplicationGroupManager _groupManager;
        public ApplicationGroupManager GroupManager
        {
            get
            {
                return _groupManager ?? new ApplicationGroupManager();
            }
            private set
            {
                _groupManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        protected void btnCreateGroup_Click(object sender, EventArgs e)
        {
            CreateGroup(new ApplicationGroup(txtGroupName.Text.Trim(), txtDescription.Text.Trim()));
        }

        private void CreateGroup(ApplicationGroup applicationgroup, params string[] selectedRoles)
        {
            var result = this.GroupManager.CreateGroup(applicationgroup);
            if (result.Succeeded)
            {
                selectedRoles = selectedRoles ?? new string[] { };
                // Add the roles selected:
                // this.GroupManager.SetGroupRoles(applicationgroup.Id, selectedRoles);
                ClearControl();
                uc_sucess.SuccessMessage = "Group Created.";
                lvGroups.DataBind();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
            else
            {
                uc_sucess.SuccessMessage = result.Errors.FirstOrDefault(); ;
                lvGroups.DataBind();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }

        private void ClearControl()
        {
            txtGroupName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        protected void RemoveGroup(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string groupID = btnDelete.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(groupID))
            {
                var result = this.GroupManager.DeleteGroup(groupID);

                if (result.Succeeded)
                {
                    uc_sucess.SuccessMessage = "Group deleted.";
                    uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
                    lvGroups.DataBind();
                }
                else
                {
                    uc_sucess.SuccessMessage = result.Errors.FirstOrDefault();
                    uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
                }

            }
        }
    }
}