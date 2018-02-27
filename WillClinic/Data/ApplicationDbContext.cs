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
        public DbSet<VeteranChildren> VeteranChildren { get; set; }
        public DbSet<VeteranIntake> VeteranIntakeForms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            builder.Entity<VeteranChildrenModel>()
                .HasOne(child => child.Parent)
                .WithMany(vet => vet.Children);

            builder.Entity<VeteranChildrenModel>()
                .HasKey(a => a.VeteranModelApplicationUserId);

            builder.Entity<VeteranIntakeModel>()
                .HasOne(form => form.Author)
                .WithMany(vet => vet.IntakeForms);

            builder.Entity<VeteranIntakeModel>()
                .HasKey(a => a.VeteranModelApplicationUserId);

            builder.Entity<Veteran>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<Veteran>()
                .HasKey(a => a.ApplicationUserId);

            builder.Entity<LawyerModel>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<LawyerModel>()
                .HasKey(a => a.ApplicationUserId);

            builder.Entity<AdminModel>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<AdminModel>()
                .HasKey(a => a.ApplicationUserId);
        }
    }
}
