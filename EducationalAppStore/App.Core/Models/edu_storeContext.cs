﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using App.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Core.Models
{
    public partial class edu_storeContext : IdentityDbContext<ApplicationUser>
    {
        public edu_storeContext()
        {
        }

        public edu_storeContext(DbContextOptions<edu_storeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseCategory> CourseCategory { get; set; }
        public virtual DbSet<CourseCategoryList> CourseCategoryList { get; set; }
        public virtual DbSet<CourseLictures> CourseLictures { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseName).HasMaxLength(100);

                entity.Property(e => e.Offer).HasColumnName("offer");

                entity.Property(e => e.TeacherId).HasMaxLength(450);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CourseCategoryList>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.CourseCategory)
                    .WithMany()
                    .HasForeignKey(d => d.CourseCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseCategoryList_CourseCategory");

                entity.HasOne(d => d.Cousrse)
                    .WithMany()
                    .HasForeignKey(d => d.CousrseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseCategoryList_Course");
            });

            modelBuilder.Entity<CourseLictures>(entity =>
            {
                entity.HasKey(e => e.LictureId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LictureLink).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseLictures)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseLictures_Course");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.About).IsRequired();

                entity.Property(e => e.Acchivments).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleLink)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedinLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MyObjective).IsRequired();

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TwiterLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}