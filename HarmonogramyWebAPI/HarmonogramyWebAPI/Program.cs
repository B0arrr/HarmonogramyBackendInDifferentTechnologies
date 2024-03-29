using HarmonogramyWebAPI.DbInitializer;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite("Filename=Database.db");
});

builder.Services.AddScoped(typeof(IGenericCrudService<,>), typeof(GenericCrudService<,>));

builder.Services.AddScoped<IContext, DatabaseContext>();

builder.Services.AddTransient<DatabaseContextInitializer>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DatabaseContextInitializer>();

await initializer.Run();

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