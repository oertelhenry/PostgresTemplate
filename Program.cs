using DotNetToolbox.Utils;
using EventHistory.Database;
using EventHistory.Domain.Extensions;
using EventHistory.Endpoints;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

Log.Information($"Starting application {builder.Configuration.AppSlug()}...");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapHistoryEndpoints();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

var context = service.GetRequiredService<EventHistoryContext>();

//try
//{
//    await context.Database.MigrateAsync();
//}
//catch (Exception ex)
//{
//    Log.Error(ex, "An error occured during migration");
//}
//app.UseHttpsRedirection();

app.Run();