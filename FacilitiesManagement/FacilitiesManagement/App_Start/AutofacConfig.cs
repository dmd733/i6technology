using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Framework.Accounting.Implementations;
using Framework.Accounting.Interfaces;

namespace FacilitiesManagement
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider(); //Inject Properties Into FilterAttributes section of MvcIntegration
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<MockGeneralLedgerService>().As<IGeneralLedgerService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}