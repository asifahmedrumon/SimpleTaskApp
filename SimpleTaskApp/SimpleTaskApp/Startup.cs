using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleTaskApp.Startup))]
namespace SimpleTaskApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
