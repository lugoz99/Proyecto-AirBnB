using Autofac;
using Autofac.Integration.Mvc;
using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Implementation.Implementation.Parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Implementation.Implementation.Parameters;
using SFAirBUdc.Repository.Implementatios.Implementation.Parameters;
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

            // Registro de city
            builder.RegisterType<CityImplementationApplication>()
                .As<ICityApplication>().InstancePerRequest();
            builder.RegisterType<CityImplementationRepository>().As<ICityRepository>().InstancePerRequest();

            // Registrar CountryImplementationApplication como ICountryApplication (si es necesario)
            builder.RegisterType<CountryImplementationApplication>()
                .As<ICountryApplication>().InstancePerRequest();
            builder.RegisterType<CountryImplementationRepository>().As<ICountryRepository>().InstancePerRequest();

            // Registro Customer

            builder.RegisterType<CustomerImplementationApplication>()
                .As<ICustomerApplication>().InstancePerRequest();
            builder.RegisterType<CustomerImplementationRepository>().As<ICustomerRepository>().InstancePerRequest();
            // Registro Property

            builder.RegisterType<PropertyImplementationApplication>()
                .As<IPropertyApplication>().InstancePerRequest();   
            builder.RegisterType<PropertyImplementationRepository>().As<IPropertyRepository>().InstancePerRequest();


            // Registro PropertyOwner

            builder.RegisterType<PropertyOwnerImplementationApplication>()
                .As<IPropertyOwnerApplication>().InstancePerRequest();

            
            builder.RegisterType<PropertyOwnerImplementationRepository>().As<IPropertyOwnerRepository>().InstancePerRequest();



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