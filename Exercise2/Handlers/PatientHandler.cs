static class PateintHandler{
private static List<Patient> _pateints= new List<Patient>();

    private static int IdNumber=1;
public static IResult GetPatients(){
return Results.Ok(_pateints);

}
public static IResult GetPatient(int id){
    var patient=_pateints.FirstOrDefault(P=>P.Id==id);
    if (patient is null){
        return Results.BadRequest("please try again");

    }
    return Results.Ok(patient);
}
public static IResult AddPatient(Patient patient){
    patient.Id=_pateints.Count+1;
    _pateints.Add(patient);
     
    return Results.Created("",patient);
}
public static IResult UpdatePatient(int id ,Patient patient){
var UpdatePatient=_pateints.FirstOrDefault(d=>d.Id==id);
if (UpdatePatient is null){
    return Results.BadRequest();
}
UpdatePatient.Name=patient.Name;
UpdatePatient.Address=patient.Address;
UpdatePatient.Phone=patient.Phone;
return Results.NoContent();
}
public static IResult DELETE(int id){
    var patient=_pateints.FirstOrDefault(d=>d.Id==id);
    if (patient is null ){
        return Results.BadRequest("Qab Khaldan baa u delete greynaysa");
    }
    _pateints.Remove(patient);
    return Results.NoContent ();
    
}
}