using Autofac;
using Autofac.Integration.Mvc;
using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Implementation.Implementation.Parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Implementation.Implementation.Parameters;
using System.Reflection;
using System.Web.Mvc;

namespace SFAirBUdc.GUI.App_Start
{
    public class IoCConfiguration
    {
        public static void RegistrarControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers
            (Assembly.GetExecutingAssembly());
        }

        public static void RegistrarRepos(ContainerBuilder builder)
        {


            builder.RegisterType<CityImplementationApplication>()
                .As<ICityApplication>().InstancePerRequest();
            // Registrar CountryImplementationApplication como ICountryApplication (si es necesario)
            builder.RegisterType<CountryImplementationApplication>()
                .As<ICountryApplication>().InstancePerRequest();
            builder.RegisterType<CityImplementationRepository>().As<ICityRepository>().InstancePerRequest();
            builder.RegisterType<CountryImplementationRepository>().As<ICountryRepository>().InstancePerRequest();

        }

        public static void RegitrarClases(ContainerBuilder builder)
        {
            
        }
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            RegistrarControllers(builder);
            RegistrarRepos(builder);
            RegitrarClases(builder);

            IContainer contenedor = builder.Build();

            DependencyResolver.SetResolver
                (new AutofacDependencyResolver(contenedor));
        }
    }
}