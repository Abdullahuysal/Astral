using Astral.PaymentIntegration.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var sqlConnection = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<PaymentDbContext>(options => options.UseSqlServer(sqlConnection));

var app = builder.Build();
app.UseHttpsRedirection();
app.Run();


