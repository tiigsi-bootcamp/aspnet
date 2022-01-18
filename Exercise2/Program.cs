// Doctors API

// Doctor: Id, Name, Specialty
// GET /doctors: Returns list of doctors.
// GET /doctors/1: Returns only one doctor.
// POST /doctors: Add a single doctor.
// PUT /doctors/1: Update all of the doctor info except the ID.
// DELETE /doctors/1: Delete only one doctor that has the specified id.

// Patients
// Patient: Id, Name, Address, Phone

 
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



//GEt Doctors
app.MapGet("doctors",DoctorHandler.GetDoctors);

//Get Doctors/1

app.MapGet("doctors/{id}",DoctorHandler.GetDoctor);

//Post add doctors
app.MapPost("doctors",DoctorHandler.AddDoctor);

//Put
app.MapPut("doctors/{id}",DoctorHandler.UpdateDoctor);

//Dele

app.MapDelete("doctors{id}",DoctorHandler.DeleteDoctor);


//Get Patients 

app.MapGet("patients",PateintHandler.GetPatients);

app.MapGet("patients/{id}",PateintHandler.GetPatient);
//Add Patien
app.MapPost("patients",PateintHandler.AddPatient);

app.MapPut("patients/{id}", PateintHandler.UpatePatient);

//Delet
app.MapDelete("patients/{id}",PateintHandler.DeletePatient);


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
