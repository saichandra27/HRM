using HRM.Data.DbContext;
using HRM.Data.Entities;
using HRM.Interface;
using HRM.Services;
using HRM.Services.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace HRM
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<ILog, Logger>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, HRMDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<HRMUser>, UserStore<HRMUser>>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IUserProfileService, UserProfileService>();
            container.RegisterType<ILeaveTypesService, LeaveTypesService>();
            container.RegisterType<IJobService, JobService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}