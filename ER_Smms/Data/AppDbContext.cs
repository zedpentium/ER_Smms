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

        public DbSet<Harbour> Harbours { get; set; }
        public DbSet<Pier> Piers { get; set; }
        public DbSet<Boatslip> Boatslips { get; set; }
        public DbSet<MooringType> MooringTypes { get; set; }
        public DbSet<BoatData> BoatDatas { get; set; }
        public DbSet<WinterstoreSpot> WinterstoreSpots { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceApplication> ServiceApplications { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }
        public DbSet<Applicant> Applicants { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // *********---- Reference Info below, incase i need it /Eric R ---**********

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


            // --- Change Column Order of a table. example
            //modelBuilder.Entity<Employee>(x =>
            //{
            //    x.Property(b => b.Id)
            //        .HasColumnOrder(0);

            //    x.Property(b => b.FirstName)
            //        .HasColumnOrder(1);

            //    x.Property(b => b.LastName)
            //        .HasColumnOrder(2);
            //});


            // -------------------- End of code example for starting Id on other then 1 --------





            // *************--- Setting up all the tables and relationships ---*************






            // ********************* Harbour stuff ******************************

            // ------- Primary keys
            modelBuilder.Entity<IdentityAppUser>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<Harbour>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<Pier>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<Boatslip>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<MooringType>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<BoatData>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<WinterstoreSpot>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<ServiceType>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<ServiceApplication>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<ServiceHistory>()
                .HasKey(mb => mb.Id);

            modelBuilder.Entity<Applicant>()
                .HasKey(mb => mb.Id);



            // ------- Setting/Defining Properties manually/extra

            // Boatslip
            modelBuilder.Entity<Boatslip>()
                .Property(a => a.Length).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Boatslip>()
                .Property(a => a.Width).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Boatslip>()
                .Property(a => a.Depth).HasColumnType("decimal(5,2)");



            // BoatData
            modelBuilder.Entity<BoatData>()
                .Property(a => a.Length).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<BoatData>()
                .Property(a => a.Width).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<BoatData>()
                .Property(a => a.Depth).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<BoatData>()
                .Property(a => a.Weight).HasColumnType("decimal(7,2)");

            modelBuilder.Entity<BoatData>()
                .Property(a => a.Height).HasColumnType("decimal(5,2)");


            // WinterstoreSpot
            modelBuilder.Entity<WinterstoreSpot>()
                .Property(a => a.Length).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<WinterstoreSpot>()
                .Property(a => a.Width).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<WinterstoreSpot>()
                .Property(a => a.Height).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<WinterstoreSpot>()
                .Property(a => a.SpotM2).HasColumnType("decimal(5,2)");


            // ServiceType
            modelBuilder.Entity<ServiceType>()
                .Property(a => a.Price).HasColumnType("decimal(8,2)");

            modelBuilder.Entity<ServiceType>()
                .Property(a => a.Length).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ServiceType>()
                .Property(a => a.Width).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ServiceType>()
                .Property(a => a.Depth).HasColumnType("decimal(5,2)");


            // Applicant
            modelBuilder.Entity<Applicant>()
                .Property(a => a.Length).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Applicant>()
                .Property(a => a.Width).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Applicant>()
                .Property(a => a.Depth).HasColumnType("decimal(5,2)");


            // ------- One-to-Many
            // ----- In the Database, all HasOne creates new column named ModelId
            // ----- For example take below HasOne Harbour in the Entity Pier
            // ----- That creates a column HarbourId in table Pier
            // ----- that column + relationslinks stated in model makes core Entity to properly
            // ----- know and store objects in objects sent in via Repo and .SaveChange

            // Pier
            modelBuilder.Entity<Pier>()
                 .HasOne(ho => ho.Harbour)
                 .WithMany(wm => wm.Piers)
                 //.HasForeignKey(ho => ho.Id)
                .OnDelete(DeleteBehavior.SetNull);


            // Boatslip

            //modelBuilder.Entity<Boatslip>()
            //    .Property<int>("BoatDataForeignKey");

            //modelBuilder.Entity<Boatslip>()
            //    .HasOne(ho => ho.BoatData)
            //     .WithMany(wm => wm.Boatslips)
            //    .HasForeignKey(ho => ho.Id)
            //     .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Boatslip>()
                .HasOne(ho => ho.Pier)
                 .WithMany(wm => wm.Boatslips)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Boatslip>()
                 .HasOne(ho => ho.ServiceType)
                 .WithMany(wm => wm.Boatslips)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Boatslip>()
                 .HasOne(ho => ho.MooringType)
                 .WithMany(wm => wm.Boatslips)
                 .OnDelete(DeleteBehavior.SetNull);


            // WinterstoreSpot
            modelBuilder.Entity<WinterstoreSpot>()
                 .HasOne(ho => ho.ServiceType)
                 .WithMany(wm => wm.WinterstoreSpots)
                 .OnDelete(DeleteBehavior.SetNull);


            // BoatData
            modelBuilder.Entity<BoatData>()
                 .HasOne(ho => ho.Customer)
                 .WithMany(wm => wm.BoatDatas)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BoatData>()
                 .HasOne(ho => ho.Boatslip)
                 .WithMany(wo => wo.BoatDatas)
                 //.HasForeignKey(wo => wo.Id)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BoatData>()
                 .HasOne(ho => ho.WinterstoreSpot)
                 .WithMany(wo => wo.BoatDatas)
                 //.HasForeignKey<WinterstoreSpot>(wo => wo.BoatDataId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);


            // ServiceApplication
            modelBuilder.Entity<ServiceApplication>()
                 .HasOne(ho => ho.Customer)
                 .WithMany(wm => wm.ServiceApplications)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceApplication>()
                 .HasOne(ho => ho.BoatData)
                 .WithMany(wm => wm.ServiceApplications)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceApplication>()
                 .HasOne(ho => ho.ServiceType)
                 .WithMany(wm => wm.ServiceApplications)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceApplication>()
                 .HasOne(ho => ho.Applicant)
                 .WithMany(wm => wm.ServiceApplications)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);


            // HistoryService
            modelBuilder.Entity<ServiceHistory>()
                 .HasOne(ho => ho.Customer)
                 .WithMany(wm => wm.ServiceHistories)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceHistory>()
                 .HasOne(ho => ho.BoatData)
                 .WithMany(wm => wm.ServiceHistories)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceHistory>()
                 .HasOne(ho => ho.ServiceType)
                 .WithMany(wm => wm.ServiceHistories)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceHistory>()
                 .HasOne(ho => ho.Boatslip)
                 .WithMany(wm => wm.ServiceHistories)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceHistory>()
                 .HasOne(ho => ho.WinterstoreSpot)
                 .WithMany(wm => wm.ServiceHistories)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.SetNull);

            // ------- Harbour Many-to-Many

            //modelBuilder.Entity<BoatslipHistory>()
            //     .HasOne(ho => ho.BoatData)
            //     .WithMany(wm => wm.Boatslips)
            //     .OnDelete(DeleteBehavior.SetNull);



            // ********************* END - Harbour stuff ******************************





            // ----------------- End tables & relations ---------------------------------





            // ------ START - SEEDING ****** IDENTITY - UNCOMMENT IF u creating a new database !!! /Eric R******-------------------

            // --- Creating Roles

            //IdentityRole roleSuperAdmin = new IdentityRole()
            //{
            //    Id = "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022",
            //    Name = "SuperAdmin",
            //    NormalizedName = "SUPERADMIN"
            //};

            //IdentityRole roleAdmin = new IdentityRole()
            //{
            //    Id = "438db5c8-0513-43a0-a84c-cd416c4e3a54",
            //    Name = "Admin",
            //    NormalizedName = "ADMIN"
            //};
            //IdentityRole roleUser = new IdentityRole()
            //{
            //    Id = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
            //    Name = "User",
            //    NormalizedName = "USER"
            //};

            //modelBuilder.Entity<IdentityRole>().HasData(
            //  roleSuperAdmin, roleAdmin, roleUser);



            //// ---------  Seeding Users  ----------


            ////hash the password before storing in db
            //var hashit = new PasswordHasher<IdentityAppUser>();

            //IdentityAppUser superAdminUser = new IdentityAppUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = "superadmin@email.com",
            //    NormalizedUserName = "SUPERADMIN@EMAIL.COM",
            //    Email = "superadmin@email.com",
            //    NormalizedEmail = "superadmin@email.com".ToUpper(),
            //    PasswordHash = hashit.HashPassword(null, "SuperAdmin77"),
            //    FirstName = "Eric SuperAdmin",
            //    LastName =  "Rönnhult",
            //    City = "Skövde"
            //};


            //IdentityAppUser adminUser = new IdentityAppUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = "admin@email.com",
            //    NormalizedUserName = "ADMIN@EMAIL.COM",
            //    Email = "admin@email.com",
            //    NormalizedEmail = "admin@email.com".ToUpper(),
            //    PasswordHash = hashit.HashPassword(null, "Admin77"),
            //    FirstName = "Mattias Admin",
            //    LastName = "Fredriksson",
            //    City = "Göteborg"
            //};

            //IdentityAppUser customer1 = new IdentityAppUser
            //{
            //    Id = Guid.NewGuid().ToString(), // primary key
            //    UserName = "customer1@email.com",
            //    Email = "customer1@email.com",
            //    NormalizedEmail = "customer1@email.com".ToUpper(),
            //    NormalizedUserName = "CUSTOMER1",
            //    PasswordHash = hashit.HashPassword(null, "Customer11"),
            //    FirstName = "Kund nr 1",
            //    LastName = "EfterNamn kund 1",
            //    City = "nått"
            //};


            //modelBuilder.Entity<IdentityAppUser>().HasData(
            //    superAdminUser, adminUser, customer1 /*, customer2, customer3*/
            //);


            ////   ----------- Setting roles to users ---------------


            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(

            //    new IdentityUserRole<string>
            //    {
            //        RoleId = roleSuperAdmin.Id,
            //        UserId = superAdminUser.Id
            //    }
            //    ,
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = roleAdmin.Id,
            //        UserId = adminUser.Id
            //    }
            //    ,

            //    new IdentityUserRole<string>
            //    {
            //        RoleId = roleUser.Id,
            //        UserId = customer1.Id
            //    }
            //);


            //// ----------- Seeding with Template Harbour, MooringType ----------------

            //modelBuilder.Entity<Harbour>().HasData(
            //    new Harbour { Id = 1, Label = "Hamn. Editera denna!", Info = "Editera Info här" }
            //);

            //modelBuilder.Entity<MooringType>().HasData(
            //    new MooringType { Id = 1, Label = "Y-Bom", Info = "Editera Info här" },
            //    new MooringType { Id = 2, Label = "Boj", Info = "Editera Info här" }
            //    //new MooringType { Id = 3, Label = "Stolpe", Info = "Editera Info här" }
            //);

            // ---- END ---   SEEDING Identity etc ONLY if u make new database !!!!!!! /Eric R


        }




    }
}
