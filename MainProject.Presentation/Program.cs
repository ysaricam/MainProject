using MainProject.Application;
using MainProject.Domain.Interfaces;
using MainProject.Infrastructure;
using MainProject.Infrastructure.Repositories; 
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(MainProject.Application.AssemblyReference).Assembly));

var app = builder.Build();

// Development ortamı için ek ayarlar (Swagger vb. daha sonra eklenebilir)
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();