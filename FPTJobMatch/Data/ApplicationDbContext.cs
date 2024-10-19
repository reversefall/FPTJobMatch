using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FPTJobMatch.Models;
using Microsoft.AspNetCore.Identity;

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
            modelBuilder.Entity<Application>()
                .HasOne(j => j.JobPost)
                .WithMany(d => d.Applications)
                .HasForeignKey(j => j.JobPostId);
            //modelBuilder.Entity<User>()
            //    .HasMany(a => a.Applications)
            //    .WithOne(b => 
            //    .HasForeignKey(b => b.UserId);

            SeedUserRole(modelBuilder);



        }



        private void SeedUserRole(ModelBuilder modelBuilder)
        {
            var empAccount = new IdentityUser
            {
                Id = "user1",
                UserName = "emp@gmail.com",
                Email = "emp@gmail.com",
                NormalizedUserName = "EMP0@GMAIL.COM",
                NormalizedEmail = "EMP0@GMAIL.COM",
                EmailConfirmed = true,
            };

            var userAccount = new IdentityUser
            {
                Id = "user2",
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedUserName = "USER1@GMAIL.COM",
                NormalizedEmail = "USER1@GMAIL.COM",
                EmailConfirmed = true,
            };

            var hasher = new PasswordHasher<IdentityUser>();

            empAccount.PasswordHash = hasher.HashPassword(empAccount, "123456");
            userAccount.PasswordHash = hasher.HashPassword(userAccount, "123456");

            modelBuilder.Entity<IdentityUser>().HasData(empAccount, userAccount);

            // Setup Identity role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "role1",
                    Name = "Employer",
                    NormalizedName = "EMPLOYER",
                },
                new IdentityRole
                {
                    Id = "role2",
                    Name = "User",
                    NormalizedName = "USER",
                }
             );

            // Setup Identity User Role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "user1",
                    RoleId = "role1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "user2",
                    RoleId = "role2",
                }
                );
        }
    }
}
