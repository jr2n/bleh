using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RDFindAuto.Startup))]
namespace RDFindAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
