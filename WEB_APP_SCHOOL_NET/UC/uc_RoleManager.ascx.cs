using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public partial class uc_RoleManager : System.Web.UI.UserControl
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetRoles();
            }
        }

       


        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));

            // Roles.CreateRole(txtRoleCreate.Text.Trim());
            var role = new ApplicationRole(txtRoleCreate.Text.Trim());//, txtRoleCreate.Text.Trim() + " Role");       
          
            if (RoleManager.RoleExists(txtRoleCreate.Text.Trim()))
            {
                uc_sucess.SuccessMessage = "Role exist.";
            }
            else
            {
                IdentityResult ir = RoleManager.Create(new IdentityRole(txtRoleCreate.Text.Trim()));
                uc_sucess.SuccessMessage = "Role created.";
                GetRoles();
            }


            txtRoleCreate.Text = string.Empty;
            
           
            uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);

        }
        public void GetRoles()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
            var roles = RoleManager.Roles;// Roles.GetAllRoles().AsQueryable();
            lvRoles.DataSource = roles.ToList();
            lvRoles.DataBind();
        }



        protected void RemoveRoles(object sender, EventArgs e)
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
            LinkButton btnDelete = (LinkButton)sender;
            string roleName = btnDelete.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(roleName))
            {
                var roleStore = new RoleStore<IdentityRole>();
                var manager = new RoleManager<IdentityRole>(roleStore);
                // var role = manager.Delete(new IdentityRole(roleName));

                var role = RoleManager.Roles.SingleOrDefault(r => r.Name == roleName);
                // ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
                RoleManager.Delete(role);
                // _db.DeleteRole(_db, userManager, role.Id);

                uc_sucess.SuccessMessage = "Role deleted.";
                GetRoles();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }
    }
}