using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ER_Smms.Models;

namespace ER_Smms.Data
{
    public class AppDbContext : IdentityDbContext<IdentityAppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<Harbour> Harbours { get; set; }
        public DbSet<Pier> Piers { get; set; }
        public DbSet<Boatslip> Boatslips { get; set; }



        //public DbSet<PersonLanguage> PersonLanguages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // You can customize the ASP.NET Identity model under this section.
            // For example, you can rename the ASP.NET Identity table names and more.



            // -------------- How to start Id autoincrement other then 1
            //    class MyContext : DbContext
            //{
            //    public DbSet<Order> Orders { get; set; }

            //    protected override void OnModelCreating(ModelBuilder modelBuilder)
            //    {
            //        modelBuilder.HasSequence<int>("Order_seq", schema: "dbo")
            //            .StartsAt(1000)
            //            .IncrementsBy(1);

            //        modelBuilder.Entity<Order>()
            //            .Property(o => o.OrderNo)
            //            .HasDefaultValueSql("NEXT VALUE FOR dbo.Order_seq");
            //    }
            //}

            //public class Order
            //{
            //    public int OrderId { get; set; }
            //    public int OrderNo { get; set; }
            //    public string Url { get; set; }
            //}
            // -------------------- End of code example for starting Id on other then 1 --------





            // ------- Setting up all the tables and relationships ----------

            // Setting Primarykeys, instead of [Key] in code. One place to handle all of it /ER
            modelBuilder.Entity<Person>()
                    .HasKey(mb => mb.PersonId);
            //.HasName("PrimaryKey_PersonId"); // for reference that i CAN change the name /ER

            modelBuilder.Entity<City>()
                .HasKey(mb => mb.CityId);

            modelBuilder.Entity<Country>()
                .HasKey(mb => mb.CountryId);

            modelBuilder.Entity<Language>()
                .HasKey(mb => mb.LanguageId);


            // Setting up One-to-Many
            modelBuilder.Entity<Person>()
                 .HasOne(mbo => mbo.City);

            modelBuilder.Entity<City>()
                 .HasMany(mbm => mbm.People);


// ********************* Harbour stuff ******************************

            // Primary keys for harbour and pier
            modelBuilder.Entity<Harbour>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<Pier>()
                .HasKey(mb => mb.Id);


            // Harbour-Pier One-to-Many

            modelBuilder.Entity<Harbour>()
                 .HasMany(hm => hm.Piers)
                 .WithOne(wo => wo.Harbour)
                 .OnDelete(DeleteBehavior.SetNull);




            // ********************* END - Harbour stuff ******************************


            modelBuilder.Entity<City>()
                .HasOne(mbo => mbo.Country);

            modelBuilder.Entity<Country>()
                .HasMany(mbm => mbm.Cities);


            modelBuilder.Entity<Person>()
                 .HasMany(p => p.Languages);

            modelBuilder.Entity<Language>()
                 .HasMany(la => la.People);


            // Setting up the join-table for the mutual many-to-many bind/relationship
            modelBuilder.Entity<PersonLanguage>()  // EF Core 3.x specific. Join table /ER
                .HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguage>() // One Person to Many Languages
                .HasOne(ec => ec.Person)
                .WithMany(e => e.PersonLanguages)
                .HasForeignKey(ec => ec.PersonId);

            modelBuilder.Entity<PersonLanguage>()  // One Language to Many People
                .HasOne(ec => ec.Language)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(ec => ec.LanguageId);

            // ----------------- End tables & relations ---------------------------------




            // --- Seeding with country, city, languages, person -------------

            //modelBuilder.Entity<Country>().HasData(
            //    new Country { CountryId = 1, CountryName = "Sweden" },
            //    new Country { CountryId = 2, CountryName = "Norway" },
            //    new Country { CountryId = 3, CountryName = "Finland" },
            //    new Country { CountryId = 4, CountryName = "Netherlands" },
            //    new Country { CountryId = 5, CountryName = "Blondland" }
            //);

            //modelBuilder.Entity<City>().HasData(
            //    new City { CityId = 1, CityName = "Skövde", CountryId = 1 },
            //    new City { CityId = 2, CityName = "Trondheim", CountryId = 2 },
            //    new City { CityId = 3, CityName = "Kelontekemä", CountryId = 3 },
            //    new City { CityId = 4, CityName = "Eindhoven", CountryId = 4 },
            //    new City { CityId = 5, CityName = "Tiahölm", CountryId = 5 }
            //);

            //modelBuilder.Entity<Language>().HasData(
            //    new Language { LanguageId = 1, LanguageName = "Swedish" },
            //    new Language { LanguageId = 2, LanguageName = "Norwegian" },
            //    new Language { LanguageId = 3, LanguageName = "Finnish" },
            //    new Language { LanguageId = 4, LanguageName = "Dutch" },
            //    new Language { LanguageId = 5, LanguageName = "English" }
            //);


