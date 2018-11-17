using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WEB_APP_SCHOOL_NET.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WEB_APP_SCHOOL_NET.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

       
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
                
        public int ORG_ID { get; set; }

        //public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole Role { get; set; }
       /// public bool IsSysAdmin { get { return this.Role.IsSysAdmin; } }

        public ApplicationUserRole()
            : base()
        { }

        //public bool IsPermissionInRole(string _permission)
        //{
        //    bool _retVal = false;
        //    try
        //    {
        //        _retVal = this.Role.IsPermissionInRole(_permission);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return _retVal;
        //}

       // public bool IsSysAdmin => this.Role.IsSysAdmin;TODO:NEED to un comment
    }
    // Must be expressed in terms of our custom UserRole:
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole() : base()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        //public ApplicationRole()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }
        //public ApplicationRole(string name, string description)
        //    : base(name)
        //{
        //    this.Description = description;
        //}

        public virtual string Description { get; set; }

        // Add any custom Role properties/code here

        public bool IsSysAdmin { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    if (modelBuilder == null)
        //    {
        //        throw new ArgumentNullException("ModelBuilder is NULL");
        //    }

        //    base.OnModelCreating(modelBuilder);

        //    //Defining the keys and relations
        //    modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        //    modelBuilder.Entity<ApplicationRole>().HasKey<string>(r => r.Id).ToTable("AspNetRoles");
        //    modelBuilder.Entity<ApplicationUser>().HasMany<ApplicationUserRole>((ApplicationUser u) => u.UserRoles);
        //    modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

        //    // Map Users to Groups:
        //    modelBuilder.Entity<ApplicationGroup>()
        //        .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
        //        .WithRequired()
        //        .HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
        //    modelBuilder.Entity<ApplicationUserGroup>()
        //        .HasKey((ApplicationUserGroup r) =>
        //            new
        //            {
        //                ApplicationUserId = r.ApplicationUserId,
        //                ApplicationGroupId = r.ApplicationGroupId
        //            }).ToTable("ApplicationUserGroups");

        //    // Map Roles to Groups:
        //    modelBuilder.Entity<ApplicationGroup>()
        //        .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
        //        .WithRequired()
        //        .HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
        //    modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
        //        new
        //        {
        //            ApplicationRoleId = gr.ApplicationRoleId,
        //            ApplicationGroupId = gr.ApplicationGroupId
        //        }).ToTable("ApplicationGroupRoles");
        //}
        public virtual DbSet<ApplicationGroup> ApplicationGroupDTO { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class ApplicationRoleStore
 : RoleStore<ApplicationRole, string, ApplicationUserRole>,
 IQueryableRoleStore<ApplicationRole, string>,
 IRoleStore<ApplicationRole, string>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }

}

#region Helpers
namespace WEB_APP_SCHOOL_NET
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
