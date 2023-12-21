using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Domain.Entities.Auth;

namespace UserManagementSystem.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<User>();

            //create a role
            builder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });

            //create a user
            builder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "usermanagementadmin@gmail.com",
                   NormalizedUserName = "USERMANAGEMENTADMIN@GMAIL.COM",
                   PasswordHash = hasher.HashPassword(null, "Pa$$w0rd1"),
                   FirstName = "Admin",
                   LastName = "Admin",
                   Email = "usermanagementadmin@gmail.com",
                   NormalizedEmail = "USERMANAGEMENTADMIN@GMAIL.COM"

               }
               );

            //asign admin role to the user we created
            builder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = 1,
                UserId = 1

            });

            //create a role
            builder.Entity<Role>().HasData(new Role { Id = 2, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });


            //create a user
            builder.Entity<User>().HasData(
               new User
               {
                   Id = 2,
                   UserName = "usermanagementsuperadmin@gmail.com",
                   NormalizedUserName = "USERMANAGEMENTSUPERADMIN@GMAIL.COM",
                   PasswordHash = hasher.HashPassword(null, "Pa$$w0rd2"),
                   FirstName = "SuperAdmin",
                   LastName = "SuperAdmin",
                   Email = "usermanagementsuperadmin@gmail.com",
                   NormalizedEmail = "USERMANAGEMENTSUPERADMIN@GMAIL.COM"

               }
               );

            //asign admin role to the user we created
            builder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = 2,
                UserId = 2
            });
        }
    }
}
