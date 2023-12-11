using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System;

public class Patient_Data
{
    [Key]
    public int PatientID {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public string? Email {get;set;}

    public int? RoomID {get; set;}
    public Room_data? Room {get;set;}

    public List<Appointment_Data>? Patient_Appointments {get;set;}

}
