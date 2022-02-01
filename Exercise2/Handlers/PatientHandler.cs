static class PateintHandler
{
    private static List<Patient> _patients = new List<Patient>();

    public static IResult GetPatients()  
    {
        return Results.Ok(_patients);
    } 

    public static IResult GetPatient(int id)
    {
        var patient = _patients.FirstOrDefault(d => d.Id == id);

        if (patient is null)
        {
            return Results.BadRequest();
        }

        return Results.Ok(patient);
    }

    public static IResult AddPatient(Patient patient)
    {
        // patient.Id = _patients.Count+1;
        _patients.Add(patient);

        return Results.Created("",patient);
    }

    public static IResult UpatePatient(int id, Patient patient)

    {
        var index = _patients.FindIndex(d => d.Id == id);
        if (index is -1)
        {
            return Results.BadRequest();
        }

        _patients[index] = patient with { Id = id};

        return Results.NoContent();
    }
    
    
    public static IResult DeletePatient(int id)
    {
        var index = _patients.FindIndex(d => d.Id == id);
        if (index is -1)
        {
            return Results.BadRequest();
        }

        _patients.RemoveAt(index);

        return Results.NoContent();

    }
    
    
    
}