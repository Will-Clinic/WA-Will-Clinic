using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WillClinic.Models;

namespace WillClinic.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Admin> Admin;
        public DbSet<Lawyer> Lawyer;
        public DbSet<Veteran> Veterans;
        public DbSet<VeteranChildren> VeteranChildren;
        public DbSet<VeteranIntake> VeteranIntakeForm;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<VeteranChildren>()
                .HasOne(child => child.Parent)
                .WithMany(vet => vet.Children);

            builder.Entity<VeteranIntake>()
                .HasOne(form => form.Author)
                .WithMany(vet => vet.IntakeForms);

            builder.Entity<Veteran>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Veteran>()
                .HasKey(veteran => veteran.ApplicationUserId);

            builder.Entity<Lawyer>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Lawyer>()
                .HasKey(lawyer => lawyer.ApplicationUserId);

            builder.Entity<Admin>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Admin>()
                .HasKey(admin => admin.ApplicationUserId);



        }


        public DbSet<WillClinic.Models.Lawyer> Lawyer_1 { get; set; }
    }
}
