﻿using ERPSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // do not comment out, causes IdentityDbContext errors
            #region Enum mapping
            modelBuilder
                .Entity<Assignment>()
                .Property(e => e.AssignmentState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Branch>()
                .Property(e => e.BranchState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Company>()
                .Property(e => e.CompanyState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Department>()
                .Property(e => e.DepartmentState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Employee>()
                .Property(e => e.EmployeeState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Position>()
                .Property(e => e.PositionState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Project>()
                .Property(e => e.ProjectState)
                .HasConversion<string>()
                .HasMaxLength(16);
            modelBuilder
                .Entity<Report>()
                .Property(e => e.ReportState)
                .HasConversion<string>()
                .HasMaxLength(16);
            #endregion
            //Many-to-many cycles of cascade deletes fix
            //https://github.com/dotnet/efcore/issues/22803#issuecomment-729221687
            //https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete#optional-relationship-with-dependentschildren-loaded
            modelBuilder.Entity<Employee>()
                        .HasMany(f => f.Mentors)
                        .WithMany(g => g.Mentees)
                        .UsingEntity<Dictionary<string, object>>(
                            "MentorsMentees",
                            j => j.HasOne<Mentor>().WithMany().OnDelete(DeleteBehavior.Cascade),
                            j => j.HasOne<Employee>().WithMany().OnDelete(DeleteBehavior.ClientCascade));
            //One-to-many cycles of cascade deletes fix
            //https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete
            modelBuilder.Entity<Branch>()
                        .HasMany(e => e.Employees)
                        .WithOne(e => e.Branch)
                        .OnDelete(DeleteBehavior.ClientCascade);
            
            //One-to-one cycles of cascade deletes fix
            modelBuilder.Entity<Department>()
                        .HasOne(e => e.DepartmentHead)
                        .WithOne(e => e.Department)
                        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Project>()
                        .HasOne(e => e.ProjectManager)
                        .WithOne(e => e.Project)
                        .OnDelete(DeleteBehavior.ClientCascade);
        }
        #region DBSet
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentHead> DepartmentHeads { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GeneralManager> GeneralManagers { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Report> Reports { get; set; }
        #endregion
    }
}