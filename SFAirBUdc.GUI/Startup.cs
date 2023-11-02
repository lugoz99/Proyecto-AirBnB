using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(SFAirBUdc.GUI.Startup))]
namespace SFAirBUdc.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Models.ApplicationDbContext>());
           
        }
    }
}
