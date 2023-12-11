using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System;

public class Doctor_Data
{
    [Key]
    public int DoctorID {get;set;}
    public string? DoctorName {get;set;}
    public string? Specialty {get;set;}
    public List<Appointment_Data>? Doctor_Appointments {get;set;}

}
