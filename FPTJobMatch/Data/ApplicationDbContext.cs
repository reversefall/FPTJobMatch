using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FPTJobMatch.Models;

namespace FPTJobMatch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FPTJobMatch.Models.Category> Category { get; set; }
        public DbSet<FPTJobMatch.Models.JobPost> JobPost { get; set; }
        public DbSet<FPTJobMatch.Models.Application> Application { get; set; }
        public DbSet<FPTJobMatch.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobPost>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.JobPosts)
                .HasForeignKey(sc => sc.CategoryId);

        }
    }
}
