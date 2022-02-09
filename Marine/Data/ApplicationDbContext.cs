using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marine.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        #region ctor


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }


        #endregion


        #region Seed Data

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RolesYSU(builder);

            base.OnModelCreating(builder);
        }


        private void RolesYSU(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var SuperAdmin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "hikdul.dev@gmail.com",
                NormalizedEmail = "hikdul.dev@gmail.com".ToUpper(),
                UserName = "hikdul.dev@gmail.com",
                NormalizedUserName = "hikdul.dev@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+51 931 084 717",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Alau123#")

            };

            var RoleSistAdmin = new IdentityRole()
            {

                Id = Guid.NewGuid().ToString(),
                Name = "AdmoSistema",
                NormalizedName = "AdmoSistema".ToUpperInvariant()

            };

            var RoleGtePlanta = new IdentityRole()
            {

                Id = Guid.NewGuid().ToString(),
                Name = "Gerenteplanta",
                NormalizedName = "Gerenteplanta".ToUpperInvariant()

            };

            var RoleSuperv = new IdentityRole()
            {

                Id = Guid.NewGuid().ToString(),
                Name = "Superv",
                NormalizedName = "Superv".ToUpperInvariant()

            };

            var RoleCliente = new IdentityRole()
            {

                Id = Guid.NewGuid().ToString(),
                Name = "Cliente",
                NormalizedName = "Cliente".ToUpperInvariant()

            };


            var hikdul = new IdentityUserRole<string>()
            {
                RoleId = RoleSistAdmin.Id,
                UserId = SuperAdmin.Id
            };

            builder.Entity<IdentityUser>().HasData(SuperAdmin);
            builder.Entity<IdentityRole>().HasData(RoleSistAdmin);
            builder.Entity<IdentityRole>().HasData(RoleGtePlanta);
            builder.Entity<IdentityRole>().HasData(RoleCliente);
            builder.Entity<IdentityRole>().HasData(RoleSuperv);

            builder.Entity<IdentityUserRole<string>>().HasData(hikdul);

        }

        #endregion


    }
}
