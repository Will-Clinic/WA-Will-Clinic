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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Veteran> Veterans { get; set; }
        public DbSet<VeteranChildren> VeteranChildren { get; set; }
        public DbSet<VeteranIntake> VeteranIntakeForms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

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
    }
}
