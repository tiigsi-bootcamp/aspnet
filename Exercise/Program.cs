// Doctors API

// Doctor: Id, Name, Specialty
// GET /doctors: Returns list of doctors.
// GET /doctors/1: Returns only one doctor.
// POST /doctors: Add a single doctor.

var doctors = new List<Doctor>
{
	new Doctor(1, "Name", "Test"),
	new Doctor(2, "Test Test", "Testing")
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/doctors", () => doctors);
app.MapGet("/doctors/{id}", (int id) =>
{
	var doctor = doctors.FirstOrDefault(d => d.Id == id);
	if (doctor is null)
	{
		return Results.NotFound("Doctor not found!");
	}

	return Results.Ok(doctor);
});

app.MapPost("/doctors", (Doctor doctor) =>
{
	doctors.Add(doctor);

	return "Doctor has been saved successfully!";
});

app.Run();
