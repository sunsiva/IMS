using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMS.UI.Startup))]
namespace IMS.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
