﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SatyamShivanshExample.Models;

public partial class ActsJune25Context : DbContext
{
    public ActsJune25Context()
    {
    }

    public ActsJune25Context(DbContextOptions<ActsJune25Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=ActsJune25;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__Departme__0148CAAE034037D0");

            entity.Property(e => e.DeptNo).ValueGeneratedNever();
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__AF2D66D3470F9BFD");

            entity.Property(e => e.EmpNo).ValueGeneratedNever();
            entity.Property(e => e.Basic).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
