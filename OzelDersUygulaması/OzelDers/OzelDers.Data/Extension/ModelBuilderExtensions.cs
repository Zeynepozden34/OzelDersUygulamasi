using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelDers.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Extension
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region RolBilgileri
            List<Role> roles = new List<Role>
            {
                new Role
                {
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new Role
                {
                    Name="User",
                    NormalizedName="USER"
                },
                new Role
                {
                    Name="Teacher",
                    NormalizedName="TEACHER"
                },
                new Role
                {
                    Name="Student",
                    NormalizedName="STUDENT"
                }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region KullanıcıBilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Deniz",
                    LastName="Admin",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Gender="Kadın",
                    Email="admin@gmail.com",
                    NormalizedEmail="ADMIN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="5555555555",
                    Location="İstanbul"
                },
                new User
                {
                    FirstName="Kemal",
                    LastName="User",
                    UserName="user",
                    NormalizedUserName="USER",
                    Gender="Erkek",
                    Email="user@gmail.com",
                    NormalizedEmail="USER@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="4444444444",
                    Location="Ankara"
                },
                              new User
                {
                    FirstName="Defne",
                    LastName="Teacher",
                    UserName="teacher",
                    NormalizedUserName="TEACHER",
                    Gender="Kadın",
                    Email="teacher@gmail.com",
                    NormalizedEmail="TEACHER@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="4444444455",
                    Location="Ankara"
                },
                                            new User
                {
                    FirstName="Yusuf",
                    LastName="Student",
                    UserName="student",
                    NormalizedUserName="STUDENT",
                    Gender="Erkek",
                    Email="student@gmail.com",
                    NormalizedEmail="STUDENT@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="5554444444",
                    Location="Ankara"
                }

            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Parolaİşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            #endregion

            #region KullanıcıRolAtamaİşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles.First(r=>r.Name=="Admin").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles.First(r=>r.Name=="User").Id
                },
                     new IdentityUserRole<string>
                {
                    UserId=users[2].Id,
                    RoleId=roles.First(r=>r.Name=="User").Id
                },
                          new IdentityUserRole<string>
                {
                    UserId=users[3].Id,
                    RoleId=roles.First(r=>r.Name=="User").Id
                }

            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

           
        }
    }
}

