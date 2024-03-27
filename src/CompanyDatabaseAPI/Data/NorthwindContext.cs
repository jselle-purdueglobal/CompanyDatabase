using System;
using System.Collections.Generic;
using CompanyDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDatabaseAPI.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Northwind");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasConstraintName("FK_Employees_Employees");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Freight).HasDefaultValue(0m);

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Employees");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A7ABE73A9");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RolePermissionId).HasName("PK__RolePerm__120F469A69EC3CF5");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions).HasConstraintName("FK__RolePermi__RoleI__25518C17");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC948EFFCD");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("FK__Users__RoleID__22751F6C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
