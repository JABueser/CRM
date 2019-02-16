using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VMS.Startup))]
namespace VMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
