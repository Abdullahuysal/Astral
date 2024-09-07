//using MassTransit;
using Astral.Notification.Application.ApplicationQueries.NotificationQueries;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetNotificationQueryHandler).Assembly));


//builder.Services.AddMassTransit(busConfigurator =>
//{
//    busConfigurator.SetKebabCaseEndpointNameFormatter();

//    busConfigurator.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
