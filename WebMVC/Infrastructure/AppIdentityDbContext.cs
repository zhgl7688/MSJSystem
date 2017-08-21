using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebMVC.Models;

namespace WebMVC.Infrastructure
{
        public class AppIdentityDbContext : IdentityDbContext<AppUser>
        {
            public AppIdentityDbContext() : base("ConnectionString") { }
            static AppIdentityDbContext()
            {
                Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
            }
            public static AppIdentityDbContext Create()
            {
                return new AppIdentityDbContext();
            }
            public DbSet<AgentInput> AgentInputs { get; set; }
            public DbSet<BrandsInput> BrandsInputs { get; set; }
         }
        public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
        {
            protected override void Seed(AppIdentityDbContext context)
            {
                PerformInitialSetup(context);
                base.Seed(context);
            }

            public void PerformInitialSetup(AppIdentityDbContext context)
            {
            //初始化
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));
            string roleName = "Administrators";
            string userName = "Admin";
            string password = "Password2017";
            string email = "amin@MSJ.com";
            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }
            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
            }
        }
    public class MsjDbContext :  DbContext
    {
        public MsjDbContext() : base("ConnectionString") { }
      
        public DbSet<AgentInput> AgentInputs { get; set; }
        public DbSet<BrandsInput> BrandsInputs { get; set; }
    }
}