using Astral.Membership.API.Extensions;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Repositories;
using Astral.Membership.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers();
var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));
app.MapControllers();
app.Run();