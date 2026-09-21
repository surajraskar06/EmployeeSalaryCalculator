using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSalaryCalculator.Models;

public partial class DailyTaskContext : DbContext
{
    public DailyTaskContext()
    {
    }

    public DailyTaskContext(DbContextOptions<DailyTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployeeSalary> TblEmployeeSalaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SURAJ; Database=DailyTask; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployeeSalary>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__TblEmplo__7AD04F1133AACAFA");

            entity.ToTable("TblEmployeeSalary");

            entity.Property(e => e.BasicSalary).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.DearnessAllowance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GrossSalary).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.HouseRentAllowance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NetSalary).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ProvidentFund).HasColumnType("decimal(15, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
