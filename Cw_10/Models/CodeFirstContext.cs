using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw_10.Models
{
    public class CodeFirstContext : DbContext
    {

        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }



        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");

                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");

                entity.HasOne(d => d.Doctor)
                   .WithMany(d => d.Prescriptions)
                   .HasForeignKey(d => d.IdDoctor)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("Prescription_Doctor");
           });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.IdDoctor).HasName("Doctor_PK");

                entity.Property(d => d.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(d => d.LastName).HasMaxLength(50).IsRequired();
                entity.Property(d => d.Email).HasMaxLength(70).IsRequired();
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(d => d.IdMedicament).HasName("Medicament_PK");

                entity.Property(d => d.Name).HasMaxLength(50).IsRequired();
                entity.Property(d => d.Description).HasMaxLength(100).IsRequired();
                entity.Property(d => d.Type).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(d => new { d.IdMedicament, d.IdPrescription }).HasName("PrescriptionMedicament_PK");

                entity.Property(d => d.Dose);
                entity.Property(d => d.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(d => d.Prescription)
                    .WithMany(d => d.Prescription_Medicaments)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescriptionMedicament_Prescription");

                entity.HasOne(d => d.Medicament)
                    .WithMany(d => d.Prescription_Medicaments)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PrescriptionMedicament_Medicament");
            });
        }

    }
}
