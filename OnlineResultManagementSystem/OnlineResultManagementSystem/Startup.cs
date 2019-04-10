using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineResultManagementSystem.Startup))]
namespace OnlineResultManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
