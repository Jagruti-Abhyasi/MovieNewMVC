using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieNewMVC.Startup))]
namespace MovieNewMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
