using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestApi_1.Models;

public partial class MbookingContext : DbContext
{
    public MbookingContext()
    {
    }

    public MbookingContext(DbContextOptions<MbookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingTabel> BookingTabels { get; set; }

    public virtual DbSet<ClientTable> ClientTables { get; set; }

    public virtual DbSet<ClientVehicle> ClientVehicles { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<NewClietVehicleView> NewClietVehicleViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=VMG-Gordon\\GORDONNEWDB,30120; Database=MBooking; User Id=sa; Password= Pr0perty1WWW;TrustServerCertificate=True;\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingTabel>(entity =>
        {
            entity.HasKey(e => e.BookingId);

            entity.ToTable("Booking_Tabel");

            entity.Property(e => e.BookingId).HasColumnName("Booking_Id");
            entity.Property(e => e.BookingDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Booking_Date");
            entity.Property(e => e.BookingNotes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Booking_Notes");
            entity.Property(e => e.BookingTime)
                .HasPrecision(5)
                .HasColumnName("Booking_Time");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client_Name");
            entity.Property(e => e.ClietnCar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Clietn_Car");
            entity.Property(e => e.VehicleMake)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehicle_Make");
        });

        modelBuilder.Entity<ClientTable>(entity =>
        {
            entity.HasKey(e => e.ClientId);

            entity.ToTable("Client_table");

            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client_Name");
            entity.Property(e => e.ClientPhoneNumde)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client_PhoneNumde");
            entity.Property(e => e.ClientSurename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client_Surename");
        });

        modelBuilder.Entity<ClientVehicle>(entity =>
        {
            entity.ToTable("Client_Vehicle");

            entity.Property(e => e.ClientVehicleId).HasColumnName("Client_Vehicle_Id");
            entity.Property(e => e.VehicleMake)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehicle_Make");
            entity.Property(e => e.VehicleModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehicle_Model");
            entity.Property(e => e.VehicleRegistration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehicle_Registration");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("login");

            entity.Property(e => e.LoginId).HasColumnName("Login_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NewClietVehicleView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewClietVehicleView");

            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName(" Client Name");
            entity.Property(e => e.ClientPhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client Phone Number");
            entity.Property(e => e.ClientSurename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client Surename");
            entity.Property(e => e.Description)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("License Number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
