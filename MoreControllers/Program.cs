// MVC: Model Controller.

var builder = WebApplication.CreateBuilder(args);

// Service Registration.
builder.Services.AddControllers();

var app = builder.Build();

// Middleware pipeline.

app.MapControllers();

app.Run();
