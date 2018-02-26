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

        public DbSet<AdminModel> Admin;
        public DbSet<LawyerModel> Lawyer;
        public DbSet<VeteranModel> Veterans;
        public DbSet<VeteranChildrenModel> VeteranChildren;
        public DbSet<VeteranIntakeModel> VeteranIntakeForm;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<VeteranChildrenModel>()
                .HasOne(child => child.Parent)
                .WithMany(vet => vet.Children);

            builder.Entity<VeteranIntakeModel>()
                .HasOne(form => form.Author)
                .WithMany(vet => vet.IntakeForms);

            builder.Entity<VeteranModel>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<LawyerModel>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();

            builder.Entity<AdminModel>()
                .HasOne(vet => vet.ApplicationUser)
                .WithOne();



        }
    }
}
