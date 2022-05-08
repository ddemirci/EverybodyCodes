using EverybodyCodes.Contracts;
using EverybodyCodes.Data;
using EverybodyCodes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using EverybodyCodes.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CameraDetailsContext>(x => x.UseInMemoryDatabase("cameraDetails"));

// Configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service methods registration
builder.Services.AddTransient<ICameraService, CameraService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Set in memory database
using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<CameraDetailsContext>();
    
    if (context == null) return;
    FillDatabase(context);
}

app.Run();


void FillDatabase(CameraDetailsContext context)
{
    string path = $"{app.Environment.ContentRootPath}\\DataSource\\cameras-defb.csv";

    string[] lines = File.ReadAllLines(path);
    foreach (string line in lines)
    {
        string[] columns = line.Split(';');
        if (columns.Length < 3) continue;

        if (!double.TryParse(columns[1], out var latitude) || !double.TryParse(columns[2], out var longitude)) continue;

        context.CameraDetails.Add(new CameraDetails(columns[0], latitude, longitude));
    }
    context.SaveChanges();
}