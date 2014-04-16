using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Framework.Implementations;
using Framework.Interfaces;

namespace OnlineInsuranceAgency
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider(); //Inject Properties Into FilterAttributes section of MvcIntegration
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<GmailEmailService>().As<IEmailService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}