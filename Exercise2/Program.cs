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

var patients = new List<Patient>();

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

// GET /patients
app.MapGet("/patients", () => patients);

// GET /patients/5
app.MapGet("/patients/{id}", (int id) =>
{
	var patient = patients.FirstOrDefault(p => p.Id == id);
	if (patient is null)
	{
		return Results.NotFound();
	}

	return Results.Ok(patient);
});

// POST /patients
app.MapPost("/patients", (Patient patient) =>
{
	patient.Id = patients.Count + 1;
	patients.Add(patient);

	return Results.Created("/patients/" + patient.Id, patient);
});

// PUT /patients/5
app.MapPut("/patients/{id}", (int id, Patient patient) =>
{
	var targetPatient = patients.FirstOrDefault(p => p.Id == id);
	if (targetPatient is null)
	{
		return Results.BadRequest("Patient could not be recognized.");
	}

	targetPatient.Name = patient.Name;
	targetPatient.Address = patient.Address;
	targetPatient.Phone = patient.Phone;

	return Results.NoContent();
});

// DELETE /patients/5
app.MapDelete("/patients/{id}", (int id) =>
{
	var patient = patients.FirstOrDefault(p => p.Id == id);
	if (patient is null)
	{
		return Results.BadRequest("Patient could not be recognized.");
	}

	patients.Remove(patient);
	return Results.NoContent();
});

// Drug: Id, Name, Quantity, Description, Origin, Price
// GET /drugs
app.MapGet("/drugs", DrugHandler.GetDrugs);

// GET /drugs/5
app.MapGet("/drugs/{id}", DrugHandler.GetDrug);

// POST /drugs
app.MapPost("/drugs", DrugHandler.AddDrug);

// PUT /drugs/5
app.MapPut("/drugs/{id}", DrugHandler.UpdateDrug);

// DELETE /drugs/5
app.MapDelete("/drugs/{id}", DrugHandler.DeleteDrug);

app.Run();
