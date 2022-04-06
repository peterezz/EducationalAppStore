﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class Edu_StoreContext : DbContext
    {
        public Edu_StoreContext()
        {
        }

        public Edu_StoreContext(DbContextOptions<Edu_StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseCategory> CourseCategory { get; set; }
        public virtual DbSet<TeacherCourses> TeacherCourses { get; set; }
        public virtual DbSet<TeacherLanguages> TeacherLanguages { get; set; }
        public virtual DbSet<TeacherSkills> TeacherSkills { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.Property(e => e.CourseCategoryId).HasColumnName("CourseCategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<TeacherCourses>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseName).HasMaxLength(150);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("TeacherID");
            });

            modelBuilder.Entity<TeacherLanguages>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(450)
                    .HasColumnName("TeacherID");
            });

            modelBuilder.Entity<TeacherSkills>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Skill).HasMaxLength(50);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("TeacherID");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Exceperience).HasMaxLength(50);

                entity.Property(e => e.FacebookLink).HasMaxLength(200);

                entity.Property(e => e.InstegramLink).HasMaxLength(200);

                entity.Property(e => e.LinkedinLink).HasMaxLength(200);

                entity.Property(e => e.TwiterLink).HasMaxLength(200);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Teachers_Teachers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}