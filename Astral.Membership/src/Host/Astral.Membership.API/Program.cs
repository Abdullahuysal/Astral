var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

Console.WriteLine("Sa");
Console.ReadLine();
var app = builder.Build();
app.Run();
