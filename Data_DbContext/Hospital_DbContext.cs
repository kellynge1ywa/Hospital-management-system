using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System;

public class Hospital_DbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
    {
        optBuilder.UseSqlServer(@"Server=KELLY;Database=Hospital_Database;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room_data>()
        .HasMany(r=>r.Patients)
        .WithOne(p=>p.Room)
        .HasForeignKey(pd =>pd.RoomID);

        modelBuilder.Entity<Doctor_Data>()
        .HasMany(d=>d.Doctor_Appointments)
        .WithOne(ap=>ap.Doctor)
        .HasForeignKey(df=>df.DoctorID);

        modelBuilder.Entity<Patient_Data>()
        .HasMany(p=>p.Patient_Appointments)
        .WithOne(ap=>ap.Patients)
        .HasForeignKey(pf=>pf.PatientID);

        // modelBuilder.Entity<Appointment_Data>().HasNoKey();
    }

    public DbSet<Room_data> Rooms {get;set;}
    public DbSet<Patient_Data> Patients {get;set;}

    public DbSet<Doctor_Data> Doctors {get;set;}
    public DbSet<Appointment_Data>Appointments {get;set;}

}
