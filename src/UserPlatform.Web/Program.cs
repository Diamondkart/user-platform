using ExceptionHandling.CustomMiddlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using UserPlatform.ApplicationCore;
using UserPlatform.Persistence;
using UserPlatform.Web.Extensions;
using UserPlatform.Web.TestUtils;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(c => c.BuildConfiguration(args));

// Add services to the container.

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomServices();
builder.Services.AddConnectionString(builder.Configuration);

builder.Services.AddPersistenceBuilderServices();
// ApplicationCore
builder.Services.AddApplicationCoreServices();

builder.Services.UseFluentValidation();

builder.Services.AddControllers()
    .UseApiBehaviorOptions();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:8000";
        options.Audience = "UserPlatform";
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });
    
    
    
    //.AddScheme<JwtBearerOptions, DiamondJwtAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, s => { });

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.UseRouting();

app.UseCors(options => options.AllowAnyOrigin());
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();