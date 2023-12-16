using System;
using System.Collections.Generic;
using HospitalManegementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManegementSystem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorPateint> DoctorPateints { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Pateint> Pateints { get; set; }

    public virtual DbSet<PateintMedicine> PateintMedicines { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=HospitalManegmentSystem; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC076C7F56AB");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_Date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__4D94879B");

            entity.HasOne(d => d.Pateint).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PateintId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Patei__4CA06362");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC0700AE952B");

            entity.ToTable("Doctor");

            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Specialization)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Doctor__Hospital__440B1D61");
        });

        modelBuilder.Entity<DoctorPateint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorPa__3214EC07C59C4C15");

            entity.ToTable("DoctorPateint");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorPateints)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorPat__Docto__5EBF139D");

            entity.HasOne(d => d.Pateint).WithMany(p => p.DoctorPateints)
                .HasForeignKey(d => d.PateintId)
                .HasConstraintName("FK__DoctorPat__Patei__5DCAEF64");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC07BA12B964");

            entity.ToTable("Hospital");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicine__3214EC075B4891ED");

            entity.ToTable("Medicine");

            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenericName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pateint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pateint__3214EC07E492F555");

            entity.ToTable("Pateint");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Pateints)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Pateint__Hospita__48CFD27E");

            entity.HasOne(d => d.Ward).WithMany(p => p.Pateints)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pateint__WardId__49C3F6B7");
        });

        modelBuilder.Entity<PateintMedicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PateintM__3214EC0758A9B8D5");

            entity.ToTable("PateintMedicine");

            entity.HasOne(d => d.Medicine).WithMany(p => p.PateintMedicines)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK__PateintMe__Medic__628FA481");

            entity.HasOne(d => d.Pateint).WithMany(p => p.PateintMedicines)
                .HasForeignKey(d => d.PateintId)
                .HasConstraintName("FK__PateintMe__Patei__619B8048");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC07E8655629");

            entity.ToTable("Prescription");

            entity.Property(e => e.PrescriptionDate)
                .HasColumnType("datetime")
                .HasColumnName("Prescription_Date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prescript__Docto__5165187F");

            entity.HasOne(d => d.Pateint).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PateintId)
                .HasConstraintName("FK__Prescript__Patei__5070F446");
        });

        modelBuilder.Entity<PrescriptionMedicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC0747C3C6D7");

            entity.ToTable("PrescriptionMedicine");

            entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

            entity.HasOne(d => d.Medicine).WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK__Prescript__Medic__5AEE82B9");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("FK__Prescript__Presc__59FA5E80");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ward__3214EC075E512422");

            entity.ToTable("Ward");

            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Wards)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Ward__HospitalId__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
