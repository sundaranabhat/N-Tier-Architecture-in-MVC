using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoMappinginMVC.Startup))]
namespace AutoMappinginMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
