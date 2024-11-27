﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class KoiFengShuiAdvisorContext : DbContext
{
    public KoiFengShuiAdvisorContext()
    {
        
    }
    public KoiFengShuiAdvisorContext(DbContextOptions<KoiFengShuiAdvisorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ElementType> ElementTypes { get; set; }

    public virtual DbSet<FengShuiScore> FengShuiScores { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<PondFeature> PondFeatures { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostPackage> PostPackages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElementType>(entity =>
        {
            entity.HasKey(e => e.ElementId).HasName("PK__ElementT__A429721AC2B3CA1B");

            entity.HasIndex(e => e.ElementName, "UQ__ElementT__692AC439AC696963").IsUnique();

            entity.Property(e => e.ElementName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<FengShuiScore>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__FengShui__7DD229D1AFAC07CE");

            entity.Property(e => e.CompatibilityScore).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Element).WithMany(p => p.FengShuiScores)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK__FengShuiS__Eleme__5BE2A6F2");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.FengShuiScores)
                .HasForeignKey(d => d.KoiFishId)
                .HasConstraintName("FK__FengShuiS__KoiFi__5CD6CB2B");

            entity.HasOne(d => d.PondFeature).WithMany(p => p.FengShuiScores)
                .HasForeignKey(d => d.PondFeatureId)
                .HasConstraintName("FK__FengShuiS__PondF__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.FengShuiScores)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__FengShuiS__UserI__5AEE82B9");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiFishId).HasName("PK__KoiFish__44D35C2510720AA1");

            entity.ToTable("KoiFish");

            entity.Property(e => e.FishName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.SuitableElement).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.SuitableElementId)
                .HasConstraintName("FK__KoiFish__Suitabl__5535A963");
        });

        modelBuilder.Entity<PondFeature>(entity =>
        {
            entity.HasKey(e => e.PondFeatureId).HasName("PK__PondFeat__413AD98BDFC08DE0");

            entity.Property(e => e.FeatureType)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FeatureValue)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.SuitableElement).WithMany(p => p.PondFeatures)
                .HasForeignKey(d => d.SuitableElementId)
                .HasConstraintName("FK__PondFeatu__Suita__5812160E");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA126018AE009205");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.FengShuiElement).WithMany(p => p.Posts)
                .HasForeignKey(d => d.FengShuiElementId)
                .HasConstraintName("FK__Posts__FengShuiE__656C112C");

            entity.HasOne(d => d.Package).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__Posts__PackageId__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Posts__UserId__6477ECF3");
        });

        modelBuilder.Entity<PostPackage>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__PostPack__322035CC0D6EC10D");

            entity.Property(e => e.PackageName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A8CC7D796");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160EB6092F7").IsUnique();

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.StatId).HasName("PK__Statisti__3A162D3E65D4D1BB");

            entity.ToTable("Statistic");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C890A3053");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E496FCDCBF").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}