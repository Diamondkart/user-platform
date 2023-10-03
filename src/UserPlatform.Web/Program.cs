using ExceptionHandling.CustomMiddlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using UserPlatform.ApplicationCore;
using UserPlatform.Persistence;
using UserPlatform.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(c => c.BuildConfiguration(args));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomServices();
builder.Services.AddConnectionString(builder.Configuration);

builder.Services.AddPersistenceBuilderServices();
// ApplicationCore
builder.Services.AddApplicationCoreServices();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.UseRouting();
app.UseAuthorization();
app.UseCors(options => options.AllowAnyOrigin());
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();