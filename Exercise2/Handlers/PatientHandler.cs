static class PatientHandler
{
    static private int _idCounter = 1;
   static private List<Patient> _Patients = new List<Patient>();

   public static  IResult GetPatients(){
      return Results.Ok(_Patients);
   }
   public static  IResult GetPatient(int id){
       var patient = _Patients.FirstOrDefault(d => d.Id == id);
       if(patient == null){
           return Results.BadRequest("not found");
       }
      return Results.Ok(patient);
   }
   public static  IResult AddPatient(Patient patient){
       patient.Id = _idCounter;
       _Patients.Add(patient);
       _idCounter += 1;
      return Results.NoContent();
   }
   public static  IResult UpdatePatient(int id,Patient patient){
       var patientInfo = _Patients.FirstOrDefault(d => d.Id == id);
       if(patientInfo == null){
           return Results.BadRequest("not found");
       }
       patientInfo.Name = patient.Name;
       patientInfo.Address = patient.Address;
       patientInfo.Phone = patient.Phone;
      return Results.NoContent();
   }
   public static IResult DeletePatient(int id){
      var patient = _Patients.FirstOrDefault(d => d.Id == id);
      if(patient == null){
          return Results.BadRequest();
      }
      _Patients.Remove(patient);
      return Results.NoContent();
   }
}