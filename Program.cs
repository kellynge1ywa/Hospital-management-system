using Hospital_Management_System;

try
{

    using Hospital_DbContext hospitalDbContext= new Hospital_DbContext();
    var Appointments = new List<Appointment_Data>(){
        new Appointment_Data()
        { AppointmentDate=new DateTime(2023,12,27), AppointmentTime=new DateTime(1,1,1,15,40,0), FormattedData= new DateTime(2023,12,27).ToShortDateString()},
        new Appointment_Data(){ AppointmentDate=new DateTime(2023,12,20), AppointmentTime=new DateTime(1,1,1,14,45,0), FormattedData=new DateTime(2023,12,20).ToShortDateString()},
        new Appointment_Data(){ AppointmentDate=new DateTime(2023,12,15), AppointmentTime=new DateTime(1,1,1,12,30,0),FormattedData=new DateTime(2023,12,15).ToShortDateString()}
    };

    foreach(var appointment in Appointments){
        Console.WriteLine($"Appointment Date: {appointment.AppointmentDate.ToShortDateString()}");
        Console.WriteLine($"Appointment Time: {appointment.AppointmentTime.ToShortTimeString()}");
        // Console.WriteLine();

    }
    
    hospitalDbContext.SaveChanges();

    var patients= new List<Patient_Data>()
    {
        new Patient_Data()
        {FirstName="Patient", LastName="Patient", Email="patient@gmail.com",Patient_Appointments=Appointments },
        
        new Patient_Data()
        {FirstName="Mgonjwa", LastName="Name", Email="mgonjwaname@gmail.com",Patient_Appointments=Appointments },
        
        new Patient_Data()
        {FirstName="Sick", LastName="Patient", Email="sickpatient@gmail.com",Patient_Appointments=Appointments }
    };

    var Room1= new Room_data(){
        Room_Number="T123",
        Room_Type="Shared",
        Patients=patients


    };
    hospitalDbContext.Rooms.Add(Room1);
    hospitalDbContext.SaveChanges();
    Console.WriteLine("Rooms and Patients data added successfully");

    var Doctor1= new Doctor_Data(){
        DoctorName="Good doctor",
        Specialty="General Doctor",
        Doctor_Appointments=Appointments
    };

    hospitalDbContext.Doctors.Add(Doctor1);
    hospitalDbContext.SaveChanges();
    Console.WriteLine("Doctor data added successfully");

    

}catch(Exception ex){
    Console.WriteLine(ex.Message);
} 


//READ DATA ALL DATA


try {
    var hospital_context= new Hospital_DbContext();
     // Get all patients

    var  all_patients= hospital_context.Patients.ToList();
    foreach(var one_patient in all_patients){
        Console.WriteLine($"Name: {one_patient.FirstName} {one_patient.LastName} Email: {one_patient.Email} Room_Id: {one_patient.RoomID} ");
    }
    
    //Get all doctors

    var all_doctors= hospital_context.Doctors.ToList();
    foreach(var one_doctor in all_doctors){
        Console.WriteLine($"Name: {one_doctor.DoctorName}- Speciality: {one_doctor.Specialty}");
    }

    //Get all appointments
    
    var all_appointments=hospital_context.Appointments.ToList();
    foreach(var one_appointment in all_appointments){
        Console.WriteLine($"Date:{one_appointment.FormattedData}- Time: {one_appointment.AppointmentTime}- Patient: {one_appointment.PatientID}- Doctor: {one_appointment.DoctorID}");
    }

    //Get all rooms

    var all_rooms= hospital_context.Rooms.ToList();
    foreach(var one_room in all_rooms){
        Console.WriteLine($"Room Number:{one_room.Room_Number} Room Type: {one_room.Room_Type}");
    }
}
catch(Exception ex){
    Console.WriteLine(ex.Message);
} 


//GET DATA BY ID AND UPDATE