            //modelBuilder.Entity<Person>().HasData(
            //    new Person { PersonId = 1, PersonName = "Eric Rönnhult", PersonPhoneNumber = "0733 323382", CityId = 1 },
            //    new Person { PersonId = 2, PersonName = "Morten Grefte Greft", PersonPhoneNumber = "0735464", CityId = 2 },
            //    new Person { PersonId = 3, PersonName = "Pekka Heino", PersonPhoneNumber = "045654", CityId = 3 },
            //    new Person { PersonId = 4, PersonName = "Frans Veerport", PersonPhoneNumber = "0486548", CityId = 4 },
            //    new Person { PersonId = 5, PersonName = "James May", PersonPhoneNumber = "4587687678", CityId = 5 }
            //);


            //modelBuilder.Entity<PersonLanguage>().HasData(
            //    new PersonLanguage { PersonId = 1, LanguageId = 1 },
            //    new PersonLanguage { PersonId = 1, LanguageId = 5 },
            //    new PersonLanguage { PersonId = 2, LanguageId = 2 },
            //    new PersonLanguage { PersonId = 2, LanguageId = 5 },
            //    new PersonLanguage { PersonId = 3, LanguageId = 3 },
            //    new PersonLanguage { PersonId = 3, LanguageId = 5 },
            //    new PersonLanguage { PersonId = 4, LanguageId = 4 },
            //    new PersonLanguage { PersonId = 4, LanguageId = 5 },
            //    new PersonLanguage { PersonId = 5, LanguageId = 5 }
            //);
            //---------------------------------------



            // ------****** IDENTITY ******-------------------

            // --- Creating Roles

            IdentityRole roleSuperAdmin = new IdentityRole()
            {
                Id = "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022",
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            };

            IdentityRole roleAdmin = new IdentityRole()
            {
                Id = "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            IdentityRole roleUser = new IdentityRole()
            {
                Id = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                Name = "User",
                NormalizedName = "USER"
            };

            modelBuilder.Entity<IdentityRole>().HasData(
              roleSuperAdmin, roleAdmin, roleUser);



            // ---------  Seeding Users  ----------

            //hash the password before storing in db
            var hashit = new PasswordHasher<IdentityAppUser>();

            IdentityAppUser superAdminUser = new IdentityAppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superadmin@email.com",
                NormalizedUserName = "SUPERADMIN@EMAIL.COM",
                Email = "superadmin@email.com",
                NormalizedEmail = "superadmin@email.com".ToUpper(),
                PasswordHash = hashit.HashPassword(null, "SuperAdmin77")
            };


            IdentityAppUser adminUser = new IdentityAppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@email.com",
                NormalizedUserName = "ADMIN@EMAIL.COM",
                Email = "admin@email.com",
                NormalizedEmail = "admin@email.com".ToUpper(),
                PasswordHash = hashit.HashPassword(null, "Admin77")
            };

            IdentityAppUser customer1 = new IdentityAppUser
            {
                Id = Guid.NewGuid().ToString(), // primary key
                UserName = "customer1@email.com",
                Email = "customer1@email.com",
                NormalizedEmail = "customer1@email.com".ToUpper(),
                NormalizedUserName = "CUSTOMER1",
                PasswordHash = hashit.HashPassword(null, "Customer1")
            };

            //IdentityAppUser customer2 = new IdentityAppUser
            //{
            //    Id = Guid.NewGuid().ToString(), // primary key
            //    UserName = "customer2@email.com",
            //    NormalizedUserName = "CUSTOMER2",
            //    Email = "customer2@email.com",
            //    NormalizedEmail = "customer2@email.com".ToUpper(),
            //    PasswordHash = hashit.HashPassword(null, "customer2")
            //};
            //IdentityAppUser customer3 = new IdentityAppUser
            //{
            //    Id = Guid.NewGuid().ToString(),// primary key
            //    UserName = "customer3@email.com",
            //    Email = "customer3@email.com",
            //    NormalizedEmail = "customer3@email.com".ToUpper(),
            //    NormalizedUserName = "CUSTOMER3",
            //    PasswordHash = hashit.HashPassword(null, "customer3")
            //};

            modelBuilder.Entity<IdentityAppUser>().HasData(
                superAdminUser, adminUser, customer1 /*, customer2, customer3*/
            );

            //   ----------- Setting roles to users ---------------


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    RoleId = roleSuperAdmin.Id,
                    UserId = superAdminUser.Id
                }
               ,
               new IdentityUserRole<string>
               {
                   RoleId = roleAdmin.Id,
                   UserId = adminUser.Id
               }
               ,
           //,
           //    new IdentityUserRole<string>
           //    {
           //        RoleId = roleUser.Id,
           //        UserId = adminUser.Id
           //    }
           //,
               new IdentityUserRole<string>
               {
                   RoleId = roleUser.Id,
                   UserId = customer1.Id
               }
           //,
           //    new IdentityUserRole<string>
           //    {
           //        RoleId = roleUser.Id,
           //        UserId = customer2.Id
           //    }

           //,
           //    new IdentityUserRole<string>
           //    {
           //        RoleId = roleUser.Id,
           //        UserId = customer3.Id
           //    }
           );


            // -----------------------------------------
        }




    }
}
