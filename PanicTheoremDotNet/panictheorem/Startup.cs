using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(panictheorem.Startup))]
namespace panictheorem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
