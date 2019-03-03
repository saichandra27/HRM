using HRM.Data.DbContext;
using HRM.Data.Entities;
using HRM.Data.Entities.Module;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HRM.Data.DbConfiguration
{
    public class Configuration : DbMigrationsConfiguration<HRMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HRMDbContext context)
        {
            // SeedModuleNamesAndRoles(context);

            var userManager = new UserManager<HRMUser>(new UserStore<HRMUser>(context));

            if (!context.Users.Any(u => u.UserName.Equals("admin")))
            {
                var sysUser = new HRMUser()
                {
                    UserName = "System",
                    LockoutEnabled = false,
                    Email = "system@email.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                };
                userManager.Create(sysUser, "P@ssw0rd123");
                var systemuserid = context.Users.Where(usr => usr.Email.Equals(sysUser.Email)).FirstOrDefault().Id;
                userManager.AddToRole(systemuserid, "SystemAdmin");

                var Adminuser = new HRMUser()
                {
                    UserName = "Admin",
                    LockoutEnabled = true,
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                userManager.Create(Adminuser, "P@ssw0rd123");
                var adminuserid = context.Users.Where(usr => usr.Email.Equals(sysUser.Email)).FirstOrDefault().Id;
                userManager.AddToRole(adminuserid, "SystemAdmin");

                var supportUser = new HRMUser()
                {
                    UserName = "SupportUser",
                    LockoutEnabled = true,
                    Email = "support@email.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                };
                userManager.Create(supportUser, "P@ssw0rd123");
                var supportserid = context.Users.Where(usr => usr.Email.Equals(sysUser.Email)).FirstOrDefault().Id;
                userManager.AddToRole(supportserid, "Support");
            }
        }

        private void SeedModuleNamesAndRoles(HRMDbContext context)
        {
            var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));

            var SystemAdmin = new Role() { Name = "SystemAdmin", InUse = true };
            var Support = new Role() { Name = "Support", InUse = true };
            var LeavesManagementModule = new Module() { Name = "LeavesModule" };

            context.Module.Add(LeavesManagementModule);
            context.Role.Add(SystemAdmin);
            context.Role.Add(Support);

            context.ModuleRole.Add(new ModuleRole() { ModuleId = LeavesManagementModule.Id, RoleId = SystemAdmin.Id });
            context.ModuleRole.Add(new ModuleRole() { ModuleId = LeavesManagementModule.Id, RoleId = Support.Id });

            context.SaveChanges();
        }
    }
}
