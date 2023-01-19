using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuardEmpSignin.Models;

public partial class GuardDbContext :IdentityDbContext
{

    public GuardDbContext(DbContextOptions<GuardDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpDetail> EmpDetails { get; set; }

    public virtual DbSet<EmployeeTempBadge> EmployeeTempBadges { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=HSHLT-1795\\SQLEXPRESS;Initial Catalog=GuardDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmpDetail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EmpFirstname)
                .HasMaxLength(50)
                .HasColumnName("empFirstname");
            entity.Property(e => e.EmpLastname)
                .HasMaxLength(50)
                .HasColumnName("empLastname");
            entity.Property(e => e.Photo).HasColumnType("text");
        });

        modelBuilder.Entity<EmployeeTempBadge>(entity =>
        {
            entity.ToTable("EmployeeTempBadge");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AssignT).HasColumnType("datetime");
            entity.Property(e => e.EmployeeFirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.EmployeeLastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SignInT).HasColumnType("datetime");
            entity.Property(e => e.SignOutT).HasColumnType("datetime");
            entity.Property(e => e.TempBadge)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
