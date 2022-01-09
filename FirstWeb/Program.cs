var builder = WebApplication.CreateBuilder(args);

// Attach different components of your web app.

var app = builder.Build();

var handler = () =>
{
	Console.WriteLine("I got a request!");
	return "What do you want sxb?!";
};

app.MapGet("/", () => "Hello World!!!");
app.MapGet("/home", () => "Home page!");
app.MapGet("/what", handler);

app.Run();
