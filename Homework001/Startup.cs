using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework001.Startup))]
namespace Homework001
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
