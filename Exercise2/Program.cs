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
//get  Doctors
app.MapGet("/doctors",  DoctorHandler.getDoctors);
//get single doctor
app.MapGet("/doctors/{id}",  DoctorHandler.GetDoctor);
//post or add DOctor
app.MapPost("/doctors",DoctorHandler.Add);
// put or update Doctor
app.MapPut("/doctors/{id}", DoctorHandler.Put);
// DELETE Doctor
app.MapDelete("/doctors/{id}",DoctorHandler.DELETE);


// GET /patients


app.MapGet("/patients", PateintHandler.GetPatients);
//// GET single patients
app.MapGet("/patients/{id}", PateintHandler.GetPatient);
// add /patients
app.MapPost("/patients", PateintHandler.AddPatient);
// update /patients
app.MapPut("/patients/{id}",PateintHandler.UpdatePatient);
// DELETE /patients
app.MapDelete("/patients/{id}", PateintHandler.DELETE);


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

// TODO: Refactor the other endpoints.

app.Run();
