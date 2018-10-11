using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPAssignment1.Startup))]
namespace ASPAssignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
