// Doctors API

// Doctor: Id, Name, Specialty
// GET /doctors: Returns list of doctors.
// GET /doctors/1: Returns only one doctor.
// POST /doctors: Add a single doctor.
// PUT /doctors/1: Update all of the doctor info except the ID.
// DELETE /doctors/1: Delete only one doctor that has the specified id.

// Patients
// Patient: Id, Name, Address, Phone

var doctors = new List<Doctor>
{
	new Doctor(1, "Test Name", "Test"),
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

app.MapPut("/doctors/{id}", (int id, Doctor doctor) =>
{
	var index = doctors.FindIndex(d => d.Id == id);
	if (index is -1)
	{
		return Results.BadRequest();
	}

	doctors[index] = doctor with { Id = id };

	return Results.NoContent();
});

app.MapDelete("/doctors/{id}", (int id) =>
{
	var index = doctors.FindIndex(d => d.Id == id);
	if (index is -1)
	{
		return Results.BadRequest("Doctor not found.");
	}

	doctors.RemoveAt(index);
	return Results.NoContent();
});

app.Run();
