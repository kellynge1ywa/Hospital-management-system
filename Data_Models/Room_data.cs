using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System;

public class Room_data
{
    [Key]
    public int RoomID {get; set;}

    public string? Room_Number {get;set;}
    public string? Room_Type{get;set;}
    public List<Patient_Data>? Patients {get;set;}

}
