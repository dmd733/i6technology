using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineInsuranceAgency.Startup))]
namespace OnlineInsuranceAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
