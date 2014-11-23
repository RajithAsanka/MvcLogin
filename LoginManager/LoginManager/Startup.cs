using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginManager.Startup))]
namespace LoginManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
