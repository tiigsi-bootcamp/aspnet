static class DoctorHandler{
    private static int IdNumber=1;
private static List<Doctor> _doctors=new List<Doctor>();
public static IResult getDoctors(){
return Results.Ok(_doctors);
}
public static IResult GetDoctor(int id ){
 var doctor=_doctors.FirstOrDefault(d=> d.Id ==id);
 if (doctor is null){
     return Results.NotFound("not recongnazing ");
 }
 return Results.Ok(doctor);
}
public static IResult Add(Doctor doctor){
doctor=doctor with {Id =IdNumber};
     _doctors.Add(doctor);
     IdNumber +=1;
     return Results.Created("",doctor);
}
public static IResult Put(int id, Doctor doctor){
    	var DoctorInd = _doctors.FindIndex(d => d.Id == id);
		if (DoctorInd == -1)
		{
			return Results.BadRequest("Doctor not be recognized.");
		}

		_doctors[DoctorInd] = doctor with { Id = id };

		return Results.NoContent();
}
public static IResult DELETE(int id){
    	var DoctorInd= _doctors.FindIndex(d => d.Id == id);
		if (DoctorInd== -1)
		{
			return Results.BadRequest("Doctor not be recognized.");
		}

		_doctors.RemoveAt(DoctorInd);

		return Results.NoContent();
}
}