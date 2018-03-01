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

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Veteran> Veterans { get; set; }
        public DbSet<VeteranChild> VeteranChildren { get; set; }
        public DbSet<VeteranIntakeForm> VeteranIntakeForms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            builder.Entity<VeteranChild>()
                .HasOne(child => child.Veteran)
                .WithMany(vet => vet.Children);

            builder.Entity<VeteranChild>()
                .HasKey(a => a.ID);

            builder.Entity<VeteranIntakeForm>()
                .HasOne(form => form.Veteran)
                .WithMany(vet => vet.IntakeForms);

            builder.Entity<VeteranIntakeForm>()
                .HasKey(a => a.ID);

            builder.Entity<Veteran>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Veteran>()
                .HasKey(a => a.ApplicationUserId);

            builder.Entity<Lawyer>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Lawyer>()
                .HasKey(a => a.ApplicationUserId);

            builder.Entity<Admin>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Admin>()
                .HasKey(a => a.ApplicationUserId);
        }
    }
}
