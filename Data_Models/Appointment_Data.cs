using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System;

public class Appointment_Data
{
    [Key]
    public int AppointmentID {get;set;}

    public int? PatientID {get;set;}
    public int? DoctorID {get;set;}
    public DateTime AppointmentDate {get;set;}
    public DateTime AppointmentTime {get;set;}

    public string? FormattedData {get;set;}

    public Patient_Data? Patients {get;set;}

    public Doctor_Data? Doctor {get;set;}

}
