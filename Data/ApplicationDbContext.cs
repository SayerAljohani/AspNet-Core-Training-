﻿using System;
using System.Collections.Generic;
using System.Text;
using aspCoreTraining.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspCoreTraining.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LectureStudent> LectureStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LectureStudent>()
                .HasAlternateKey(c => new { c.ApplicationUserId, c.LectureId}).HasName("IX_Lecture_student");
        }
    }
}