try
{
    var hospital_context= new Hospital_DbContext();
     //Find one patient

    var show_patient= hospital_context.Patients.Find(3);
    if(show_patient != null){
        Console.WriteLine($"Name :{show_patient.FirstName} {show_patient.LastName} Email: {show_patient.Email} Room: {show_patient.RoomID}");
    } else
    {
        Console.WriteLine("Invalid patient ID");
    }


    //Find one patient and update

    var patient1=hospital_context.Patients.Find(2);
    if (patient1!= null){
        
        Console.WriteLine($"Before: {hospital_context.Entry(patient1).State}");
        patient1.FirstName="Ndovu";
        patient1.LastName="Elephant";
        patient1.Email="ndovu@gmail.com";

        Console.WriteLine($"After update: {hospital_context.Entry(patient1).State}");
        hospital_context.SaveChanges();
    }
    else{
        Console.WriteLine("Patient not found");
    }

    //Find one doctor

    var show_doctor= hospital_context.Doctors.Find(1);
    if(show_doctor != null){
        Console.WriteLine($"Name :{show_doctor?.DoctorName} Specialty: {show_doctor?.Specialty}");
    } else
    {
        Console.WriteLine("Invalid doctor ID");
    }


    //Find one doctor and update
    var Doctor1=hospital_context.Doctors.Find(1);
    if (Doctor1!= null){
        
        Console.WriteLine($"Before: {hospital_context.Entry(Doctor1).State}");
        Doctor1.DoctorName="Simba";
        Doctor1.Specialty="Lion";
        

        Console.WriteLine($"After update: {hospital_context.Entry(Doctor1).State}");
        hospital_context.SaveChanges();
    }
    else{
        Console.WriteLine("Doctor not found");
    }


    //Find an appointment

     var show_appointment= hospital_context.Appointments.Find(1);
    if(show_appointment != null){
        Console.WriteLine($"Date :{show_appointment.FormattedData} Time: {show_appointment.AppointmentTime}");
    } else
    {
        Console.WriteLine("Invalid appointment ID");
    }

    //Find an appointment and update

    var Appointment1=hospital_context.Appointments.Find(1);
    if (Appointment1!= null){
        
        Console.WriteLine($"Before: {hospital_context.Entry(Appointment1).State}");
        Appointment1.AppointmentDate= new DateTime(2023, 12,29);
        Appointment1.AppointmentTime= new DateTime(1,1,1,12,00,0);
        Appointment1.FormattedData= new DateTime(2023,12,29).ToShortDateString();
        

        Console.WriteLine($"After update: {hospital_context.Entry(Appointment1).State}");
        hospital_context.SaveChanges();
    }
    else{
        Console.WriteLine("Appointment not found");
    }

    //Show room 

     var show_room= hospital_context.Rooms.Find(1);
    if(show_room != null){
        Console.WriteLine($"Name :{show_room.Room_Number} Specialty: {show_room.Room_Type}");
    } else
    {
        Console.WriteLine("Invalid room ID");
    }

    //Find one room and update
    var Room1=hospital_context.Rooms.Find(1);
    if (Room1!= null){
        
        Console.WriteLine($"Before: {hospital_context.Entry(Room1).State}");
        Room1.Room_Number="Tsavo";
        Room1.Room_Type="Single";
        
        Console.WriteLine($"After update: {hospital_context.Entry(Room1).State}");
        hospital_context.SaveChanges();
    }
    else{
        Console.WriteLine("Doctor not found");
    }
}
catch(Exception ex){
    Console.WriteLine(ex.Message);
}

//DELETE ITEMS
try{
    var hospital_context= new Hospital_DbContext();

    //Delete patient
    var patient1=hospital_context.Patients.Find(2);

    if(patient1!=null){
        Console.WriteLine($"Before deleting: {hospital_context.Entry(patient1).State}");
        hospital_context.Remove(patient1);
        Console.WriteLine($"Before deleting: {hospital_context.Entry(patient1).State}");
        hospital_context.SaveChanges();
        Console.WriteLine($"Before deleting: {hospital_context.Entry(patient1).State}");

    } else{
        Console.WriteLine("Patient not found");
    }

    //Delete doctor

     var doctor1=hospital_context.Doctors.Find(1);

    if(doctor1!=null){
        Console.WriteLine($"Before deleting: {hospital_context.Entry(doctor1).State}");
        hospital_context.Remove(doctor1);
        Console.WriteLine($"Before deleting: {hospital_context.Entry(doctor1).State}");
        hospital_context.SaveChanges();
        Console.WriteLine($"Before deleting: {hospital_context.Entry(doctor1).State}");

    } else{
        Console.WriteLine("Doctor not found");
    }

    //Delete room

    var room1=hospital_context.Rooms.Find(1);

    if(room1!=null){
        Console.WriteLine($"Before deleting: {hospital_context.Entry(room1).State}");
        hospital_context.Remove(room1);
        Console.WriteLine($"Before deleting: {hospital_context.Entry(room1).State}");
        hospital_context.SaveChanges();
        Console.WriteLine($"Before deleting: {hospital_context.Entry(room1).State}");

    } else{
        Console.WriteLine("Room not found");
    }

    //Delete appointment

     var appointment1=hospital_context.Appointments.Find(1);

    if(appointment1!=null){
        Console.WriteLine($"Before deleting: {hospital_context.Entry(appointment1).State}");
        hospital_context.Remove(appointment1);
        Console.WriteLine($"Before deleting: {hospital_context.Entry(appointment1).State}");
        hospital_context.SaveChanges();
        Console.WriteLine($"Before deleting: {hospital_context.Entry(appointment1).State}");

    } else{
        Console.WriteLine("Appointment not found");
    }
 

}
catch(Exception Ex){
    Console.WriteLine(Ex.Message);
}
