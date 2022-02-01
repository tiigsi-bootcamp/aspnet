static class DoctorHandler
{

    private static int _idTracker = 1;
    private static  List<Doctor> _doctors = new List<Doctor>();

    public static IResult GetDoctors()

    {
        return Results.Ok(_doctors );
    }

    public static IResult GetDoctor(int id)

    {
        var doctor = _doctors.FirstOrDefault(d => d.Id == id);

        if (doctor is null)

        {
            return Results.BadRequest("doctors was not Found 🤷‍♀️🤷‍♀️");

        }

        return Results.Ok(doctor);
    }

    //Add Doctor AddDoctor

    public static  IResult AddDoctor(Doctor doctor)
    {
        _doctors.Add(doctor);

        return Results.Created("",doctor);

    }
    
    //UpdateDoctor

    public static IResult UpdateDoctor(int id ,Doctor doctor)

    {
        var index = _doctors.FindIndex(d => d.Id == id);

        if (index is -1)
        {
            return Results.BadRequest();
        }

        _doctors[index] = doctor with { Id = id };

        return Results.NoContent();
    }
    
    public static IResult DeleteDoctor(int id)
    {
        var index = _doctors.FindIndex(d => d.Id == id);

        if (index is -1)
        {
            return Results.BadRequest();
        }

        _doctors.RemoveAt(index);

        return Results.NoContent();
    }

    
    
    
};