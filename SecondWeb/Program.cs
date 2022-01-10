var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/today", () => $"Today is: {DateTime.Today:dddd}");

app.MapGet("/person", () => new Person(1, "Mohamed Ahmed"));

app.MapGet("/hello", (string name) => $"Hello {name}");

app.Run();

record Person(int Id, string Name);
