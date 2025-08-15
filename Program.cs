using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Services;
using TaskManager.Api.Services.Interfaces;
using TaskManager.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configuramos SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// ✅ Servicios
builder.Services.AddScoped<ITaskService, TaskService>();

// ✅ Configuración de CORS (agrega esto)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // URL del frontend Angular
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Aplicar CORS (agrega esto ANTES de UseHttpsRedirection)
app.UseCors("AllowAngularApp");

// Crear DB si no existe y agregar tareas de ejemplo
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Tasks.Any())
    {
        db.Tasks.AddRange(
            new TaskItem { Title = "Aprender .NET 8", IsCompleted = false },
            new TaskItem { Title = "Probar API con curl", IsCompleted = false },
            new TaskItem { Title = "Configurar Angular frontend", IsCompleted = false }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();