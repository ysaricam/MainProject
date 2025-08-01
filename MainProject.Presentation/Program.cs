using FluentValidation;
using MainProject.Application;
using MainProject.Domain.Interfaces;
using MainProject.Infrastructure;
using MainProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation.AspNetCore;
using MainProject.Presentation.Middleware;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MainProject API",
        Description = "An ASP.NET Core Web API for MainProject"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(MainProject.Application.AssemblyReference).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(MainProject.Application.AssemblyReference).Assembly);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(typeof(MainProject.Application.AssemblyReference).Assembly);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Development ortamı için ek ayarlar
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MainProject API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();