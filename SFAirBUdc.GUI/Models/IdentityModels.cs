﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SFAirBUdc.GUI.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que authenticationType debe coincidir con el valor definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizadas aquí
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SFAirBUdc.GUI.Models.Parameters.CityModel> CityModels { get; set; }

        public System.Data.Entity.DbSet<SFAirBUdc.GUI.Models.Parameters.CountryModel> CountryModels { get; set; }

        public System.Data.Entity.DbSet<SFAirBUdc.Repository.Implementatios.DataModel.Property> Properties { get; set; }

        public System.Data.Entity.DbSet<SFAirBUdc.Repository.Implementatios.DataModel.City> Cities { get; set; }

        public System.Data.Entity.DbSet<SFAirBUdc.Repository.Implementatios.DataModel.PropertyOwner> PropertyOwners { get; set; }

        public System.Data.Entity.DbSet<SFAirBUdc.GUI.Models.Parameters.CustomerModel> CustomerModels { get; set; }

        public System.Data.Entity.DbSet<SFAirBUdc.GUI.Models.Parameters.ReservationModel> ReservationModels { get; set; }
    }
}