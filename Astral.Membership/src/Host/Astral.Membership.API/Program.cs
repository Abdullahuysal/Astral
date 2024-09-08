using Astral.Membership.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));
builder.Services.AddControllers();
var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));
app.MapControllers();
app.Run();