// Request Types
// More Routing

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("main", (string q) => "This is main! " + q);

app.MapPost("hola", () => "POST is working!");

app.MapPost("login", (LoginInfo info) => "Login is working");

// Request Methods
// GET

// POST: Submitting large/sensitive information
// PUT: Updates
// PATCH: Partial Update
// DELETE: Delete something.

// OPTIONS: Can we talk? 204
// HEAD: 

app.Run();
