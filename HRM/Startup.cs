using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRM.Startup))]
namespace HRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {                                                                  
            ConfigureAuth(app);
        }
    }
}
