using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SFAirBUdc.GUI.Startup))]
namespace SFAirBUdc.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
