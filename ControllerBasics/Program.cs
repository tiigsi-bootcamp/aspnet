// MVC: Model Controller

var builder = WebApplication.CreateBuilder(args);

// Register all controllers.
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
